namespace FidelioIntegration.Fias.Entities.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class FiasForAttribute : Attribute
{
    public string Name { get; private init; }

    public FiasForAttribute(string name) => Name = name;
}