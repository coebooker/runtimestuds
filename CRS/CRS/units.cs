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
        private int num_time;
        private List<string> timeBlocks;
        private List<classTime> time_blocks_alternative;
        private List<student> enrolledStudents = new List<student>();
        private List<string> preReqLst = new List<string>();
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
        public void addPreReqs(List<string> newPreReqs)
        {
            preReqLst = newPreReqs;
        }
        public List<classTime> getClassTime()
        {
            return time_blocks_alternative;
        }
        public void setTimeBlocks(List<string> newTimeBlocks)
        {
            timeBlocks = newTimeBlocks;
            //Shige if you could implement the time class list here that'd be pretty cash money
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
        public List<string> getTimeblockLst()
        {
            return timeBlocks;
        }

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


        public string Decode(string encoded)
        {
            int days = Convert.ToInt32(encoded.Substring(0, 2));
            int time = Convert.ToInt32(encoded.Substring(2, 2));
            int length = Convert.ToInt32(encoded.Substring(4, 1));

            //string outputDecoded = string.Format("{0, -5}: {1,-30}", DecodeDay(days), DecodeTime(time, length));
            string outputDecoded = DecodeDay(days) + " : " + DecodeTime(time, length);
            return outputDecoded;
        }
        public string Decode2(string encoded)
        {
            return "placeholder";
        }
        public string DecodeDay(int dayEncoded)
        {
            int dayEncodedCopy = dayEncoded;
            string[] dayInWeek = { "F", "R", "W", "T", "M" };
            int baseNumber = 16;
            string daysClasses = "";
            for (int i = 0; i < 5; i++)
            {
                if (dayEncodedCopy >= baseNumber)
                {
                    daysClasses = dayInWeek[i] + daysClasses;
                    dayEncodedCopy = dayEncodedCopy - baseNumber;
                }
                baseNumber = baseNumber / 2;
            }
            return daysClasses;
        }
        public string DecodeTime(int timeEncoded, int lengthEncoded)
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
                    endampm = "PM";
                else
                    endampm = "AM";
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

namespace UF
{
    public static class utilities
    {
        public static string encodeTime(string from, string to)
        {
            // Convert them to military time
            if (from.EndsWith("PM"))
            {
                int hour = Convert.ToInt32(from.Substring(0, 1));
                hour += 12;
                from = hour.ToString() + from.Substring(1);
            }
            if (to.EndsWith("PM"))
            {
                int hour = Convert.ToInt32(from.Substring(0, 1));
                hour += 12;
                to = hour.ToString() + to.Substring(1);
            }

            // Get rid of AM and PM
            from = from.Substring(0, from.Length - 2);
            to = to.Substring(0, to.Length - 2);


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
        public static string readInChunk(ref string l)
        {
            int index = l.IndexOf(" ");
            if (index == -1)
                return l;
            string s = l.Substring(0, index);
            l = l.Substring(index);
            l = l.Trim();
            return s;
        }
    }
}