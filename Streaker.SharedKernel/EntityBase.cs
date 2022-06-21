namespace Streaker.SharedKernel
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    /// <typeparam name="T">The type to use for the entity's ID. This is often an <see cref="int" /> but is flexible
    /// enough to support other types, such as <see cref="Guid"/> or <see cref="string"/>.</typeparam>
    public abstract class EntityBase<T> where T : notnull
    {
        /// <summary>
        /// Gets or sets the unique ID of this entity.
        /// </summary>
        public T Id { get; set; }
    }
}