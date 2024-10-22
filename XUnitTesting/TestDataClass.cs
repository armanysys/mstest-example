
using System.Collections;

namespace XUnitTesting
{
    public class TestDataClass : IEnumerable<object[]>
    {
        public readonly List<object[]> _data = new()
        {
            new object[] { new EmailTestCase("invalid@invalid.invalid", false) },
            new object[] { new EmailTestCase("armando.antonio@chubb.com", true) }
        };


        public IEnumerator<object[]> GetEnumerator()  => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
