using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Algorithms;

namespace TargetSeeker_PathFinder
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        //the main method
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Matrix_PathFinder_App());
        }
    }
}