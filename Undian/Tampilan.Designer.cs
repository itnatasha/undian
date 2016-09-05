namespace Undian
{
    partial class Tampilan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.prize = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblrunning = new System.Windows.Forms.Label();
            this.timerruningtext = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.prize);
            this.panel1.Location = new System.Drawing.Point(13, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 152);
            this.panel1.TabIndex = 2;
            // 
            // prize
            // 
            this.prize.AutoSize = true;
            this.prize.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prize.Location = new System.Drawing.Point(3, 36);
            this.prize.Name = "prize";
            this.prize.Size = new System.Drawing.Size(204, 73);
            this.prize.TabIndex = 0;
            this.prize.Text = "label1";
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Location = new System.Drawing.Point(771, 9);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(14, 13);
            this.exit.TabIndex = 3;
            this.exit.TabStop = true;
            this.exit.Text = "X";
            this.exit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.exit_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblrunning);
            this.panel2.Location = new System.Drawing.Point(9, 514);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 45);
            this.panel2.TabIndex = 4;
            // 
            // lblrunning
            // 
            this.lblrunning.AutoSize = true;
            this.lblrunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrunning.Location = new System.Drawing.Point(1200, 13);
            this.lblrunning.Name = "lblrunning";
            this.lblrunning.Size = new System.Drawing.Size(64, 25);
            this.lblrunning.TabIndex = 0;
            this.lblrunning.Text = "label1";
            // 
            // timerruningtext
            // 
            this.timerruningtext.Enabled = true;
            this.timerruningtext.Tick += new System.EventHandler(this.timerruningtext_Tick);
            // 
            // Tampilan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tampilan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tampilan";
            this.Load += new System.EventHandler(this.timer1_Tick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label prize;
        private System.Windows.Forms.LinkLabel exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblrunning;
        private System.Windows.Forms.Timer timerruningtext;



    }
}