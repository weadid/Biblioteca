using LibrarySerialization;

namespace TestForLib
{
    internal class TestObject
    {
        [Serialize(1, 2)]
        public int Age { get; set; }

        [Serialize(2, 40)]
        public string Name { get; set; }
    }
}
