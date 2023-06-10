using System;
using System.IO;
using LibrarySerialization;

namespace TestForLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestObject t1 = null;
            using (var stream = File.OpenWrite("serializeObject.dat"))
            {
                t1 = new TestObject { Age = 15, Name = "Oleg" };
                Serializer.Serialize(t1, stream);
            }

            TestObject t2 = null;
            using (var stream = File.OpenRead("serializeObject.dat"))
            {
                t2 = Serializer.Deserialize<TestObject>(stream);
            }

            Console.WriteLine($"t1 = {t1.Name} {t1.Age}");
            Console.WriteLine($"t2 = {t1.Name} {t2.Age}");

            Console.ReadLine();
        }
    }
}
