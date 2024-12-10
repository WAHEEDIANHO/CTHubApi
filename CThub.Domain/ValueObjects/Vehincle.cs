namespace CThub.Domain.ValueObjects;

public record Vehincle
{
    public string Name { get; } = default!;
    public string Type { get; } = default!;
    public string Model { get; } = default!;
    public int Capacity { get; } = default!;


    private Vehincle(string name, string type, string model, int capacity)
    {
        Name = name;
        Type = type;
        Model = model;
        Capacity = capacity;
    }

    public static Vehincle Of(string name, string type, string model, int capacity)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(type);
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(capacity, 3);

        return new Vehincle(name, type, model, capacity);
    }
}