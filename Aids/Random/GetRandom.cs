﻿using Abc.Aids.Methods;
using Abc.Aids.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Abc.Aids.Random {

    public static class GetRandom {

        private static readonly System.Random r = new System.Random();

        public static bool Bool() => Int32() % 2 == 0;

        public static char Char(char min = char.MinValue, char max = char.MaxValue)
            => (char)UInt16(min, max);

        public static Color Color()
            => System.Drawing.Color.FromArgb(UInt8(), UInt8(), UInt8());

        public static DateTime DateTime(DateTime? min = null, DateTime? max = null) {
            var m = min ?? System.DateTime.MinValue;
            var x = max ?? System.DateTime.MaxValue;
            var d = new DateTime(Int64(m.Ticks, x.Ticks));
            if (d.Hour == 3) d = d.AddHours(UInt8(4, 22));

            return d;
        }

        public static decimal Decimal(decimal min = decimal.MinValue,
            decimal max = decimal.MaxValue) {
            if (min == max) return min;

            return Safe.Run(() =>
                    Convert.ToDecimal(Double(Convert.ToDouble(min), Convert.ToDouble(max))),
                min);
        }

        public static double Double(double min = double.MinValue, double max = double.MaxValue) {
            if (min.CompareTo(max) == 0) return min;
            Sort.Ascending(ref min, ref max);
            var d = r.NextDouble();

            if (max > 0) return min + d * max - d * min;

            return min - d * min + d * max;
        }

        public static T Enum<T>() => (T)Enum(typeof(T));

        public static object Enum(Type t) {
            var count = GetEnum.Count(t);
            var index = Int32(0, count);

            return GetEnum.Value(t, index);
        }

        public static float Float(float min = float.MinValue, float max = float.MaxValue)
            => Convert.ToSingle(Double(min, max));

        public static sbyte Int8(sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue)
            => (sbyte)Int32(min, max);

        public static short Int16(short min = short.MinValue, short max = short.MaxValue)
            => (short)Int32(min, max);

        public static int Int32(int min = int.MinValue, int max = int.MaxValue) {
            if (min.CompareTo(max) == 0) return min;
            if (min.CompareTo(max) > 0) return r.Next(max, min);

            return r.Next(min, max);
        }

        public static long Int64(long min = long.MinValue, long max = long.MaxValue) {
            if (min == max) return min;

            return Safe.Run(() =>
                    Convert.ToInt64(Double(Convert.ToDouble(min), Convert.ToDouble(max))),
                min);
        }

        public static string String(byte minLenght = 5, byte maxLenght = 10) {
            var b = new StringBuilder();
            var size = UInt8(minLenght, maxLenght);
            for (var i = 0; i < size; i++) b.Append(Char('a', 'z'));

            return b.ToString();
        }

        public static TimeSpan TimeSpan() => new TimeSpan(Int64());

        public static byte UInt8(byte min = byte.MinValue, byte max = byte.MaxValue)
            => (byte)Int32(min, max);

        public static ushort UInt16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue)
            => (ushort)Int32(min, max);

        public static uint UInt32(uint min = uint.MinValue, uint max = uint.MaxValue)
            => Convert.ToUInt32(Double(min, max));

        public static ulong UInt64(ulong min = ulong.MinValue, ulong max = ulong.MaxValue) {
            if (min == max) return min;

            return Safe.Run(() =>
                    Convert.ToUInt64(Double(Convert.ToDouble(min), Convert.ToDouble(max))),
                min);
        }

        public static object Value(Type t) {
            var x = Nullable.GetUnderlyingType(t);
            if (!(x is null)) t = x;

            if (t.IsArray) return Array(t.GetElementType());
            if (t.IsEnum) return Enum(t);
            if (t == typeof(string)) return String();
            if (t == typeof(char)) return Char();
            if (t == typeof(Color)) return Color();
            if (t == typeof(bool)) return Bool();
            if (t == typeof(DateTime)) return DateTime();
            if (t == typeof(decimal)) return Decimal();
            if (t == typeof(double)) return Double();
            if (t == typeof(float)) return Float();
            if (t == typeof(byte)) return UInt8();
            if (t == typeof(ushort)) return UInt16();
            if (t == typeof(uint)) return UInt32();
            if (t == typeof(ulong)) return UInt64();
            if (t == typeof(sbyte)) return Int8();
            if (t == typeof(short)) return Int16();
            if (t == typeof(int)) return Int32();
            if (t == typeof(long)) return Int64();
            if (t == typeof(TimeSpan)) return TimeSpan();
            if (t == typeof(char?)) return Char();
            if (t == typeof(Color?)) return Color();
            if (t == typeof(bool?)) return Bool();
            if (t == typeof(DateTime?)) return DateTime();
            if (t == typeof(decimal?)) return Decimal();
            if (t == typeof(double?)) return Double();
            if (t == typeof(float?)) return Float();
            if (t == typeof(byte?)) return UInt8();
            if (t == typeof(ushort?)) return UInt16();
            if (t == typeof(uint?)) return UInt32();
            if (t == typeof(ulong?)) return UInt64();
            if (t == typeof(sbyte?)) return Int8();
            if (t == typeof(short?)) return Int16();
            if (t == typeof(int?)) return Int32();
            if (t == typeof(long?)) return Int64();
            if (t == typeof(TimeSpan)) return TimeSpan();

            return Object(t);
        }

        public static object Array(Type t) {
            if (t is null) return null;
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(t);
            var list = (IList)Activator.CreateInstance(constructedListType);
            for (var i = 0; i < UInt8(3, 10); i++) list.Add(Value(t));
            var array = System.Array.CreateInstance(t, list.Count);
            list.CopyTo(array, 0);

            return array;
        }

        public static T Object<T>() {
            var o = CreateNew.Instance<T>();
            SetRandom.Values(o);

            return o;
        }

        public static object Object(Type t) {
            var o = CreateNew.Instance(t);
            SetRandom.Values(o);

            return o;
        }

        public static string Email()
            => $"{String()}.{String()}@{String()}.{String()}";

        public static string Password()
            => $"{String()}{Char('\x20', '\x2f')}{UInt32().ToString()}.{String().ToUpper()}";

        public static List<T> List<T>(Func<T> func) {
            var list = new List<T>();
            for (var i = 0; i < UInt8(2, 10); i++) list.Add(func());

            return list;
        }

        public static object AnyDouble(byte minValue = 0, byte maxValue = 100) {
            var i = UInt8();

            return (i % 10) switch {
                0 => Int32(minValue, maxValue),
                1 => UInt32(minValue, maxValue),
                2 => Float(minValue, maxValue),
                3 => Int8(0),
                4 => UInt8(minValue, maxValue),
                5 => Int16(minValue, maxValue),
                6 => UInt16(minValue, maxValue),
                7 => Int64(minValue, maxValue),
                8 => UInt64(minValue, maxValue),
                _ => Double(minValue, maxValue)
            };
        }

        public static object AnyInt(byte minValue = 0, byte maxValue = 100) {
            var i = UInt8();

            return (i % 5) switch {
                0 => Int8(0),
                1 => UInt8(minValue, maxValue),
                2 => Int16(minValue, maxValue),
                4 => UInt16(minValue, maxValue),
                _ => Int32(minValue, maxValue)
            };
        }

        public static object AnyValue() {
            var i = Int32();

            return (i % 10) switch {
                0 => (object)DateTime(),
                1 => String(),
                2 => Char(),
                3 => Int32(),
                4 => Double(),
                5 => Decimal(),
                6 => UInt32(),
                7 => Float(),
                8 => Int8(),
                9 => UInt8(),
                10 => Int16(),
                11 => UInt16(),
                12 => Int64(),
                13 => UInt64(),
                _ => String()
            };
        }

    }

}







