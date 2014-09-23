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
    public partial class frmUpdateScore : Form, IData
    {
        public frmUpdateScore()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the score textbox with data based on selected
        /// score from Update Student Scores form
        /// </summary>
        /// <param name="sender">Update Student Scores form</param>
        private void frmUpdateScore_Load(object sender, EventArgs e)
        {
            string score = frmUpdateStudentScores.selectedScore;
            txtScore.Text = score;
        }

        /// <summary>
        /// Stores the input store in the dialog tag to send back to main control.
        /// </summary>
        public void SaveData()
        {
            if (Validator.IsPresent(txtScore, "Score") && Validator.IsNumeric(txtScore, "Score"))
            {
                string score = txtScore.Text;

                this.Tag = score;
                this.DialogResult = DialogResult.OK;
            }

        }

        /// <summary>
        /// Saves the input data
        /// </summary>
        /// <param name="sender">Update button</param>
        /// <param name="e">On button click</param>
        private void btnUpdate_Click(object sender, EventArgs e)
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
