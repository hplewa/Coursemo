using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursemo
{
  partial class Course
  {
    public string department { get; private set; }
    public int courseNum { get; private set; }
    public string semester { get; private set; }
    public int year { get; private set; }
    public int crn { get; private set; }
    public string type { get; private set; }
    public string day { get; private set; }
    public string time { get; private set; }
    public int capacity { get; private set; }

    public Course(string dept, int cn, string sem, int y, int c, string t, string d, string ti, int ca)
    {
      department = dept;
      courseNum = cn;
      semester = sem;
      year = y;
      crn = c;
      type = t;
      day = d;
      time = ti;
      capacity = ca;
    }
    public override string ToString()
    {
      return department + " " +
        courseNum.ToString() + " " +
        semester + " " +
        year.ToString() + " " +
        crn.ToString() + " " +
        type + " " +
        day + " " +
        time + " " +
        capacity.ToString();
    }
  }
}
