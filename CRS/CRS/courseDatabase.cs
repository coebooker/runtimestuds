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

        // Class constructor
        public courseDatabase(string filepath, ref ComboBox cb, ref TextBox tb, ref userDatabase userDB)
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
                faculty courseFac = userDB.getFaculty(instructor.Trim());
                courseFac.nextSemesterCourses.Add(crs);
                index = code.IndexOf('-');
                if (!cb.Items.Contains(code.Substring(0, index)))
                {
                    cb.Items.Add(code.Substring(0, index));
                    cb.AutoCompleteCustomSource.Add(code.Substring(0, index));
                }
                if (!tb.AutoCompleteCustomSource.Contains(title))
                    tb.AutoCompleteCustomSource.Add(title);
            }

        }


        // Gets the faculty's next semester coures
        public List<course> getNextFacCrsLst(string username)
        {
            List<course> crsLst = new List<course>();
            foreach (course crs in this.crsLst)
                if (crs.instructor.ToLower() == username)
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
                if (courses.crsID == courseID)
                {
                    return courses;
                }
            }
            return crs;
        }


        // Change the database
        public void removeCrs(string crsID, string nextSemester, string filepath)
        {
            // Remove the course from the list
            course removedCrs = getCourse(crsID);
            crsLst.Remove(removedCrs);

            // Remove the course from students' schedule
            List<student> enrolledStdLst = removedCrs.getStudents();
            foreach (student std in enrolledStdLst)
            {
                std.dropCrsFromNext(removedCrs);
            }

            //Updates the coursedb.in file to remove the removed course from it
            string[] courseLines = File.ReadAllLines(filepath);
            string[] newCourseLinesArr;
            List<string> newCourseLines = new List<string>();
            foreach (string courseString in courseLines)
            {
                string courseID = courseString.Substring(4, 10);
                if (courseID == removedCrs.crsID)
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
        public void changeCourse(string newInstructor, string courseID, List<string> newTimeBlocks, course changedCourse, string filepath)
        {
            changedCourse.setInstructor(newInstructor);
            changedCourse.setTimeBlocks(newTimeBlocks);

            //Opens courseDB file to change the course
            string[] CourseLines = File.ReadAllLines(filepath);
            string[] newCourseLinesArr;
            List<string> newCourseLines = new List<string>();
            foreach (string line in CourseLines)
            {
                string currentCourseID = line.Substring(0, 10).Trim();
                if (currentCourseID == courseID)
                {
                    string courseBeforeBlocks = line.Substring(0, 47);
                    string blockNum = newTimeBlocks.Count().ToString() + " ";
                    foreach (string timeBlocks in newTimeBlocks)
                    {
                        blockNum += timeBlocks.PadRight(6);
                    }
                    //Making the blockNum subtring to it's length -1 cuts off the last space that shouldn't be there
                    string newCourseLine = courseBeforeBlocks + blockNum.Substring(0, blockNum.Length - 1);
                    newCourseLines.Add(newCourseLine);
                }
                else
                {
                    newCourseLines.Add(line);
                }
                newCourseLinesArr = newCourseLines.ToArray();
                System.IO.File.WriteAllLines(filepath, newCourseLinesArr);
            }
        }
    }
}
