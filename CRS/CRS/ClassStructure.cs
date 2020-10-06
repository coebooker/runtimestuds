using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRS
{
    public class baseUser
    {
        public string username;
        public string password;
        public string fname;
        public string mname;
        public string lname;
    }

    public class student : baseUser
    {
        private string advisor;
        public student(string f, string m, string l, string adv, string usrname, string psw)
        {
            fname = f;
            mname = m;
            lname = l;
            advisor = adv;
            username = usrname;
            password = psw;

        }
        private List<course> RegisteredCourses = new List<course>();
        private List<PreviousCourse> CourseHistory = new List<PreviousCourse>();
    }

    public class faculty : baseUser
    {
        public faculty(string f, string m, string l, string usrname, string psw)
        {
            fname = f;
            mname = m;
            lname = l;
            username = usrname;
            password = psw;
        }
        private List<course> CourseSchedule = new List<course>();
    }

    public class admin : baseUser
    {
        public admin(string f, string m, string l, string usrname, string psw)
        {
            fname = f;
            mname = m;
            lname = l;
            username = usrname;
            password = psw;
        }
        private List<course> CourseSchedule = new List<course>();
        private List<course> RegisteredCourses = new List<course>();
    }

    public class userDatabase
    {
        // Class constructor
        public userDatabase()
        {
            StudentsList = new List<student>();
            FacultyList = new List<faculty>();
            AdminList = new List<admin>();
        }
        public List<student> getStudentList()
        {
            return StudentsList;
        }

        public List<faculty> getFacultyList()
        {
            return FacultyList;
        }

        public void readInData(string filepath)
        {
            string line;
            System.IO.StreamReader input = new System.IO.StreamReader(filepath);
            while ((line = input.ReadLine()) != null)
            {
                string username = line.Substring(0, 10).Trim();
                string password = line.Substring(11, 10).Trim();
                string firstName = line.Substring(22, 15).Trim();
                string middleName = line.Substring(38, 15).Trim();
                string lastName = line.Substring(54, 15).Trim();
                string status = line.Substring(70).Trim();

                if (status == "faculty")
                {
                    faculty fac = new faculty(firstName, middleName, lastName, username, password);
                    FacultyList.Add(fac);
                }
                else if (status == "admin")
                {
                    admin adm = new admin(firstName, middleName, lastName, username, password);
                    AdminList.Add(adm);
                }
                else
                {
                    student std = new student(firstName, middleName, lastName, status, username, password);
                    StudentsList.Add(std);
                }
            }
        }

        public bool isValidUser(string username, string password, string usertype)
        {
            switch (usertype)
            {
                case "student":
                    foreach (student stu in StudentsList)
                    {
                        if (stu.username == username && stu.password == password)
                            return true;
                    }
                    break;
                case "faculty":
                    foreach (faculty fac in FacultyList)
                    {
                        if (fac.username == username && fac.password == password)
                            return true;
                    }
                    break;
                case "admin":
                    foreach (admin adm in AdminList)
                    {
                        if (adm.username == username && adm.password == password)
                            return true;
                    }
                    break;
            }
            return false;
        }

        private List<student> StudentsList;
        private List<faculty> FacultyList;
        private List<admin> AdminList;
    }




    public class courseDatabase
    {
        public courseDatabase()
        {
            CourseLst = new List<course>();
        }

        public void readInCourse(string filepath)
        {
            string line;
            System.IO.StreamReader input = new System.IO.StreamReader(filepath);
            while ((line = input.ReadLine()) != null)
            {
                List<string> user = new List<string>();
                string name = line.Substring(0, 10).Trim();
                string title = line.Substring(11, 15).Trim();
                string instructor = line.Substring(27, 10).Trim();
                string credit = line.Substring(38, 4).Trim();
                string seats = line.Substring(43, 3).Trim();
                string time_blocks = line.Substring(47, 1).Trim();
                int num_time_blocks = int.Parse(time_blocks);
                int index = 49;
                List<string> BlockLst = new List<string>();
                for (int i = 1; i < num_time_blocks; i++)
                {
                    index += 6;
                    string current_time_block = line.Substring(index, 5);
                    BlockLst.Add(current_time_block);
                }
                course currentCourse = new course(name, title, instructor, credit, seats, num_time_blocks, BlockLst);
                CourseLst.Add(currentCourse);
            }
        }

        public List<course> GetCourses()
        {
            return CourseLst;
        }

        private List<course> CourseLst;
    }
    public class course
    {
        private string name;
        private string title;
        private string instructor;
        private string credit;
        private string seats;
        private int num_time;
        private List<string> time_blocks;

        public course(string nme, string ttl, string ist, string crdt, string sea, int num_time_b, List<string> time_bs)
        {
            name = nme;
            title = ttl;
            instructor = ist;
            credit = crdt;
            seats = sea;
            num_time = num_time_b;
            time_blocks = time_bs;
        }

        public string getCode()
        {
            return name;
        }
        public string getName()
        {
            return title;
        }
        public string getInstructor()
        {
            return instructor;
        }
        public string getCredit()
        {
            return credit;
        }
        public string getSeats()
        {
            return seats;
        }

        public string getBlocks()
        {
            string tempString = "";
            foreach (string crsBlock in time_blocks)
            {
                tempString = tempString + Decode(crsBlock) + " | ";
            }
            return tempString;
        }

        public string Decode(string encoded)
        {
            int days = Convert.ToInt32(encoded.Substring(0, 2));
            int time = Convert.ToInt32(encoded.Substring(2, 2));
            int length = Convert.ToInt32(encoded.Substring(4, 1));

            string outputDecoded = DecodeDay(days) + DecodeTime(time, length);
            return outputDecoded;
        }

        public string DecodeDay(int dayEncoded)
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

            return Convert.ToString(timeHour).PadLeft(2, '0') + ":" + Convert.ToString(timeMin).PadLeft(2, '0') + ampm + " to " + Convert.ToString(endTimeHour).PadLeft(2, '0') + ":" + Convert.ToString(endTimeMin).PadLeft(2, '0') + endampm;
        }
    }

    public class PreviousCourse
    {
        public string student;
        public string name;
        public string semester;
        public float credit;
        public string grade;
        public PreviousCourse(string stud, string nme, string semes, float crdt, string grd)
        {
            student = stud;
            name = nme;
            semester = semes;
            credit = crdt;
            grade = grd;
        }
    }
    public class PreviousCourseDB
        {
            public List<PreviousCourse> AllPreviousCourses = new List<PreviousCourse>;
            public PreviousCourseDB(string filepath)
            {
                string line;
                System.IO.StreamReader input = new System.IO.StreamReader(filepath);
                while ((line = input.ReadLine()) != null)
                {
                    string username = line.Substring(0, 10).Trim();
                    string courseNumStr = line.Substring(11, 2).Trim();
                    int courseNum = int.Parse(courseNumStr);
                    int loc = 14;
                    for(int i = 0; i < courseNum; i++)
                    {
                        string courseName = line.Substring(loc, 10);
                        loc += 11;
                        string semester = line.Substring(loc, 3);
                        loc += 4;
                        string creditStr = line.Substring(loc, 4);
                        float credit = float.Parse(creditStr);
                        loc += 4;
                        string grade = line.Substring(loc, 3);
                        loc += 4;
                        PreviousCourse currentCourse = new PreviousCourse(username, courseName, semester, credit, grade);
                        AllPreviousCourses.Add(currentCourse); 
                    }
                }
        }
    }
}


