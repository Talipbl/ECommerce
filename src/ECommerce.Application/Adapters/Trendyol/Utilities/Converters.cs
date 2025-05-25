using AutoMapper;
using Ecommerce.Shared.Extensions;
using Ecommerce.Shared.Utilities.Results;
using Trendyol.Client;

namespace ECommerce.Trendyol;

public class DateTimeConverter : ITypeConverter<DateTime, long>
{
    public long Convert(DateTime source, long destination, ResolutionContext context) => (source.ToDateTimeOffset()).ToUnixTimeSeconds();
}
public class UnixMillisecondsToDateTimeConverter : ITypeConverter<long, DateTime>
{
    public DateTime Convert(long source, DateTime destination, ResolutionContext context) => DateTimeOffset.FromUnixTimeMilliseconds(source).LocalDateTime;
}
public class UnixMillisecondsToUtcDateTimeConverter : IValueConverter<long, DateTime>
{
    public DateTime Convert(long sourceMember, ResolutionContext context) => DateTimeOffset.FromUnixTimeMilliseconds(sourceMember).UtcDateTime;
}
public class QueryOptionConverter : ITypeConverter<QueryOption, QueryBooleanOption>
{
    public QueryBooleanOption Convert(QueryOption source, QueryBooleanOption destination, ResolutionContext context) => (QueryBooleanOption)((int)source);
}