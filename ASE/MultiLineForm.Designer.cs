namespace ASE
{
    partial class MultiLineForm
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
            this.multiCommandTextBox = new System.Windows.Forms.RichTextBox();
            this.RunScriptBtn = new System.Windows.Forms.Button();
            this.LoadScriptBtn = new System.Windows.Forms.Button();
            this.SaveScriptBtn = new System.Windows.Forms.Button();
            this.ResetScript = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // multiCommandTextBox
            // 
            this.multiCommandTextBox.Location = new System.Drawing.Point(12, 12);
            this.multiCommandTextBox.Name = "multiCommandTextBox";
            this.multiCommandTextBox.Size = new System.Drawing.Size(309, 406);
            this.multiCommandTextBox.TabIndex = 0;
            this.multiCommandTextBox.Text = "";
            // 
            // RunScriptBtn
            // 
            this.RunScriptBtn.BackColor = System.Drawing.Color.SpringGreen;
            this.RunScriptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunScriptBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RunScriptBtn.Location = new System.Drawing.Point(12, 437);
            this.RunScriptBtn.Name = "RunScriptBtn";
            this.RunScriptBtn.Size = new System.Drawing.Size(109, 37);
            this.RunScriptBtn.TabIndex = 1;
            this.RunScriptBtn.Text = "Run";
            this.RunScriptBtn.UseVisualStyleBackColor = false;
            this.RunScriptBtn.Click += new System.EventHandler(this.RunScriptBtn_Click);
            // 
            // LoadScriptBtn
            // 
            this.LoadScriptBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.LoadScriptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadScriptBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadScriptBtn.Location = new System.Drawing.Point(212, 437);
            this.LoadScriptBtn.Name = "LoadScriptBtn";
            this.LoadScriptBtn.Size = new System.Drawing.Size(109, 37);
            this.LoadScriptBtn.TabIndex = 2;
            this.LoadScriptBtn.Text = "Load Script";
            this.LoadScriptBtn.UseVisualStyleBackColor = false;
            this.LoadScriptBtn.Click += new System.EventHandler(this.LoadScriptBtn_Click);
            // 
            // SaveScriptBtn
            // 
            this.SaveScriptBtn.BackColor = System.Drawing.Color.Brown;
            this.SaveScriptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveScriptBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveScriptBtn.Location = new System.Drawing.Point(12, 495);
            this.SaveScriptBtn.Name = "SaveScriptBtn";
            this.SaveScriptBtn.Size = new System.Drawing.Size(109, 35);
            this.SaveScriptBtn.TabIndex = 3;
            this.SaveScriptBtn.Text = "Save Script";
            this.SaveScriptBtn.UseVisualStyleBackColor = false;
            this.SaveScriptBtn.Click += new System.EventHandler(this.SaveScriptBtn_Click);
            // 
            // ResetScript
            // 
            this.ResetScript.BackColor = System.Drawing.Color.Red;
            this.ResetScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetScript.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ResetScript.Location = new System.Drawing.Point(211, 495);
            this.ResetScript.Name = "ResetScript";
            this.ResetScript.Size = new System.Drawing.Size(109, 35);
            this.ResetScript.TabIndex = 4;
            this.ResetScript.Text = "Reset";
            this.ResetScript.UseVisualStyleBackColor = false;

            // 
            // MultiLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(332, 556);
            this.Controls.Add(this.ResetScript);
            this.Controls.Add(this.SaveScriptBtn);
            this.Controls.Add(this.LoadScriptBtn);
            this.Controls.Add(this.RunScriptBtn);
            this.Controls.Add(this.multiCommandTextBox);
            this.Name = "MultiLineForm";
            this.Text = "MultiLineForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox multiCommandTextBox;
        private System.Windows.Forms.Button RunScriptBtn;
        private System.Windows.Forms.Button LoadScriptBtn;
        private System.Windows.Forms.Button SaveScriptBtn;
        private System.Windows.Forms.Button ResetScript;
    }
}