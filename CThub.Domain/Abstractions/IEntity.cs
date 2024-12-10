namespace CThub.Domain.Abstractions;

public interface IEntity<T>: IEntity
{
    T Id { get; set; }
}

public interface IEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifieldAt { get; set; }
    // public string? CreatedBy { get; set; }
}