namespace Streaker.Core.Tests.Aggregates
{
    public class UserUndertakingTests
    {
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
    }
}
