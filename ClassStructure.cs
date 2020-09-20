using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace class
{
    class userDatabase
    {
        List<student> StudentsLst = new List<student>();
        List<faculty> FacultyLst = new List<faculty>();
        List<admin> AdminLst = new List<admin>();
    }
    class courseDatabase
    {
        List<course> CourseLst = new List<course>();
    }
    class course
    {
        private string instructor;
        private string name;
    }
    class baseUser
    {
        private string user;
        private string password;
    }
    class student : baseUser
{
   
        private List<course> RegisteredCourses = new List<course>;
        bool register()
        {
            return true;
        }
}
    class faculty : baseUser 
    {
  
        private List<course> CourseSchedule = new List<course>;
    }
    class admin : baseUser 
    {
        //list of current schedule and registered courses
        private List<course> CourseSchedule = new List<course>;
        private List<course> RegisteredCourses = new List<course>;
        bool register()
            {
                return true;
            }
    }

}
