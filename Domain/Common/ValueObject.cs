using Abc.Aids.Methods;
using System;

namespace Abc.Domain.Common {

    public abstract class ValueObject<TData> : BaseEntity where TData : class, new() {

        protected readonly TData data;
        internal static Guid guid;
        protected internal ValueObject(TData d = null) => data = d ?? new TData();

        public TData Data {
            get {
                if (data is null) return null;
                var d = new TData();
                Copy.Members(data, d);

                return d;
            }
        }

        public bool IsUnspecified => isUnspecified();

        private bool isUnspecified() {
            return data is null || arePropertiesEqual(data, new TData());
        }

        private static bool arePropertiesEqual(TData a, TData b) {
            foreach (var property in a.GetType().GetProperties()) {
                var name = property.Name;

                var p = b.GetType().GetProperty(name);

                if (p is null) return false;
                var expected = property.GetValue(a);
                var actual = p.GetValue(b);

                switch (expected) {
                    case null when (actual is null):
                        continue;
                    case null:
                        return false;
                }
                if (name == "Id"
                    && isGuid(expected as string)
                    && isGuid(actual as string)) continue;

                if (!expected.Equals(actual)) return false;
            }

            return true;
        }

        private static bool isGuid(string s) {
            try {
                guid = new Guid(s);
                return true;
            } catch (FormatException) { return false; }
        }

    }

}
