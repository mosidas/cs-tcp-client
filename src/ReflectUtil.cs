﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace tcp_client
{
    public static class ReflectUtil
    {
        public static object GetField(object obj, string fieldName)
        {
            var tp = obj.GetType();
            var info = GetAllFields(tp)
                .Where(f => f.Name == fieldName).Single();
            return info.GetValue(obj);
        }
        public static void SetField(object obj, string fieldName, object value)
        {
            var tp = obj.GetType();
            var info = GetAllFields(tp)
                .Where(f => f.Name == fieldName).Single();
            info.SetValue(obj, value);
        }
        public static object GetStaticField(Assembly assembly, string typeName, string fieldName)
        {
            var tp = assembly.GetType(typeName);
            var info = GetAllFields(tp)
                .Where(f => f.IsStatic)
                .Where(f => f.Name == fieldName).Single();
            return info.GetValue(null);
        }

        public static object GetProperty(object obj, string propertyName)
        {
            var tp = obj.GetType();
            var info = GetAllProperties(tp)
                .Where(f => f.Name == propertyName).Single();
            return info.GetValue(obj, null);
        }
        public static object CallMethod(object obj, string methodName, params object[] prm)
        {
            var tp = obj.GetType();
            var info = GetAllMethods(tp)
                .Where(f => f.Name == methodName && f.GetParameters().Length == prm.Length).Single();
            object rez = info.Invoke(obj, prm);
            return rez;
        }
        public static object NewInstance(Assembly assembly, string typeName, params object[] prm)
        {
            var tp = assembly.GetType(typeName);
            var info = tp.GetConstructors()
                .Where(f => f.GetParameters().Length == prm.Length).Single();
            object rez = info.Invoke(prm);
            return rez;
        }
        public static object InvokeStaticMethod(Assembly assembly, string typeName, string methodName, params object[] prm)
        {
            var tp = assembly.GetType(typeName);
            var info = GetAllMethods(tp)
                .Where(f => f.IsStatic)
                .Where(f => f.Name == methodName && f.GetParameters().Length == prm.Length).Single();
            object rez = info.Invoke(null, prm);
            return rez;
        }
        public static object GetEnumValue(Assembly assembly, string typeName, int value)
        {
            var tp = assembly.GetType(typeName);
            object rez = Enum.ToObject(tp, value);
            return rez;
        }

        private static IEnumerable<FieldInfo> GetAllFields(Type t)
        {
            if (t == null)
                return Enumerable.Empty<FieldInfo>();

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic |
                                 BindingFlags.Static | BindingFlags.Instance |
                                 BindingFlags.DeclaredOnly;
            return t.GetFields(flags).Concat(GetAllFields(t.BaseType));
        }
        private static IEnumerable<PropertyInfo> GetAllProperties(Type t)
        {
            if (t == null)
                return Enumerable.Empty<PropertyInfo>();

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic |
                                 BindingFlags.Static | BindingFlags.Instance |
                                 BindingFlags.DeclaredOnly;
            return t.GetProperties(flags).Concat(GetAllProperties(t.BaseType));
        }
        private static IEnumerable<MethodInfo> GetAllMethods(Type t)
        {
            if (t == null)
                return Enumerable.Empty<MethodInfo>();

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic |
                                 BindingFlags.Static | BindingFlags.Instance |
                                 BindingFlags.DeclaredOnly;
            return t.GetMethods(flags).Concat(GetAllMethods(t.BaseType));
        }
    }
}
