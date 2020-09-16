using System;

namespace decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            // for testing
            Console.WriteLine(Decode("10162"));
            Console.WriteLine(Decode("15233"));
        }

        static string Decode(string encoded)
        {
            int days = Convert.ToInt32(encoded.Substring(0, 2));
            int time = Convert.ToInt32(encoded.Substring(2, 2));
            int length = Convert.ToInt32(encoded.Substring(4, 1));
          
            string outputDecoded = DecodeDay(days) + DecodeTime(time, length);
            return outputDecoded;
        }

        static string DecodeDay(int dayEncoded)
        {
            int dayEncodedCopy = dayEncoded;
            string[] dayInWeek = { "Fridays ", "Thursdays ", "Wednesdays ", "Tuesdays ", "Mondays " };
            int baseNumber = 16;
            string daysClasses = "";
            for (int i = 0; i < 5; i++)
            {
                if (dayEncodedCopy >= baseNumber)
                {
                    daysClasses = dayInWeek[i] + daysClasses;
                    dayEncodedCopy = dayEncodedCopy - baseNumber;
                }
                baseNumber = baseNumber/2;
            }

            //char[] charArray = daysClasses.ToCharArray();
            //Array.Reverse(charArray);
            return new string(daysClasses);
        }

        static string DecodeTime(int timeEncoded, int lengthEncoded)
        {
            string ampm = "AM";
            string endampm = "AM";
            float tempMin = Convert.ToSingle(timeEncoded) / 2;
            int timeInMin = Convert.ToInt32(tempMin * 60.0);
            if (timeInMin > 720)
            {
                ampm = "PM";
                endampm = ampm;
                timeInMin = timeInMin - 720;
            }

            int timeHour = timeInMin / 60;
            int timeMin = timeInMin % 60;

            int lenMin = 30 * lengthEncoded;
            int endTimeInMin = lenMin + timeInMin;
            if (lenMin + timeInMin > 720)
            {
                endTimeInMin = endTimeInMin - 720;
                if (ampm == "AM")
                {
                    endampm = "PM";
                }
                else
                {
                    endampm = "AM";
                }
            }

            int endTimeHour = endTimeInMin / 60;
            int endTimeMin = endTimeInMin % 60;

            return Convert.ToString(timeHour).PadLeft(2,'0')+":"+Convert.ToString(timeMin).PadLeft(2,'0')+ampm+" to "+ Convert.ToString(endTimeHour).PadLeft(2, '0') + ":" + Convert.ToString(endTimeMin).PadLeft(2, '0') + endampm;
        }
    }
}