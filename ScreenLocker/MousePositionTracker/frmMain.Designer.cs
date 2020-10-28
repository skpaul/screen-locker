namespace MousePositionTracker
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.lblYPosition = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblXPosition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblYPosition
            // 
            this.lblYPosition.AutoSize = true;
            this.lblYPosition.Location = new System.Drawing.Point(84, 25);
            this.lblYPosition.Name = "lblYPosition";
            this.lblYPosition.Size = new System.Drawing.Size(35, 13);
            this.lblYPosition.TabIndex = 7;
            this.lblYPosition.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y Position :";
            // 
            // lblXPosition
            // 
            this.lblXPosition.AutoSize = true;
            this.lblXPosition.Location = new System.Drawing.Point(84, 7);
            this.lblXPosition.Name = "lblXPosition";
            this.lblXPosition.Size = new System.Drawing.Size(35, 13);
            this.lblXPosition.TabIndex = 5;
            this.lblXPosition.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X Position :";
            // 
            // MyTimer
            // 
            this.MyTimer.Enabled = true;
            this.MyTimer.Interval = 1000;
            this.MyTimer.Tick += new System.EventHandler(this.MyTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 47);
            this.Controls.Add(this.lblYPosition);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblXPosition);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Mouse Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblYPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblXPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer MyTimer;
    }
}

