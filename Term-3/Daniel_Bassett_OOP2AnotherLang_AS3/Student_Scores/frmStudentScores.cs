using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/************************
* @author  Daniel Bassett
*************************/

namespace Student_Scores
{
    public partial class frmStudentScores : Form
    {
        private Student joel = new Student();
        private Student doug = new Student();
        private Student anne = new Student();

        private List<int> joelScores = new List<int>() { 97, 71, 83 };
        private List<int> dougScores = new List<int>() { 99, 93, 97 };
        private List<int> anneScores = new List<int>() { 100, 100, 100 };

        private ArrayList studentList = new ArrayList();

        public static Student selectedStudent;

        public frmStudentScores()
        {
            joel.Name = "Joel Murach";
            joel.Scores = joelScores;
            studentList.Add(joel);

            doug.Name = "Doug Lowe";
            doug.Scores = dougScores;
            studentList.Add(doug);

            anne.Name = "Anne Boehm";
            anne.Scores = anneScores;
            studentList.Add(anne);

            InitializeComponent();
        }

        /// <summary>
        /// Clears and fills the listbox with students from the arraylist
        /// </summary>
        private void FillStudentListBox()
        {
            lstStudents.Items.Clear();
            foreach (Student s in studentList)
            {
                lstStudents.Items.Add(s.getDisplayText("|"));
            }
        }

        /// <summary>
        /// Fills the student list box on form load
        /// </summary>
        /// <param name="sender">Student Scores form</param>
        /// <param name="e">On load</param>
        private void frmStudentScores_Load(object sender, EventArgs e)
        {
            FillStudentListBox();
        }

        /// <summary>
        /// Displays data for the score total, score count and average textboxes
        /// </summary>
        private void displayCalculationFields()
        {
            Student student = (Student)studentList[lstStudents.SelectedIndex];
            txtScoreTotal.Text = student.getScoreTotal().ToString();
            txtScoreCount.Text = student.getScoreCount().ToString();
            txtAverage.Text = student.getAverage().ToString();
        }

        /// <summary>
        /// Displays the calculated fields if the item selection changes
        /// </summary>
        /// <param name="sender">Student listbox</param>
        /// <param name="e">On item index change</param>
        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                displayCalculationFields();
            }
            catch (ArgumentOutOfRangeException)
            {      
            }         
        }

        /// <summary>
        /// Opens the 'Add New Student' form and receives a new student object
        /// from the form if the dialog result is OK. Adds the new student to 
        /// the listbox and arraylist
        /// </summary>
        /// <param name="sender">Add New ... button</param>
        /// <param name="e">On button click</param>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form newStudentForm = new frmAddNewStudent();
            DialogResult selectedButton = newStudentForm.ShowDialog();
            if (selectedButton == DialogResult.OK)
            {
                studentList.Add(newStudentForm.Tag);
                FillStudentListBox();
            }
            txtScoreTotal.Text = null;
            txtScoreCount.Text = null;
            txtAverage.Text = null;
        }

        /// <summary>
        /// Opens the 'Update Student Scores' form if a student from the listbox
        /// is selected. Receives a new student from the form if the dialog
        /// result is OK and replaces the student in the listbox and arraylist.
        /// </summary>
        /// <param name="sender">Update ... button</param>
        /// <param name="e">On button click</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                selectedStudent = (Student)studentList[lstStudents.SelectedIndex];

                Form newUpdateStudentForm = new frmUpdateStudentScores();
                DialogResult selectedButton = newUpdateStudentForm.ShowDialog();

                if (selectedButton == DialogResult.OK)
                {
                    studentList.Insert(lstStudents.SelectedIndex, newUpdateStudentForm.Tag);
                    studentList.Remove(selectedStudent);
                    FillStudentListBox();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a student from the list to update first", "Selection Error");
            }
            txtScoreTotal.Text = null;
            txtScoreCount.Text = null;
            txtAverage.Text = null;
        }

        /// <summary>
        /// Deletes the selected student from the list box and the arraylist
        /// </summary>
        /// <param name="sender">Delete button</param>
        /// <param name="e">On button click</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int studentIndex = lstStudents.SelectedIndex;

                lstStudents.Items.Remove((Student)studentList[studentIndex]);
                studentList.RemoveAt(lstStudents.SelectedIndex);
                FillStudentListBox();
                if (lstStudents.Items.Count == 0)
                {
                    txtScoreTotal.Text = null;
                    txtScoreCount.Text = null;
                    txtAverage.Text = null;
                }
                else if (lstStudents.SelectedItem == null && studentIndex != 0)
                {
                    lstStudents.SetSelected(studentIndex - 1, true);
                }
                else
                {
                    lstStudents.SetSelected(studentIndex, true);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a student from the list to delete first", "Selection Error");
            }  

        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender">Exit button</param>
        /// <param name="e">On button click</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

    
}
