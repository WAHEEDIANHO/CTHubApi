namespace CThub.Domain.Abstractions;

public abstract class Entity<T>: IEntity<T>
{
    public T Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifieldAt { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<T> entity) return false;
        if (ReferenceEquals(this, obj)) return true;
        
        if (obj.GetType() != GetType()) return false;
        return Id != null && Id.Equals(entity.Id);  
    }

    public override int GetHashCode()
    {
        return Id?.GetHashCode() ?? 0;
    }

    public override string ToString()
    {
        return Id?.ToString() ?? base.ToString();
    }
}

public abstract class Entity: IEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifieldAt { get; set; }
}