using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibrarySerialization
{
    public class SerializeAttribute : Attribute
    {
        public int Position { get; set; }
        public int Length { get; set; }

        public SerializeAttribute(int position, int length)
        {
            Position = position;
            Length = length;
        }
    }

    public class Serializer
    {
        private static IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            var attributeType = typeof(SerializeAttribute);

            return type
                .GetProperties()
                .Where(prop => prop.GetCustomAttributes(attributeType, false).Any())
                .OrderBy(
                    prop =>
                    ((SerializeAttribute)prop.GetCustomAttributes(attributeType, false).First()).
                        Position);
        }
        public static void Serialize<T>(T obj, Stream target) where T : class, new()
        {
            var properties = GetProperties(obj.GetType());

            using (var writer = new StreamWriter(target))
            {
                var attributeType = typeof(SerializeAttribute);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(obj, null).ToString();
                    writer.Write(value);
                }
                writer.WriteLine();
            }
        }

        public static T Deserialize<T>(Stream source) where T : class, new()
        {
            var properties = GetProperties(typeof(T));
            var obj = new T();
            using (var reader = new StreamReader(source))
            {
                var attributeType = typeof(SerializeAttribute);
                foreach (var propertyInfo in properties)
                {
                    var attr = (SerializeAttribute)propertyInfo.GetCustomAttributes(attributeType, false).First();

                    var buffer = new char[attr.Length];
                    reader.Read(buffer, 0, buffer.Length);
                    var value = new string(buffer).Trim();

                    if (propertyInfo.PropertyType != typeof(string))
                    {
                        propertyInfo.SetValue(obj, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                    }
                    else
                    {
                        propertyInfo.SetValue(obj, value.Trim(), null);
                    }
                }
            }
            return obj;
        }

    }
}
