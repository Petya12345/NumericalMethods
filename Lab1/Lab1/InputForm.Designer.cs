namespace Lab1
{
    partial class InputForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.setMatrixSizeBtn = new System.Windows.Forms.Button();
            this.algorithmComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.condButton = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epsilonTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(522, 333);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Matrix size";
            // 
            // setMatrixSizeBtn
            // 
            this.setMatrixSizeBtn.Location = new System.Drawing.Point(116, 7);
            this.setMatrixSizeBtn.Name = "setMatrixSizeBtn";
            this.setMatrixSizeBtn.Size = new System.Drawing.Size(35, 23);
            this.setMatrixSizeBtn.TabIndex = 3;
            this.setMatrixSizeBtn.Text = "Set";
            this.setMatrixSizeBtn.UseVisualStyleBackColor = true;
            this.setMatrixSizeBtn.Click += new System.EventHandler(this.setMatrixSizeBtn_Click);
            // 
            // algorithmComboBox
            // 
            this.algorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algorithmComboBox.FormattingEnabled = true;
            this.algorithmComboBox.Location = new System.Drawing.Point(213, 9);
            this.algorithmComboBox.Name = "algorithmComboBox";
            this.algorithmComboBox.Size = new System.Drawing.Size(149, 21);
            this.algorithmComboBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Algorithm";
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(368, 9);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(54, 23);
            this.solveButton.TabIndex = 6;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // condButton
            // 
            this.condButton.Location = new System.Drawing.Point(428, 9);
            this.condButton.Name = "condButton";
            this.condButton.Size = new System.Drawing.Size(104, 23);
            this.condButton.TabIndex = 7;
            this.condButton.Text = "Calculate Cond(A)";
            this.condButton.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(75, 9);
            this.maskedTextBox1.Mask = "099";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(34, 20);
            this.maskedTextBox1.TabIndex = 8;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView2.Location = new System.Drawing.Point(544, 36);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(88, 334);
            this.dataGridView2.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "0";
            this.Column1.Name = "Column1";
            this.Column1.Width = 20;
            // 
            // epsilonTextBox
            // 
            this.epsilonTextBox.Location = new System.Drawing.Point(555, 9);
            this.epsilonTextBox.Name = "epsilonTextBox";
            this.epsilonTextBox.Size = new System.Drawing.Size(78, 20);
            this.epsilonTextBox.TabIndex = 10;
            this.epsilonTextBox.Text = "0.0001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "E";
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 382);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.epsilonTextBox);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.condButton);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.algorithmComboBox);
            this.Controls.Add(this.setMatrixSizeBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "InputForm";
            this.Text = "Lab1";
            this.Load += new System.EventHandler(this.InputForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setMatrixSizeBtn;
        private System.Windows.Forms.ComboBox algorithmComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button condButton;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TextBox epsilonTextBox;
        private System.Windows.Forms.Label label3;
    }
}

