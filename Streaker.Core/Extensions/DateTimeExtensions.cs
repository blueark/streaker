using Streaker.Core.Entities;
using Streaker.Core.Enums;
using Streaker.Core.Exceptions;

namespace Streaker.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime AddFrequency(this DateTime date, FrequencyUnit unit, int amount)
        {
            return unit switch
            {
                FrequencyUnit.Millisecond => date.AddMilliseconds(amount),
                FrequencyUnit.Second => date.AddSeconds(amount),
                FrequencyUnit.Minute => date.AddMinutes(amount),
                FrequencyUnit.Hour => date.AddHours(amount),
                FrequencyUnit.Day => date.AddDays(amount),
                FrequencyUnit.Week => date.AddDays(amount * 7),
                FrequencyUnit.Month => date.AddMonths(amount),
                FrequencyUnit.Year => date.AddYears(amount),
                _ => throw new FrequencyUnitException("Unable to calculate frequency addition")
            };
        }
    }
}
