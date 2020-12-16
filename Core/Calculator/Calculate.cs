using Abc.Aids.Methods;
using Abc.Aids.Values;
using System;
using System.Collections.Generic;

namespace Abc.Core.Calculator {

    public class Calculate {

        private readonly Stack<object> stack;

        public Calculate() => stack = new Stack<object>();

        public object Get() => Safe.Run(() => stack.Pop(), null, true);

        public object Peek() => Safe.Run(() => stack.Peek(), null, true);

        public void Set(object x) => Safe.Run(() => stack.Push(x), true);

        public void Clear() => stack.Clear();

        public void Perform(Operation o) {
            switch (o) {
                case Operation.Add:
                    Add();

                    break;
                case Operation.Subtract:
                    Subtract();

                    break;
                case Operation.Multiply:
                    Multiply();

                    break;
                case Operation.Divide:
                    Divide();

                    break;
                case Operation.Power:
                    Power();

                    break;
                case Operation.Inverse:
                    Inverse();

                    break;
                case Operation.Opposite:
                    Opposite();

                    break;
                case Operation.Square:
                    Square();

                    break;
                case Operation.Sqrt:
                    Sqrt();

                    break;
                case Operation.And:
                    And();

                    break;
                case Operation.Or:
                    Or();

                    break;
                case Operation.Xor:
                    Xor();

                    break;
                case Operation.Not:
                    Not();

                    break;
                case Operation.Equal:
                    Equal();

                    break;
                case Operation.Greater:
                    Greater();

                    break;
                case Operation.Less:
                    Less();

                    break;
                case Operation.GetYear:
                    GetYear();

                    break;
                case Operation.GetMonth:
                    GetMonth();

                    break;
                case Operation.GetDay:
                    GetDay();

                    break;
                case Operation.GetHour:
                    GetHour();

                    break;
                case Operation.GetMinute:
                    GetMinute();

                    break;
                case Operation.GetSecond:
                    GetSecond();

                    break;
                case Operation.GetAge:
                    GetAge();

                    break;
                case Operation.GetInterval:
                    GetInterval();

                    break;
                case Operation.ToYears:
                    ToYears();

                    break;
                case Operation.ToMonths:
                    ToMonths();

                    break;
                case Operation.ToDays:
                    ToDays();

                    break;
                case Operation.ToHours:
                    ToHours();

                    break;
                case Operation.ToMinutes:
                    ToMinutes();

                    break;
                case Operation.ToSeconds:
                    ToSeconds();

                    break;
                case Operation.AddSeconds:
                    AddSeconds();

                    break;
                case Operation.AddMinutes:
                    AddMinutes();

                    break;
                case Operation.AddHours:
                    AddHours();

                    break;
                case Operation.AddDays:
                    AddDays();

                    break;
                case Operation.AddMonths:
                    AddMonths();

                    break;
                case Operation.AddYears:
                    AddYears();

                    break;
                case Operation.Length:
                    Length();

                    break;
                case Operation.ToUpper:
                    ToUpper();

                    break;
                case Operation.ToLower:
                    ToLower();

                    break;
                case Operation.Trim:
                    Trim();

                    break;
                case Operation.Substring:
                    Substring();

                    break;
                case Operation.Contains:
                    Contains();

                    break;
                case Operation.EndsWith:
                    EndsWith();

                    break;
                case Operation.StartsWith:
                    StartsWith();

                    break;
                default:
                    Dummy();

                    break;
            }
        }

        public void Dummy() { }

        public virtual void Add() => perform(Calculating.Add);
        public virtual void Subtract() => perform(Calculating.Subtract);
        public virtual void Multiply() => perform(Calculating.Multiply);
        public virtual void Divide() => perform(Calculating.Divide);

        public virtual void Power() => perform(Calculating.Power);
        public virtual void Opposite() => perform(Calculating.Opposite);
        public virtual void Sqrt() => perform(Calculating.Sqrt);
        public virtual void Square() => perform(Calculating.Square);
        public virtual void Inverse() => perform(Calculating.Inverse);

        public virtual void And() => perform(Calculating.And);
        public virtual void Or() => perform(Calculating.Or);
        public virtual void Xor() => perform(Calculating.Xor);
        public virtual void Not() => perform(Calculating.Not);

        public virtual void Equal() => perform(Calculating.IsEqual);
        public virtual void Greater() => perform(Calculating.IsGreater);
        public virtual void Less() => perform(Calculating.IsLess);

        public virtual void GetYear() => perform(Calculating.GetYear);
        public virtual void GetMonth() => perform(Calculating.GetMonth);
        public virtual void GetDay() => perform(Calculating.GetDay);
        public virtual void GetHour() => perform(Calculating.GetHour);
        public virtual void GetMinute() => perform(Calculating.GetMinute);
        public virtual void GetSecond() => perform(Calculating.GetSecond);

        public virtual void AddDays() => perform(Calculating.AddDays);
        public virtual void AddHours() => perform(Calculating.AddHours);
        public virtual void AddMinutes() => perform(Calculating.AddMinutes);
        public virtual void AddMonths() => perform(Calculating.AddMonths);
        public virtual void AddSeconds() => perform(Calculating.AddSeconds);
        public virtual void AddYears() => perform(Calculating.AddYears);

        public virtual void GetAge() => perform(Calculating.GetAge);
        public virtual void GetInterval() => perform(Calculating.GetInterval);

        public virtual void ToYears() => perform(Calculating.ToYears);
        public virtual void ToMonths() => perform(Calculating.ToMonths);
        public virtual void ToDays() => perform(Calculating.ToDays);
        public virtual void ToHours() => perform(Calculating.ToHours);
        public virtual void ToMinutes() => perform(Calculating.ToMinutes);
        public virtual void ToSeconds() => perform(Calculating.ToSeconds);

        public virtual void Contains() => perform(Calculating.Contains);
        public virtual void EndsWith() => perform(Calculating.EndsWith);
        public virtual void Length() => perform(Calculating.GetLength);
        public virtual void StartsWith() => perform(Calculating.StartsWith);
        public virtual void ToLower() => perform(Calculating.ToLower);
        public virtual void ToUpper() => perform(Calculating.ToUpper);
        public virtual void Trim() => perform(Calculating.Trim);

        public virtual void Substring() => Safe.Run(() => {
            var y = Get();
            var x = Get();
            Set(IsType.String(x) ? Calculating.Substring(x, y) : Calculating.Substring(Get(), x, y));
        });

        protected virtual void perform(Func<object, object, object> op) => Safe.Run(() => {
            var y = Get();
            Set(op(Get(), y));
        });
        protected virtual void perform(Func<object, object, bool> op) => Safe.Run(() => {
            var y = Get();
            Set(op(Get(), y));
        });
        protected virtual void perform(Func<object, object> op) => Safe.Run(() => Set(op(Get())));

    }

}
