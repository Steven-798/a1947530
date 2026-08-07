using Xunit;
using Prac1B;

namespace Prac1B.Tests
{
    public class PersonTests
    {
        [Fact]
        public void FullName_ReturnsExpectedFormat()
        {
            var p = new Person("Alice", "Smith", 22);
            string result = p.FullName();
            Assert.Equal("Alice Smith", result);
        }

        [Fact]
        public void IsAdult_ReturnsTrue_WhenAge18OrMore()
        {
            var p18 = new Person("Bob", "Brown", 18);
            var p30 = new Person("Charlie", "Davis", 30);
            var p17 = new Person("Kid", "Lee",17);

            Assert.True(p18.IsAdult());
            Assert.True(p30.IsAdult());
            Assert.False(p17.IsAdult());
        }
    }
}
