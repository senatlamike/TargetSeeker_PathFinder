using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TargetSeeker_PathFinderDemo
{
    public partial class startup_form : Form
    {
        public startup_form()
        {
            InitializeComponent();
        }

        private void openGame_Click(object sender, EventArgs e)
        {
            Matrix_PathFinder_App frm = new Matrix_PathFinder_App();
            frm.Show();
        }

        // Create Form2.
        public class Matrix_PathFinder_App : Form
        {
            public Matrix_PathFinder_App()
            {
               // Text = "Matrix_PathFinder_App";
            }
        }
    }
}