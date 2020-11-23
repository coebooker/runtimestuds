using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using UF;

namespace CRS
{
    public class userDatabase
    {
        // Class constructor
        public userDatabase(string filepath)
        {
            stdLst = new List<student>();
            facLst = new List<faculty>();
            adminLst = new List<admin>();
            manLst = new List<manager>();

            string line;
            System.IO.StreamReader input = new System.IO.StreamReader(filepath);
            while ((line = input.ReadLine()) != null)
            {
                string username = line.Substring(0, 10).Trim().ToLower();
                string password = line.Substring(11, 10).Trim();
                string firstName = line.Substring(22, 10).Trim();
                string middleName = line.Substring(38, 15).Trim();
                string lastName = line.Substring(54, 15).Trim();
                string status = line.Substring(70).Trim().ToLower();

                if (status == "faculty")
                {
                    faculty fac = new faculty(firstName, middleName, lastName, username, password);
                    facLst.Add(fac);
                }
                else if (status == "admin")
                {
                    admin adm = new admin(firstName, middleName, lastName, username, password);
                    adminLst.Add(adm);
                }
                else if (status == "manager")
                {
                    manager man = new manager(firstName, middleName, lastName, username, password);
                    manLst.Add(man);
                }
                else
                {
                    student std = new student(firstName, middleName, lastName, status, username, password);
                    stdLst.Add(std);
                }
            }

            foreach (student std in stdLst)
                for (int i = 0; i < facLst.Count(); i++)
                    if (std.advisor == facLst[i].username)
                    {
                        facLst[i].addAdvisee(std);
                        break;
                    }
            input.Close();
        }
        public bool isValidUser(string username, string password, ref string usertype)
        {
            foreach (student std in stdLst)
                if (std.username == username && std.password == password)
                {
                    usertype = "student";
                    return true;
                }
            foreach (faculty fac in facLst)
                if (fac.username == username && fac.password == password)
                {
                    usertype = "faculty";
                    return true;
                }
            foreach (admin adm in adminLst)
                if (adm.username == username && adm.password == password)
                {
                    usertype = "admin";
                    return true;
                }
            foreach (manager man in manLst)
            {
                if (man.username == username && man.password == password)
                {
                    usertype = "manager";
                    return true;
                }
            }
            return false;
        }


        public void updateDatabase()
        {
            List<String> UserDBString = new List<String>();
            List<String> histString = new List<String>();
            foreach (student std in stdLst)
            {
                string currentLine = std.username.PadRight(11) + std.password.PadRight(11) + std.fname.PadRight(16) + std.mname.PadRight(16) + std.lname.PadRight(16) + std.advisor.PadRight(10);
                UserDBString.Add(currentLine);
                string username = std.username;
                int numCrs = std.pastCrs.Count + std.currentCrs.Count + std.registeredCrs.Count;
                string hist = username.PadRight(11) + numCrs.ToString().PadRight(3);
                foreach (previousCourse pcrs in std.pastCrs)
                    hist += pcrs.crsID.PadRight(11) + pcrs.semester.PadRight(4) + pcrs.credit.ToString().PadRight(5) + pcrs.grade.PadRight(4);
                foreach (previousCourse pcrs in std.currentCrs)
                    hist += pcrs.crsID.PadRight(11) + "F14 " + pcrs.credit.ToString().PadRight(5) + "N   ";
                foreach (course crs in std.registeredCrs)
                    hist += crs.crsID.PadRight(11) + "S15 " + crs.credit.ToString().PadRight(5) + "N   ";
                histString.Add(hist);
            }
            foreach (faculty currentFaculty in facLst)
            {
                string currentLine = currentFaculty.username.PadRight(11) + currentFaculty.password.PadRight(11) + currentFaculty.fname.PadRight(16) + currentFaculty.mname.PadRight(16) + currentFaculty.lname.PadRight(16) + "faculty".PadRight(10);
                UserDBString.Add(currentLine);
            }
            foreach (admin currentAdmin in adminLst)
            {
                string currentLine = currentAdmin.username.PadRight(11) + currentAdmin.password.PadRight(11) + currentAdmin.fname.PadRight(16) + currentAdmin.mname.PadRight(16) + currentAdmin.lname.PadRight(16) + "admin".PadRight(10);
                UserDBString.Add(currentLine);
            }
            foreach (manager currentManager in manLst)
            {
                string currentLine = currentManager.username.PadRight(11) + currentManager.password.PadRight(11) + currentManager.fname.PadRight(16) + currentManager.mname.PadRight(16) + currentManager.lname.PadRight(16) + "manager".PadRight(10);
                UserDBString.Add(currentLine);
            }
            string[] newUserLinesArr;
            newUserLinesArr = UserDBString.ToArray();
            string[] newHistLinesArr;
            newHistLinesArr = histString.ToArray();
            File.WriteAllLines(@"..\..\userDB.in", newUserLinesArr);
            File.WriteAllLines(@"..\..\historyDB.in", newHistLinesArr);
        }


        // Retrieve information from the user database
        public List<student> getStudentList()
        {
            return stdLst;
        }
        public List<faculty> getFacultyList()
        {
            return facLst;
        }
        public List<admin> getAdminList()
        {
            return adminLst;
        }
        public List<manager> getManagerList()
        {
            return manLst;
        }
        public student getStudent(string username)
        {
            student std = stdLst[0]; // Default value
            foreach (student stu in stdLst)
                if (stu.username.Trim() == username.Trim().ToLower())
                    return stu;
            return std;
        }
        public faculty getFaculty(string username)
        {
            faculty fac = facLst[0]; // Default value
            foreach (faculty f in facLst)
                if (f.username.Trim() == username.ToLower())
                    return f;
            return fac;
        }


        // Change the database
        //----------------------------------------
        public void addCrsToStd(string crsID, string nextSemester, ref courseDatabase crsDB, student currentStudent)
        {
            foreach (course crs in crsDB.getCourseList())
                if (crsID.Trim() == crs.crsID.Trim())
                {
                    course selectedCourse = crs;
                    selectedCourse.enrollUser(currentStudent);
                    course courseAdding = selectedCourse;
                    currentStudent.addClassToNext(courseAdding);
                    return;
                }
        }
        public void addUser(string username, string password, string fname, string mname, string lname, string status, string filepath)
        {
            string fileLine = username.PadRight(11) + password.PadRight(11) + fname.PadRight(16) + mname.PadRight(16) + lname.PadRight(16) + status.PadRight(10);
            if (status == "admin")
            {
                admin newAdm = new admin(fname, mname, lname, username, password);
                adminLst.Add(newAdm);
            }
            else if (status == "faculty")
            {
                faculty newFac = new faculty(fname, mname, lname, username, password);
                facLst.Add(newFac);
            }
            else if (status == "manager")
            {
                manager newMan = new manager(fname, mname, lname, username, password);
                manLst.Add(newMan);
            }
            else
            {
                student newStd = new student(fname, mname, lname, status, username, password);
                stdLst.Add(newStd);
                foreach (faculty fac in facLst)
                    if (newStd.advisor.Trim() == fac.username.Trim())
                        fac.addAdvisee(newStd);
            }
        }
        public void changeAdvisor(string stdName, string facName)
        {
            // Change the student's advisor
            student std = getStudent(stdName);
            string curAdvisor = std.advisor;
            std.setAdvisor(facName);

            // Add the student to the new faulty's advisee list
            faculty fac = getFaculty(facName);
            fac.addAdvisee(std);

            // Remove the student from the previous faculty's advisee list
            fac = getFaculty(curAdvisor);
            fac.removeAdvisee(stdName);
        }
        public void dropCrsFromStd(string courseID, ref courseDatabase courseDB, student currentStudent)
        {
            foreach (course crs in courseDB.getCourseList())
                if (courseID.Trim() == crs.crsID.Trim())
                {
                    currentStudent.dropCrsFromNext(crs);
                    crs.disenrollUser(currentStudent);
                    return;
                }
        }
        public void removeStd(string username, ref courseDatabase crsDB)
        {
            student std = getStudent(username);

            // Increment the number of seats available for each course the student has registered for
            List<course> registeredCrsLst = std.registeredCrs;
            foreach (course registeredCrs in registeredCrsLst)
                foreach (course crs in crsDB.getCourseList())
                    if (registeredCrs.crsID == crs.crsID)
                    {
                        crs.disenrollUser(std);
                        break;
                    }

            // Remove the student from the advisees list of his advisor
            faculty advisor = getFaculty(std.advisor);
            advisor.removeAdvisee(username);

            // Remove the student from the database
            stdLst.Remove(std);
        }
        public void removeFac(string username)
        {
            //Loops through their advisees and changes the students' advisor to "Staff"
            faculty fac = getFaculty(username);
            foreach (student std in fac.adviseesLst)
                std.setAdvisor("Staff");

            // Remove the faculty
            facLst.Remove(fac);
        }
        public void changeInstrutor(courseDatabase crsDB, string newInstructor, string oldInstructor, string crsID)
        {
            foreach (faculty fac in facLst)
            {
                bool newI = false;
                bool oldI = false;
                if (!newI)
                    if (fac.username.Trim() == newInstructor.Trim())
                    {
                        course crs = crsDB.getCourse(crsID);
                        fac.nextSemesterCourses.Add(crs);
                        newI = true;
                    }
                if (!oldI)
                    if (fac.username.Trim() == oldInstructor.Trim())
                    {
                        foreach (course crs in fac.nextSemesterCourses)
                            if (crs.crsID == crsID.Trim())
                            {
                                fac.nextSemesterCourses.Remove(crs);
                                oldI = true;
                                break;
                            }    
                    }
                if (oldI && newI)
                    break;
            }
        }
        public void changeTime(string crsID, string instructor, courseDatabase crsDB)
        {
            foreach (faculty fac in facLst)
                if (fac.username == instructor.Trim())
                    foreach (course crs in fac.nextSemesterCourses)
                        if (crs.crsID.Trim() == crsID.Trim())
                        {
                            course curCrs = crsDB.getCourse(crsID);
                            crs.timeBlocks = curCrs.timeBlocks;

                        }
        }
        
        public void addPrevCourses(ref courseDatabase crsDB, string nextSemester)
        {
            string line;
            System.IO.StreamReader input = new System.IO.StreamReader(@"..\..\historyDB.in");
            while ((line = input.ReadLine()) != null)
            {
                string username = line.Substring(0, 10).Trim().ToLower();   // Needed ToLower()
                string courseNumStr = line.Substring(11, 2).Trim();
                int courseNum = int.Parse(courseNumStr);
                int loc = 14;

                student std = stdLst.Find(s => s.username.Trim() == username);

                for (int i = 0; i < courseNum; i++)
                {
                    string crsID = line.Substring(loc, 10).Trim();
                    loc += 11;
                    string semester = line.Substring(loc, 3).Trim();
                    loc += 4;
                    string creditStr = line.Substring(loc, 4).Trim();
                    float credit = float.Parse(creditStr);
                    loc += 4;
                    string grade;
                    if ((line.Length - loc) >= 3)
                        grade = line.Substring(loc, 3).Trim().ToString();
                    else
                        grade = line.Substring(loc).Trim().ToString();
                    loc += 5;
                    if (semester == nextSemester)
                    {
                        course crs = crsDB.getCourse(crsID);
                        std.addClassToNext(crs);
                        crs.enrollUser(std);
                    }
                    else if (semester == "F14")
                    {
                        previousCourse pcrs = new previousCourse(username, crsID, semester, credit, grade);
                        std.addClassToCurrent(pcrs);
                    }
                    else
                    {
                        previousCourse currentCourse = new previousCourse(username, crsID, semester, credit, grade);
                        std.addClassToPast(currentCourse);
                    }
                }
            }
            input.Close();
            foreach (student std in stdLst)
                std.calculateGPA();
        }
        
        private List<student> stdLst;
        private List<faculty> facLst;
        private List<admin> adminLst;
        public List<manager> manLst { get; private set; }
    }
}
