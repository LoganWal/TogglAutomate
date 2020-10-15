namespace AutomateTogglMonthlyCatchUp
{
    using System;
    using AutomateTogglShared.Helpers;

    public class Program
    {
        private static void Main(string[] args)
        {
            var currentDate = DateTime.Now;
            var iterator = new DateTime(currentDate.Year, currentDate.Month, 1);

            while (iterator <= currentDate)
            {
                var date = iterator.DayOfWeek;

                if (date == DayOfWeek.Sunday || date == DayOfWeek.Saturday)
                {
                    iterator = iterator.AddDays(1);
                    continue;
                }

                TogglRequestHelper.SendTogglRequest(iterator);

                iterator = iterator.AddDays(1);
            }
        }
    }
}
