
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
            this.SuspendLayout();
            // 
            // swipeCardButton
            // 
            this.swipeCardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.swipeCardButton.Location = new System.Drawing.Point(38, 50);
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
            this.DisplayLabel.Location = new System.Drawing.Point(180, 60);
            this.DisplayLabel.Name = "DisplayLabel";
            this.DisplayLabel.Size = new System.Drawing.Size(50, 20);
            this.DisplayLabel.TabIndex = 1;
            this.DisplayLabel.Text = "label1";
            // 
            // openDoor
            // 
            this.openDoor.Location = new System.Drawing.Point(38, 112);
            this.openDoor.Name = "openDoor";
            this.openDoor.Size = new System.Drawing.Size(117, 39);
            this.openDoor.TabIndex = 2;
            this.openDoor.Text = "Open Door";
            this.openDoor.UseVisualStyleBackColor = true;
            this.openDoor.Click += new System.EventHandler(this.openDoor_Click);
            // 
            // LeaveToiletButton
            // 
            this.LeaveToiletButton.Location = new System.Drawing.Point(38, 177);
            this.LeaveToiletButton.Name = "LeaveToiletButton";
            this.LeaveToiletButton.Size = new System.Drawing.Size(117, 29);
            this.LeaveToiletButton.TabIndex = 3;
            this.LeaveToiletButton.Text = "Leave Toilet";
            this.LeaveToiletButton.UseVisualStyleBackColor = true;
            this.LeaveToiletButton.Click += new System.EventHandler(this.LeaveToiletButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 686);
            this.Controls.Add(this.LeaveToiletButton);
            this.Controls.Add(this.openDoor);
            this.Controls.Add(this.DisplayLabel);
            this.Controls.Add(this.swipeCardButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button swipeCardButton;
        private System.Windows.Forms.Label DisplayLabel;
        private System.Windows.Forms.Button openDoor;
        private System.Windows.Forms.Button LeaveToiletButton;
    }
}

