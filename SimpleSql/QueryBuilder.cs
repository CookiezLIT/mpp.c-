using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SimpleSql
{
    public static class QueryBuilder
    {
        public enum Operations
        {
            GetById,
            GetAll,
            Create,
            Update,
            Delete
        }

        private static string SetFieldTo(string fieldName, object value)
        {
            return $"{fieldName}='{value}'";
        }

        private static string InsertValues(IEnumerable<object> values)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var value in values)
            {
                sb.Append($"'{value}', ");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        private static string SetValues(IDictionary<string, object> dictionary)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var keyValuePair in dictionary)
            {
                sb.Append($"{keyValuePair.Key}='{keyValuePair.Value}', ");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        public static string Build(Operations operation, Type type)
        {
            var dbTable = (string)type.GetCustomAttributesData().Select(a => a.ConstructorArguments[0].Value).FirstOrDefault();
            var template = BuildTemplate(operation, dbTable);
            return string.Format(template);
        }

        public static string Build(Operations operation, Type type, Guid id)
        {
            var dbTable = (string)type.GetCustomAttributesData().Select(a => a.ConstructorArguments[0].Value).FirstOrDefault();
            var template = BuildTemplate(operation, dbTable);
            var idColumn = "id";

            switch (operation)
            {
                case Operations.GetById:
                    var getWhereCondition = SetFieldTo(idColumn, id);
                    return string.Format(template, getWhereCondition);
                case Operations.Delete:
                    var deleteWhereCondition = SetFieldTo(idColumn, id);
                    return string.Format(template, deleteWhereCondition);
                default:
                    return string.Empty;
            }
        }

        public static string Build(Operations operation, object modelObject)
        {
            var dictionary = Map(modelObject);
            var idProperty = modelObject.GetType().GetProperty("Id");
            var idColumn = "id";
            var dbTable = (string)modelObject.GetType().GetCustomAttributesData().Select(a => a.ConstructorArguments[0].Value).FirstOrDefault();
            var template = BuildTemplate(operation, dbTable);
            
            switch (operation)
            {
                case Operations.Create:
                    var values = InsertValues(dictionary.Values);
                    return string.Format(template, values);
                case Operations.Update:
                    var updateWhereCondition = SetFieldTo(idColumn, dictionary[idColumn]);
                    dictionary.Remove(idColumn);
                    var setValues = SetValues(dictionary);
                    return string.Format(template, setValues, updateWhereCondition);
                case Operations.Delete:
                    var deleteWhereCondition = SetFieldTo(idColumn, dictionary[idColumn]);
                    return string.Format(template, deleteWhereCondition);
                default:
                    return string.Empty;
            }
        }

        public static string BuildTemplate(Operations operation, string dbTable)
        {
            return operation switch
            {
                Operations.GetById => $"SELECT * FROM {dbTable} WHERE {{0}}",
                Operations.GetAll => $"SELECT * FROM {dbTable}",
                Operations.Create => $"INSERT INTO {dbTable} VALUES({{0}})",
                Operations.Update => $"UPDATE {dbTable} SET {{0}} WHERE {{1}}",
                Operations.Delete => $"DELETE FROM {dbTable} WHERE {{0}}",
                _ => string.Empty,
            };
        }

        public static Dictionary<string, object> Map(object modelObject)
        {
            var dictionary = new Dictionary<string, object>();

            foreach (var objectProperty in modelObject.GetType().GetProperties())
            {
                var key = (string)objectProperty.GetCustomAttributesData().Where(a => a.AttributeType == typeof(ColumnAttribute)).Select(a => a.ConstructorArguments[0].Value).FirstOrDefault();
                var value = objectProperty.GetValue(modelObject, null);
                dictionary.Add(key, value);
            }
            return dictionary;
        }
    }
}
