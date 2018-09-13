using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursemo
{
  partial class Student
  {
    public string lastName { get; private set; }
    public string firstName { get; private set; }
    public string netid { get; private set; }

    public Student(string l, string f, string n)
    {
      lastName = l;
      firstName = f;
      netid = n;
    }

    public override string ToString()
    {
      return firstName + " " + lastName + ": " + netid;
    }
  }
}
