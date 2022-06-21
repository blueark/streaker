using Streaker.Core.Entities;
using Streaker.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Streaker.Core.Aggregates
{
    /// <summary>
    /// Represents a summary of a task carried out by a user.
    /// </summary>
    public class UserUndertaking
    {
        private DateTime lastTime = default;

        public UserUndertaking()
        {
            this.User = new User();
            this.Task = new Undertaking();
        }

        public UserUndertaking(User user, Undertaking task)
        {
            this.User = user;
            this.Task = task;
            this.lastTime = task.Created;
        }

        public UserUndertaking(User user, Undertaking task, int streak)
            : this(user, task)
        {
            this.CurrentStreak = streak;
        }

        public UserUndertaking(User user, Undertaking task, int streak, DateTime last)
            : this(user, task, streak)
        {
            this.lastTime = last;
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
        /// <remarks></remarks>
        public DateTime LastTime { get
            {
                return this.lastTime > this.Task.Created ? this.lastTime : this.Task.Created;
            }
            set
            {
                this.lastTime = value;
            }
        }

        /// <summary>
        /// Gets the date/time the streak will expire.
        /// </summary>
        [NotMapped]
        public DateTime StreakExpiry => this.LastTime.AddFrequency(this.Task.Units, this.Task.Frequency);
    }
}
