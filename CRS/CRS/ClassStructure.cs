using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
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
                for (int i = 0; i < FacultyLst.Count(); i++)
                    if (std.getAdvisor() == FacultyLst[i].username)
                    {
                        FacultyLst[i].addAdvisee(std);
                        break;
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
                if (stu.username.ToLower() == username.ToLower())
                    return stu;
            return std;
        }
        public faculty getFaculty(string username)
        {
            faculty fac = FacultyLst[0]; // Default value
            foreach (faculty f in FacultyLst)
                if (f.username.ToLower() == username.ToLower())
                    return f;
            return fac;
        }

        public void removeFaculty(string facultyUsername, string userFilepath, string courseFilepath, ref courseDatabase coursedb)
        {
            //Loops through their advisees and changes the students' advisor to "Staff"
            faculty currectFac = getFaculty(facultyUsername);
            foreach(student currentStudent in currectFac.getAdviseesLst())
            {
                currentStudent.setAdvisor("Staff");
            }
            //Loops through their courses and the instructor to "Staff", also needs to update the file
            List<course> courseLst = coursedb.getNextFacCrsLst(facultyUsername);
            foreach(course currentCourse in courseLst)
            {
                currentCourse.setInstructor("Staff");
            }
            //Updates the UserDB.in file to remove the faculty member from it
            string[] userLines = File.ReadAllLines(userFilepath);
            string[] newUserLinesArr;
            List<string> newUserLines = new List<string>();
            foreach (string userString in userLines)
            {
                string username = userString.Substring(0, 10);
                if (facultyUsername == username)
                {
                    //skips the iteration if it’s the course that’s being deleted
                    continue;
                }
                else
                {
                    newUserLines.Add(userString);
                }
                newUserLinesArr = newUserLines.ToArray();
                File.WriteAllLines(userFilepath, newUserLinesArr);
            }
            //Changes the all of this instructor's courses in courseDB.in instructor to "Staff"
            string[] CourseLines = File.ReadAllLines(courseFilepath);
            string[] newCourseLinesArr;
            List<string> newCourseLines = new List<string>();
            foreach (string courseString in userLines)
            {
                string username = courseString.Substring(31, 10).Trim();
                if (facultyUsername == username)
                {
                    //if this function doesn't work the first thing to check will be grabbing 31 characters, not sure if it should be 30 or 31 depends on how the compiler handles it
                    string beforeInstructor = courseString.Substring(0, 31);
                    string afterInstructor = courseString.Substring(42);
                    string newCourseString = beforeInstructor + "Staff      " + afterInstructor;
                    newCourseLines.Add(newCourseString);
                }
                else
                {
                    newCourseLines.Add(courseString);
                }
                newCourseLinesArr = newUserLines.ToArray();
                File.WriteAllLines(courseFilepath, newCourseLinesArr);
            }
        }

        // Change the database
        public void addCourseToStudent(string studentName, string courseID, string nextSemester, ref courseDatabase courseDB, student currentStudent)
        {
            int stdIndex = StudentsLst.IndexOf(currentStudent);
            foreach (course crs in courseDB.getCourseList())
                if (courseID.Trim() == crs.getCode().Trim())
                {
                    course selectedCourse = crs;
                    selectedCourse.enrollUser(currentStudent);
                    course courseAdding = selectedCourse;
                    currentStudent.addClassToNext(courseAdding);
                    currentStudent.addClassToHistory(courseAdding, nextSemester);
                    StudentsLst[stdIndex] = currentStudent;
                    return;
                }
        }
        public void deleteCourseFromStudent(string courseID, string nextSemester, ref courseDatabase courseDB, student currentStudent)
        {
            course courseDeleting = courseDB.getCourseList()[0];
            int stdIndex = StudentsLst.IndexOf(currentStudent);
            foreach (course crs in courseDB.getCourseList())
                if (courseID.Trim() == crs.getCode().Trim())
                {
                    course selectedCourse = crs;
                    selectedCourse.disenrollUser(currentStudent);
                    courseDeleting = selectedCourse;
                    currentStudent.deleteCourseFromNext(courseDeleting);
                    currentStudent.deleteClassFromHistory(courseDeleting, nextSemester);
                    StudentsLst[stdIndex] = currentStudent;
                    return;
                }
        }
        public void removeStd(string username, ref courseDatabase crsDB)
        {
            student std = getStudent(username);

            // Increment the number of seats available for each course the student has registered for
            List<course> registeredCrsLst = std.getRegisteredCrs();
            foreach (course registeredCrs in registeredCrsLst)
                foreach (course crs in crsDB.getCourseList())
                    if (registeredCrs.getCode() == crs.getCode())
                    {
                        crs.disenrollUser(std);
                        break;
                    }

            // Remove the student from the advisees list of his advisor
            faculty advisor = getFaculty(std.getAdvisor());
            advisor.removeAdvisee(username);

            // Remove the student from the database
            StudentsLst.Remove(std);
        }
        public void updateStd(int stdIndex, student std)
        {
            StudentsLst[stdIndex] = std;
        }
        public void updateFac(int facIndex, faculty fac)
        {
            FacultyLst[facIndex] = fac;
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
        public void addPrevCourses(string filepath, ref courseDatabase crsDB)
        {
            string line;
            System.IO.StreamReader input = new System.IO.StreamReader(filepath);
            while ((line = input.ReadLine()) != null)
            {
                string username = line.Substring(0, 10).Trim();
                string courseNumStr = line.Substring(11, 2).Trim();
                int courseNum = int.Parse(courseNumStr);
                int loc = 14;

                student std = StudentsLst.Find(s => s.username.ToLower() == username.ToLower());
                int std_index = StudentsLst.IndexOf(std);

                for (int i = 0; i < courseNum; i++)
                {
                    string courseName = line.Substring(loc, 10).Trim();
                    loc += 11;
                    string semester = line.Substring(loc, 3).Trim();
                    loc += 4;
                    string creditStr = line.Substring(loc, 4).Trim();
                    float credit = float.Parse(creditStr);
                    loc += 4;
                    string grade = line.Substring(loc, 3).Trim().ToString();
                    loc += 5;
                    previousCourse currentCourse = new previousCourse(username, courseName, semester, credit, grade);
                    std.createCrsHist(currentCourse, ref crsDB);
                    StudentsLst[std_index] = std;
                }
            }
            input.Close();
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

        // Retrieve information
        public List<course> getNextFacCrsLst(string username)
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

         // Change the database
        public void removeCrs(string crsID, ref userDatabase usrDB, string nextSemester, string filepath)
        {
            course removedCrs = getCourse(crsID);
            crsLst.Remove(removedCrs);
            List<student> enrolledStdLst = removedCrs.getStudents();
            List<student> stdLst = usrDB.getStudentList();
            foreach (student std in enrolledStdLst)
            {
                int stdIndex = stdLst.IndexOf(std);
                std.deleteClassFromHistory(removedCrs, nextSemester);
                std.deleteCourseFromNext(removedCrs);
                usrDB.updateStd(stdIndex, std);
            }

            faculty fac = usrDB.getFaculty(removedCrs.getInstructor());
            int facIndex = usrDB.getFacultyList().IndexOf(fac);
            fac.removeCrsFromSch(removedCrs);
            usrDB.updateFac(facIndex, fac);
            
            //Updates the coursedb.in file to remove the removed course from it
            string[] courseLines = File.ReadAllLines(filepath);
            string[] newCourseLinesArr;
            List<string> newCourseLines = new List<string>();
            foreach(string courseString in courseLines)
            {
                string courseID = courseString.Substring(4, 10);
                if (courseID == removedCrs.getCode())
                {
                    //skips the iteration if it’s the course that’s being deleted
                    continue;
                }
                else
                {
                    newCourseLines.Add(courseString);
                }
                newCourseLinesArr = newCourseLines.ToArray();
                File.WriteAllLines(filepath, newCourseLinesArr);
            }
        }

        //public void updateCrs(int crsIndex, course crs)
        private List<course> crsLst;
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
        private List<course> RegisteredCourses;
        private List<previousCourse> CourseHistory;

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

        // Extracting info from the object //
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
        
        public void setAdvisor(string advisorStr)
        {
            advisor = advisorStr;
        }
        public void updateCourseFiles(string filepath)
        {
            List<string> newLines = new List<string>();
            string[] lines = File.ReadAllLines(filepath);
            foreach(string user in lines)
            {
                string currentUsername = user.Substring(0, 10);
                if (currentUsername.Trim() == username){
                    string newLine = "";
                    newLine += currentUsername + ' ';
                    int numCourses = CourseHistory.Count();
                    newLine += numCourses.ToString() + "  ";
                    foreach(previousCourse currentCourse in CourseHistory)
                    {
                        newLine += currentCourse.coursename.PadRight(11);
                        newLine += currentCourse.semester + ' ';
                        newLine += currentCourse.credit.ToString().PadRight(5);
                        newLine += currentCourse.grade.PadRight(4);
                    }
                    newLines.Add(newLine);
                }
                else
                {
                    newLines.Add(user);
                }
            }
            string[] lineArr = newLines.ToArray();
            System.IO.File.WriteAllLines(filepath, lineArr);
        }
        public List<previousCourse> GetCurrentTermList()
        {
            List<previousCourse> CurrentTermList = new List<previousCourse>();
            foreach (previousCourse crs in CourseHistory)
                if(crs.semester.Trim() == "F14")
                    CurrentTermList.Add(crs);
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
        public string getUName()
        {
            return username;
        }


        // Making changes to the object //
        public void createCrsHist(previousCourse pcrs, ref courseDatabase crsDB)
        {
            CourseHistory.Add(pcrs);
            if (pcrs.semester == "S15")
                foreach (course crs in crsDB.getCourseList())
                    if (pcrs.coursename == crs.getCode())
                    {
                        RegisteredCourses.Add(crs);
                        crs.enrollUser(this);
                    }
        }
        public void addClassToNext(course courseAdded)
        {
            RegisteredCourses.Add(courseAdded);
        }
        public void addClassToHistory(course courseAdded, string currentSemester)
        {
            previousCourse courseAddedHistory = new previousCourse(username, courseAdded.getCode().Trim(), currentSemester, Convert.ToSingle(courseAdded.getCredit().Trim()), "N");
            CourseHistory.Add(courseAddedHistory);
        }
        public void deleteCourseFromNext(course courseDeleted)
        {
            RegisteredCourses.Remove(courseDeleted);
        }
        public void deleteClassFromHistory(course courseDeleted, string nextSemester)
        {
            previousCourse c = new previousCourse(
                username.Trim(), 
                courseDeleted.getCode().Trim(), 
                nextSemester, 
                float.Parse(courseDeleted.getCredit().Trim()), 
                "N");
            foreach (previousCourse crs in CourseHistory)
                if (crs.username == c.username && crs.semester == c.semester &&
                    crs.credit == c.credit && crs.coursename == c.coursename
                    && crs.grade == c.grade)
                {
                    CourseHistory.Remove(crs);
                    return;
                }
        }

        public string timeCheck()
        {
            string message = "There is no time conflict";
            foreach (course courseA in RegisteredCourses)
            {
                List<classTime> timeBlocksA = courseA.getClassTime();
                foreach (course courseB in RegisteredCourses)
                {
                    List<classTime> timeBlocksB = courseB.getClassTime();
                    if (courseA != courseB)
                        foreach (classTime timeA in timeBlocksA)
                            foreach (classTime timeB in timeBlocksB)
                                if (timeA.getDays().Intersect(timeB.getDays()).Count() != 0)
                                {
                                    double startA = timeA.getStartTime();
                                    double startB = timeB.getStartTime();
                                    double endA = timeA.getEndTime();
                                    double endB = timeB.getEndTime();
                                    
                                    if (!(startA == endB || startB == endA))
                                    {
                                        //    |-----|   A
                                        // |-----|      B
                                        if (startA >= startB)
                                            if (startA <= endB)
                                                message = "There is a time overlap between " + courseA.getCode() + " and " + courseB.getCode()+" for next semester";
                                        
                                        // |-----|      A
                                        //    |-----|   B
                                        if (startB >= startA)
                                            if (startB <= endA)
                                                message = "There is a time overlap between " + courseA.getCode() + " and " + courseB.getCode()+ " for next semester";
                                    }

                                }
                }
            }
            return message;
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
                    if (prvCrs.coursename.Trim().Substring(0, prvCrs.coursename.Trim().Length - 3) == crsBngAdded.getCode().Trim().Substring(0, crsBngAdded.getCode().Trim().Length - 3))
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
            {"D-",0.7f}
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

        public void addAdvisee(student std)
        {
            adviseesLst.Add(std);
        }
        public void removeAdvisee(string username)
        {
            foreach (student advisee in adviseesLst)
                if (username.ToLower().Trim() == advisee.username.ToLower().Trim())
                {
                    adviseesLst.Remove(advisee);
                    return;
                }
        }
        public void removeCrsFromSch(course removedCrs)
        {
            courseSchedule.Remove(removedCrs);
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
        private List<course> CourseSchedule = new List<course>();
        private List<course> RegisteredCourses = new List<course>();
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
        public void setInstructor(string instructorUsername)
        {
            instructor = instructorUsername;
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
    }
    public class previousCourse
    {
        public string username;
        public string coursename;
        public string semester;
        public float credit;
        public string grade;
        public previousCourse(string stud, string nme, string semes, float crdt, string grd)
        {
            username = stud;
            coursename = nme;
            semester = semes;
            credit = crdt;
            grade = grd;
        }
    }
}

