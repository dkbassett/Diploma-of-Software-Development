using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Scores
{
    public class Student
    {
        private string name;
        private List<int> scores = new List<int>();

        public Student() { }

        public Student(string name, List<int> scores)
        {
            this.Name = name;
            this.Scores = scores;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public List<int> Scores
        {
            get
            {
                return scores;
            }
            set
            {
                scores = value;
            }
        }

        /// <summary>
        /// Creates a string consisting of the name and scores
        /// </summary>
        /// <param name="seperator">Choice of delimiter</param>
        /// <returns>string</returns>
        public string getDisplayText(string seperator)
        {
            string scoreString = null;

            foreach (int score in scores)
            {
                scoreString += seperator + score;
            }

            string studentString = name + scoreString;
            return studentString;
        }

        /// <summary>
        /// Calculates the score total
        /// </summary>
        /// <returns>integer</returns>
        public int getScoreTotal()
        {
            int scoreTotal = 0;
            foreach (int score in scores)
            {
                scoreTotal += score;
            }
            return scoreTotal;
        }

        /// <summary>
        /// Calculates the score count
        /// </summary>
        /// <returns>integer</returns>
        public int getScoreCount()
        {
            int scoreCount = 0;
            scoreCount = scores.Count;
            return scoreCount;
        }

        /// <summary>
        /// Calculates the score average
        /// </summary>
        /// <returns>integer</returns>
        public int getAverage()
        {
            int average = 0;
            if (!(getScoreCount() == 0))
            {
                average = getScoreTotal() / getScoreCount();
            }
            return average;
        }
    }
}
