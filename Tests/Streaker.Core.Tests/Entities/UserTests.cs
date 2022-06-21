namespace Streaker.Core.Tests.Entities
{
    public class UserTests
    {
        [Fact]
        public void UserDefaultValues()
        {
            var user = new User();
            Assert.Equal(0, user.Id);
            Assert.Equal(string.Empty, user.Name);
            Assert.Equal(string.Empty, user.AuthenticationType);
            Assert.False(user.IsAuthenticated);
        }
    }
}
