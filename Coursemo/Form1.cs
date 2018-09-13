using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

//
// Multi-user Coursemo application for UIC course registrations.
//
// Hubert Plewa
// U. of Illinois, Chicago
// CS480, Summer 2018
//

namespace Coursemo
{
  public partial class Form1 : Form
  {
    static private List<Student> students = null;
    static private List<Course> courses = null;
    static private bool delay_flag = true;

    public Form1()
    {
      InitializeComponent();
    }

    //Delete all rows in Registrations, Transactions, and Waitlist tables
    private void resetButton_Click(object sender, EventArgs e)
    {
      using (var db = new CoursemoDataContext())
      {
        var TxOptions = new System.Transactions.TransactionOptions();
        TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

        using (var Tx = new System.Transactions.TransactionScope(
          System.Transactions.TransactionScopeOption.Required, TxOptions))
        {
          try
          {
            if (delay_flag)
            {
              Delay();
            }
            db.Registrations.DeleteAllOnSubmit(from r in db.Registrations select r);

            if (delay_flag)
            {
              Delay();
            }
            db.Waitlists.DeleteAllOnSubmit(from w in db.Waitlists select w);

            if (delay_flag)
            {
              Delay();
            }
            db.Transactions.DeleteAllOnSubmit(from t in db.Transactions select t);
            db.SubmitChanges();
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
          finally
          {
            Tx.Complete();
          }
        }
        MessageBox.Show("Database reset.");
      }
    }

    //Get students from DB
    //Display students in students listbox
    private void showStudentsButton_Click(object sender, EventArgs e)
    {
      this.studentsLB.Items.Clear();
      using (var db = new CoursemoDataContext())
      {
        var TxOptions = new System.Transactions.TransactionOptions();
        TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

        using (var Tx = new System.Transactions.TransactionScope(
          System.Transactions.TransactionScopeOption.Required, TxOptions))
        {
          try
          {
            if (students == null)
            {
              if (delay_flag)
              {
                Delay();
              }
              students = new List<Student>();
              var query = (from s in db.Students
                           orderby s.Netid
                           select s).ToList();
              foreach (var s in query)
              {
                students.Add(new Student(s.LastName, s.FirstName, s.Netid));
              }
            }
            foreach (var s in students)
            {
              this.studentsLB.Items.Add(s);
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
          finally
          {
            Tx.Complete();
          }
        }
      }
    }

    //Display registered courses for this student
    private void studentsLB_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.registrationLB.Items.Clear();

      Student student = getSelectedStudent();
      if (student == null)
      {
        return;
      }

      using (var db = new CoursemoDataContext())
      {
        var TxOptions = new System.Transactions.TransactionOptions();
        TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

        using (var Tx = new System.Transactions.TransactionScope(
          System.Transactions.TransactionScopeOption.Required, TxOptions))
        {
          try
          {
            if (delay_flag)
            {
              Delay();
            }
            var registeredCourses = (from r in db.Registrations
                                     join c in db.Courses on r.CRN equals c.CRN
                                     where r.Netid == student.netid
                                     orderby c.CRN
                                     select c).ToList();
            if (registeredCourses.Count > 0)
            {
              foreach (var r in registeredCourses)
              {
                this.registrationLB.Items.Add(r.CRN + " " + r.Department + " " + r.CourseNum.ToString());
              }
            }
            else
            {
              this.registrationLB.Items.Add("No registered courses...");
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
          finally
          {
            Tx.Complete();
          }
        }
      }
    }

    private void showCoursesButton_Click(object sender, EventArgs e)
    {
      this.coursesLB.Items.Clear();
      using (var db = new CoursemoDataContext())
      {
        var TxOptions = new System.Transactions.TransactionOptions();
        TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

        using (var Tx = new System.Transactions.TransactionScope(
          System.Transactions.TransactionScopeOption.Required, TxOptions))
        {
          try
          {
            if (courses == null)
            {
              courses = new List<Course>();
              if (delay_flag)
              {
                Delay();
              }
              var query = (from c in db.Courses
                           orderby c.Department, c.CourseNum, c.CRN
                           select c).ToList();
              foreach (var c in query)
              {
                courses.Add(new Course(c.Department, c.CourseNum, c.Semester, c.Year, c.CRN, c.Time, c.Day, c.Time, c.Capacity));
              }
            }
            foreach (var c in courses)
            {
              this.coursesLB.Items.Add(c);
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
          finally
          {
            Tx.Complete();
          }
        }
      }
    }

    private Student getSelectedStudent()
    {
      if (this.studentsLB.SelectedItem == null)
      {
        return null;
      }
      return students[this.studentsLB.SelectedIndex];
    }

    private Course getSelectedCourse()
    {
      if (this.coursesLB.SelectedItem == null)
      {
        return null;
      }
      return courses[this.coursesLB.SelectedIndex];
    }

    //Get the selected student and course
    //Try to enroll the student in the course
    //If the course is full, put students on waitlist
    private void enrollButton_Click(object sender, EventArgs e)
    {
      if (this.studentsLB.SelectedItem == null)
      {
        MessageBox.Show("Select a student to enroll.");
        return;
      }
      Student student = getSelectedStudent();
      //MessageBox.Show(student.ToString());

      if (this.coursesLB.SelectedItem == null)
      {
        MessageBox.Show("Select a course to enroll in.");
        return;
      }
      Course course = getSelectedCourse();
      //MessageBox.Show(course.ToString());
      string msg = null;
      using (var db = new CoursemoDataContext())
      {
        var TxOptions = new System.Transactions.TransactionOptions();
        TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

        using (var Tx = new System.Transactions.TransactionScope(
          System.Transactions.TransactionScopeOption.Required, TxOptions))
        {
          try {
            if (delay_flag)
            {
              Delay();
            }
            var enrolled = from r in db.Registrations
                           where r.Netid == student.netid
                           where r.CRN == course.crn
                           select r;

            if (delay_flag)
            {
              Delay();
            }
            var waiting = from w in db.Waitlists
                          where w.Netid == student.netid
                          where w.CRN == course.crn
                          select w;
            //Is the student already enrolled in this class?
            if (enrolled.Any())
            {
              //MessageBox.Show(student.netid + " is already enrolled in course " + course.crn);
              msg = student.netid + " is already enrolled in course " + course.crn;
            }
            //Is the student on the waitlist for this class?
            else if (waiting.Any())
            {
              //MessageBox.Show(student.netid + " is already on the waitlist for course " + course.crn);
              msg = student.netid + " is already on the waitlist for course " + course.crn;
            }
            //Student not enrolled or waiting for this course
            else
            {
              //Get number of registrations for this course
              if (delay_flag)
              {
                Delay();
              }
              var query = (from r in db.Registrations
                           where r.CRN == course.crn
                           select r.RID).ToList();

              //Is this class full?
              if (query.Count == course.capacity)
              {
                //MessageBox.Show(course.crn + " is full, putting " + student.netid + " on the waitlist for this course.");
                //Put on waitlist
                if (delay_flag)
                {
                  Delay();
                }
                Waitlist wait = new Waitlist
                {
                  Netid = student.netid,
                  CRN = course.crn,
                  RegTime = DateTime.Now
                };
                db.Waitlists.InsertOnSubmit(wait);

                if (delay_flag)
                {
                  Delay();
                }
                var placeInLine = from w in db.Waitlists
                                  where w.CRN == course.crn
                                  orderby w.RegTime
                                  select w.WID;

                //MessageBox.Show(student.netid + " put on waitlist for " + course.crn + ". Place in line: " + (placeInLine.Count() + 1).ToString());
                msg = student.netid + " put on waitlist for " + course.crn + ". Place in line: " + (placeInLine.Count() + 1).ToString();
              }
              else
              {
                //Enroll
                if (delay_flag)
                {
                  Delay();
                }
                Registration r = new Registration
                {
                  Netid = student.netid,
                  CRN = course.crn
                };
                db.Registrations.InsertOnSubmit(r);
                //MessageBox.Show(student.netid + " enrolled in " + course.crn);
                msg = student.netid + " enrolled in " + course.crn;
              }
            }
            db.SubmitChanges();
            Tx.Complete();
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
            //msg = "Enrollment failed. Try again.";
            //Tx.Dispose();
          }
        }
        MessageBox.Show(msg);
      }
    }

    //Display waitlist for this course
    private void coursesLB_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.enrolledCourseLB.Items.Clear();
      this.waitlistLB.Items.Clear();

      Course course = getSelectedCourse();
      if (course == null)
      {
        return;
      }

      using (var db = new CoursemoDataContext())
      {
        var TxOptions = new System.Transactions.TransactionOptions();
        TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

        using (var Tx = new System.Transactions.TransactionScope(
          System.Transactions.TransactionScopeOption.Required, TxOptions))
        {
          try
          {
            if (delay_flag)
            {
              Delay();
            }
            var enrolled = (from r in db.Registrations
                            where r.CRN == course.crn
                            select r).ToList();
            if (enrolled.Any())
            {
              foreach (var en in enrolled)
              {
                this.enrolledCourseLB.Items.Add(en.Netid);
              }
            }
            else
            {
              this.enrolledCourseLB.Items.Add("No enrollments.");
            }

            if (delay_flag)
            {
              Delay();
            }
            var waitlist = (from w in db.Waitlists
                            where w.CRN == course.crn
                            orderby w.RegTime
                            select w).ToList();
            if (waitlist.Any())
            {
              foreach (var w in waitlist)
              {
                this.waitlistLB.Items.Add(w.Netid + " " + w.CRN + " " + w.RegTime.ToString());
              }
            }
            else
            {
              this.waitlistLB.Items.Add("No waitlist...");
            }
            Tx.Complete();
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }

    //Get selected student and enrolled course
    //Delete entry in registrations table
    //Check waitlist for dropped course, enroll first in line
    private void dropCourseButton_Click(object sender, EventArgs e)
    {
      Student student = getSelectedStudent();
      if (student == null)
      {
        MessageBox.Show("Select a student.");
        return;
      }
      if (this.registrationLB.SelectedItem == null)
      {
        MessageBox.Show("Select a registered course.");
        return;
      }
      int selectedCRN = Convert.ToInt32(this.registrationLB.SelectedItem.ToString().Split(' ')[0]);
      //MessageBox.Show(selectedCRN.ToString()); 

      string msg = null;

      using (var db = new CoursemoDataContext())
      {
        var TxOptions = new System.Transactions.TransactionOptions();
        TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

        using (var Tx = new System.Transactions.TransactionScope(
          System.Transactions.TransactionScopeOption.Required, TxOptions))
        {
          try
          {
            if (delay_flag)
            {
              Delay();
            }
            db.Registrations.DeleteAllOnSubmit(from r in db.Registrations
                                               where r.CRN == selectedCRN
                                               where r.Netid == student.netid
                                               select r);
            //MessageBox.Show(student.netid + " dropped " + selectedCRN);
            msg = student.netid + " dropped " + selectedCRN;

            if (delay_flag)
            {
              Delay();
            }
            var waiting = (from w in db.Waitlists
                           where w.CRN == selectedCRN
                           orderby w.RegTime
                           select w).ToList();

            //Is there a waitlist for this class?
            if (waiting.Any())
            {
              if (delay_flag)
              {
                Delay();
              }
              var front = students.Find(
                              delegate (Student s)
                              {
                                return s.netid == waiting[0].Netid;
                              }
                            );
              //Enroll
              if (delay_flag)
              {
                Delay();
              }
              Registration r = new Registration
              {
                Netid = front.netid,
                CRN = selectedCRN
              };
              db.Registrations.InsertOnSubmit(r);
              //MessageBox.Show(front.netid + " enrolled in " + selectedCRN);
              //msg = front.netid + " enrolled in " + selectedCRN;

              //Remove enrolled student from waitlist
              if (delay_flag)
              {
                Delay();
              }
              db.Waitlists.DeleteAllOnSubmit(from w in db.Waitlists
                                             where w.Netid == front.netid
                                             where w.CRN == selectedCRN
                                             select w);
            }
            db.SubmitChanges();
            Tx.Complete();
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
      MessageBox.Show(msg);
    }

    private void swapButton_Click(object sender, EventArgs e)
    {
      string netidA = this.netidATextBox.Text;
      if (netidA == null)
      {
        MessageBox.Show("Enter student A's netid.");
        return;
      }
      int crnA = Convert.ToInt32(this.crnATextBox.Text);
      if (this.crnATextBox.Text == null)
      {
        MessageBox.Show("Enter student A's CRN.");
        return;
      }
      string netidB = this.netidBTextBox.Text;
      if (netidB == null)
      {
        MessageBox.Show("Enter student B's netid.");
        return;
      }
      int crnB = Convert.ToInt32(this.crnBTextBox.Text);
      if (this.crnBTextBox.Text == null)
      {
        MessageBox.Show("Enter student B's CRN.");
        return;
      }
      string msg = null;
      using (var db = new CoursemoDataContext())
      {
        var TxOptions = new System.Transactions.TransactionOptions();
        TxOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

        using (var Tx = new System.Transactions.TransactionScope(
          System.Transactions.TransactionScopeOption.Required, TxOptions))
        {
          try
          {
            //Check if student A exists
            if (delay_flag)
            {
              Delay();
            }
            var aExists = from s in db.Students
                          where s.Netid == netidA
                          select s.Netid;
            if (!aExists.Any())
            {
              msg = netidA + " does not exist.";
              throw new System.InvalidOperationException(msg);
            }
            //Check if student A is enrolled in crnA
            var aEnrolled = from r in db.Registrations
                            where r.Netid == netidA
                            where r.CRN == crnA
                            select r;
            if (!aEnrolled.Any())
            {
              msg = netidA + " is not enrolled in " + crnA.ToString() + ".";
              throw new System.InvalidOperationException(msg);
            }

            if (delay_flag)
            {
              Delay();
            }
            //Check if student B exists
            var bExists = from s in db.Students
                          where s.Netid == netidB
                          select s.Netid;
            if (!bExists.Any())
            {
              msg = netidB + " does not exist.";
              throw new System.InvalidOperationException(msg);
            }

            if (delay_flag)
            {
              Delay();
            }
            //Check if student B is enrolled in crnB
            var bEnrolled = from r in db.Registrations
                            where r.Netid == netidB
                            where r.CRN == crnB
                            select r;
            if (!bEnrolled.Any())
            {
              msg = netidB + " is not enrolled in " + crnB.ToString() + ".";
              throw new System.InvalidOperationException(msg);
            }

            if (delay_flag)
            {
              Delay();
            }
            //Clear out student a's waitlist entry for b's class
            var aWaiting = from w in db.Waitlists
                           where w.Netid == netidA
                           where w.CRN == crnB
                           select w;
            db.Waitlists.DeleteAllOnSubmit(aWaiting);

            if (delay_flag)
            {
              Delay();
            }
            //Clear out student b's waitlist entry for a's class
            var bWaiting = from w in db.Waitlists
                           where w.Netid == netidB
                           where w.CRN == crnA
                           select w;
            db.Waitlists.DeleteAllOnSubmit(bWaiting);

            //Swap registrations
            if (delay_flag)
            {
              Delay();
            }
            aEnrolled.First().CRN = crnB;

            if (delay_flag)
            {
              Delay();
            }
            bEnrolled.First().CRN = crnA;
            //MessageBox.Show(netidA + " swapped course " + crnA.ToString() + " for " + crnB.ToString() + " with " + netidB);
            msg = netidA + " swapped course " + crnA.ToString() + " for " + crnB.ToString() + " with " + netidB;
            db.SubmitChanges();
            Tx.Complete();
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
      MessageBox.Show(msg);
    }

    private void Delay()
    {
      int timeInMS;
      if (System.Int32.TryParse(this.delayTextBox.Text, out timeInMS) == true)
        ;
      else
        timeInMS = 0;  // no delay:
      System.Threading.Thread.Sleep(timeInMS);
    }
    private void enrolledCourseListBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void toolStripLabel2_Click(object sender, EventArgs e)
    {

    }
  }
}

