
namespace _CurveDrawer
{
    partial class CurveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurveForm));
            this.btnCurveLength = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblXY = new System.Windows.Forms.Label();
            this.cboxPointColor = new System.Windows.Forms.ComboBox();
            this.cboxLineColor = new System.Windows.Forms.ComboBox();
            this.pnlDrawing = new System.Windows.Forms.Panel();
            this.lblPointerColor = new System.Windows.Forms.Label();
            this.lblLineColor = new System.Windows.Forms.Label();
            this.lblDrawingArea = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCurveLength
            // 
            this.btnCurveLength.Location = new System.Drawing.Point(39, 52);
            this.btnCurveLength.Name = "btnCurveLength";
            this.btnCurveLength.Size = new System.Drawing.Size(70, 70);
            this.btnCurveLength.TabIndex = 0;
            this.btnCurveLength.Text = "Calculate Curve Length";
            this.btnCurveLength.UseVisualStyleBackColor = true;
            this.btnCurveLength.Click += new System.EventHandler(this.btnCurveLength_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(678, 52);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 70);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblXY
            // 
            this.lblXY.AutoSize = true;
            this.lblXY.Location = new System.Drawing.Point(571, 9);
            this.lblXY.Name = "lblXY";
            this.lblXY.Size = new System.Drawing.Size(30, 13);
            this.lblXY.TabIndex = 2;
            this.lblXY.Text = "X: Y:";
            // 
            // cboxPointColor
            // 
            this.cboxPointColor.FormattingEnabled = true;
            this.cboxPointColor.Items.AddRange(new object[] {
            "Black",
            "Red",
            "Blue"});
            this.cboxPointColor.Location = new System.Drawing.Point(12, 25);
            this.cboxPointColor.Name = "cboxPointColor";
            this.cboxPointColor.Size = new System.Drawing.Size(124, 21);
            this.cboxPointColor.TabIndex = 3;
            this.cboxPointColor.SelectedIndexChanged += new System.EventHandler(this.cboxPointColor_SelectedIndexChanged);
            // 
            // cboxLineColor
            // 
            this.cboxLineColor.FormattingEnabled = true;
            this.cboxLineColor.Items.AddRange(new object[] {
            "Black",
            "Red",
            "Blue"});
            this.cboxLineColor.Location = new System.Drawing.Point(648, 25);
            this.cboxLineColor.Name = "cboxLineColor";
            this.cboxLineColor.Size = new System.Drawing.Size(124, 21);
            this.cboxLineColor.TabIndex = 4;
            this.cboxLineColor.SelectedIndexChanged += new System.EventHandler(this.cboxLineColor_SelectedIndexChanged);
            // 
            // pnlDrawing
            // 
            this.pnlDrawing.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pnlDrawing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlDrawing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDrawing.Location = new System.Drawing.Point(142, 24);
            this.pnlDrawing.Name = "pnlDrawing";
            this.pnlDrawing.Size = new System.Drawing.Size(500, 500);
            this.pnlDrawing.TabIndex = 5;
            this.pnlDrawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDrawing_MouseDown);
            this.pnlDrawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDrawing_MouseMove);
            // 
            // lblPointerColor
            // 
            this.lblPointerColor.AutoSize = true;
            this.lblPointerColor.Location = new System.Drawing.Point(9, 9);
            this.lblPointerColor.Name = "lblPointerColor";
            this.lblPointerColor.Size = new System.Drawing.Size(70, 13);
            this.lblPointerColor.TabIndex = 6;
            this.lblPointerColor.Text = "Pointer Color:";
            // 
            // lblLineColor
            // 
            this.lblLineColor.AutoSize = true;
            this.lblLineColor.Location = new System.Drawing.Point(648, 9);
            this.lblLineColor.Name = "lblLineColor";
            this.lblLineColor.Size = new System.Drawing.Size(57, 13);
            this.lblLineColor.TabIndex = 7;
            this.lblLineColor.Text = "Line Color:";
            // 
            // lblDrawingArea
            // 
            this.lblDrawingArea.AutoSize = true;
            this.lblDrawingArea.Location = new System.Drawing.Point(139, 9);
            this.lblDrawingArea.Name = "lblDrawingArea";
            this.lblDrawingArea.Size = new System.Drawing.Size(74, 13);
            this.lblDrawingArea.TabIndex = 8;
            this.lblDrawingArea.Text = "Drawing Area:";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(142, 531);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(132, 13);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "Program has been opened";
            // 
            // CurveForm
            // 
            this.AccessibleName = "CurveForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblDrawingArea);
            this.Controls.Add(this.lblLineColor);
            this.Controls.Add(this.lblPointerColor);
            this.Controls.Add(this.pnlDrawing);
            this.Controls.Add(this.cboxLineColor);
            this.Controls.Add(this.cboxPointColor);
            this.Controls.Add(this.lblXY);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCurveLength);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "CurveForm";
            this.Text = "Curve Drawer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCurveLength;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblXY;
        private System.Windows.Forms.ComboBox cboxPointColor;
        private System.Windows.Forms.ComboBox cboxLineColor;
        private System.Windows.Forms.Panel pnlDrawing;
        private System.Windows.Forms.Label lblPointerColor;
        private System.Windows.Forms.Label lblLineColor;
        private System.Windows.Forms.Label lblDrawingArea;
        private System.Windows.Forms.Label lblProgress;
    }
}