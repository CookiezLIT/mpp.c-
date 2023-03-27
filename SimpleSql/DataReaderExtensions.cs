using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;

namespace SimpleSql
{
    public static class DataReaderExtensions
    {
        public static T Map<T>(this IDataReader reader) where T : class
        {
            var type = typeof(T);
            T? entity = null;
            List<object> values = new List<object>();

            foreach (var objectProperty in type.GetProperties())
            {
                var columnName = (string)objectProperty.GetCustomAttributesData().Where(a => a.AttributeType == typeof(ColumnAttribute)).Select(a => a.ConstructorArguments[0].Value).FirstOrDefault();
                values.Add(reader[columnName]);
            }
            entity = (T)Activator.CreateInstance(type, values.ToArray());
            return entity;
        }
    }
}
