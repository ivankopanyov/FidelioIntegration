namespace FidelioIntegration.Fias.Entities.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
internal class FiasOptionsAttribute : Attribute
{
    public Type Type { get; private init; }

    public FiasOptionsAttribute(Type type) => Type = type;
}