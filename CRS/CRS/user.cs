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
        public float GPA = 0;
        public float totalCredits = 0;
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
            advisor = advisorStr.Trim();
        }


        // Utility functions
        public void calculateGPA()
        {
            List<previousCourse> creditCrsLst = new List<previousCourse>();
            float gradedCredits = 0;
            float gradePoint = 0;
            foreach (previousCourse oldCrs in pastCrs)
            {
                string grade = oldCrs.grade.Trim();
                // No credit 
                if (grade == "F" || grade.StartsWith("W") || grade == "U" || grade == "X" ||
                    grade == "O" || grade == "I")
                {
                    continue;
                }
                // Bears credits
                else
                {
                    if (grade == "S" || grade == "EQ")
                        totalCredits += oldCrs.credit;
                    else
                    {
                        if (creditCrsLst.Count != 0)
                        {
                            bool found = false;
                            foreach (previousCourse pcrs in creditCrsLst)
                            {
                                if (pcrs.crsID.Trim() == oldCrs.crsID.Trim())
                                {
                                    if (oldCrs.grade.StartsWith("R"))
                                    {
                                        creditCrsLst.Remove(pcrs);
                                        creditCrsLst.Add(oldCrs);
                                        found = true;
                                        break;
                                    }
                                    else
                                        found = true;
                                }
                            }
                            if (!found)
                                creditCrsLst.Add(oldCrs);
                        }
                        else
                            creditCrsLst.Add(oldCrs);
                    }
                }
            }
            foreach (previousCourse pcrs in creditCrsLst)
            {
                totalCredits += pcrs.credit;
                gradedCredits += pcrs.credit;
                if (pcrs.grade.StartsWith("R"))
                    gradePoint += gradeDict[pcrs.grade.Substring(1)] * pcrs.credit;
                else
                    gradePoint += gradeDict[pcrs.grade] * pcrs.credit;
            }
            float f = gradePoint / gradedCredits;
            float fc = (float)Math.Round(f * 100f) / 100f;
            GPA = fc;
        }
        public validity isValidAdd(course crsBngAdded)
        {
            bool validAdd = true;
            bool warning = false;
            string warningMessage = "";
            double nextSmstCrd = 0.00;

            List<classTime> timeBlocksAdding = crsBngAdded.getClassTime();

            // Totals current semester credit & checks if course is already taken this semester
            foreach (course crs in registeredCrs)
            {
                nextSmstCrd += Convert.ToDouble(crs.credit);
                if (crsBngAdded.crsID.Trim().Substring(0, crsBngAdded.crsID.Trim().Length - 3) == crs.crsID.Trim().Substring(0, crs.crsID.Trim().Length - 3))
                {
                    validAdd = false;
                    warningMessage = "You have already enrolled in this course this semester";
                }


                List<classTime> timeBlocksCurrent = crs.getClassTime();

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
                                if (startA >= startB)
                                    if (startA <= endB)
                                    {
                                        warning = true;
                                        if (validAdd)
                                            warningMessage = "There is a time overlap";
                                    }
                                
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



            // Checks if total credit for next semester is above 5.00
            if (nextSmstCrd + Convert.ToDouble(crsBngAdded.credit.Trim()) >= 5.00)
            {
                validAdd = false;
                warningMessage = "You can not enroll in more than 5.00 credits worth of courses";
            }

            // Checks if course has been taken previously
            if (validAdd)
            {
                bool found = false;
                foreach (previousCourse prvCrs in pastCrs)
                    if (prvCrs.crsID.Trim().Substring(0, prvCrs.crsID.Trim().Length - 3) == crsBngAdded.crsID.Trim().Substring(0, crsBngAdded.crsID.Trim().Length - 3))
                    {
                        warning = true;
                        found = true;
                        if (validAdd)
                            warningMessage = "You have already taken this course previously";
                    }
                if (!found)
                    foreach (previousCourse pcrs in currentCrs)
                        if (pcrs.crsID.Trim().Substring(0, pcrs.crsID.Trim().Length - 3) == crsBngAdded.crsID.Trim().Substring(0, crsBngAdded.crsID.Trim().Length - 3))
                        {
                            warning = true;
                            if (validAdd)
                                warningMessage = "You are taking this course this semester.";
                        }
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
        public List<student> adviseesLst = new List<student>();
        public faculty(string f, string m, string l, string usrname, string psw)
        {
            fname = f;
            mname = m;
            lname = l;
            username = usrname;
            password = psw;
        }

        public void addAdvisee(student std)
        {
            adviseesLst.Add(std);
        }
        public void removeAdvisee(string username)
        {
            foreach (student advisee in adviseesLst)
                if (username.Trim().ToLower() == advisee.username.Trim())
                {
                    adviseesLst.Remove(advisee);
                    return;
                }
        }
        public void removeCrsFromNext(course crs)
        {
            nextSemesterCourses.Remove(crs);
        }
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
    }
    public class manager : admin
    {
        public manager(string f, string m, string l, string usrname, string psw) : base(f, m, l, usrname, psw)
        {
        }
    }
}
