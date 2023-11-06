namespace FidelioIntegration.Fias.Entities.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
internal class FiasMessageAttribute : Attribute
{
    public string Indicator { get; private init; }

    public FiasMessageDirections Direction { get; private init; }

    public FiasMessageAttribute(string indicator, FiasMessageDirections direction)
    {
        Indicator = indicator;
        Direction = direction;
    }
}