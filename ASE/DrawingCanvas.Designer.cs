namespace ASE
{
    partial class DrawingCanvas
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.singleCommandBox = new System.Windows.Forms.TextBox();
            this.runBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.runScriptBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.SeaShell;
            this.pictureBox.Location = new System.Drawing.Point(16, 15);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1035, 724);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // singleCommandBox
            // 
            this.singleCommandBox.Location = new System.Drawing.Point(16, 757);
            this.singleCommandBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.singleCommandBox.Multiline = true;
            this.singleCommandBox.Name = "singleCommandBox";
            this.singleCommandBox.Size = new System.Drawing.Size(264, 35);
            this.singleCommandBox.TabIndex = 1;
            // 
            // runBtn
            // 
            this.runBtn.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.runBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.runBtn.Location = new System.Drawing.Point(289, 757);
            this.runBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(121, 36);
            this.runBtn.TabIndex = 2;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = false;
            this.runBtn.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.Sienna;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearBtn.Location = new System.Drawing.Point(639, 757);
            this.ClearBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(111, 36);
            this.ClearBtn.TabIndex = 3;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.BackColor = System.Drawing.Color.Crimson;
            this.resetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.resetBtn.Location = new System.Drawing.Point(791, 757);
            this.resetBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(108, 36);
            this.resetBtn.TabIndex = 4;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // runScriptBtn
            // 
            this.runScriptBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.runScriptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runScriptBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.runScriptBtn.Location = new System.Drawing.Point(931, 757);
            this.runScriptBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.runScriptBtn.Name = "runScriptBtn";
            this.runScriptBtn.Size = new System.Drawing.Size(120, 36);
            this.runScriptBtn.TabIndex = 5;
            this.runScriptBtn.Text = "MultiLine";
            this.runScriptBtn.UseVisualStyleBackColor = false;
            this.runScriptBtn.Click += new System.EventHandler(this.RunScriptButton_Click);
            // 
            // DrawingCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1067, 807);
            this.Controls.Add(this.runScriptBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.singleCommandBox);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DrawingCanvas";
            this.Text = "Graphic Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox singleCommandBox;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button runScriptBtn;
    }
}

