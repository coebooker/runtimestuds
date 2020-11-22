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
                string username = line.Substring(0, 10).Trim();
                string password = line.Substring(11, 10).Trim();
                string firstName = line.Substring(22, 10).Trim();
                string middleName = line.Substring(38, 15).Trim();
                string lastName = line.Substring(54, 15).Trim();
                int index = line.LastIndexOf(" ");
                string status = line.Substring(70, 10).Trim();

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


        // Retrieve information from the user database
        public List<student> getStudentList()
        {
            return stdLst;
        }
        public List<faculty> getFacultyList()
        {
            return facLst;
        }
        public student getStudent(string username)
        {
            student std = stdLst[0]; // Default value
            foreach (student stu in stdLst)
                if (stu.username.ToLower() == username.ToLower())
                    return stu;
            return std;
        }
        public faculty getFaculty(string username)
        {
            faculty fac = facLst[0]; // Default value
            foreach (faculty f in facLst)
                if (f.username.ToLower() == username.ToLower())
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
        public void removeStd(string username, ref courseDatabase crsDB, string filepath)
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

            ////Updates the UserDB.in file to remove the student from it
            //string[] userLines = File.ReadAllLines(filepath);
            //string[] newUserLinesArr;
            //List<string> newUserLines = new List<string>();
            //foreach (string userString in userLines)
            //{
            //    string currentUsername = userString.Substring(0, 10);
            //    if (currentUsername == username)
            //    {
            //        //skips the iteration if it’s the course that’s being deleted
            //        continue;
            //    }
            //    else
            //    {
            //        newUserLines.Add(userString);
            //    }
            //    newUserLinesArr = newUserLines.ToArray();
            //    File.WriteAllLines(filepath, newUserLinesArr);
            //}
        }
        public void removeFac(string facultyUsername, string userFilepath, string courseFilepath, ref courseDatabase coursedb)
        {
            //Loops through their advisees and changes the students' advisor to "Staff"
            faculty currectFac = getFaculty(facultyUsername);
            foreach (student currentStudent in currectFac.adviseesLst)
                currentStudent.setAdvisor("Staff");

            //Loops through their courses and the instructor to "Staff", also needs to update the file
            List<course> courseLst = coursedb.getNextFacCrsLst(facultyUsername);
            foreach (course currentCourse in courseLst)
                currentCourse.setInstructor("Staff");

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
                    newUserLines.Add(userString);

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
        public bool isValidUser(string username, string password, ref string usertype)
        {
            foreach (student std in stdLst)
                if (std.username.ToLower() == username && std.password == password)
                {
                    usertype = "student";
                    return true;
                }
            foreach (faculty fac in facLst)
                if (fac.username.ToLower() == username && fac.password == password)
                {
                    usertype = "faculty";
                    return true;
                }
            foreach (admin adm in adminLst)
                if (adm.username.ToLower() == username && adm.password == password)
                {
                    usertype = "admin";
                    return true;
                }
            foreach(manager man in manLst)
            {
                if (man.username.ToLower() == username && man.password == password)
                {
                    usertype = "manager";
                    return true;
                }
            }
            return false;
        }
        public void addPrevCourses(string filepath, ref courseDatabase crsDB, string nextSemester)
        {
            string line;
            System.IO.StreamReader input = new System.IO.StreamReader(filepath);
            while ((line = input.ReadLine()) != null)
            {
                string username = line.Substring(0, 10).Trim();
                string courseNumStr = line.Substring(11, 2).Trim();
                int courseNum = int.Parse(courseNumStr);
                int loc = 14;

                student std = stdLst.Find(s => s.username.ToLower() == username.ToLower());

                for (int i = 0; i < courseNum; i++)
                {
                    string crsID = line.Substring(loc, 10).Trim();
                    loc += 11;
                    string semester = line.Substring(loc, 3).Trim();
                    loc += 4;
                    string creditStr = line.Substring(loc, 4).Trim();
                    float credit = float.Parse(creditStr);
                    loc += 4;
                    string grade = line.Substring(loc, 3).Trim().ToString();
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
        }
        
        private List<student> stdLst;
        private List<faculty> facLst;
        private List<admin> adminLst;
        public List<manager> manLst { get; private set; }
    }
}
