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
    public partial class frmAddScore : Form, IData
    {
        public frmAddScore()
        {
            InitializeComponent();
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
        /// <param name="sender">Add button</param>
        /// <param name="e">On button click</param>
        private void btnAdd_Click(object sender, EventArgs e)
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
