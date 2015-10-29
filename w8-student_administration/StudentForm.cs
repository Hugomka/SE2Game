using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StudentAdministration.Data;
using StudentAdministration.Logic;
using StudentAdministration.Models;

namespace StudentAdministration
{
    public partial class StudentForm : Form
    {
        private StudentRepository studentRepo;
        private GradeRepository gradeRepo;
        private Student updateStudent;

        public StudentForm()
        {
            InitializeComponent();

            // Create a new student repository that works with an SQLite
            // context: this repository instance is used for all persistency
            studentRepo = new StudentRepository(new StudentSQLiteContext());
            gradeRepo = new GradeRepository(new GradeSQLiteContext());
            UpdateControls();
        }

        private void UpdateControls()
        {
            lstStudents.Items.Clear();
            foreach (Student student in studentRepo.GetAll())
            {
                lstStudents.Items.Add(student);
            }

            // It is only possible to edit and delete students when one is selected
            bool studentSelected = lstStudents.SelectedItem != null;
            btnEditStudent.Enabled = studentSelected;
            btnDeleteStudent.Enabled = studentSelected;
            grpGrading.Enabled = false;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (updateStudent != null)
            {
                UpdateStudent();
            }
            else
            {
                InsertStudent();
            }
        }

        private void UpdateStudent()
        {
            updateStudent.Name = txtName.Text;
            updateStudent.Email = txtEmail.Text;

            if (studentRepo.Update(updateStudent))
            {
                UpdateControls();
                txtName.Text = "";
                txtEmail.Text = "";
                updateStudent = null;
            }
            else
            {
                MessageBox.Show("Updating student failed. Check if the email address is valid.");
            }
        }

        private void InsertStudent()
        {
            Student student = null;
            try
            {
                student = new Student(txtName.Text, txtEmail.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Adding student failed. Check if the email address is valid.");
                return;
            }

            if (studentRepo.Insert(student) != null)
            {
                UpdateControls();
                txtName.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                MessageBox.Show("Adding student failed. Check if the number is unique.");
            }
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update button enabled state when a student has been selected
            btnEditStudent.Enabled = lstStudents.SelectedItem != null;
            btnDeleteStudent.Enabled = lstStudents.SelectedItem != null;
            try {
                lblGrade.Text = gradeRepo.GetAverage(gradeRepo.GetForStudent(
                    (Student)lstStudents.SelectedItem)).ToString();
            }
            catch
            {
                lblGrade.Text = "0";
            }
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            updateStudent = (Student)lstStudents.SelectedItem;
            txtName.Text = updateStudent.Name;
            txtEmail.Text = updateStudent.Email;
            grpGrading.Enabled = true;
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            studentRepo.Delete(((Student)lstStudents.SelectedItem).Id);
            UpdateControls();
        }

        private void btnSetGrade_Click(object sender, EventArgs e)
        {
            Student selectedStudent = (Student)lstStudents.SelectedItem;
            gradeRepo.Insert(selectedStudent,
                new Grade(nudAnalysis.Value, nudDesign.Value, nudCode.Value));
            lblGrade.Text = gradeRepo.GetAverage(gradeRepo.GetForStudent(selectedStudent)).ToString();
            UpdateControls();
        }
    }
}
