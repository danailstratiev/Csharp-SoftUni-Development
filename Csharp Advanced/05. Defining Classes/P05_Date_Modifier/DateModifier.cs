using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace P05_Date_Modifier
{
    public class DateModifier
    {
        private string firstDate;

        private string secondDate;

        public string FirstDate { get; set; }

        public string SecondDate { get; set; }

        public TimeSpan DateDifference()
        {
            this.firstDate = FirstDate;
            this.secondDate = SecondDate;

            return (DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture).Date -
                DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture).Date);
        }
    }
}
