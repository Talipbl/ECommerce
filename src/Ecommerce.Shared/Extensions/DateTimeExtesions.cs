namespace Ecommerce.Shared.Extensions
{
    public static class DateTimeExtesions
    {
        public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime() <= DateTimeOffset.MinValue.UtcDateTime
                       ? DateTimeOffset.MinValue
                       : new DateTimeOffset(dateTime);
        }
    }
}
