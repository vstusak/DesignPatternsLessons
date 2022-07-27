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
            this.btnSwipeCard = new System.Windows.Forms.Button();
            this.btnLeaveToilet = new System.Windows.Forms.Button();
            this.btnEnterToilet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSwipeCard
            // 
            this.btnSwipeCard.Location = new System.Drawing.Point(386, 287);
            this.btnSwipeCard.Name = "btnSwipeCard";
            this.btnSwipeCard.Size = new System.Drawing.Size(92, 23);
            this.btnSwipeCard.TabIndex = 0;
            this.btnSwipeCard.Text = "Swipe Card";
            this.btnSwipeCard.UseVisualStyleBackColor = true;
            this.btnSwipeCard.Click += new System.EventHandler(this.btnSwipeCard_Click);
            // 
            // btnLeaveToilet
            // 
            this.btnLeaveToilet.Location = new System.Drawing.Point(386, 316);
            this.btnLeaveToilet.Name = "btnLeaveToilet";
            this.btnLeaveToilet.Size = new System.Drawing.Size(92, 23);
            this.btnLeaveToilet.TabIndex = 1;
            this.btnLeaveToilet.Text = "Leave Toilet";
            this.btnLeaveToilet.UseVisualStyleBackColor = true;
            this.btnLeaveToilet.Click += new System.EventHandler(this.btnLeaveToilet_Click);
            // 
            // btnEnterToilet
            // 
            this.btnEnterToilet.Location = new System.Drawing.Point(386, 258);
            this.btnEnterToilet.Name = "btnEnterToilet";
            this.btnEnterToilet.Size = new System.Drawing.Size(92, 23);
            this.btnEnterToilet.TabIndex = 2;
            this.btnEnterToilet.Text = "Enter Toilet";
            this.btnEnterToilet.UseVisualStyleBackColor = true;
            this.btnEnterToilet.Click += new System.EventHandler(this.btnEnterToilet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnterToilet);
            this.Controls.Add(this.btnLeaveToilet);
            this.Controls.Add(this.btnSwipeCard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSwipeCard;
        private Button btnLeaveToilet;
        private Button btnEnterToilet;
        private Label label1;
        private Label label2;
    }
}