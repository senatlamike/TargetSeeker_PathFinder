using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class HighResolutionTime
    {
        #region Win32APIs
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long perfcount);

        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long freq);
        #endregion

        //Variables Declaration
        private static long mStartCounter;
        private static long mFrequency;
        

        //Constuctors
        static HighResolutionTime()
        {
            QueryPerformanceFrequency(out mFrequency);
        }
        

        // Methods added here
        public static void Start()
        {
            QueryPerformanceCounter(out mStartCounter);
        }

        //gets the time taken
        public static double GetTime()
        {
            long endCounter;
            QueryPerformanceCounter(out endCounter);
            long elapsed = endCounter - mStartCounter;
            return (double) elapsed / mFrequency;
        }
        
    }
}

