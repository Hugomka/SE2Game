namespace StudentAdministration
{
    partial class StudentForm
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
            this.lstStudents = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grpStudents = new System.Windows.Forms.GroupBox();
            this.btnEditStudent = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.grpGrading = new System.Windows.Forms.GroupBox();
            this.nudCode = new System.Windows.Forms.NumericUpDown();
            this.nudDesign = new System.Windows.Forms.NumericUpDown();
            this.nudAnalysis = new System.Windows.Forms.NumericUpDown();
            this.lblGrade = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSetGrade = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpStudents.SuspendLayout();
            this.grpGrading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // lstStudents
            // 
            this.lstStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStudents.FormattingEnabled = true;
            this.lstStudents.ItemHeight = 16;
            this.lstStudents.Location = new System.Drawing.Point(8, 23);
            this.lstStudents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstStudents.Name = "lstStudents";
            this.lstStudents.Size = new System.Drawing.Size(396, 116);
            this.lstStudents.TabIndex = 0;
            this.lstStudents.SelectedIndexChanged += new System.EventHandler(this.lstStudents_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddStudent);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(16, 213);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(413, 126);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new/update student";
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddStudent.Location = new System.Drawing.Point(79, 87);
            this.btnAddStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(327, 28);
            this.btnAddStudent.TabIndex = 4;
            this.btnAddStudent.Text = "Add new/update student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(79, 55);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(325, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(79, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(325, 22);
            this.txtName.TabIndex = 2;
            // 
            // grpStudents
            // 
            this.grpStudents.Controls.Add(this.btnEditStudent);
            this.grpStudents.Controls.Add(this.btnDeleteStudent);
            this.grpStudents.Controls.Add(this.lstStudents);
            this.grpStudents.Location = new System.Drawing.Point(16, 15);
            this.grpStudents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpStudents.Name = "grpStudents";
            this.grpStudents.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpStudents.Size = new System.Drawing.Size(413, 191);
            this.grpStudents.TabIndex = 5;
            this.grpStudents.TabStop = false;
            this.grpStudents.Text = "Students";
            // 
            // btnEditStudent
            // 
            this.btnEditStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditStudent.Enabled = false;
            this.btnEditStudent.Location = new System.Drawing.Point(8, 148);
            this.btnEditStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditStudent.Name = "btnEditStudent";
            this.btnEditStudent.Size = new System.Drawing.Size(187, 28);
            this.btnEditStudent.TabIndex = 2;
            this.btnEditStudent.Text = "Edit selected";
            this.btnEditStudent.UseVisualStyleBackColor = true;
            this.btnEditStudent.Click += new System.EventHandler(this.btnEditStudent_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteStudent.Enabled = false;
            this.btnDeleteStudent.Location = new System.Drawing.Point(219, 148);
            this.btnDeleteStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(187, 28);
            this.btnDeleteStudent.TabIndex = 1;
            this.btnDeleteStudent.Text = "Delete selected";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // grpGrading
            // 
            this.grpGrading.Controls.Add(this.nudCode);
            this.grpGrading.Controls.Add(this.nudDesign);
            this.grpGrading.Controls.Add(this.nudAnalysis);
            this.grpGrading.Controls.Add(this.lblGrade);
            this.grpGrading.Controls.Add(this.label5);
            this.grpGrading.Controls.Add(this.btnSetGrade);
            this.grpGrading.Controls.Add(this.label1);
            this.grpGrading.Controls.Add(this.label4);
            this.grpGrading.Location = new System.Drawing.Point(16, 346);
            this.grpGrading.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpGrading.Name = "grpGrading";
            this.grpGrading.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpGrading.Size = new System.Drawing.Size(413, 155);
            this.grpGrading.TabIndex = 5;
            this.grpGrading.TabStop = false;
            this.grpGrading.Text = "Grading";
            // 
            // nudCode
            // 
            this.nudCode.DecimalPlaces = 1;
            this.nudCode.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudCode.Location = new System.Drawing.Point(80, 87);
            this.nudCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudCode.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCode.Name = "nudCode";
            this.nudCode.Size = new System.Drawing.Size(115, 22);
            this.nudCode.TabIndex = 10;
            // 
            // nudDesign
            // 
            this.nudDesign.DecimalPlaces = 1;
            this.nudDesign.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudDesign.Location = new System.Drawing.Point(80, 57);
            this.nudDesign.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudDesign.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDesign.Name = "nudDesign";
            this.nudDesign.Size = new System.Drawing.Size(115, 22);
            this.nudDesign.TabIndex = 9;
            // 
            // nudAnalysis
            // 
            this.nudAnalysis.DecimalPlaces = 1;
            this.nudAnalysis.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudAnalysis.Location = new System.Drawing.Point(80, 25);
            this.nudAnalysis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudAnalysis.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudAnalysis.Name = "nudAnalysis";
            this.nudAnalysis.Size = new System.Drawing.Size(115, 22);
            this.nudAnalysis.TabIndex = 8;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(267, 23);
            this.lblGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(84, 91);
            this.lblGrade.TabIndex = 7;
            this.lblGrade.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Code:";
            // 
            // btnSetGrade
            // 
            this.btnSetGrade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetGrade.Location = new System.Drawing.Point(79, 119);
            this.btnSetGrade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetGrade.Name = "btnSetGrade";
            this.btnSetGrade.Size = new System.Drawing.Size(116, 28);
            this.btnSetGrade.TabIndex = 4;
            this.btnSetGrade.Text = "Set grade";
            this.btnSetGrade.UseVisualStyleBackColor = true;
            this.btnSetGrade.Click += new System.EventHandler(this.btnSetGrade_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Design:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Analysis:";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 514);
            this.Controls.Add(this.grpGrading);
            this.Controls.Add(this.grpStudents);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Student Administration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpStudents.ResumeLayout(false);
            this.grpGrading.ResumeLayout(false);
            this.grpGrading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnalysis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstStudents;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox grpStudents;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Button btnEditStudent;
        private System.Windows.Forms.GroupBox grpGrading;
        private System.Windows.Forms.Button btnSetGrade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudCode;
        private System.Windows.Forms.NumericUpDown nudDesign;
        private System.Windows.Forms.NumericUpDown nudAnalysis;
    }
}

