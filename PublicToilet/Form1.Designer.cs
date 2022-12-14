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
            this.components = new System.ComponentModel.Container();
            this.btnSwipeCard = new System.Windows.Forms.Button();
            this.btnLeaveToilet = new System.Windows.Forms.Button();
            this.btnEnterToilet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateObserver = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbObservers = new System.Windows.Forms.ListBox();
            this.toiletV2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveObserver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.toiletV2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSwipeCard
            // 
            this.btnSwipeCard.Location = new System.Drawing.Point(108, 10);
            this.btnSwipeCard.Name = "btnSwipeCard";
            this.btnSwipeCard.Size = new System.Drawing.Size(92, 23);
            this.btnSwipeCard.TabIndex = 0;
            this.btnSwipeCard.Text = "Swipe Card";
            this.btnSwipeCard.UseVisualStyleBackColor = true;
            this.btnSwipeCard.Click += new System.EventHandler(this.btnSwipeCard_Click);
            // 
            // btnLeaveToilet
            // 
            this.btnLeaveToilet.Location = new System.Drawing.Point(205, 10);
            this.btnLeaveToilet.Name = "btnLeaveToilet";
            this.btnLeaveToilet.Size = new System.Drawing.Size(92, 23);
            this.btnLeaveToilet.TabIndex = 1;
            this.btnLeaveToilet.Text = "Leave Toilet";
            this.btnLeaveToilet.UseVisualStyleBackColor = true;
            this.btnLeaveToilet.Click += new System.EventHandler(this.btnLeaveToilet_Click);
            // 
            // btnEnterToilet
            // 
            this.btnEnterToilet.Location = new System.Drawing.Point(10, 10);
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
            this.label1.Location = new System.Drawing.Point(302, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // btnCreateObserver
            // 
            this.btnCreateObserver.Location = new System.Drawing.Point(10, 38);
            this.btnCreateObserver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateObserver.Name = "btnCreateObserver";
            this.btnCreateObserver.Size = new System.Drawing.Size(159, 22);
            this.btnCreateObserver.TabIndex = 4;
            this.btnCreateObserver.Text = "Create new observer";
            this.btnCreateObserver.UseVisualStyleBackColor = true;
            this.btnCreateObserver.Click += new System.EventHandler(this.btnCreateObserver_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 65);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(330, 373);
            this.textBox1.TabIndex = 5;
            // 
            // lbObservers
            // 
            this.lbObservers.FormattingEnabled = true;
            this.lbObservers.ItemHeight = 15;
            this.lbObservers.Location = new System.Drawing.Point(366, 84);
            this.lbObservers.Name = "lbObservers";
            this.lbObservers.Size = new System.Drawing.Size(267, 139);
            this.lbObservers.TabIndex = 6;
            // 
            // toiletV2BindingSource
            // 
            this.toiletV2BindingSource.DataSource = typeof(PublicToilet.ToiletV2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Observers:";
            // 
            // btnRemoveObserver
            // 
            this.btnRemoveObserver.Location = new System.Drawing.Point(175, 38);
            this.btnRemoveObserver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveObserver.Name = "btnRemoveObserver";
            this.btnRemoveObserver.Size = new System.Drawing.Size(165, 22);
            this.btnRemoveObserver.TabIndex = 8;
            this.btnRemoveObserver.Text = "Remove observer";
            this.btnRemoveObserver.UseVisualStyleBackColor = true;
            this.btnRemoveObserver.Click += new System.EventHandler(this.btnRemoveObserver_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemoveObserver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbObservers);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnCreateObserver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnterToilet);
            this.Controls.Add(this.btnLeaveToilet);
            this.Controls.Add(this.btnSwipeCard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.btnCreateObserver_Click);
            ((System.ComponentModel.ISupportInitialize)(this.toiletV2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSwipeCard;
        private Button btnLeaveToilet;
        private Button btnEnterToilet;
        private Button btnCreateObserver;
        private Label label1;
        private TextBox textBox1;
        private ListBox lbObservers;
        private Label label2;
        private BindingSource toiletV2BindingSource;
        private Button btnRemoveObserver;
    }
}