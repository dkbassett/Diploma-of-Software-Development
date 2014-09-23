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
    public partial class frmAddNewStudent : Form, IData
    {
        List<int> scores = new List<int>();

        public frmAddNewStudent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds a new score to the Scores textbox
        /// </summary>
        /// <param name="sender">Add Score button</param>
        /// <param name="e">On button click</param>
        private void btnAddScore_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtScore, "Score") && Validator.IsNumeric(txtScore, "Score"))
            {
                txtScores.Text += txtScore.Text + " ";
                scores.Add(Int32.Parse(txtScore.Text));
            }
        }

        /// <summary>
        /// Clears all scores from the Scores textbox
        /// </summary>
        /// <param name="sender">Clear Scores button</param>
        /// <param name="e">On button click</param>
        private void btnClearScores_Click(object sender, EventArgs e)
        {
            txtScores.Clear();
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
                Student student = new Student(name, scores);
                
                this.Tag = student;
                this.DialogResult = DialogResult.OK;
            }
   
        }

        /// <summary>
        /// Saves the input data
        /// </summary>
        /// <param name="sender">Add button</param>
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
