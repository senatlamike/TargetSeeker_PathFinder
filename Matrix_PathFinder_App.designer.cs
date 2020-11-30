using Algorithms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TargetSeeker_PathFinder
{
    public class Matrix_PathFinder_App : System.Windows.Forms.Form
    {
        manualPathFinder.MazeSolver m_Maze;
        int[,] m_iMaze;
        int m_iSize = 20;
        int m_iRowDimensions = 16;
        int m_iColDimensions = 20;
        int iSelectedX, iSelectedY;

        private System.Windows.Forms.ToolStrip ToolStrp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton seekerNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton targetNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.SaveFileDialog SaveDLG;
        private System.Windows.Forms.OpenFileDialog OpenDLG;
        private System.Windows.Forms.ToolStripButton resetForm;
        private System.Windows.Forms.CheckBox ChkDiagonals;
        private System.Windows.Forms.NumericUpDown NumUpDownHeuristic;
        private System.Windows.Forms.Label LblHeuristic;
        private System.Windows.Forms.ComboBox CboFormula;
        private System.Windows.Forms.Label LblFormula;
        private Panel_Matrix matrix_Base;
        private System.Windows.Forms.Button runSearch;
        private System.Windows.Forms.Label timeValue;
        private System.Windows.Forms.Label LblCompletedTime;
        private System.Windows.Forms.CheckBox ChkUseFastPathFinder;
        private System.Windows.Forms.CheckBox ChkReopenCloseNodes;
        private System.Windows.Forms.ToolStripButton addWall;
        private System.Windows.Forms.Button pauseSearch;
        private System.Windows.Forms.Button closeApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.Label AppTitle;
        private System.Windows.Forms.Label runLbl;
        private System.Windows.Forms.Label pauseLbl;
        private System.Windows.Forms.Label closeLbl;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Matrix_PathFinder_App()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Matrix_PathFinder_App));
            this.ToolStrp = new System.Windows.Forms.ToolStrip();
            this.resetForm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.addWall = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.seekerNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.targetNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveDLG = new System.Windows.Forms.SaveFileDialog();
            this.OpenDLG = new System.Windows.Forms.OpenFileDialog();
            this.ChkDiagonals = new System.Windows.Forms.CheckBox();
            this.NumUpDownHeuristic = new System.Windows.Forms.NumericUpDown();
            this.LblHeuristic = new System.Windows.Forms.Label();
            this.CboFormula = new System.Windows.Forms.ComboBox();
            this.LblFormula = new System.Windows.Forms.Label();
            this.runSearch = new System.Windows.Forms.Button();
            this.ChkReopenCloseNodes = new System.Windows.Forms.CheckBox();
            this.ChkUseFastPathFinder = new System.Windows.Forms.CheckBox();
            this.timeValue = new System.Windows.Forms.Label();
            this.LblCompletedTime = new System.Windows.Forms.Label();
            this.pauseSearch = new System.Windows.Forms.Button();
            this.closeApp = new System.Windows.Forms.Button();
            this.AppTitle = new System.Windows.Forms.Label();
            this.matrix_Base = new TargetSeeker_PathFinder.Panel_Matrix();
            this.runLbl = new System.Windows.Forms.Label();
            this.pauseLbl = new System.Windows.Forms.Label();
            this.closeLbl = new System.Windows.Forms.Label();
            this.bFind = new System.Windows.Forms.RadioButton();
            this.ToolStrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownHeuristic)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrp
            // 
            this.ToolStrp.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetForm,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.addWall,
            this.toolStripSeparator7,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.seekerNode,
            this.toolStripSeparator8,
            this.toolStripSeparator6,
            this.toolStripSeparator11,
            this.targetNode,
            this.toolStripSeparator9,
            this.toolStripSeparator10,
            this.toolStripSeparator12});
            this.ToolStrp.Location = new System.Drawing.Point(0, 0);
            this.ToolStrp.Name = "ToolStrp";
            this.ToolStrp.Size = new System.Drawing.Size(660, 25);
            this.ToolStrp.TabIndex = 10;
            this.ToolStrp.Text = "toolStrip1";
            // 
            // resetForm
            // 
            this.resetForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.resetForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetForm.ImageTransparentColor = System.Drawing.Color.Black;
            this.resetForm.Name = "resetForm";
            this.resetForm.Size = new System.Drawing.Size(75, 22);
            this.resetForm.Text = "Refresh Grid";
            this.resetForm.ToolTipText = "New";
            this.resetForm.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // addWall
            // 
            this.addWall.CheckOnClick = true;
            this.addWall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addWall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addWall.Name = "addWall";
            this.addWall.Size = new System.Drawing.Size(109, 22);
            this.addWall.Tag = "0";
            this.addWall.Text = "Select To Add Wall";
            this.addWall.Click += new System.EventHandler(this.Btn_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // seekerNode
            // 
            this.seekerNode.CheckOnClick = true;
            this.seekerNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            
			//color of the seeker node is Magenta
			this.seekerNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seekerNode.Name = "seekerNode";
            this.seekerNode.Size = new System.Drawing.Size(35, 22);
            this.seekerNode.Tag = "Start";
            this.seekerNode.Text = "Start";
            this.seekerNode.Click += new System.EventHandler(this.Btn_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // targetNode
            // 
            this.targetNode.CheckOnClick = true;
            this.targetNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.targetNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.targetNode.Name = "targetNode";
            this.targetNode.Size = new System.Drawing.Size(31, 22);
            this.targetNode.Tag = "End";
            this.targetNode.Text = "End";
            this.targetNode.Click += new System.EventHandler(this.Btn_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // SaveDLG
            // 
            this.SaveDLG.DefaultExt = "astar";
            this.SaveDLG.Filter = "Map files|*.astar";
            this.SaveDLG.RestoreDirectory = true;
            // 
            // OpenDLG
            // 
            this.OpenDLG.DefaultExt = "astar";
            this.OpenDLG.Filter = "Map files|*.astar";
            this.OpenDLG.RestoreDirectory = true;
            // 
            // ChkDiagonals
            // 
            this.ChkDiagonals.AutoSize = true;
            this.ChkDiagonals.Checked = true;
            this.ChkDiagonals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDiagonals.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ChkDiagonals.Location = new System.Drawing.Point(475, 163);
            this.ChkDiagonals.Name = "ChkDiagonals";
            this.ChkDiagonals.Size = new System.Drawing.Size(73, 17);
            this.ChkDiagonals.TabIndex = 13;
            this.ChkDiagonals.Text = "Diagonals";
            this.ChkDiagonals.UseVisualStyleBackColor = true;
            // 
            // NumUpDownHeuristic
            // 
            this.NumUpDownHeuristic.Location = new System.Drawing.Point(610, 118);
            this.NumUpDownHeuristic.Name = "NumUpDownHeuristic";
            this.NumUpDownHeuristic.Size = new System.Drawing.Size(38, 20);
            this.NumUpDownHeuristic.TabIndex = 15;
            this.NumUpDownHeuristic.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // LblHeuristic
            // 
            this.LblHeuristic.AutoSize = true;
            this.LblHeuristic.BackColor = System.Drawing.Color.Transparent;
            this.LblHeuristic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LblHeuristic.Location = new System.Drawing.Point(600, 101);
            this.LblHeuristic.Name = "LblHeuristic";
            this.LblHeuristic.Size = new System.Drawing.Size(48, 13);
            this.LblHeuristic.TabIndex = 16;
            this.LblHeuristic.Text = "Heuristic";
            this.LblHeuristic.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CboFormula
            // 
            this.CboFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboFormula.FormattingEnabled = true;
            this.CboFormula.Items.AddRange(new object[] {
            
			//Manhattan is the straight line distance
			"Manhattan",
            "Max(DX,DY)",
            "Diagonal Shortcut",
            "Euclidean",
            "Euclidean No SQR",
            "Custom"});
            this.CboFormula.Location = new System.Drawing.Point(478, 306);
            this.CboFormula.Name = "CboFormula";
            this.CboFormula.Size = new System.Drawing.Size(137, 21);
            this.CboFormula.TabIndex = 18;
            this.CboFormula.SelectedIndexChanged += new System.EventHandler(this.CboFormula_SelectedIndexChanged);
            // 
            // LblFormula
            // 
            this.LblFormula.AutoSize = true;
            this.LblFormula.BackColor = System.Drawing.Color.Transparent;
            this.LblFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LblFormula.Location = new System.Drawing.Point(521, 290);
            this.LblFormula.Name = "LblFormula";
            this.LblFormula.Size = new System.Drawing.Size(44, 13);
            this.LblFormula.TabIndex = 19;
            this.LblFormula.Text = "Formula";
            this.LblFormula.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // runSearch
            // 
            this.runSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("runSearch.BackgroundImage")));
            this.runSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.runSearch.Location = new System.Drawing.Point(15, 101);
            this.runSearch.Name = "runSearch";
            this.runSearch.Size = new System.Drawing.Size(144, 37);
            this.runSearch.TabIndex = 22;
            this.runSearch.UseVisualStyleBackColor = true;
            this.runSearch.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // ChkReopenCloseNodes
            // 
            this.ChkReopenCloseNodes.Checked = true;
            this.ChkReopenCloseNodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkReopenCloseNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ChkReopenCloseNodes.Location = new System.Drawing.Point(475, 202);
            this.ChkReopenCloseNodes.Name = "ChkReopenCloseNodes";
            this.ChkReopenCloseNodes.Size = new System.Drawing.Size(140, 20);
            this.ChkReopenCloseNodes.TabIndex = 31;
            this.ChkReopenCloseNodes.Text = "Reopen Closed Nodes";
            this.ChkReopenCloseNodes.UseVisualStyleBackColor = true;
            // 
            // ChkUseFastPathFinder
            // 
            this.ChkUseFastPathFinder.Checked = true;
            this.ChkUseFastPathFinder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkUseFastPathFinder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ChkUseFastPathFinder.Location = new System.Drawing.Point(478, 242);
            this.ChkUseFastPathFinder.Name = "ChkUseFastPathFinder";
            this.ChkUseFastPathFinder.Size = new System.Drawing.Size(137, 20);
            this.ChkUseFastPathFinder.TabIndex = 30;
            this.ChkUseFastPathFinder.Text = "Fast PathFinder";
            this.ChkUseFastPathFinder.UseVisualStyleBackColor = true;
            // 
            // timeValue
            // 
            this.timeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeValue.BackColor = System.Drawing.Color.Transparent;
            this.timeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeValue.Location = new System.Drawing.Point(512, 60);
            this.timeValue.Margin = new System.Windows.Forms.Padding(0);
            this.timeValue.Name = "timeValue";
            this.timeValue.Size = new System.Drawing.Size(68, 23);
            this.timeValue.TabIndex = 28;
            this.timeValue.Text = "0:000:0";
            // 
            // LblCompletedTime
            // 
            this.LblCompletedTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCompletedTime.AutoSize = true;
            this.LblCompletedTime.BackColor = System.Drawing.Color.Transparent;
            this.LblCompletedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompletedTime.Location = new System.Drawing.Point(455, 38);
            this.LblCompletedTime.Name = "LblCompletedTime";
            this.LblCompletedTime.Size = new System.Drawing.Size(205, 22);
            this.LblCompletedTime.TabIndex = 27;
            this.LblCompletedTime.Text = "Time Taken In Seconds:";
            // 
            // pauseSearch
            // 
            this.pauseSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pauseSearch.BackgroundImage")));
            this.pauseSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pauseSearch.Location = new System.Drawing.Point(165, 101);
            this.pauseSearch.Name = "pauseSearch";
            this.pauseSearch.Size = new System.Drawing.Size(144, 37);
            this.pauseSearch.TabIndex = 32;
            this.pauseSearch.UseVisualStyleBackColor = true;
            // 
            // closeApp
            // 
            this.closeApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeApp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeApp.BackgroundImage")));
            this.closeApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeApp.Location = new System.Drawing.Point(315, 101);
            this.closeApp.Name = "closeApp";
            this.closeApp.Size = new System.Drawing.Size(144, 37);
            this.closeApp.TabIndex = 33;
            this.closeApp.UseVisualStyleBackColor = true;
            // 
            // AppTitle
            // 
            this.AppTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AppTitle.AutoSize = true;
            this.AppTitle.BackColor = System.Drawing.Color.Transparent;
            this.AppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppTitle.Location = new System.Drawing.Point(62, 38);
            this.AppTitle.Name = "AppTitle";
            this.AppTitle.Size = new System.Drawing.Size(387, 29);
            this.AppTitle.TabIndex = 35;
            this.AppTitle.Text = "TargetSeeker PathFinding App";
            // 
            // matrix_Base
            // 
            this.matrix_Base.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matrix_Base.BackColor = System.Drawing.Color.White;
            this.matrix_Base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matrix_Base.DrawModeSetup = TargetSeeker_PathFinder.DrawModeSetup.None;
            this.matrix_Base.End = new System.Drawing.Point(0, 0);
            this.matrix_Base.Formula = Algorithms.HeuristicFormula.Manhattan;
            this.matrix_Base.GridSize = 20;
            this.matrix_Base.Location = new System.Drawing.Point(12, 154);
            this.matrix_Base.Name = "matrix_Base";
            this.matrix_Base.NodeWeight = ((byte)(1));
            this.matrix_Base.Size = new System.Drawing.Size(447, 301);
            this.matrix_Base.Start = new System.Drawing.Point(0, 0);
            this.matrix_Base.TabIndex = 21;
            // 
            // runLbl
            // 
            this.runLbl.AutoSize = true;
            this.runLbl.BackColor = System.Drawing.Color.Transparent;
            this.runLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.runLbl.Location = new System.Drawing.Point(64, 74);
            this.runLbl.Name = "runLbl";
            this.runLbl.Size = new System.Drawing.Size(51, 25);
            this.runLbl.TabIndex = 36;
            this.runLbl.Text = "Run";
            this.runLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pauseLbl
            // 
            this.pauseLbl.AutoSize = true;
            this.pauseLbl.BackColor = System.Drawing.Color.Transparent;
            this.pauseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.pauseLbl.Location = new System.Drawing.Point(195, 73);
            this.pauseLbl.Name = "pauseLbl";
            this.pauseLbl.Size = new System.Drawing.Size(73, 25);
            this.pauseLbl.TabIndex = 37;
            this.pauseLbl.Text = "Pause";
            this.pauseLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // closeLbl
            // 
            this.closeLbl.AutoSize = true;
            this.closeLbl.BackColor = System.Drawing.Color.Transparent;
            this.closeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.closeLbl.Location = new System.Drawing.Point(346, 74);
            this.closeLbl.Name = "closeLbl";
            this.closeLbl.Size = new System.Drawing.Size(67, 25);
            this.closeLbl.TabIndex = 38;
            this.closeLbl.Text = "Close";
            this.closeLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bFind
            // 
            this.bFind.BackColor = System.Drawing.Color.Transparent;
            this.bFind.Location = new System.Drawing.Point(475, 107);
            this.bFind.Name = "bFind";
            this.bFind.Size = new System.Drawing.Size(104, 24);
            this.bFind.TabIndex = 39;
            this.bFind.Text = "Find Path";
            this.bFind.UseVisualStyleBackColor = false;
            // 
            // Matrix_PathFinder_App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(660, 488);
            this.Controls.Add(this.bFind);
            this.Controls.Add(this.closeLbl);
            this.Controls.Add(this.pauseLbl);
            this.Controls.Add(this.runLbl);
            this.Controls.Add(this.ChkReopenCloseNodes);
            this.Controls.Add(this.AppTitle);
            this.Controls.Add(this.LblHeuristic);
            this.Controls.Add(this.NumUpDownHeuristic);
            this.Controls.Add(this.LblFormula);
            this.Controls.Add(this.ChkDiagonals);
            this.Controls.Add(this.ChkUseFastPathFinder);
            this.Controls.Add(this.CboFormula);
            this.Controls.Add(this.closeApp);
            this.Controls.Add(this.pauseSearch);
            this.Controls.Add(this.timeValue);
            this.Controls.Add(this.LblCompletedTime);
            this.Controls.Add(this.runSearch);
            this.Controls.Add(this.matrix_Base);
            this.Controls.Add(this.ToolStrp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 527);
            this.Name = "Matrix_PathFinder_App";
            this.Text = "PathFinder Application";
            this.ToolStrp.ResumeLayout(false);
            this.ToolStrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownHeuristic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.Run(new Matrix_PathFinder_App());
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show("An unhandled exception '" + exp.Message + "' has occurred. \nPlease tell me at smehrozalam@yahoo.com so that I can fix this bug. Thank you", "Error");
            }
        }
        
        private void Form1_Load(object sender, System.EventArgs e)
        {
            m_Maze = new manualPathFinder.MazeSolver(m_iRowDimensions, m_iColDimensions);
            this.matrix_Base.Size = new System.Drawing.Size(m_iColDimensions * m_iSize + 3, m_iRowDimensions * m_iSize + 3);
            m_iMaze = m_Maze.GetMaze;
        }

        private void matrix_Base_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics myGraphics = e.Graphics;
            for (int i = 0; i < m_iRowDimensions; i++)
                for (int j = 0; j < m_iColDimensions; j++)
                {
                    // print grids
                    myGraphics.DrawRectangle(new Pen(Color.Black), j * m_iSize, i * m_iSize, m_iSize, m_iSize);
                    
                    // print walls
                    if (m_iMaze[i, j] == 1)
                        myGraphics.FillRectangle(new SolidBrush(Color.DarkGray), j * m_iSize + 1, i * m_iSize + 1, m_iSize - 1, m_iSize - 1);
                    
                    //print path
                    if (m_iMaze[i, j] == 100)
                        myGraphics.FillRectangle(new SolidBrush(Color.Cyan), j * m_iSize + 1, i * m_iSize + 1, m_iSize - 1, m_iSize - 1);
                }
            //print ball
            myGraphics.FillEllipse(new SolidBrush(Color.DarkCyan), this.iSelectedX * m_iSize + 5, this.iSelectedY * m_iSize + 5, m_iSize - 10, m_iSize - 10);

        }

        //mouse event method
        private void matrix_Base_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int iX = e.X / m_iSize;
            int iY = e.Y / m_iSize;
            if (iX < m_iColDimensions && iX >= 0 && iY < m_iRowDimensions && iY >= 0)
            {
                if (this.addWall.Checked == true)
                {	
					//walls can be added along the Y-Axis and the X-Axis
                    m_iMaze = m_Maze.GetMaze;
                    if (m_iMaze[iY, iX] == 0)
                        m_iMaze[iY, iX] = 1;
                    else
                        m_iMaze[iY, iX] = 0;
					//refreshing the grid to have no walls
                    this.Refresh();
                }
                else
                {
                    if (m_iMaze[iY, iX] == 100)	//if path exists
                    {
                        //move step by step until the required position is achieved
                        while (this.iSelectedX != iX || this.iSelectedY != iY)
                        {
                            m_iMaze[this.iSelectedY, this.iSelectedX] = 0;

                            if (this.iSelectedX - 1 >= 0 && this.iSelectedX - 1 < m_iColDimensions && m_iMaze[this.iSelectedY, this.iSelectedX - 1] == 100)
                                this.iSelectedX--;
                            else if (this.iSelectedX + 1 >= 0 && this.iSelectedX + 1 < m_iColDimensions && m_iMaze[this.iSelectedY, this.iSelectedX + 1] == 100)
                                this.iSelectedX++;
                            else if (this.iSelectedY - 1 >= 0 && this.iSelectedY - 1 < m_iRowDimensions && m_iMaze[this.iSelectedY - 1, this.iSelectedX] == 100)
                                this.iSelectedY--;
                            else if (this.iSelectedY + 1 >= 0 && this.iSelectedY + 1 < m_iRowDimensions && m_iMaze[this.iSelectedY + 1, this.iSelectedX] == 100)
                                this.iSelectedY++;

                            // move diagonal
                            else if (this.iSelectedY + 1 >= 0 && this.iSelectedY + 1 < m_iRowDimensions && this.iSelectedX + 1 >= 0 && this.iSelectedX + 1 < m_iColDimensions && m_iMaze[this.iSelectedY + 1, this.iSelectedX + 1] == 100)
                            { this.iSelectedX++; this.iSelectedY++; }
                            else if (this.iSelectedY - 1 >= 0 && this.iSelectedY - 1 < m_iRowDimensions && this.iSelectedX + 1 >= 0 && this.iSelectedX + 1 < m_iColDimensions && m_iMaze[this.iSelectedY - 1, this.iSelectedX + 1] == 100)
                            { this.iSelectedX++; this.iSelectedY--; }
                            else if (this.iSelectedY + 1 >= 0 && this.iSelectedY + 1 < m_iRowDimensions && this.iSelectedX - 1 >= 0 && this.iSelectedX - 1 < m_iColDimensions && m_iMaze[this.iSelectedY + 1, this.iSelectedX - 1] == 100)
                            { this.iSelectedX--; this.iSelectedY++; }
                            else if (this.iSelectedY - 1 >= 0 && this.iSelectedY - 1 < m_iRowDimensions && this.iSelectedX - 1 >= 0 && this.iSelectedX - 1 < m_iColDimensions && m_iMaze[this.iSelectedY - 1, this.iSelectedX - 1] == 100)
                            { this.iSelectedX--; this.iSelectedY--; }

                            this.Refresh();
                        }
                    }
                }

            }
        }

        private void matrix_Base_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int iY = e.Y / m_iSize;
            int iX = e.X / m_iSize;
            if (iX < m_iColDimensions && iX >= 0 && iY < m_iRowDimensions && iY >= 0)
            {
                m_iMaze = m_Maze.GetMaze;
                if (this.addWall.Checked == false)
                {
                    int[,] iSolvedMaze = m_Maze.FindPath(iSelectedY, iSelectedX, iY, iX);
                    if (iSolvedMaze != null)
                    {
                        m_iMaze = iSolvedMaze;
                        //this.lblPath.Text = "" + iSelectedY + "," + iSelectedX + " to " + iY + "," + iX;
                    }

                    else
                        //this.lblPath.Text = "No Path Found";
                    this.Refresh();
                }
            }
        }

        private void addWall_CheckedChanged(object sender, System.EventArgs e)
        {
            m_iMaze = m_Maze.GetMaze;
            this.Refresh();
        }

        private void bFind_CheckedChanged(object sender, System.EventArgs e)
        {
            this.m_Maze.AllowDiagonals = this.ChkDiagonals.Checked;
        }

        private void cmdReset_Click(object sender, System.EventArgs e)
        {
            m_Maze = new manualPathFinder.MazeSolver(m_iRowDimensions, m_iColDimensions);
            m_Maze.AllowDiagonals = this.ChkDiagonals.Checked;
            m_iMaze = m_Maze.GetMaze;
            this.Refresh();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            MessageBox.Show("Path Found");
        }

        private void cmdExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ChkDiagonals_CheckedChanged(object sender, System.EventArgs e)
        {
            m_Maze.AllowDiagonals = ChkDiagonals.Checked;
        }

        private RadioButton bFind;


    }



}
