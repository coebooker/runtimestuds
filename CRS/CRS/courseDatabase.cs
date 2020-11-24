using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using UF;

namespace CRS
{
    public class courseDatabase
    {
        private List<course> crsLst;

        // Construct the database and update it
        public courseDatabase(ref userDatabase userDB)
        {
            this.crsLst = new List<course>();
            string line;
            System.IO.StreamReader input = new System.IO.StreamReader(@"..\..\courseDB.in");
            while ((line = input.ReadLine()) != null)
            {
                string code = line.Substring(0, 10).Trim();
                string title = line.Substring(11, 15).Trim();
                string instructor = line.Substring(27, 10).Trim().ToLower();
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
                faculty courseFac = userDB.getFaculty(instructor.Trim());
                courseFac.nextSemesterCourses.Add(crs);
            }
            input.Close();
        }
        public void getPreReqs(string filepath)
        {
            string[] preReqLines = File.ReadAllLines(filepath);
            foreach (string preReqString in preReqLines)
            {
                List<string> preReqList = new List<string>();
                string currentCourseStr = preReqString.Substring(0, 7).Trim();
                List<course> courseList = new List<course>();
                foreach (course crs in crsLst)
                    if (currentCourseStr == crs.crsID.Substring(0, currentCourseStr.Length))
                    {
                        courseList.Add(crs);
                    } 
                //Converts string to int
                int numPreReqsStr = Int32.Parse(preReqString.Substring(8, 1));
                int index = 10;
                for (int i = 0; i < numPreReqsStr; i++)
                {
                    string courseCode;
                    if (index + 7 > preReqString.Length)
                        courseCode = preReqString.Substring(index).Trim();
                    else
                        courseCode = preReqString.Substring(index, 7).Trim();
                    preReqList.Add(courseCode);
                    index += 8;
                }
                foreach (course crs in courseList)
                    crs.preReqLst = preReqList;
            }
        }
        public void updateDatabase()
        {
            List<string> CourseDBString = new List<string>();
            foreach (course currentCourse in crsLst)
            {
                string currentLine = currentCourse.crsID.PadRight(11) + currentCourse.title.PadRight(16) + currentCourse.instructor.PadRight(11) + currentCourse.credit.PadRight(5) + currentCourse.maxSeats.ToString().PadRight(4);
                int courseBlocks = currentCourse.timeBlocks.Count();
                currentLine += courseBlocks.ToString().PadRight(2);
                foreach (string timeblock in currentCourse.timeBlocks)
                {
                    currentLine += timeblock.PadRight(6);
                }
                CourseDBString.Add(currentLine);
            }
            string[] newCourseLinesArr;
            newCourseLinesArr = CourseDBString.ToArray();
            File.WriteAllLines(@"..\..\courseDB.in", newCourseLinesArr);
        }


        // Gets the faculty's next semester coures
        public List<course> getCourseList()
        {
            return crsLst;
        }
        public course getCourse(string courseID)
        {
            course crs = crsLst[0]; // Default value
            foreach (course courses in crsLst)
            {
                if (courses.crsID == courseID)
                {
                    return courses;
                }
            }
            return crs;
        }


        // Change the database
        public void removeCrs(string crsID, string filepath, ref userDatabase usrDB)
        {
            // Remove the course from the offering
            course removedCrs = getCourse(crsID);
            crsLst.Remove(removedCrs);

            // Remove the course from students' schedule
            List<student> enrolledStdLst = removedCrs.getStudents();
            foreach (student std in enrolledStdLst)
                std.dropCrsFromNext(removedCrs);

            // Remove the course from faculties' schedule
            faculty fac = usrDB.getFaculty(removedCrs.instructor);
            fac.removeCrsFromNext(removedCrs);

            ////Updates the coursedb.in file to remove the removed course from it
            //string[] courseLines = File.ReadAllLines(filepath);
            //string[] newCourseLinesArr;
            //List<string> newCourseLines = new List<string>();
            //foreach (string courseString in courseLines)
            //{
            //    string courseID = courseString.Substring(0, 10).Trim();
            //    //string courseID = courseString.Substring(4, 10);
            //    if (courseID == removedCrs.crsID.Trim())
            //        continue;   // Skip the iteration if the course is being deleted
            //    else
            //        newCourseLines.Add(courseString);

            //    newCourseLinesArr = newCourseLines.ToArray();
            //    File.WriteAllLines(filepath, newCourseLinesArr);
            //}
        }
        public void removeFac(string username)
        {
            username = username.Trim().ToLower();
            foreach (course crs in crsLst)
                if (crs.instructor.Trim() == username)
                    crs.instructor = "Staff";
        }
        public void addCrs(course crs, string filepath)
        {
            crsLst.Add(crs);
        }
        public void changeCourse(string crsID, string newInstructor, List<string> timeBlocks)
        {
            course tempCrs = getCourse(crsID);
            tempCrs.instructor = newInstructor;
            tempCrs.timeBlocks = timeBlocks;
            tempCrs.num_time = timeBlocks.Count;
            tempCrs.time_blocks_alternative.Clear();

            foreach (string timeBlock in tempCrs.timeBlocks)
            {
                List<char> days = new List<char>();
                days.AddRange(course.DecodeDay(Convert.ToInt32(timeBlock.Substring(0, 2))));

                double startTime = Convert.ToDouble(timeBlock.Substring(2, 2)) / 2;
                double endTime = startTime + Convert.ToDouble(timeBlock.Substring(4, 1)) * 0.5;

                classTime timeOfBlock = new classTime(days, startTime, endTime);
                tempCrs.time_blocks_alternative.Add(timeOfBlock);
            }
        }
    }
}
