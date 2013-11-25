namespace PruefungsPlaner.GUI
{
    partial class GUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbExaminationTitle = new System.Windows.Forms.TextBox();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.Courses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvTeachersCourses = new System.Windows.Forms.DataGridView();
            this.Teachers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStudentsCourses = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCourses = new System.Windows.Forms.TableLayoutPanel();
            this.panelTeachersCourses = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelStudentsCourses = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelTeacherTimespans = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ExamTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrepareTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachersCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsCourses)).BeginInit();
            this.panelCourses.SuspendLayout();
            this.panelTeachersCourses.SuspendLayout();
            this.panelStudentsCourses.SuspendLayout();
            this.panelTeacherTimespans.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name der Prüfung:";
            // 
            // tbExaminationTitle
            // 
            this.tbExaminationTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExaminationTitle.Location = new System.Drawing.Point(160, 66);
            this.tbExaminationTitle.Name = "tbExaminationTitle";
            this.tbExaminationTitle.Size = new System.Drawing.Size(363, 20);
            this.tbExaminationTitle.TabIndex = 1;
            // 
            // dgvCourses
            // 
            this.dgvCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Courses,
            this.ExamTime,
            this.PrepareTime});
            this.panelCourses.SetColumnSpan(this.dgvCourses, 2);
            this.dgvCourses.Location = new System.Drawing.Point(3, 92);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.Size = new System.Drawing.Size(520, 210);
            this.dgvCourses.TabIndex = 2;
            this.dgvCourses.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCourses_CellValidating);
            // 
            // Courses
            // 
            this.Courses.HeaderText = "Fächer";
            this.Courses.Name = "Courses";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(444, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Weiter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dgvTeachersCourses
            // 
            this.dgvTeachersCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTeachersCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeachersCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeachersCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Teachers});
            this.dgvTeachersCourses.Location = new System.Drawing.Point(3, 66);
            this.dgvTeachersCourses.Name = "dgvTeachersCourses";
            this.dgvTeachersCourses.Size = new System.Drawing.Size(520, 236);
            this.dgvTeachersCourses.TabIndex = 0;
            // 
            // Teachers
            // 
            this.Teachers.HeaderText = "Lehrer";
            this.Teachers.Name = "Teachers";
            // 
            // dgvStudentsCourses
            // 
            this.dgvStudentsCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudentsCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentsCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgvStudentsCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudentsCourses.Location = new System.Drawing.Point(3, 66);
            this.dgvStudentsCourses.Name = "dgvStudentsCourses";
            this.dgvStudentsCourses.Size = new System.Drawing.Size(520, 216);
            this.dgvStudentsCourses.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Schüler";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.panelCourses.SetColumnSpan(this.label2, 2);
            this.label2.Location = new System.Drawing.Point(30, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(30, 30, 3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(493, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bitte tragen Sie den Namen der Prüfung und alle prüfbaren Fächer untereinander ei" +
                "n.";
            // 
            // panelCourses
            // 
            this.panelCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCourses.ColumnCount = 2;
            this.panelCourses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.88506F));
            this.panelCourses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.11494F));
            this.panelCourses.Controls.Add(this.label2, 0, 0);
            this.panelCourses.Controls.Add(this.label1, 0, 1);
            this.panelCourses.Controls.Add(this.tbExaminationTitle, 1, 1);
            this.panelCourses.Controls.Add(this.dgvCourses, 0, 2);
            this.panelCourses.Location = new System.Drawing.Point(0, 0);
            this.panelCourses.Name = "panelCourses";
            this.panelCourses.RowCount = 3;
            this.panelCourses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelCourses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelCourses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCourses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelCourses.Size = new System.Drawing.Size(526, 305);
            this.panelCourses.TabIndex = 1;
            // 
            // panelTeachersCourses
            // 
            this.panelTeachersCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTeachersCourses.ColumnCount = 1;
            this.panelTeachersCourses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTeachersCourses.Controls.Add(this.label3, 0, 0);
            this.panelTeachersCourses.Controls.Add(this.dgvTeachersCourses, 0, 1);
            this.panelTeachersCourses.Location = new System.Drawing.Point(0, 0);
            this.panelTeachersCourses.Name = "panelTeachersCourses";
            this.panelTeachersCourses.RowCount = 2;
            this.panelTeachersCourses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelTeachersCourses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTeachersCourses.Size = new System.Drawing.Size(526, 305);
            this.panelTeachersCourses.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(30, 30, 3, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(493, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Geben Sie für jeden Lehrer die von ihm prüfbaren Fächer an.";
            // 
            // panelStudentsCourses
            // 
            this.panelStudentsCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStudentsCourses.ColumnCount = 1;
            this.panelStudentsCourses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelStudentsCourses.Controls.Add(this.label4, 0, 0);
            this.panelStudentsCourses.Controls.Add(this.dgvStudentsCourses, 0, 1);
            this.panelStudentsCourses.Location = new System.Drawing.Point(0, 0);
            this.panelStudentsCourses.Name = "panelStudentsCourses";
            this.panelStudentsCourses.RowCount = 3;
            this.panelStudentsCourses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelStudentsCourses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelStudentsCourses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelStudentsCourses.Size = new System.Drawing.Size(526, 305);
            this.panelStudentsCourses.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(30, 30, 3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(493, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ordnen Sie den Schülern ihre jeweiligen Prüfungsfächer zu.";
            // 
            // panelTeacherTimespans
            // 
            this.panelTeacherTimespans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTeacherTimespans.AutoScroll = true;
            this.panelTeacherTimespans.ColumnCount = 1;
            this.panelTeacherTimespans.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTeacherTimespans.Controls.Add(this.label5, 0, 0);
            this.panelTeacherTimespans.Location = new System.Drawing.Point(0, 0);
            this.panelTeacherTimespans.Name = "panelTeacherTimespans";
            this.panelTeacherTimespans.RowCount = 1;
            this.panelTeacherTimespans.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelTeacherTimespans.Size = new System.Drawing.Size(526, 305);
            this.panelTeacherTimespans.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 151);
            this.label5.Margin = new System.Windows.Forms.Padding(30, 30, 3, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(493, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Geben Sie die möglichen Prüfungszeiträume pro Lehrer an.";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.AutoScroll = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.dataGridView7, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.dataGridView6, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.dataGridView5, 0, 5);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(526, 305);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // dataGridView7
            // 
            this.dataGridView7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4});
            this.dataGridView7.Location = new System.Drawing.Point(3, 519);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.Size = new System.Drawing.Size(526, 114);
            this.dataGridView7.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridView6
            // 
            this.dataGridView6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.dataGridView6.Location = new System.Drawing.Point(3, 399);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.Size = new System.Drawing.Size(526, 114);
            this.dataGridView6.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(30, 30, 3, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(499, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Geben Sie die möglichen Prüfungszeiträume pro Lehrer an.";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView4);
            this.groupBox1.Location = new System.Drawing.Point(3, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 294);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Horstmann";
            // 
            // dataGridView4
            // 
            this.dataGridView4.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.Column1});
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(3, 16);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(520, 275);
            this.dataGridView4.TabIndex = 10;
            this.dataGridView4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView4_KeyDown);
            this.dataGridView4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView4_KeyPress);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // dataGridView5
            // 
            this.dataGridView5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dataGridView5.Location = new System.Drawing.Point(3, 639);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(526, 15);
            this.dataGridView5.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(171, 344);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // ExamTime
            // 
            this.ExamTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ExamTime.HeaderText = "Dauer (min)";
            this.ExamTime.Name = "ExamTime";
            this.ExamTime.Width = 86;
            // 
            // PrepareTime
            // 
            this.PrepareTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PrepareTime.HeaderText = "Vorbereitungszeit (min)";
            this.PrepareTime.Name = "PrepareTime";
            this.PrepareTime.Width = 138;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 380);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelCourses);
            this.Controls.Add(this.panelStudentsCourses);
            this.Controls.Add(this.panelTeachersCourses);
            this.Controls.Add(this.panelTeacherTimespans);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Name = "GUI";
            this.Text = "PrüfungsPlaner";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachersCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsCourses)).EndInit();
            this.panelCourses.ResumeLayout(false);
            this.panelCourses.PerformLayout();
            this.panelTeachersCourses.ResumeLayout(false);
            this.panelTeachersCourses.PerformLayout();
            this.panelStudentsCourses.ResumeLayout(false);
            this.panelStudentsCourses.PerformLayout();
            this.panelTeacherTimespans.ResumeLayout(false);
            this.panelTeacherTimespans.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExaminationTitle;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcolCourses;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvTeachersCourses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teachers;
        private System.Windows.Forms.DataGridView dgvStudentsCourses;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel panelCourses;
        private System.Windows.Forms.TableLayoutPanel panelTeachersCourses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel panelStudentsCourses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel panelTeacherTimespans;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridView dataGridView7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Courses;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrepareTime;      






    }
}