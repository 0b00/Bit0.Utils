using System;

namespace Bit0.Utils.Common.Epoch
{
    /// <summary>
    /// Date range
    /// </summary>
    public class DateRange
    {
        /// <summary>
        /// Start date
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Date range
        /// </summary>
        public DateRange()
        { }

        /// <summary>
        /// Date range
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        public DateRange(DateTime start, DateTime end)
        {
            // TODO: exception if end < start
            Start = start;
            End = end;
        }

        /// <summary>
        /// Timespan between start and end
        /// </summary>
        public TimeSpan TimeSpan => End - Start;

        /// <summary>
        /// Checks if a given date is range
        /// </summary>
        /// <param name="includeStartEnd">Including start and end</param>
        /// <returns></returns>
        public bool IsBetween(bool includeStartEnd = true)
        {
            return IsBetween(DateTime.Now, includeStartEnd);
        }

        /// <summary>
        /// Checks if a given date is range
        /// </summary>
        /// <param name="dateToCheck">Date to check</param>
        /// <param name="includeStartEnd">Including start and end</param>
        /// <returns>True if date is range</returns>
        public bool IsBetween(DateTime dateToCheck, bool includeStartEnd = true)
        {
            return includeStartEnd
                ? dateToCheck >= Start && dateToCheck <= End
                : dateToCheck > Start && dateToCheck < End;
        }
    }
}
