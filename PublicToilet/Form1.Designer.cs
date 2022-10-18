
namespace PublicToilet
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.swipeCardButton = new System.Windows.Forms.Button();
            this.DisplayLabel = new System.Windows.Forms.Label();
            this.openDoor = new System.Windows.Forms.Button();
            this.LeaveToiletButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EnableLogging = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // swipeCardButton
            // 
            this.swipeCardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.swipeCardButton.Location = new System.Drawing.Point(49, 63);
            this.swipeCardButton.Name = "swipeCardButton";
            this.swipeCardButton.Size = new System.Drawing.Size(117, 40);
            this.swipeCardButton.TabIndex = 0;
            this.swipeCardButton.Text = "Swipe Card";
            this.swipeCardButton.UseVisualStyleBackColor = true;
            this.swipeCardButton.Click += new System.EventHandler(this.swipeCardButton_Click);
            // 
            // DisplayLabel
            // 
            this.DisplayLabel.AutoSize = true;
            this.DisplayLabel.Location = new System.Drawing.Point(173, 73);
            this.DisplayLabel.Name = "DisplayLabel";
            this.DisplayLabel.Size = new System.Drawing.Size(50, 20);
            this.DisplayLabel.TabIndex = 1;
            this.DisplayLabel.Text = "label1";
            // 
            // openDoor
            // 
            this.openDoor.Location = new System.Drawing.Point(49, 124);
            this.openDoor.Name = "openDoor";
            this.openDoor.Size = new System.Drawing.Size(117, 39);
            this.openDoor.TabIndex = 2;
            this.openDoor.Text = "Open Door";
            this.openDoor.UseVisualStyleBackColor = true;
            this.openDoor.Click += new System.EventHandler(this.openDoor_Click);
            // 
            // LeaveToiletButton
            // 
            this.LeaveToiletButton.Location = new System.Drawing.Point(49, 189);
            this.LeaveToiletButton.Name = "LeaveToiletButton";
            this.LeaveToiletButton.Size = new System.Drawing.Size(117, 29);
            this.LeaveToiletButton.TabIndex = 3;
            this.LeaveToiletButton.Text = "Leave Toilet";
            this.LeaveToiletButton.UseVisualStyleBackColor = true;
            this.LeaveToiletButton.Click += new System.EventHandler(this.LeaveToiletButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.swipeCardButton);
            this.groupBox1.Controls.Add(this.DisplayLabel);
            this.groupBox1.Controls.Add(this.LeaveToiletButton);
            this.groupBox1.Controls.Add(this.openDoor);
            this.groupBox1.Location = new System.Drawing.Point(31, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(279, 256);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User section";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EnableLogging);
            this.groupBox2.Location = new System.Drawing.Point(31, 341);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(279, 281);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Admin section";
            // 
            // EnableLogging
            // 
            this.EnableLogging.Location = new System.Drawing.Point(27, 51);
            this.EnableLogging.Name = "EnableLogging";
            this.EnableLogging.Size = new System.Drawing.Size(139, 29);
            this.EnableLogging.TabIndex = 0;
            this.EnableLogging.Text = "EnableLogging";
            this.EnableLogging.UseVisualStyleBackColor = true;
            this.EnableLogging.Click += new System.EventHandler(this.EnableLogging_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(334, 35);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(499, 588);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(25, 325);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(421, 241);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 43);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(421, 212);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 685);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button swipeCardButton;
        private System.Windows.Forms.Label DisplayLabel;
        private System.Windows.Forms.Button openDoor;
        private System.Windows.Forms.Button LeaveToiletButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button EnableLogging;
    }
}

