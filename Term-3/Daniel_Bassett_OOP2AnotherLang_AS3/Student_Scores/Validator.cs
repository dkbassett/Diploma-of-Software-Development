using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Scores
{
    public static class Validator
    {
        /// <summary>
        /// Checks whether the text box contains anything
        /// </summary>
        /// <param name="textbox", "name"></param>
        /// <returns>boolean</returns>
        public static bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether the text box contains an integer
        /// </summary>
        /// <param name="textbox", "name"></param>
        /// <returns>boolean</returns>
        public static bool IsNumeric(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a whole number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
    }
}
