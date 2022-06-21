namespace Streaker.Core.Tests.Aggregates
{
    public class UserUndertakingTests
    {
        private const int SecondsPerHour = 60 * 60;
        private const int SecondsPerDay = SecondsPerHour * 24;
        private const int SecondsPerWeek = SecondsPerDay * 7;
        private const int SecondsInJanuary = SecondsPerDay * 31;
        private const int SecondsInFebruary2000 = SecondsPerDay * 29;
        private const int SecondsInMarch = SecondsInJanuary;
        private const int SecondsIn2000 = SecondsPerDay * 366;
        private const int SecondsIn2001 = SecondsPerDay * 365;

        [Fact]
        public void UserUndertakingDefaultValues()
        {
            var actual = new UserUndertaking();
            Assert.Equal(0, actual.CurrentStreak);
            Assert.Equal(DateTime.MinValue, actual.LastTime);
        }

        [Fact]
        public void UndertakingDateBecomesLastTime()
        {
            var date = DateTime.Now;
            var user = new User();
            var task = new Undertaking() { Created = date };
            var actual = new UserUndertaking(user, task);
            Assert.Equal(date, actual.LastTime);
        }

        [Fact]
        public void UpdatingTaskDateUpdatesLastDateIfNewer()
        {
            var date1 = DateTime.Now.AddDays(-30);
            var date2 = DateTime.Now;
            var user = new User();
            var task = new Undertaking() { Created = date1 };
            var actual = new UserUndertaking(user, task);
            Assert.Equal(date1, actual.LastTime);

            task.Created = date2;
            Assert.Equal(date2, actual.LastTime);
        }

        [Fact]
        public void UpdatingTaskDateNotUpdateLastDateIfOlder()
        {
            var date1 = DateTime.Now.AddDays(-30);
            var date2 = DateTime.Now;
            var user = new User();
            var task = new Undertaking() { Created = date2 };
            var actual = new UserUndertaking(user, task);
            Assert.Equal(date2, actual.LastTime);

            task.Created = date1;
            Assert.Equal(date2, actual.LastTime);
        }

        [Theory]
        [InlineData(FrequencyUnit.Millisecond, 3000, 3)]
        [InlineData(FrequencyUnit.Second, 30, 30)]
        [InlineData(FrequencyUnit.Minute, 5, 60 * 5)]
        [InlineData(FrequencyUnit.Hour, 7, SecondsPerHour * 7)]
        [InlineData(FrequencyUnit.Day, 3, SecondsPerDay * 3)]
        [InlineData(FrequencyUnit.Week, 4, SecondsPerWeek * 4)]
        [InlineData(FrequencyUnit.Month, 3, SecondsInJanuary + SecondsInFebruary2000 + SecondsInMarch)]
        [InlineData(FrequencyUnit.Year, 2, SecondsIn2000 + SecondsIn2001)]
        public void ValidExpiryDate(FrequencyUnit unit, int amount, int seconds)
        {
            var baseDate = new DateTime(2000, 1, 1);
            var user = new User();
            var task = new Undertaking() { Created = baseDate, Units = unit, Frequency = amount };
            var actual = new UserUndertaking(user, task);
            var expected = baseDate.AddSeconds(seconds);

            Assert.Equal(expected, actual.StreakExpiry);
        }
    }
}
