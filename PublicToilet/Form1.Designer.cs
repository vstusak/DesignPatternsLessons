
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
            this.label1 = new System.Windows.Forms.Label();
            this.openDoor = new System.Windows.Forms.Button();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 686);
            this.Controls.Add(this.openDoor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.swipeCardButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button swipeCardButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openDoor;
    }
}

