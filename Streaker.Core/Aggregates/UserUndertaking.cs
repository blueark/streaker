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
        private int currentStreak = 0;

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
        public int CurrentStreak {
            get
            {
                var now = DateTime.UtcNow;
                return now <= this.StreakExpiry ? this.currentStreak : 0;
            }
            set { this.currentStreak = value >= 0 ? value : 0; }
        }

        /// <summary>
        /// Gets or sets the last time this user completed the task in UTC.
        /// </summary>
        public DateTime LastTime {
            get => this.lastTime > this.Task.Created ? this.lastTime : this.Task.Created;
            set
            {
                this.lastTime = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            }
        }

        /// <summary>
        /// Gets the date/time the streak will expire.
        /// </summary>
        [NotMapped]
        public DateTime StreakExpiry => this.LastTime.AddFrequency(this.Task.Units, this.Task.Frequency);

        /// <summary>
        /// Completes a task and updates the current streak.
        /// </summary>
        public void CompleteTask()
        {
            var now = DateTime.UtcNow;
            this.CurrentStreak = now <= this.StreakExpiry ? this.CurrentStreak + 1 : 1;
            this.LastTime = now;
        }
    }
}
