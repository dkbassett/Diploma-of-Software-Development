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

namespace Reservations
{
    public partial class frmReservations : Form
    {      
        DateTime currentDateTime = DateTime.Today;
        decimal pricePerNight = 0m;
        decimal totalPrice = 0m;
        decimal averagePricePerNight = 0m;
        
        public frmReservations()
        {
            InitializeComponent();
        }

        private void frmReservations_Load(object sender, EventArgs e)
        {
            txtArrivalDate.Text = currentDateTime.ToShortDateString();
            txtDepartureDate.Text = currentDateTime.AddDays(3).ToShortDateString();
        }

        public bool IsValidData()
        {
            return
                IsPresent(txtArrivalDate, "Arrival Date") &&
                IsDateTime(txtArrivalDate, "Arrival Date") &&
                IsWithinRange(txtArrivalDate, "Arrival Date", currentDateTime, currentDateTime.AddYears(5)) &&

                IsPresent(txtDepartureDate, "Departure Date") &&
                IsDateTime(txtDepartureDate, "Departure Date") &&
                IsWithinRange(txtDepartureDate, "Departure Date", currentDateTime, currentDateTime.AddYears(5)) &&

                IsSequential(txtArrivalDate, txtDepartureDate);
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDateTime(TextBox textBox, string name)
        {
            DateTime dateTime;
            if (DateTime.TryParse(textBox.Text, out dateTime))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " was entered incorrectly. Please try again.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textBox, string name,
            DateTime min, DateTime max)
        {
            DateTime enteredDate = DateTime.Parse(textBox.Text);
            if (enteredDate < min || enteredDate > max)
            {
                MessageBox.Show(name + " must be between " + min + " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsSequential(TextBox arrival, TextBox departure)
        {
            if (DateTime.Parse(arrival.Text) > DateTime.Parse(departure.Text))
            {
                MessageBox.Show("The departure date should be after the arrival date.", "Entry Error");
                departure.Focus();
                return false;
            }
            return true;
        }       

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            totalPrice = 0m;
            averagePricePerNight = 0m;

            if (IsValidData())
            {
                DateTime arrivalDate = Convert.ToDateTime(txtArrivalDate.Text);
                DateTime departureDate = Convert.ToDateTime(txtDepartureDate.Text);

                TimeSpan timeSpan = departureDate.Subtract(arrivalDate);
                int numberOfDays = timeSpan.Days;

                DateTime currentDateCounter = arrivalDate;
                DayOfWeek dayOfWeek = currentDateCounter.DayOfWeek;

                int numberOfDaysCounter = numberOfDays;
                while (numberOfDaysCounter > 0)
                {
                    if (dayOfWeek == DayOfWeek.Friday || dayOfWeek == DayOfWeek.Saturday)
                    {
                        pricePerNight = 150m;
                    }
                    else
                    {
                        pricePerNight = 120m;
                    }
                    totalPrice += pricePerNight;

                    currentDateCounter = currentDateCounter.AddDays(1);
                    dayOfWeek = currentDateCounter.DayOfWeek;
                    numberOfDaysCounter--;
                }

                averagePricePerNight = totalPrice / numberOfDays;

                txtNights.Text = timeSpan.Days.ToString();
                txtTotalPrice.Text = totalPrice.ToString("c");
                txtAvgPrice.Text = averagePricePerNight.ToString("c");
            }     
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}