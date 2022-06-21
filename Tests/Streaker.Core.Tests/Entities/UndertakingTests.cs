namespace Streaker.Core.Tests.Entities
{
    public class UndertakingTests
    {
        [Fact]
        public void UndertakingDefaultValues()
        {
            var task = new Undertaking();
            Assert.Equal(0, task.Id);
            Assert.Equal(DateTime.MinValue, task.Created);
            Assert.Equal(string.Empty, task.Name);
            Assert.Equal(1, task.Frequency);
            Assert.Equal(FrequencyUnit.Day, task.Units);
        }
    }
}
