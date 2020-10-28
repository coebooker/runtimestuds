using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

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
        private float GPA;
        private float totalCredits;
        private float gradedCredits;
        private float gradePoints;

        // Class constructor
        public student(string f, string m, string l, string adv, string usrname, string psw)
        {
            fname = f;
            mname = m;
            lname = l;
            advisor = adv;
            username = usrname;
            password = psw;
            RegisteredCourses = new List<course>();
            CourseHistory = new List<previousCourse>();
        }

        // Extracting info from the object
        public List<previousCourse> getCrsHist()
        {
            return CourseHistory;
        }
        public List<course> getRegisteredCrs()
        {
            return RegisteredCourses;
        }
        public float getGPA()
        {
            return GPA;
        }
        public float getCredits()
        {
            return totalCredits;
        }
        public List<previousCourse> GetCurrentTermList()
        {
            List<previousCourse> CurrentTermList = new List<previousCourse>();
            foreach (previousCourse crs in CourseHistory)
            {
                if(crs.semester == "F14")
                {
                    CurrentTermList.Add(crs);
                }
            }
            return CurrentTermList;
        }
        public string getAdvisor()
        {
            return advisor;
        }
        public string getFName()
        {
            return fname;
        }
        public string getMName()
        {
            return mname;
        }
        public string getLName()
        {
            return lname;
        }

        // Making changes to the object //
        public void addCrsHist(previousCourse pcrs)
        {
            CourseHistory.Add(pcrs);
            totalCredits += pcrs.credit;
            if (pcrs.grade != "S")
            {
                gradedCredits += pcrs.credit;
                gradePoints += gradeDict[pcrs.grade];
                GPA = gradePoints / gradedCredits;
            }
        }

        public void addClassToCurrent(course courseAdded)
        {
            RegisteredCourses.Add(courseAdded);
        }
        public void addClassToHistory(course courseAdded, string currentSemester)
        {
            previousCourse courseAddedHistory = new previousCourse(username, courseAdded.getCode().Trim(), currentSemester, Convert.ToSingle(courseAdded.getCredit().Trim()), "N");
            CourseHistory.Add(courseAddedHistory);
        }
        public void deleteCourseFromCurrent(course courseDeleted)
        {
            RegisteredCourses.Remove(courseDeleted);
        }
        public void deleteClassFromHistory(course courseDeleted, string currentSemester)
        {
            previousCourse courseDeletedHistory = new previousCourse(username, courseDeleted.getCode().Trim(), currentSemester, Convert.ToSingle(courseDeleted.getCredit().Trim()), "N");
            CourseHistory.Remove(courseDeletedHistory);
        }

        public validity isValidAdd(string crntSmst, course crsBngAdded) 
        {
            bool validAdd = true;
            bool warning = false;
            string warningMessage = "";
            double crntSmstCrdt = 0.00;

            List<classTime> timeBlocksAdding = crsBngAdded.getClassTime();

            // Totals current semester credit & checks if course is already taken this semester
            foreach (course currentCourse in RegisteredCourses)
            {
                crntSmstCrdt += Convert.ToDouble(currentCourse.getCredit());
                if (crsBngAdded.getCode().Trim().Substring(0, crsBngAdded.getCode().Trim().Length - 3) == currentCourse.getCode().Trim().Substring(0, currentCourse.getCode().Trim().Length - 3))
                {
                    validAdd = false;
                    warningMessage = "You have already enrolled in this course this semester";
                }

                // Test warningMessage = crsBngAdded.getCode().Trim() + currentCourse.getCode().Trim();
                // Test validAdd = false;


                List<classTime> timeBlocksCurrent = currentCourse.getClassTime();
                


                foreach (classTime eachCurrentBlock in  timeBlocksCurrent)
                {
                    foreach(classTime eachAddingBlock in timeBlocksAdding)
                    {
                        if(eachCurrentBlock.getDays().Intersect(eachAddingBlock.getDays()).Count() != 0)
                        {
                            double startA = eachCurrentBlock.getStartTime();
                            double startB = eachAddingBlock.getStartTime();
                            double endA = eachCurrentBlock.getEndTime();
                            double endB = eachAddingBlock.getEndTime();


                            if (!(startA == endB || startB == endA))
                            {
                                //    |-----|   A
                                // |-----|      B
                                if (startA >= startB)
                                {
                                    if (startA <= endB)
                                    {
                                        warning = true;
                                        if(validAdd)
                                        {
                                            warningMessage = "There is a time overlap";
                                        }
                                    }
                                }


                                // |-----|      A
                                //    |-----|   B
                                if (startB >= startA)
                                {
                                    if (startB <= endA)
                                    {
                                        warning = true;
                                        if (validAdd)
                                        {
                                            warningMessage = "There is a time overlap";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }



            // Checks if total credit for current semester is above 5.00
            if (crntSmstCrdt + Convert.ToDouble(crsBngAdded.getCredit().Trim()) >= 5.00)
            {
                validAdd = false;
                warningMessage = "You can not enroll in more than 5.00 credits worth of courses";
            }

            // Checks if course has been taken previously
            if (validAdd)
            {
                
                foreach (previousCourse prvCrs in CourseHistory)
                {
                    if (prvCrs.name.Trim().Substring(0, prvCrs.name.Trim().Length - 3) == crsBngAdded.getCode().Trim().Substring(0, crsBngAdded.getCode().Trim().Length - 3))
                    {
                        warning = true;
                        if (validAdd)
                        {
                            warningMessage = "You have already taken this course previously";
                        }
                    }
                }
            }
            //check number of seats avaialble
            if (crsBngAdded.getSeats() == 0)
            {
                validAdd = false;
                warningMessage = "There are no seats available for the class";
            }


            validity returningVal = new validity(validAdd, warning, warningMessage);
            return returningVal;
        }

        private List<course> RegisteredCourses;
        private List<previousCourse> CourseHistory;
        public Dictionary<string, float> gradeDict = new Dictionary<string, float>()
        {
            {"A",4.0f},
            {"A-",3.7f},
            {"B+",3.3f},
            {"B",3.0f},
            {"B-",2.7f},
            {"C+",2.3f},
            {"C",2.0f},
            {"C-",1.7f},
            {"D+",1.3f},
            {"D",1.0f},
            {"D-",0.7f},
            {"F",0.0f},
            {"WF",0.0f},
        };
    }

    public class faculty : baseUser
    {
        public faculty(string f, string m, string l, string usrname, string psw)
        {
            courseSchedule = new List<course>();
            adviseesLst = new List<student>();
            fname = f;
            mname = m;
            lname = l;
            username = usrname;
            password = psw;
        }

        public List<student> getAdviseesLst()
        {
            return adviseesLst;
        }
        public List<course> getCourseSchedule()
        {
            return courseSchedule;
        }

        public void addAdvisee(student std)
        {
            adviseesLst.Add(std);
        }
        private List<course> courseSchedule;
        private List<student> adviseesLst;
        
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
        public void deleteCourse(course DeletedCourse, userDatabase userDB, courseDatabase courseDB)
        {
            //Removes the course from registered students
            foreach (student currentStudent in DeletedCourse.getStudents())
            {
                //NEEDS TO UPDATE historyDB.in for users that are deregistered
                currentStudent.deleteCourseFromCurrent(DeletedCourse);
            }
            //Removes the course from the faculty
            faculty CourseFaculty = userDB.getFaculty(DeletedCourse.getInstructor());
            CourseFaculty.getCourseSchedule().Remove(DeletedCourse);
            //Removes the course from the Course Database
            courseDB.getCourseList().Remove(DeletedCourse);
        }
    }

    public class userDatabase
    {
        // Class constructor
        public userDatabase(string filepath)
        {
            StudentsLst = new List<student>();
            FacultyLst = new List<faculty>();
            AdminList = new List<admin>();
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
                    FacultyLst.Add(fac);
                }
                else if (status == "admin")
                {
                    admin adm = new admin(firstName, middleName, lastName, username, password);
                    AdminList.Add(adm);
                }
                else
                {
                    student std = new student(firstName, middleName, lastName, status, username, password);
                    StudentsLst.Add(std);
                }
            }
            foreach (student std in StudentsLst)
            {
                for (int i = 0; i < FacultyLst.Count(); i++)
                {
                    if (std.getAdvisor() == FacultyLst[i].username)
                    {
                        FacultyLst[i].addAdvisee(std);
                        break;
                    }
                }
            }
        }

        public List<student> getStudentList()
        {
            return StudentsLst;
        }
        public List<faculty> getFacultyList()
        {
            return FacultyLst;
        }
        public student getStudent(string username)
        {
            student std = StudentsLst[0]; // Default value
            foreach (student stu in StudentsLst)
                if (stu.username.ToLower() == username)
                    return stu;
            return std;
        }
        public faculty getFaculty(string username)
        {
            faculty fac = FacultyLst[0]; // Default value
            foreach (faculty f in FacultyLst)
                if (f.username.ToLower() == username)
                    return f;
            return fac;
        }


        public void addCourseToStudent(string studentName, string courseID, string currentSemester, ref courseDatabase courseDB, student currentStudent)
        {
            course courseAdding = courseDB.getCourseList()[0];
            foreach(course crs in courseDB.getCourseList())
            {
                if(courseID.Trim() == crs.getCode().Trim())
                {
                    course selectedCourse = crs;
                    selectedCourse.enrollUser(currentStudent);
                    courseAdding = selectedCourse;
                    currentStudent.addClassToCurrent(courseAdding);
                    currentStudent.addClassToHistory(courseAdding, currentSemester);
                }
            }
        }
        public void deleteCourseFromStudent(string studentName, string courseID, string currentSemester, ref courseDatabase courseDB,student currentStudent)
        {
            course courseDeleting = courseDB.getCourseList()[0];
            foreach(course crs in courseDB.getCourseList())
            {
                if (courseID.Trim() == crs.getCode().Trim())
                {
                    course selectedCourse = crs;
                    selectedCourse.disenrollUser(currentStudent);
                    courseDeleting = selectedCourse;
                    currentStudent.deleteCourseFromCurrent(courseDeleting);
                    currentStudent.deleteClassFromHistory(courseDeleting, currentSemester);
                }
            }
        }
        public bool isValidUser(string username, string password, ref string usertype)
        {
            foreach (student std in StudentsLst)
                if (std.username.ToLower() == username && std.password.ToLower() == password)
                {
                    usertype = "student";
                    return true;
                }
            foreach (faculty fac in FacultyLst)
                if (fac.username.ToLower() == username && fac.password.ToLower() == password)
                {
                    usertype = "faculty";
                    return true;
                }
            foreach (admin adm in AdminList)
                if (adm.username.ToLower() == username && adm.password.ToLower() == password)
                {
                    usertype = "admin";
                    return true;
                }
            return false;
        }
        public void addPrevCourses(string filepath)
        {
            string line;
            System.IO.StreamReader input = new System.IO.StreamReader(filepath);
            while ((line = input.ReadLine()) != null)
            {
                string username = line.Substring(0, 10).Trim().ToLower();
                string courseNumStr = line.Substring(11, 2).Trim();
                int courseNum = int.Parse(courseNumStr);
                int loc = 14;

                student std = StudentsLst.Find(s => s.username.ToLower() == username);
                int std_index = StudentsLst.IndexOf(std);

                for (int i = 0; i < courseNum - 1; i++)
                {
                    string courseName = line.Substring(loc, 10);
                    loc += 11;
                    string semester = line.Substring(loc, 3);
                    loc += 4;
                    string creditStr = line.Substring(loc, 4);
                    float credit = float.Parse(creditStr);
                    loc += 4;
                    string grade = line.Substring(loc, 3).Trim().ToString();
                    loc += 5;
                    previousCourse currentCourse = new previousCourse(username, courseName, semester, credit, grade);
                    std.addCrsHist(currentCourse);
                    StudentsLst[std_index] = std;
                }
            }
        }

        private List<student> StudentsLst;
        private List<faculty> FacultyLst;
        private List<admin> AdminList;
    }

    public class courseDatabase
    {
        public courseDatabase(string filepath)
        {
            this.crsLst = new List<course>();
            string line;
            System.IO.StreamReader input = new System.IO.StreamReader(filepath);
            while ((line = input.ReadLine()) != null)
            {
                string code = line.Substring(0, 10).Trim();
                string title = line.Substring(11, 15).Trim();
                string instructor = line.Substring(27, 10).Trim();
                string credit = line.Substring(38, 4).Trim();
                int seats = Convert.ToInt32(line.Substring(43, 3).Trim());
                int num_time_blocks = int.Parse(line.Substring(47, 1).Trim());
                int index = 49;
                List<string> BlockLst = new List<string>();
                for (int i = 0; i < num_time_blocks; i++)
                {
                    string time_block = line.Substring(index, 5);
                    BlockLst.Add(time_block);
                    index += 6;
                }
                course crs = new course(code, title, instructor, credit, seats, num_time_blocks, BlockLst);
                crsLst.Add(crs);
            }
   
        }

        public List<course> getFacultyCourseLst(string username)
        {
            List<course> crsLst = new List<course>();
            foreach (course crs in this.crsLst)
                if (crs.getInstructor().ToLower() == username)
                    crsLst.Add(crs);
            return crsLst;
        }
        public List<course> getCourseList()
        {
            return crsLst;
        }
        public course getCourse(string courseID)
        {
            course crs = crsLst[0]; // Default value
            foreach (course courses in crsLst)
            {
                if (courses.getCode() == courseID)
                {
                    return courses;
                }
            }
            return crs;
        }

        private List<course> crsLst;
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
        public course(string nme, string ttl, string ist, string crdt, int sea, int num_time_b, List<string> time_bs)
        {
            code = nme;
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

                double startTime = Convert.ToDouble(timeBlock.Substring(2, 2))/2;
                double endTime = startTime + Convert.ToDouble(timeBlock.Substring(4, 1))*0.5;

                classTime timeOfBlock = new classTime(days, startTime, endTime);
                time_blocks_alternative.Add(timeOfBlock);
            }
        }

        public List<classTime> getClassTime()
        {
            return time_blocks_alternative;
        }
        public string getCode()
        {
            return code;
        }
        public string getTitle()
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
        public int getSeats()
        {
            return seats;
        }
        public int getMaxSeats()
        {
            return maxSeats;
        }
        public string getBlocks()
        {
            string tempString = "";
            foreach (string crsBlock in timeBlocks)
                tempString = tempString + Decode(crsBlock) + Environment.NewLine;
            tempString = tempString.Trim();
            return tempString;
        }
        public List<student> getStudents()
        {
            return enrolledStudents;
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
            string outputDecoded = DecodeDay(days) + " : "+ DecodeTime(time, length);
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

        private string code;
        private string title;
        private string instructor;
        private string credit;
        private int seats;
        private int maxSeats;
        private int num_time;
        private List<string> timeBlocks;
        private List<classTime> time_blocks_alternative;
        private List<student> enrolledStudents = new List<student>();
    }
    public class previousCourse
    {
        public string student;
        public string name;
        public string semester;
        public float credit;
        public string grade;
        public previousCourse(string stud, string nme, string semes, float crdt, string grd)
        {
            student = stud;
            name = nme;
            semester = semes;
            credit = crdt;
            grade = grd;
        }
    }
}

