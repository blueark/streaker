using Streaker.Core.Entities;

namespace Streaker.Core.Aggregates
{
    /// <summary>
    /// Represents a summary of a task carried out by a user.
    /// </summary>
    public class UserUndertaking
    {
        public UserUndertaking()
        {
            this.User = new User();
            this.Task = new Undertaking();
        }

        public UserUndertaking(User user, Undertaking task)
        {
            this.User = user;
            this.Task = task;
            this.LastTime = task.Created;
        }

        public UserUndertaking(User user, Undertaking task, int streak)
            : this(user, task)
        {
            this.CurrentStreak = streak;
        }

        public UserUndertaking(User user, Undertaking task, int streak, DateTime last)
            : this(user, task, streak)
        {
            this.LastTime = last;
        }

        /// <summary>
        /// Gets or sets the user involved in this task.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the task's details.
        /// </summary>
        public Undertaking Task { get; set; }

        /// <summary>
        /// Gets or sets this user's current streak.
        /// </summary>
        public int CurrentStreak { get; set; }

        /// <summary>
        /// Gets or sets the last time this user completed the task.
        /// </summary>
        public DateTime LastTime { get; set; }
    }
}
