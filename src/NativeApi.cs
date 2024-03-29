﻿using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace tcp_client
{
    public unsafe static class NativeApi
    {
        internal enum BufferType
        {
            Empty,
            Data,
            Token,
            Parameters,
            Missing,
            Extra,
            Trailer,
            Header,
            Padding = 9,
            Stream,
            ChannelBindings = 14,
            TargetHost = 16,
            ReadOnlyFlag = -2147483648,
            ReadOnlyWithChecksum = 268435456
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct SSPIHandle
        {
            public IntPtr HandleHi;
            public IntPtr HandleLo;
            public bool IsZero
            {
                get
                {
                    return this.HandleHi == IntPtr.Zero && this.HandleLo == IntPtr.Zero;
                }
            }
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal void SetToInvalid()
            {
                this.HandleHi = IntPtr.Zero;
                this.HandleLo = IntPtr.Zero;
            }
            public override string ToString()
            {
                return this.HandleHi.ToString("x") + ":" + this.HandleLo.ToString("x");
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        internal class SecurityBufferDescriptor
        {
            public readonly int Version;
            public readonly int Count;
            public unsafe void* UnmanagedPointer;
            public SecurityBufferDescriptor(int count)
            {
                this.Version = 0;
                this.Count = count;
                this.UnmanagedPointer = null;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SecurityBufferStruct
        {
            public int count;
            public BufferType type;
            public IntPtr token;
            public static readonly int Size = sizeof(SecurityBufferStruct);
        }

        internal enum SecurityStatus
        {
            OK,
            ContinueNeeded = 590610,
            CompleteNeeded,
            CompAndContinue,
            ContextExpired = 590615,
            CredentialsNeeded = 590624,
            Renegotiate,
            OutOfMemory = -2146893056,
            InvalidHandle,
            Unsupported,
            TargetUnknown,
            InternalError,
            PackageNotFound,
            NotOwner,
            CannotInstall,
            InvalidToken,
            CannotPack,
            QopNotSupported,
            NoImpersonation,
            LogonDenied,
            UnknownCredentials,
            NoCredentials,
            MessageAltered,
            OutOfSequence,
            NoAuthenticatingAuthority,
            IncompleteMessage = -2146893032,
            IncompleteCredentials = -2146893024,
            BufferNotEnough,
            WrongPrincipal,
            TimeSkew = -2146893020,
            UntrustedRoot,
            IllegalMessage,
            CertUnknown,
            CertExpired,
            AlgorithmMismatch = -2146893007,
            SecurityQosFailed,
            SmartcardLogonRequired = -2146892994,
            UnsupportedPreauth = -2146892989,
            BadBinding = -2146892986
        }
        [Flags]
        internal enum ContextFlags
        {
            Zero = 0,
            Delegate = 1,
            MutualAuth = 2,
            ReplayDetect = 4,
            SequenceDetect = 8,
            Confidentiality = 16,
            UseSessionKey = 32,
            AllocateMemory = 256,
            Connection = 2048,
            InitExtendedError = 16384,
            AcceptExtendedError = 32768,
            InitStream = 32768,
            AcceptStream = 65536,
            InitIntegrity = 65536,
            AcceptIntegrity = 131072,
            InitManualCredValidation = 524288,
            InitUseSuppliedCreds = 128,
            InitIdentify = 131072,
            AcceptIdentify = 524288,
            ProxyBindings = 67108864,
            AllowMissingBindings = 268435456,
            UnverifiedTargetName = 536870912
        }
        internal enum Endianness
        {
            Network,
            Native = 16
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [DllImport("secur32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern int ApplyControlToken(ref SSPIHandle contextHandle, [In][Out] SecurityBufferDescriptor outputBuffer);

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [DllImport("secur32.dll", ExactSpelling = true, SetLastError = true)]
        internal unsafe static extern int AcceptSecurityContext(ref SSPIHandle credentialHandle, ref SSPIHandle contextHandle, [In] SecurityBufferDescriptor inputBuffer, [In] ContextFlags inFlags, [In] Endianness endianness, ref SSPIHandle outContextPtr, [In][Out] SecurityBufferDescriptor outputBuffer, [In][Out] ref ContextFlags attributes, out long timeStamp);

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [DllImport("secur32.dll", ExactSpelling = true, SetLastError = true)]
        internal unsafe static extern int InitializeSecurityContextW(ref SSPIHandle credentialHandle, ref SSPIHandle contextHandle, [In] byte* targetName, [In] ContextFlags inFlags, [In] int reservedI, [In] Endianness endianness, [In] SecurityBufferDescriptor inputBuffer, [In] int reservedII, ref SSPIHandle outContextPtr, [In][Out] SecurityBufferDescriptor outputBuffer, [In][Out] ref ContextFlags attributes, out long timeStamp);
    }
}
