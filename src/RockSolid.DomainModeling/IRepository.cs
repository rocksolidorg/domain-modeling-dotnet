namespace RockSolid.DomainModeling;

public interface IRepository<TAggregate, TId>
    where TAggregate : Entity<TId>, IAggregateRoot
    where TId : notnull
{
    Task<TAggregate?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(TAggregate entity);
    void Remove(TAggregate entity);
}
