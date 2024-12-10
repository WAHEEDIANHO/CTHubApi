namespace CThub.Domain.Abstractions;

public abstract class Entity<T>: IEntity<T>
{
    public T Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifieldAt { get; set; }
}

public abstract class Entity: IEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifieldAt { get; set; }
}