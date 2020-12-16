
using Abc.Aids.Reflection;
using System;
using System.Linq.Expressions;

namespace Abc.Aids.Services {
    public sealed class ExcelRowClassMapper {

        public ExcelRowClassMapper() { }

        public ExcelRowClassMapper(string name, object value, ExcelRowClassMapperType valueType) {
            Name = name;
            Value = value;
            ValueType = valueType;
        }

        public static ExcelRowClassMapper Create<T>(Expression<Func<T, object>> name, object value, ExcelRowClassMapperType valueType) => new ExcelRowClassMapper(GetMember.Name<T>(name), value, valueType);

        public string Name { get; set; }
        public object Value { get; set; }
        public ExcelRowClassMapperType ValueType { get; set; }

    }

}
