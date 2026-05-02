namespace SalaryPro
{
    partial class LinkerForm
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
            rtbInput = new RichTextBox();
            btnProcess = new Button();
            SuspendLayout();
            // 
            // rtbInput
            // 
            rtbInput.Location = new Point(12, 12);
            rtbInput.Name = "rtbInput";
            rtbInput.Size = new Size(332, 666);
            rtbInput.TabIndex = 0;
            rtbInput.Text = "";
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(106, 684);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(144, 23);
            btnProcess.TabIndex = 1;
            btnProcess.Text = "Згенерувати ссилки";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // LinkerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 719);
            Controls.Add(btnProcess);
            Controls.Add(rtbInput);
            Name = "LinkerForm";
            Text = "LinkerForm";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbInput;
        private Button btnProcess;
    }
}