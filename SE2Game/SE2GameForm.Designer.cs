namespace SE2Game
{
    partial class SE2GameForm
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
            this.components = new System.ComponentModel.Container();
            this.picGameWorld = new System.Windows.Forms.PictureBox();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.lbHP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRandomMap = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.nudEnemyCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAI = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGameWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnemyCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picGameWorld
            // 
            this.picGameWorld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGameWorld.Location = new System.Drawing.Point(12, 12);
            this.picGameWorld.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picGameWorld.Name = "picGameWorld";
            this.picGameWorld.Size = new System.Drawing.Size(641, 592);
            this.picGameWorld.TabIndex = 0;
            this.picGameWorld.TabStop = false;
            this.picGameWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.picGameWorld_Paint);
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 33;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStart.Location = new System.Drawing.Point(660, 542);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(128, 28);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbHP
            // 
            this.lbHP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbHP.AutoSize = true;
            this.lbHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHP.ForeColor = System.Drawing.Color.DarkRed;
            this.lbHP.Location = new System.Drawing.Point(723, 574);
            this.lbHP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHP.Name = "lbHP";
            this.lbHP.Size = new System.Drawing.Size(62, 31);
            this.lbHP.TabIndex = 6;
            this.lbHP.Text = "100";
            this.lbHP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(656, 574);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "HP:";
            // 
            // btnRandomMap
            // 
            this.btnRandomMap.Location = new System.Drawing.Point(8, 65);
            this.btnRandomMap.Margin = new System.Windows.Forms.Padding(4);
            this.btnRandomMap.Name = "btnRandomMap";
            this.btnRandomMap.Size = new System.Drawing.Size(112, 28);
            this.btnRandomMap.TabIndex = 2;
            this.btnRandomMap.Text = "Randomize";
            this.btnRandomMap.UseVisualStyleBackColor = true;
            this.btnRandomMap.Click += new System.EventHandler(this.btnRandomMap_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(660, 506);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(128, 28);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // nudEnemyCount
            // 
            this.nudEnemyCount.Location = new System.Drawing.Point(8, 39);
            this.nudEnemyCount.Margin = new System.Windows.Forms.Padding(4);
            this.nudEnemyCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudEnemyCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEnemyCount.Name = "nudEnemyCount";
            this.nudEnemyCount.Size = new System.Drawing.Size(112, 22);
            this.nudEnemyCount.TabIndex = 4;
            this.nudEnemyCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudEnemyCount.ValueChanged += new System.EventHandler(this.nudEnemyCount_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.btnOpenFile);
            this.groupBox1.Controls.Add(this.btnRandomMap);
            this.groupBox1.Location = new System.Drawing.Point(660, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(128, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(8, 23);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(112, 28);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "Open file";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbAI);
            this.groupBox2.Controls.Add(this.nudEnemyCount);
            this.groupBox2.Location = new System.Drawing.Point(660, 121);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(128, 128);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enemies";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "AI:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Count:";
            // 
            // cmbAI
            // 
            this.cmbAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAI.FormattingEnabled = true;
            this.cmbAI.Location = new System.Drawing.Point(8, 87);
            this.cmbAI.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAI.Name = "cmbAI";
            this.cmbAI.Size = new System.Drawing.Size(111, 24);
            this.cmbAI.Sorted = true;
            this.cmbAI.TabIndex = 8;
            // 
            // SE2GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 610);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbHP);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.picGameWorld);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SE2GameForm";
            this.Text = "SE2GameForm";
            ((System.ComponentModel.ISupportInitialize)(this.picGameWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnemyCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGameWorld;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbHP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRandomMap;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.NumericUpDown nudEnemyCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAI;
        private System.Windows.Forms.Button btnOpenFile;
    }
}