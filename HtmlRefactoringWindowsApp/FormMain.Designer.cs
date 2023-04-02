
namespace HtmlRefactoringWindowsApp
{
    partial class FormMain
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
            buttonStart = new Button();
            textBoxFileName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxStartLoadTime = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBoxStartValidationTime = new TextBox();
            textBoxEndValidationTime = new TextBox();
            label5 = new Label();
            textBoxNumberOfProperties = new TextBox();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(40, 76);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(560, 23);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // textBoxFileName
            // 
            textBoxFileName.Location = new Point(200, 37);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(400, 23);
            textBoxFileName.TabIndex = 1;
            textBoxFileName.Text = "D:\\_Repos\\css-reaper (delphi11)\\css-reaper.css";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 40);
            label1.Name = "label1";
            label1.Size = new Size(146, 15);
            label1.TabIndex = 2;
            label1.Text = "CSS parameters source file";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 120);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 3;
            label2.Text = "Start file loading time";
            label2.Click += label2_Click;
            // 
            // textBoxStartLoadTime
            // 
            textBoxStartLoadTime.Location = new Point(200, 117);
            textBoxStartLoadTime.Name = "textBoxStartLoadTime";
            textBoxStartLoadTime.Size = new Size(400, 23);
            textBoxStartLoadTime.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 160);
            label3.Name = "label3";
            label3.Size = new Size(113, 15);
            label3.TabIndex = 5;
            label3.Text = "Start validation time";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 200);
            label4.Name = "label4";
            label4.Size = new Size(109, 15);
            label4.TabIndex = 6;
            label4.Text = "End validation time";
            // 
            // textBoxStartValidationTime
            // 
            textBoxStartValidationTime.Location = new Point(200, 157);
            textBoxStartValidationTime.Name = "textBoxStartValidationTime";
            textBoxStartValidationTime.Size = new Size(400, 23);
            textBoxStartValidationTime.TabIndex = 7;
            // 
            // textBoxEndValidationTime
            // 
            textBoxEndValidationTime.Location = new Point(200, 197);
            textBoxEndValidationTime.Name = "textBoxEndValidationTime";
            textBoxEndValidationTime.Size = new Size(400, 23);
            textBoxEndValidationTime.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 240);
            label5.Name = "label5";
            label5.Size = new Size(121, 15);
            label5.TabIndex = 9;
            label5.Text = "Number of properties";
            // 
            // textBoxNumberOfProperties
            // 
            textBoxNumberOfProperties.Location = new Point(200, 237);
            textBoxNumberOfProperties.Name = "textBoxNumberOfProperties";
            textBoxNumberOfProperties.Size = new Size(400, 23);
            textBoxNumberOfProperties.TabIndex = 10;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 303);
            Controls.Add(textBoxNumberOfProperties);
            Controls.Add(label5);
            Controls.Add(textBoxEndValidationTime);
            Controls.Add(textBoxStartValidationTime);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxStartLoadTime);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxFileName);
            Controls.Add(buttonStart);
            Name = "FormMain";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStart;
        private TextBox textBoxFileName;
        private Label label1;
        private Label label2;
        private TextBox textBoxStartLoadTime;
        private Label label3;
        private Label label4;
        private TextBox textBoxStartValidationTime;
        private TextBox textBoxEndValidationTime;
        private Label label5;
        private TextBox textBoxNumberOfProperties;
    }
}