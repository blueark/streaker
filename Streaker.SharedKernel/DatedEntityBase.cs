namespace Streaker.SharedKernel
{
    public abstract class DatedEntityBase<T> : EntityBase<T> where T : notnull
    {
        private DateTime utcDateTime;

        /// <summary>
        /// Gets the entity's creation date in UTC.
        /// </summary>
        public DateTime Created
        {
            get => this.utcDateTime;
            set => this.utcDateTime = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
    }
}
