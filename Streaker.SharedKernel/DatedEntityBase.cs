namespace Streaker.SharedKernel
{
    public class DatedEntityBase<T> : EntityBase<T> where T : notnull
    {
        public DateTime Created { get; set; }
    }
}
