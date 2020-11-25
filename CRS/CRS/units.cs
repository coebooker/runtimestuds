using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using UF;

namespace CRS
{
    public class validity
    {
        public bool valid;
        public bool warning;
        public string message;

        public validity(bool isValid, bool isWarning, string warningMessage)
        {
            valid = isValid;
            warning = isWarning;
            message = warningMessage;
        }
    }
    public class classTime
    {
        public classTime(List<char> day, double start, double end)
        {
            days = day;
            startTime = start;
            endTime = end;
        }
        private List<char> days;
        private double startTime;
        private double endTime;

        public List<char> getDays()
        {
            return days;
        }

        public double getStartTime()
        {
            return startTime;
        }

        public double getEndTime()
        {
            return endTime;
        }
    }
    public class course
    {
        public string crsID;
        public string title;
        public string instructor;
        public string credit;
        public int seats;
        public int maxSeats;
        public int num_time;
        public List<string> timeBlocks;
        public List<classTime> time_blocks_alternative;
        private List<student> enrolledStudents = new List<student>();
        public List<string> preReqLst = new List<string>();

        // Class constructor
        public course(string crsID, string ttl, string ist, string crdt, int sea, int num_time_b, List<string> time_bs)
        {
            this.crsID = crsID;
            title = ttl;
            instructor = ist;
            credit = crdt;
            seats = sea;
            maxSeats = sea;
            num_time = num_time_b;
            timeBlocks = time_bs;
            time_blocks_alternative = new List<classTime> { };

            foreach (string timeBlock in time_bs)
            {
                List<char> days = new List<char>();
                days.AddRange(DecodeDay(Convert.ToInt32(timeBlock.Substring(0, 2))));

                double startTime = Convert.ToDouble(timeBlock.Substring(2, 2)) / 2;
                double endTime = startTime + Convert.ToDouble(timeBlock.Substring(4, 1)) * 0.5;

                classTime timeOfBlock = new classTime(days, startTime, endTime);
                time_blocks_alternative.Add(timeOfBlock);
            }
        }

        // Retrieve information from objects
        public List<classTime> getClassTime()
        {
            return time_blocks_alternative;
        }
        public void setInstructor(string instructorUsername)
        {
            instructor = instructorUsername;
        }
        public string getBlocks()
        {
            string tempString = "";
            foreach (string crsBlock in timeBlocks)
                tempString = tempString + Decode(crsBlock) + '\n';
            return tempString.Remove(tempString.Length - 1, 1);
        }
        public List<student> getStudents()
        {
            return enrolledStudents;
        }

        // Enroll and disenroll users
        public void disenrollUser(student currentStudent)
        {
            student std = enrolledStudents.Find(s => currentStudent.username == s.username);
            enrolledStudents.Remove(std);
            seats += 1;
        }
        public void enrollUser(student currentStudent)
        {
            enrolledStudents.Add(currentStudent);
            seats -= 1;
        }


        // Schedule Decoders
        public static string Decode(string schEncoded)
        {
            int days = Convert.ToInt32(schEncoded.Substring(0, 2));
            int startingTime = Convert.ToInt32(schEncoded.Substring(2, 2));
            int length = Convert.ToInt32(schEncoded.Substring(4, 1));

            return DecodeDay(days) + " : " + DecodeTime(startingTime, length);
        }
        public static string DecodeDay(int dayEncoded)
        {
            string[] dayList = { "F", "R", "W", "T", "M" };
            int baseNumber = 16;
            string days = "";
            for (int i = 0; i < 5; i++)
            {
                if (dayEncoded >= baseNumber)
                {
                    dayEncoded -= baseNumber;
                    days = dayList[i] + days;
                }
                baseNumber = baseNumber / 2;
            }
            return days;
        }
        public static string DecodeTime(int timeEncoded, int lengthEncoded)
        {
            string ampm = "AM";
            string endampm = "AM";
            float tempMin = Convert.ToSingle(timeEncoded) / 2;
            int timeInMin = Convert.ToInt32(tempMin * 60.0);
            if (timeInMin >= 780)
            {
                ampm = "PM";
                endampm = ampm;
                timeInMin = timeInMin - 720;
            }
            else if (780 > timeInMin && timeInMin >= 720)
            {
                ampm = "PM";
                endampm = "PM";
            }

            int timeHour = timeInMin / 60;
            int timeMin = timeInMin % 60;

            int lenMin = 30 * lengthEncoded;
            int endTimeInMin = lenMin + timeInMin;
            if (endTimeInMin >= 780)
            {
                endTimeInMin = endTimeInMin - 720;
                endampm = "PM";
            }
            else if (780 > endTimeInMin && endTimeInMin >= 720)
            {
                endampm = "PM";
            }

            int endTimeHour = endTimeInMin / 60;
            int endTimeMin = endTimeInMin % 60;

            return Convert.ToString(timeHour).PadLeft(2, '0') + ":" + Convert.ToString(timeMin).PadLeft(2, '0') + ampm + " to " + Convert.ToString(endTimeHour).PadLeft(2, '0') + ":" + Convert.ToString(endTimeMin).PadLeft(2, '0') + endampm;
        }
    }
    public class previousCourse
    {
        public string username;
        public string crsID;
        public string semester;
        public float credit;
        public string grade;
        public previousCourse(string stud, string nme, string semes, float crdt, string grd)
        {
            username = stud;
            crsID = nme;
            semester = semes;
            credit = crdt;
            grade = grd;
        }
    }
}

// Define utility functions
namespace UF
{
    public static class utilities
    {
        public static string encodeTime(string from, string to)
        {
            // Convert them to military time
            if (from.EndsWith("PM") != from.StartsWith("12"))
            {
                int hour = Convert.ToInt32(from.Substring(0, 1));
                hour += 12;
                from = hour.ToString() + from.Substring(1);
            }
            if (to.EndsWith("PM") != to.StartsWith("12"))
            {
                int hour = Convert.ToInt32(from.Substring(0, 1));
                hour += 12;
                to = hour.ToString() + to.Substring(1);
            }

            // Get rid of AM and PM
            from = from.Substring(0, from.Length - 2).Trim();
            to = to.Substring(0, to.Length - 2).Trim();


            // Convert them to floating point number
            int index = from.IndexOf(":");
            float fromHour = Convert.ToInt32(from.Substring(0, index));
            if (from.EndsWith("30"))
                fromHour += 0.5f;
            string tt = Convert.ToInt32(fromHour * 2).ToString();

            index = to.IndexOf(":");
            float toHour = Convert.ToInt32(to.Substring(0, index));
            if (to.EndsWith("30"))
                toHour += 0.5f;
            string l = Convert.ToInt32((toHour - fromHour) / 0.5).ToString();

            return tt + l;
        }
    }
}