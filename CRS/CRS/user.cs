using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using UF;

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
        public string advisor;
        public float GPA;
        public float totalCredits;
        public List<course> registeredCrs;
        public List<previousCourse> currentCrs;
        public List<previousCourse> pastCrs;

        // Class constructor
        public student(string fname, string mname, string lname, string advisor, string username, string password)
        {
            this.fname = fname;
            this.mname = mname;
            this.lname = lname;
            this.advisor = advisor;
            this.username = username;
            this.password = password;
            registeredCrs = new List<course>();
            pastCrs = new List<previousCourse>();
            currentCrs = new List<previousCourse>();
        }


        // Making changes to the object //
        public void addClassToPast(previousCourse pcrs)
        {
            // Don't have to branch on "S15" and "F14" because addPrevCourses function already does
            // Sorry!! 

            //TO-DO UPDATE CALCULATE GPA FUNCTION TO BE HERE. ALSO INCREMENT TOTAL CREDITS
            pastCrs.Add(pcrs);
        }
        public void addClassToCurrent(previousCourse pcrs)
        {
            currentCrs.Add(pcrs);
        }
        public void addClassToNext(course courseAdded)
        {
            registeredCrs.Add(courseAdded);
        }
        public void dropCrsFromNext(course courseDeleted)
        {
            registeredCrs.Remove(courseDeleted);
        }
        public void setAdvisor(string advisorStr)
        {
            advisor = advisorStr;
        }


        // Utility functions
        public void updateHistoryFile(string filepath)
        {
            List<string> newLines = new List<string>();

            // Read in all the lines in the file and store them in an array
            string[] lines = File.ReadAllLines(filepath);

            foreach (string user in lines)
            {
                string currentUsername = user.Substring(0, 10);
                if (currentUsername.Trim().ToLower() == username.ToLower())
                {
                    string newLine = "";
                    newLine += currentUsername + ' ';
                    int numCourses = pastCrs.Count() + registeredCrs.Count() + currentCrs.Count();
                    newLine += String.Format("{0,-2}", numCourses.ToString());
                    foreach (previousCourse currentCourse in pastCrs)
                    {
                        newLine += " " + currentCourse.crsID.PadRight(11);
                        newLine += currentCourse.semester + ' ';
                        newLine += currentCourse.credit.ToString().PadRight(5);
                        newLine += currentCourse.grade.PadRight(3);
                    }
                    foreach (course crs in registeredCrs)
                    {
                        newLine += " " + crs.crsID.PadRight(11);
                        newLine += "S15 ";
                        newLine += crs.credit.ToString().PadRight(5);
                        newLine += "N  ";
                    }
                    foreach(previousCourse currentCourse in currentCrs)
                    {
                        newLine += " " + currentCourse.crsID.PadRight(11);
                        newLine += currentCourse.semester + ' ';
                        newLine += currentCourse.credit.ToString().PadRight(5);
                        newLine += currentCourse.grade.PadRight(3);
                    }
                    newLines.Add(newLine);
                }
                else
                    newLines.Add(user);
            }
            string[] lineArr = newLines.ToArray();
            System.IO.File.WriteAllLines(filepath, lineArr);
        }
        public void calculateGPA()
        {
            List<float> GPACredits = new List<float>();
            foreach (previousCourse oldCrs in pastCrs)
            {
                string currentGrade = oldCrs.grade;
                if (currentGrade.Substring(0, 1) == "R")
                {
                    string gradeStr = currentGrade.Substring(1);
                    bool applicableGrade = gradeDict.ContainsKey(gradeStr);
                    if (applicableGrade)
                    {
                        float currentGPA = gradeDict[gradeStr];
                        GPACredits.Add(currentGPA);
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    bool applicableGrade = gradeDict.ContainsKey(currentGrade);
                    if (applicableGrade)
                    {
                        float currentGPA = gradeDict[currentGrade];
                        GPACredits.Add(currentGPA);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            this.GPA = GPACredits.Sum() / GPACredits.Count();
        }
        public validity isValidAdd(course crsBngAdded)
        {
            bool validAdd = true;
            bool warning = false;
            string warningMessage = "";
            double crntSmstCrdt = 0.00;

            List<classTime> timeBlocksAdding = crsBngAdded.getClassTime();

            // Totals current semester credit & checks if course is already taken this semester
            foreach (course currentCourse in registeredCrs)
            {
                crntSmstCrdt += Convert.ToDouble(currentCourse.credit);
                if (crsBngAdded.crsID.Trim().Substring(0, crsBngAdded.crsID.Trim().Length - 3) == currentCourse.crsID.Trim().Substring(0, currentCourse.crsID.Trim().Length - 3))
                {
                    validAdd = false;
                    warningMessage = "You have already enrolled in this course this semester";
                }

                // Test warningMessage = crsBngAdded.crsID.Trim() + currentCourse.crsID.Trim();
                // Test validAdd = false;


                List<classTime> timeBlocksCurrent = currentCourse.getClassTime();

                foreach (classTime eachCurrentBlock in timeBlocksCurrent)
                    foreach (classTime eachAddingBlock in timeBlocksAdding)
                        if (eachCurrentBlock.getDays().Intersect(eachAddingBlock.getDays()).Count() != 0)
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
                                    if (startA <= endB)
                                    {
                                        warning = true;
                                        if (validAdd)
                                            warningMessage = "There is a time overlap";
                                    }


                                // |-----|      A
                                //    |-----|   B
                                if (startB >= startA)
                                    if (startB <= endA)
                                    {
                                        warning = true;
                                        if (validAdd)
                                            warningMessage = "There is a time overlap";
                                    }
                            }
                        }
            }



            // Checks if total credit for current semester is above 5.00
            if (crntSmstCrdt + Convert.ToDouble(crsBngAdded.credit.Trim()) >= 5.00)
            {
                validAdd = false;
                warningMessage = "You can not enroll in more than 5.00 credits worth of courses";
            }

            // Checks if course has been taken previously
            if (validAdd)
                foreach (previousCourse prvCrs in pastCrs)
                    if (prvCrs.crsID.Trim().Substring(0, prvCrs.crsID.Trim().Length - 3) == crsBngAdded.crsID.Trim().Substring(0, crsBngAdded.crsID.Trim().Length - 3))
                    {
                        warning = true;
                        if (validAdd)
                            warningMessage = "You have already taken this course previously";
                    }

            //check number of seats avaialble
            if (crsBngAdded.seats == 0)
            {
                validAdd = false;
                warningMessage = "There are no seats available for the class";
            }

            validity returningVal = new validity(validAdd, warning, warningMessage);
            return returningVal;
        }
        public string timeCheck()
        {
            string message = "There is no time conflict";
            foreach (course courseA in registeredCrs)
            {
                List<classTime> timeBlocksA = courseA.getClassTime();
                foreach (course courseB in registeredCrs)
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
                                                message = "There is a time overlap between " + courseA.crsID + " and " + courseB.crsID + " for next semester";

                                        // |-----|      A
                                        //    |-----|   B
                                        if (startB >= startA)
                                            if (startB <= endA)
                                                message = "There is a time overlap between " + courseA.crsID + " and " + courseB.crsID + " for next semester";
                                    }

                                }
                }
            }
            return message;
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
        public List<course> nextSemesterCourses = new List<course>();
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
        //Returns a list of the courses this faculty is scheduled to teach next semester
        public List<course> getNextSemesterCourses(ref courseDatabase courseDB)
        {
            return nextSemesterCourses;
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
    public class manager : admin
    {
        public manager(string f, string m, string l, string usrname, string psw) : base(f, m, l, usrname, psw)
        {
        }
    }
}
