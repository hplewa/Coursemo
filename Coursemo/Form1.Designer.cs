namespace Coursemo
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.resetButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
      this.delayTextBox = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.studentsLB = new System.Windows.Forms.ListBox();
      this.showStudentsButton = new System.Windows.Forms.Button();
      this.showCoursesButton = new System.Windows.Forms.Button();
      this.coursesLB = new System.Windows.Forms.ListBox();
      this.enrollButton = new System.Windows.Forms.Button();
      this.registrationLB = new System.Windows.Forms.ListBox();
      this.waitlistLB = new System.Windows.Forms.ListBox();
      this.dropCourseButton = new System.Windows.Forms.Button();
      this.swapButton = new System.Windows.Forms.Button();
      this.netidBTextBox = new System.Windows.Forms.TextBox();
      this.crnBTextBox = new System.Windows.Forms.TextBox();
      this.crnATextBox = new System.Windows.Forms.TextBox();
      this.netidATextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.enrolledLabel = new System.Windows.Forms.Label();
      this.enrolledCourseLB = new System.Windows.Forms.ListBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetButton,
            this.toolStripLabel2,
            this.delayTextBox,
            this.toolStripLabel1});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(1463, 27);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // resetButton
      // 
      this.resetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
      this.resetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.resetButton.Name = "resetButton";
      this.resetButton.Size = new System.Drawing.Size(116, 24);
      this.resetButton.Text = "Reset Database";
      this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
      // 
      // toolStripLabel2
      // 
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new System.Drawing.Size(47, 24);
      this.toolStripLabel2.Text = "Delay";
      this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
      // 
      // delayTextBox
      // 
      this.delayTextBox.Name = "delayTextBox";
      this.delayTextBox.Size = new System.Drawing.Size(100, 27);
      this.delayTextBox.Text = "1000";
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(28, 24);
      this.toolStripLabel1.Text = "ms";
      // 
      // studentsLB
      // 
      this.studentsLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.studentsLB.FormattingEnabled = true;
      this.studentsLB.HorizontalScrollbar = true;
      this.studentsLB.ItemHeight = 25;
      this.studentsLB.Location = new System.Drawing.Point(12, 102);
      this.studentsLB.Name = "studentsLB";
      this.studentsLB.Size = new System.Drawing.Size(449, 304);
      this.studentsLB.TabIndex = 1;
      this.studentsLB.SelectedIndexChanged += new System.EventHandler(this.studentsLB_SelectedIndexChanged);
      // 
      // showStudentsButton
      // 
      this.showStudentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.showStudentsButton.Location = new System.Drawing.Point(13, 44);
      this.showStudentsButton.Name = "showStudentsButton";
      this.showStudentsButton.Size = new System.Drawing.Size(448, 36);
      this.showStudentsButton.TabIndex = 2;
      this.showStudentsButton.Text = "Show All Students";
      this.showStudentsButton.UseVisualStyleBackColor = true;
      this.showStudentsButton.Click += new System.EventHandler(this.showStudentsButton_Click);
      // 
      // showCoursesButton
      // 
      this.showCoursesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.showCoursesButton.Location = new System.Drawing.Point(488, 44);
      this.showCoursesButton.Name = "showCoursesButton";
      this.showCoursesButton.Size = new System.Drawing.Size(695, 37);
      this.showCoursesButton.TabIndex = 3;
      this.showCoursesButton.Text = "Show All Courses";
      this.showCoursesButton.UseVisualStyleBackColor = true;
      this.showCoursesButton.Click += new System.EventHandler(this.showCoursesButton_Click);
      // 
      // coursesLB
      // 
      this.coursesLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.coursesLB.FormattingEnabled = true;
      this.coursesLB.HorizontalScrollbar = true;
      this.coursesLB.ItemHeight = 25;
      this.coursesLB.Location = new System.Drawing.Point(488, 102);
      this.coursesLB.Name = "coursesLB";
      this.coursesLB.Size = new System.Drawing.Size(695, 304);
      this.coursesLB.TabIndex = 4;
      this.coursesLB.SelectedIndexChanged += new System.EventHandler(this.coursesLB_SelectedIndexChanged);
      // 
      // enrollButton
      // 
      this.enrollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.enrollButton.Location = new System.Drawing.Point(1216, 44);
      this.enrollButton.Name = "enrollButton";
      this.enrollButton.Size = new System.Drawing.Size(228, 57);
      this.enrollButton.TabIndex = 5;
      this.enrollButton.Text = "Enroll";
      this.enrollButton.UseVisualStyleBackColor = true;
      this.enrollButton.Click += new System.EventHandler(this.enrollButton_Click);
      // 
      // registrationLB
      // 
      this.registrationLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.registrationLB.FormattingEnabled = true;
      this.registrationLB.HorizontalScrollbar = true;
      this.registrationLB.ItemHeight = 25;
      this.registrationLB.Location = new System.Drawing.Point(13, 461);
      this.registrationLB.Name = "registrationLB";
      this.registrationLB.Size = new System.Drawing.Size(448, 179);
      this.registrationLB.TabIndex = 6;
      // 
      // waitlistLB
      // 
      this.waitlistLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.waitlistLB.FormattingEnabled = true;
      this.waitlistLB.HorizontalScrollbar = true;
      this.waitlistLB.ItemHeight = 25;
      this.waitlistLB.Location = new System.Drawing.Point(766, 461);
      this.waitlistLB.Name = "waitlistLB";
      this.waitlistLB.Size = new System.Drawing.Size(416, 179);
      this.waitlistLB.TabIndex = 7;
      // 
      // dropCourseButton
      // 
      this.dropCourseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dropCourseButton.Location = new System.Drawing.Point(1216, 122);
      this.dropCourseButton.Name = "dropCourseButton";
      this.dropCourseButton.Size = new System.Drawing.Size(228, 60);
      this.dropCourseButton.TabIndex = 8;
      this.dropCourseButton.Text = "Drop Course";
      this.dropCourseButton.UseVisualStyleBackColor = true;
      this.dropCourseButton.Click += new System.EventHandler(this.dropCourseButton_Click);
      // 
      // swapButton
      // 
      this.swapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.swapButton.Location = new System.Drawing.Point(1216, 316);
      this.swapButton.Name = "swapButton";
      this.swapButton.Size = new System.Drawing.Size(216, 62);
      this.swapButton.TabIndex = 11;
      this.swapButton.Text = "Swap Courses";
      this.swapButton.UseVisualStyleBackColor = true;
      this.swapButton.Click += new System.EventHandler(this.swapButton_Click);
      // 
      // netidBTextBox
      // 
      this.netidBTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.netidBTextBox.Location = new System.Drawing.Point(1216, 281);
      this.netidBTextBox.Name = "netidBTextBox";
      this.netidBTextBox.Size = new System.Drawing.Size(111, 30);
      this.netidBTextBox.TabIndex = 12;
      // 
      // crnBTextBox
      // 
      this.crnBTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.crnBTextBox.Location = new System.Drawing.Point(1333, 281);
      this.crnBTextBox.Name = "crnBTextBox";
      this.crnBTextBox.Size = new System.Drawing.Size(111, 30);
      this.crnBTextBox.TabIndex = 13;
      // 
      // crnATextBox
      // 
      this.crnATextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.crnATextBox.Location = new System.Drawing.Point(1333, 241);
      this.crnATextBox.Name = "crnATextBox";
      this.crnATextBox.Size = new System.Drawing.Size(111, 30);
      this.crnATextBox.TabIndex = 15;
      // 
      // netidATextBox
      // 
      this.netidATextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.netidATextBox.Location = new System.Drawing.Point(1216, 241);
      this.netidATextBox.Name = "netidATextBox";
      this.netidATextBox.Size = new System.Drawing.Size(111, 30);
      this.netidATextBox.TabIndex = 14;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 428);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(184, 25);
      this.label1.TabIndex = 9;
      this.label1.Text = "Registered Courses";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(761, 428);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(144, 25);
      this.label2.TabIndex = 10;
      this.label2.Text = "Course Waitlist";
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(1216, 316);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(228, 62);
      this.button1.TabIndex = 11;
      this.button1.Text = "Swap Courses";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.swapButton_Click);
      // 
      // enrolledLabel
      // 
      this.enrolledLabel.AutoSize = true;
      this.enrolledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.enrolledLabel.Location = new System.Drawing.Point(483, 428);
      this.enrolledLabel.Name = "enrolledLabel";
      this.enrolledLabel.Size = new System.Drawing.Size(172, 25);
      this.enrolledLabel.TabIndex = 17;
      this.enrolledLabel.Text = "Enrolled in Course";
      // 
      // enrolledCourseLB
      // 
      this.enrolledCourseLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.enrolledCourseLB.FormattingEnabled = true;
      this.enrolledCourseLB.HorizontalScrollbar = true;
      this.enrolledCourseLB.ItemHeight = 25;
      this.enrolledCourseLB.Location = new System.Drawing.Point(488, 461);
      this.enrolledCourseLB.Name = "enrolledCourseLB";
      this.enrolledCourseLB.Size = new System.Drawing.Size(256, 179);
      this.enrolledCourseLB.TabIndex = 16;
      this.enrolledCourseLB.SelectedIndexChanged += new System.EventHandler(this.enrolledCourseListBox_SelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(1240, 213);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(57, 25);
      this.label3.TabIndex = 18;
      this.label3.Text = "Netid";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(1360, 213);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(54, 25);
      this.label4.TabIndex = 19;
      this.label4.Text = "CRN";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(1189, 244);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(23, 25);
      this.label5.TabIndex = 20;
      this.label5.Text = "1";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(1189, 286);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(23, 25);
      this.label6.TabIndex = 21;
      this.label6.Text = "2";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Salmon;
      this.ClientSize = new System.Drawing.Size(1463, 661);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.enrolledLabel);
      this.Controls.Add(this.enrolledCourseLB);
      this.Controls.Add(this.crnATextBox);
      this.Controls.Add(this.netidATextBox);
      this.Controls.Add(this.crnBTextBox);
      this.Controls.Add(this.netidBTextBox);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.swapButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dropCourseButton);
      this.Controls.Add(this.waitlistLB);
      this.Controls.Add(this.registrationLB);
      this.Controls.Add(this.enrollButton);
      this.Controls.Add(this.coursesLB);
      this.Controls.Add(this.showCoursesButton);
      this.Controls.Add(this.showStudentsButton);
      this.Controls.Add(this.studentsLB);
      this.Controls.Add(this.toolStrip1);
      this.ForeColor = System.Drawing.SystemColors.ControlText;
      this.Name = "Form1";
      this.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.Text = "Form1";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton resetButton;
    private System.Windows.Forms.ListBox studentsLB;
    private System.Windows.Forms.Button showStudentsButton;
    private System.Windows.Forms.Button showCoursesButton;
    private System.Windows.Forms.ListBox coursesLB;
    private System.Windows.Forms.Button enrollButton;
    private System.Windows.Forms.ListBox registrationLB;
    private System.Windows.Forms.ListBox waitlistLB;
    private System.Windows.Forms.Button dropCourseButton;
    private System.Windows.Forms.Button swapButton;
    private System.Windows.Forms.TextBox netidBTextBox;
    private System.Windows.Forms.TextBox crnBTextBox;
    private System.Windows.Forms.TextBox crnATextBox;
    private System.Windows.Forms.TextBox netidATextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label enrolledLabel;
    private System.Windows.Forms.ListBox enrolledCourseLB;
    private System.Windows.Forms.ToolStripTextBox delayTextBox;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
  }
}

