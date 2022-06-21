using Streaker.Core.Entities;

namespace Streaker.Core.Aggregates
{
    /// <summary>
    /// Represents a summary of a task carried out by a user.
    /// </summary>
    public class UserUndertaking
    {
        public User? User { get; set; }

        public Undertaking? Task { get; set; }

        public int CurrentStreak { get; set; }
    }
}
