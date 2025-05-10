using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using RockSolid.DomainModeling;

BenchmarkRunner.Run(Assembly.GetExecutingAssembly());
[MemoryDiagnoser]
public class DomainEventAddClearBenchmarks
{
    [Params(10, 100, 1000, 10_000)]
    public int EventCount;

    [Benchmark]
    public void AddAndClear_DirectList()
    {
        var entity = new DirectEntity(Guid.NewGuid());

        for (int i = 0; i < EventCount; i++)
        {
            entity.DoDummy(i);
        }

        var _ = entity.DomainEvents.Count; // Simulate inspection
        entity.ClearDomainEvents();
    }


}

public sealed class DummyEvent(int sequence) : IDomainEvent
{
    public int Sequence { get; } = sequence;
}


public sealed class DirectEntity(Guid id) : Entity<Guid>(id)
{
    public void DoDummy(int sequence)
    {
        AddDomainEvent(new DummyEvent(sequence));
    }

}





[MemoryDiagnoser]
public class DomainEventAccessBenchmarks
{
    private readonly WithAsReadOnly _entityWithWrapper = new(Guid.NewGuid());
    private readonly WithDirectList _entityWithDirectList = new(Guid.NewGuid());

    [Benchmark(Baseline = true)]
    public IReadOnlyCollection<IDomainEvent> ReturnDirectList() =>
        _entityWithDirectList.DomainEvents;

    [Benchmark]
    public IReadOnlyCollection<IDomainEvent> ReturnAsReadOnly() =>
        _entityWithWrapper.DomainEvents;
}

public sealed class WithDirectList : EntityDirectList<Guid>
{
    public WithDirectList(Guid id) : base(id)
    {
        AddDomainEvent(new SomethingHappened());
    }
}

public sealed class WithAsReadOnly : EntityWithWrapper<Guid>
{
    public WithAsReadOnly(Guid id) : base(id)
    {
        AddDomainEvent(new SomethingHappened());
    }
}

public sealed class SomethingHappened : IDomainEvent { }

public abstract class EntityDirectList<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

    protected void AddDomainEvent(IDomainEvent @event) => _domainEvents.Add(@event);

    protected EntityDirectList(TId id) => Id = id;

    public TId Id { get; }
}

public abstract class EntityWithWrapper<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent @event) => _domainEvents.Add(@event);

    protected EntityWithWrapper(TId id) => Id = id;

    public TId Id { get; }
}
