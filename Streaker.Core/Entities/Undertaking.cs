using Streaker.Core.Enums;
using Streaker.SharedKernel;

namespace Streaker.Core.Entities
{
    /// <summary>
    /// Represents a task that should be completed at regular intervals.
    /// </summary>
    public class Undertaking : DatedEntityBase<int>
    {
        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the number of times this task should be completed in the given time period.
        /// </summary>
        public int Frequency { get; set; } = 1;

        /// <summary>
        /// Gets or sets the time period to apply to the task frequency.
        /// </summary>
        public FrequencyUnit Units { get; set; } = FrequencyUnit.Day;
    }
}
