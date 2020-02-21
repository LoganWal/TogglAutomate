namespace AutomateToggl
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var date = DateTime.Now.DayOfWeek;

            if (date == DayOfWeek.Sunday || date == DayOfWeek.Saturday)
            {
                return;
            }

            TogglRequestHelper.SendTogglRequest(DateTime.Now);
        }
    }
}
