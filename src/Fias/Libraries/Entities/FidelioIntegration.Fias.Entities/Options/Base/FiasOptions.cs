namespace FidelioIntegration.Fias.Entities;

public abstract class FiasOptions
{
	internal FiasOptions() { }

	public static T? All<T>() where T : FiasOptions, new()
	{
		if (Activator.CreateInstance(typeof(T)) is not T options)
			return null;

        var setters = typeof(T)
            .GetProperties()
            .Select(property => property.SetMethod)
            .Where(method => method is not null);

        try
        {
            foreach (var setter in setters)
                setter!.Invoke(options, new object[] { true });

            return options;
        }
        catch
        {
            return null;
        }
    }
}

