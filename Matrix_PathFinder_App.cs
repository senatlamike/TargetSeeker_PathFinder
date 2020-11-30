using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Algorithms;
using System.Globalization;

namespace TargetSeeker_PathFinder
{
    //inheritance
    public class Matrix_PathFinder_App : Form
    {
        // Constants Declaration
        private const string STOP       = "";
        private const string RUN        = "";
        private const string PAUSE      = "";
        private const string CONTINUE   = "Continue";

        private const string NODE_START = "Start";
        private const string NODE_END   = "End";
        private const string NODE_X     = "X";
        

        // Variables Declaration
        private Thread      mPFThread   = null;
        private IPathFinder mPathFinder = null;
        //private int         mDelay;
        private bool        mPaused;
        private bool        mRunning;
        

        // Constuctors
        public Matrix_PathFinder_App()
        {
            InitializeComponent();

            CboFormula.SelectedIndex    = 0;
            runSearch.Text           = RUN;
            pauseSearch.Text               = PAUSE;
            seekerNode.Text               = NODE_START;
            targetNode.Text                 = NODE_END;
        }
        

        // PathFinder Events
        private delegate void PathFinderDebugDelegate(int parentX, int parentY, int x, int y, PathFinderNodeType type, int totalCost, int cost);
        private void PathFinderDebug(int parentX, int parentY, int x, int y, PathFinderNodeType type, int totalCost, int cost)
        {
            if (InvokeRequired)
            {
                while(mPaused)
                    Thread.Sleep(100);

                Invoke(new PathFinderDebugDelegate(PathFinderDebug), new object[]{parentX, parentY, x, y, type, totalCost, cost});
                return;
            }

            matrix_Base.DrawDebug(parentX, parentY, x, y, type, totalCost, cost);
        }
        

        // Methods
        public void Run()
        {
            matrix_Base.Refresh();
            runSearch.Text   = STOP;
            ToolStrp.Enabled    = false;
            pauseSearch.Enabled    = true;

            mPFThread = new Thread(new ThreadStart(RunPathFinder));
            mPFThread.Name = "Path Finder Thread";
            mPFThread.Start();
        }

        public void Stop()
        {
            if (mPathFinder != null)
                mPathFinder.FindPathStop();

            mPFThread.Abort();
            
            mPaused             = false;
            runSearch.Text   = RUN;
            pauseSearch.Text       = PAUSE;
            ToolStrp.Enabled    = true;
            pauseSearch.Enabled    = false;
        }

        private delegate void UpdateTimeLabelDelegate(double time);
        private void UpdateTimeLabel(double time)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateTimeLabelDelegate(UpdateTimeLabel), new object[]{time});
                return;
            }

            timeValue.Text = time.ToString("N4");
        }


        public void RunPathFinder()
        {
            if (ChkUseFastPathFinder.Checked)
            {
                if (!(mPathFinder is PathFinderFast))
                {
                    if (mPathFinder != null)
                        mPathFinder.PathFinderDebug -= new PathFinderDebugHandler(PathFinderDebug);

                    mPathFinder = new PathFinderFast(matrix_Base.Matrix);
                    mPathFinder.PathFinderDebug += new PathFinderDebugHandler(PathFinderDebug);
                }
            }
            else
            {
                if (!(mPathFinder is PathFinder))
                {
                    if (mPathFinder != null)
                        mPathFinder.PathFinderDebug -= new PathFinderDebugHandler(PathFinderDebug);

                    mPathFinder = new PathFinder(matrix_Base.Matrix);
                    mPathFinder.PathFinderDebug += new PathFinderDebugHandler(PathFinderDebug);
                }
            }

            mPathFinder.Formula                 = matrix_Base.Formula;
            mPathFinder.Diagonals               = ChkDiagonals.Checked;
            mPathFinder.HeuristicEstimate       = (int) NumUpDownHeuristic.Value;
            mPathFinder.ReopenCloseNodes        = ChkReopenCloseNodes.Checked;
            mPathFinder.DebugFoundPath          = true;

            List<PathFinderNode> path = mPathFinder.FindPath(matrix_Base.Start, matrix_Base.End);
            UpdateTimeLabel(mPathFinder.CompletedTime);

            if (path == null)
                MessageBox.Show("Path Not Found");

            if (runSearch.Text == STOP)
                BtnStartStop_Click(null, EventArgs.Empty);
        }
        

        // Events
        private void TBarGridSize_Scroll(object sender, EventArgs e)
        {
            
        }

        private delegate void BtnStartStop_ClickDelegate(object sender, EventArgs e);
        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new BtnStartStop_ClickDelegate(BtnStartStop_Click), new object[]{sender, e});
                return;
            }

            if (!mRunning)
                Run();
            else
                Stop();
            mRunning = !mRunning;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (!mPaused)
                pauseSearch.Text = CONTINUE;
            else
                pauseSearch.Text = PAUSE;
            mPaused = !mPaused;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton) sender;
            foreach(ToolStripItem item in ToolStrp.Items)
            {
                ToolStripButton toolButton = item as ToolStripButton;
                if (toolButton != null && toolButton.CheckOnClick)
                    toolButton.Checked = false;
            }
            btn.Checked = true;

            string text = btn.Tag as string;
            if (text == NODE_START)
                matrix_Base.DrawModeSetup = DrawModeSetup.Start;
            else if (text == NODE_END)
                matrix_Base.DrawModeSetup = DrawModeSetup.End;
            else if (text == NODE_X)
            {
                matrix_Base.NodeWeight = 0;
                matrix_Base.DrawModeSetup = DrawModeSetup.Block;
            }
            else
            {
                matrix_Base.NodeWeight = byte.Parse(text);
                matrix_Base.DrawModeSetup = DrawModeSetup.Block;
            }
        }

        private void CboFormula_SelectedIndexChanged(object sender, EventArgs e)
        {
            matrix_Base.Formula = (HeuristicFormula) CboFormula.SelectedIndex + 1;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            matrix_Base.ResetMatrix();
            matrix_Base.Invalidate();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveDLG.InitialDirectory = Application.StartupPath;

            if (SaveDLG.ShowDialog(this) == DialogResult.OK)
            {
                if (SaveDLG.FileName.Length == 0)
                    return;

                FileStream fs = new FileStream(SaveDLG.FileName, FileMode.Create, FileAccess.Write);
 
                fs.WriteByte((byte) (matrix_Base.Start.X >> 8));
                fs.WriteByte((byte) (matrix_Base.Start.X & 0x000000FF));
                fs.WriteByte((byte) (matrix_Base.Start.Y >> 8));
                fs.WriteByte((byte) (matrix_Base.Start.Y & 0x000000FF));
                fs.WriteByte((byte) (matrix_Base.End.X >> 8));
                fs.WriteByte((byte) (matrix_Base.End.X & 0x000000FF));
                fs.WriteByte((byte) (matrix_Base.End.Y >> 8));
                fs.WriteByte((byte) (matrix_Base.End.Y & 0x000000FF));
                fs.WriteByte((byte) (ChkDiagonals.Checked ? 1 : 0));   
                fs.WriteByte((byte) (ChkReopenCloseNodes.Checked ? 1 : 0));
                fs.WriteByte((byte) NumUpDownHeuristic.Value);
                fs.WriteByte((byte) CboFormula.SelectedIndex);
                
                for(int y=0;y<1000; y++)
                    for(int x=0;x<1000; x++)
                        fs.WriteByte(matrix_Base.Matrix[x,y]);

                fs.Close();
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (OpenDLG.ShowDialog(this) == DialogResult.OK)
            {
                if (OpenDLG.FileName.Length == 0)
                    return;

                FileStream fs = new FileStream(OpenDLG.FileName, FileMode.Open, FileAccess.Read);
                if (fs.Length != 1000021)
                {
                    MessageBox.Show(this, "Invalid File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                matrix_Base.DrawModeSetup= DrawModeSetup.None;
                foreach(ToolStripItem item in ToolStrp.Items)
                {
                    if (item is ToolStripButton)
                        ((ToolStripButton) item).Checked = false;
                }

                matrix_Base.Start            = new Point(fs.ReadByte() << 8 | fs.ReadByte(), fs.ReadByte() << 8 | fs.ReadByte());
                matrix_Base.End              = new Point(fs.ReadByte() << 8 | fs.ReadByte(), fs.ReadByte() << 8 | fs.ReadByte());
                ChkDiagonals.Checked    = fs.ReadByte() > 0;
                ChkReopenCloseNodes.Checked         = fs.ReadByte() > 0;
                NumUpDownHeuristic.Value= fs.ReadByte();
                CboFormula.SelectedIndex= fs.ReadByte();

                for(int y=0;y<1000; y++)
                    for(int x=0;x<1000; x++)
                        matrix_Base.Matrix[x,y] = (byte) fs.ReadByte();

                fs.Close();    
                matrix_Base.Invalidate();
            }

        }
        

        // Overrides
        protected override void OnClosing(CancelEventArgs e)
        {
            if (runSearch.Text == STOP)
                BtnStartStop_Click(null, EventArgs.Empty);
            base.OnClosing(e);
        }
        

        //closing the app
        private void closeApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}