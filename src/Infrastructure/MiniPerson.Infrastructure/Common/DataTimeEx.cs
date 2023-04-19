namespace MiniPerson.Infrastructure.Common
{
    public static class DataTimeEx
    {
        public static string GetDayShamsi(this string day)
        {
            switch (day)
            {
                case "Saturday":
                    day = "شنبه";
                    break;
                case "Sunday":
                    day = "یکشنبه";
                    break;
                case "Monday":
                    day = "دوشنبه";
                    break;
                case "Tuesday":
                    day = "سه شنبه";
                    break;
                case "Wednesday":
                    day = "چهارشنبه";
                    break;
                case "Thursday":
                    day = "پنج شنبه";
                    break;
                case "Friday":
                    day = "جمعه";
                    break;
                default:
                    // code block
                    break;
            }
            return day;

        }
    }
}
