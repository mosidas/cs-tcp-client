﻿using System;
using System.IO;
using System.Net.Security;
using System.Runtime.InteropServices;

namespace tcp_client
{
    public unsafe static class SslDirectCall
    {
        public static void CloseNotify(SslStream sslStream)
        {
            if (sslStream.IsAuthenticated)
            {
                bool isServer = sslStream.IsServer;

                byte[] result;
                int resultSz;
                var asmbSystem = typeof(System.Net.Authorization).Assembly;

                int SCHANNEL_SHUTDOWN = 1;
                var workArray = BitConverter.GetBytes(SCHANNEL_SHUTDOWN);

                var sslstate = ReflectUtil.GetField(sslStream, "_SslState");
                var context = ReflectUtil.GetProperty(sslstate, "Context");

                var securityContext = ReflectUtil.GetField(context, "m_SecurityContext");
                var securityContextHandleOriginal = ReflectUtil.GetField(securityContext, "_handle");
                NativeApi.SSPIHandle securityContextHandle = default(NativeApi.SSPIHandle);
                securityContextHandle.HandleHi = (IntPtr)ReflectUtil.GetField(securityContextHandleOriginal, "HandleHi");
                securityContextHandle.HandleLo = (IntPtr)ReflectUtil.GetField(securityContextHandleOriginal, "HandleLo");

                var credentialsHandle = ReflectUtil.GetField(context, "m_CredentialsHandle");
                var credentialsHandleHandleOriginal = ReflectUtil.GetField(credentialsHandle, "_handle");
                NativeApi.SSPIHandle credentialsHandleHandle = default(NativeApi.SSPIHandle);
                credentialsHandleHandle.HandleHi = (IntPtr)ReflectUtil.GetField(credentialsHandleHandleOriginal, "HandleHi");
                credentialsHandleHandle.HandleLo = (IntPtr)ReflectUtil.GetField(credentialsHandleHandleOriginal, "HandleLo");

                int bufferSize = 1;
                NativeApi.SecurityBufferDescriptor securityBufferDescriptor = new NativeApi.SecurityBufferDescriptor(bufferSize);
                NativeApi.SecurityBufferStruct[] unmanagedBuffer = new NativeApi.SecurityBufferStruct[bufferSize];

                fixed (NativeApi.SecurityBufferStruct* ptr = unmanagedBuffer)
                fixed (void* workArrayPtr = workArray)
                {
                    securityBufferDescriptor.UnmanagedPointer = (void*)ptr;

                    unmanagedBuffer[0].token = (IntPtr)workArrayPtr;
                    unmanagedBuffer[0].count = workArray.Length;
                    unmanagedBuffer[0].type = NativeApi.BufferType.Token;

                    NativeApi.SecurityStatus status;
                    status = (NativeApi.SecurityStatus)NativeApi.ApplyControlToken(ref securityContextHandle, securityBufferDescriptor);
                    if (status == NativeApi.SecurityStatus.OK)
                    {
                        unmanagedBuffer[0].token = IntPtr.Zero;
                        unmanagedBuffer[0].count = 0;
                        unmanagedBuffer[0].type = NativeApi.BufferType.Token;

                        NativeApi.SSPIHandle contextHandleOut = default(NativeApi.SSPIHandle);
                        NativeApi.ContextFlags outflags = NativeApi.ContextFlags.Zero;
                        long ts = 0;

                        var inflags = NativeApi.ContextFlags.SequenceDetect |
                                    NativeApi.ContextFlags.ReplayDetect |
                                    NativeApi.ContextFlags.Confidentiality |
                                    NativeApi.ContextFlags.AcceptExtendedError |
                                    NativeApi.ContextFlags.AllocateMemory |
                                    NativeApi.ContextFlags.InitStream;

                        if (isServer)
                        {
                            status = (NativeApi.SecurityStatus)NativeApi.AcceptSecurityContext(ref credentialsHandleHandle, ref securityContextHandle, null,
                                inflags, NativeApi.Endianness.Native, ref contextHandleOut, securityBufferDescriptor, ref outflags, out ts);
                        }
                        else
                        {
                            status = (NativeApi.SecurityStatus)NativeApi.InitializeSecurityContextW(ref credentialsHandleHandle, ref securityContextHandle, null,
                                inflags, 0, NativeApi.Endianness.Native, null, 0, ref contextHandleOut, securityBufferDescriptor, ref outflags, out ts);
                        }
                        if (status == NativeApi.SecurityStatus.OK)
                        {
                            byte[] resultArr = new byte[unmanagedBuffer[0].count];
                            Marshal.Copy(unmanagedBuffer[0].token, resultArr, 0, resultArr.Length);
                            Marshal.FreeCoTaskMem(unmanagedBuffer[0].token);
                            result = resultArr;
                            resultSz = resultArr.Length;
                        }
                        else
                        {
                            throw new InvalidOperationException(string.Format("AcceptSecurityContext/InitializeSecurityContextW returned [{0}] during CloseNotify.", status));
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException(string.Format("ApplyControlToken returned [{0}] during CloseNotify.", status));
                    }
                }

                var innerStream = (Stream)ReflectUtil.GetProperty(sslstate, "InnerStream");
                innerStream.Write(result, 0, resultSz);
            }
        }
    }
}
