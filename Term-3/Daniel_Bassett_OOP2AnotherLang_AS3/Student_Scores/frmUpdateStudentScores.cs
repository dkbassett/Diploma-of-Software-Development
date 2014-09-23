using System;
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
    public partial class frmUpdateStudentScores : Form, IData
    {
        public static string selectedScore;

        public frmUpdateStudentScores()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the name and scores textboxes with data based on selected
        /// student from Student Scores form
        /// </summary>
        /// <param name="sender">Update Student Scores form</param>
        /// <param name="e">On load</param>
        private void frmUpdateStudentScores_Load(object sender, EventArgs e)
        {
            Student student = frmStudentScores.selectedStudent;

            txtName.Text = student.Name;
            foreach (int score in student.Scores)
            {
                lstScores.Items.Add(score);
            }
        }

        /// <summary>
        /// Opens the Add Score form and receives a new score if dialog
        /// result is OK and adds it to the listbox.
        /// </summary>
        /// <param name="sender">Add button</param>
        /// <param name="e">On button click</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form newAddScoreForm = new frmAddScore();
            DialogResult selectedButton = newAddScoreForm.ShowDialog();
            if (selectedButton == DialogResult.OK)
            {
                lstScores.Items.Add(newAddScoreForm.Tag);
            }
        }

        /// <summary>
        /// Opens the Update Score form and receives a new socre is dialog
        /// result is OK and replaces the selected item in listbox.
        /// </summary>
        /// <param name="sender">Update button</param>
        /// <param name="e">On button click</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                selectedScore = lstScores.SelectedItem.ToString();

                Form newUpdateScoreForm = new frmUpdateScore();
                DialogResult selectedButton = newUpdateScoreForm.ShowDialog();

                if (selectedButton == DialogResult.OK)
                {
                    lstScores.Items.Insert(lstScores.SelectedIndex, newUpdateScoreForm.Tag);
                    lstScores.Items.RemoveAt(lstScores.SelectedIndex);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("A score must first be selected in order to update", "Selection error");
            }
        }     

        /// <summary>
        /// Deletes a score from the listbox
        /// </summary>
        /// <param name="sender">Remove button</param>
        /// <param name="e">On button click</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            lstScores.Items.Remove(lstScores.SelectedItem);
        }

        /// <summary>
        /// Clears all scores from listbox
        /// </summary>
        /// <param name="sender">Clear Scores button</param>
        /// <param name="e">On button click</param>
        private void btnClearScores_Click(object sender, EventArgs e)
        {
            lstScores.Items.Clear();
        }

        /// <summary>
        /// Creates a new student with data from the name and score fields.
        /// Stores this student in the dialog tag to send back to main control.
        /// </summary>
        public void SaveData()
        {
            if (Validator.IsPresent(txtName, "Name"))
            {
                string name = txtName.Text;
                List<int> scores = new List<int>();

                for (int i = 0; i < lstScores.Items.Count; i++)
                {
                    scores.Add(Convert.ToInt32(lstScores.Items[i]));
                }

                Student student = new Student(name, scores);

                this.Tag = student;
                this.DialogResult = DialogResult.OK;
            }

        }

        /// <summary>
        /// Saves the input data
        /// </summary>
        /// <param name="sender">OK button</param>
        /// <param name="e">On button click</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender">Cancel button</param>
        /// <param name="e">On button click</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
