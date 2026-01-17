using System.ComponentModel;
using System.Reflection;

namespace Common.Extensions;

public static class EnumExtensions
{
    public static string GetEnumDescription(this Enum value)
    {
		ArgumentNullException.ThrowIfNull(value);

		FieldInfo field = value.GetType().GetField(value.ToString())!;

        DescriptionAttribute? attribute = (DescriptionAttribute?)field
                                                                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                                .FirstOrDefault();

        return attribute?.Description ?? value.ToString();
    }

	public static TEnum GetEnumOption<TEnum>(this string description) where TEnum : struct, Enum
	{
		foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
		{
			var attribute = field.GetCustomAttribute<DescriptionAttribute>();
			if (attribute?.Description == description || field.Name == description)
			{
				try
				{
					return (TEnum)field.GetValue(null)!;
				}
				catch
				{
					return default;
				}
			}
		}

		throw new ArgumentException($"'{description}' is not a valid description for enum {typeof(TEnum)}.");
	}

	public static IList<TEnum> GetOptionsSimilarTo<TEnum>(string term) where TEnum : struct, Enum
	{
		List<TEnum> similarOptions = [];

		string description;

		foreach (var option in Enum.GetValues<TEnum>())
		{
			if (option.ToString().Contains(term, StringComparison.InvariantCultureIgnoreCase))
			{
				similarOptions.Add(option);
				continue;
			}

			description = option.GetEnumDescription();
			if (!string.IsNullOrWhiteSpace(description) && description.Contains(term, StringComparison.InvariantCultureIgnoreCase))
				similarOptions.Add(option);
		}

		return similarOptions;
	}
}