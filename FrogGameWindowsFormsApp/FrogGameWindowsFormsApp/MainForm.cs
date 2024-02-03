using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrogGameWindowsFormsApp
{
    public partial class MainForm : Form
    {
       
        //public string count
        //{
        //    get { return countStepsLabel.Text; }
        //    set { countStepsLabel.Text = value;}
        //}
        public MainForm()
        {
            InitializeComponent();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            
            Swap((PictureBox)sender);
            countStepsLabel.Text = (int.Parse(countStepsLabel.Text) +1).ToString();

            if(IsEndGame())
            {
               WinForm winForm = new WinForm(countStepsLabel.Text);
               winForm.ShowDialog();
            }
        }

        private bool IsEndGame()
        {
            var startLocationXEmptyPictureBox = 440;
            if (leftPictureBox1.Location.X > emptyPictureBox.Location.X &&
                leftPictureBox2.Location.X > emptyPictureBox.Location.X &&
                leftPictureBox3.Location.X > emptyPictureBox.Location.X &&
                leftPictureBox4.Location.X > emptyPictureBox.Location.X && 
                emptyPictureBox.Location.X == startLocationXEmptyPictureBox)
            {
                
                return true;
            }
            return false;
        }

        private void Swap (PictureBox clickedPicture)
        {
            var distance = Math.Abs(clickedPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;

            if (distance > 2)
            {
                MessageBox.Show("Так нельзя");
            }
            else
            {
                var location = clickedPicture.Location;
                clickedPicture.Location = emptyPictureBox.Location;
                emptyPictureBox.Location = location;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (IsEndGame())
            {
                WinForm winForm = new WinForm(countStepsLabel.Text);
                winForm.ShowDialog();
            }
        }
    }
}
