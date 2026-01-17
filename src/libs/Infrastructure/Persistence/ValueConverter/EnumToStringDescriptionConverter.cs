using Common.Extensions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.ValueConverter;

public sealed class EnumToStringDescriptionConverter<TEnum> : ValueConverter<TEnum, string> where TEnum : struct, Enum
{
	public EnumToStringDescriptionConverter()
		: base(
			v => v.GetEnumDescription(),
			v => v.GetEnumOption<TEnum>())
	{ }
}