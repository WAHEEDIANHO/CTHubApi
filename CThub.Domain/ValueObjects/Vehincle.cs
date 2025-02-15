namespace CThub.Domain.ValueObjects;

public record Vehincle
{
    public string Name { get; } = default!;
    public Enums.Vehincle Type { get; } = default!;
    public string Model { get; } = default!;
    public int Capacity { get; } = default!;


    private Vehincle(string name, Enums.Vehincle type, string model, int capacity)
    {
        Name = name;
        Type = type;
        Model = model;
        Capacity = capacity;
    }

    public static Vehincle Of(string name, Enums.Vehincle type, string model, int capacity)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(type);
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        // if (type == Enums.Vehincle.CAR)
        // {
        //     ArgumentOutOfRangeException.ThrowIfLessThan(capacity, 4);
        //     // ArgumentOutOfRangeException.ThrowIfGreaterThan(capacity, 3);
        //
        // }else if (type == Enums.Vehincle.TRICYCLE)
        // {
        //     ArgumentOutOfRangeException.ThrowIfGreaterThan(capacity, 3);
        // }

        return new Vehincle(name, type, model, capacity);
    }
}