namespace DecoratorPattern
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
            HitEvent = new Button();
            FacebookBox = new CheckBox();
            EmailBox = new CheckBox();
            SlackBox = new CheckBox();
            TinderBox = new CheckBox();
            ChromeBox = new CheckBox();
            output = new TextBox();
            SuspendLayout();
            // 
            // HitEvent
            // 
            HitEvent.Location = new Point(343, 379);
            HitEvent.Name = "HitEvent";
            HitEvent.Size = new Size(75, 23);
            HitEvent.TabIndex = 0;
            HitEvent.Text = "Hit event";
            HitEvent.UseVisualStyleBackColor = true;
            HitEvent.Click += HitEvent_Click;
            // 
            // FacebookBox
            // 
            FacebookBox.AutoSize = true;
            FacebookBox.Location = new Point(566, 79);
            FacebookBox.Name = "FacebookBox";
            FacebookBox.Size = new Size(77, 19);
            FacebookBox.TabIndex = 1;
            FacebookBox.Text = "Facebook";
            FacebookBox.UseVisualStyleBackColor = true;
            FacebookBox.CheckedChanged += FacebookBox_CheckedChanged;
            // 
            // EmailBox
            // 
            EmailBox.AutoSize = true;
            EmailBox.Location = new Point(566, 110);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(55, 19);
            EmailBox.TabIndex = 2;
            EmailBox.Text = "Email";
            EmailBox.UseVisualStyleBackColor = true;
            EmailBox.CheckedChanged += EmailBox_CheckedChanged;
            // 
            // SlackBox
            // 
            SlackBox.AutoSize = true;
            SlackBox.Location = new Point(566, 135);
            SlackBox.Name = "SlackBox";
            SlackBox.Size = new Size(53, 19);
            SlackBox.TabIndex = 3;
            SlackBox.Text = "Slack";
            SlackBox.UseVisualStyleBackColor = true;
            SlackBox.CheckedChanged += SlackBox_CheckedChanged;
            // 
            // TinderBox
            // 
            TinderBox.AutoSize = true;
            TinderBox.Location = new Point(566, 160);
            TinderBox.Name = "TinderBox";
            TinderBox.Size = new Size(59, 19);
            TinderBox.TabIndex = 4;
            TinderBox.Text = "Tinder";
            TinderBox.UseVisualStyleBackColor = true;
            TinderBox.CheckedChanged += TinderBox_CheckedChanged;
            // 
            // ChromeBox
            // 
            ChromeBox.AutoSize = true;
            ChromeBox.Location = new Point(566, 185);
            ChromeBox.Name = "ChromeBox";
            ChromeBox.Size = new Size(69, 19);
            ChromeBox.TabIndex = 5;
            ChromeBox.Text = "Chrome";
            ChromeBox.UseVisualStyleBackColor = true;
            ChromeBox.CheckedChanged += ChromeBox_CheckedChanged;
            // 
            // output
            // 
            output.Location = new Point(81, 46);
            output.Multiline = true;
            output.Name = "output";
            output.Size = new Size(463, 300);
            output.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(output);
            Controls.Add(ChromeBox);
            Controls.Add(TinderBox);
            Controls.Add(SlackBox);
            Controls.Add(EmailBox);
            Controls.Add(FacebookBox);
            Controls.Add(HitEvent);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button HitEvent;
        private CheckBox FacebookBox;
        private CheckBox EmailBox;
        private CheckBox SlackBox;
        private CheckBox TinderBox;
        private CheckBox ChromeBox;
        private TextBox output;
    }
}
