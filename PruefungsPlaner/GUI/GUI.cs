using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PruefungsPlaner.GUI
{
    public partial class GUI : Form
    {
        public GUI()
        {            
            InitializeComponent();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Hello GUI");
            ms = new ContextMenuStrip();
            ms.Items.Add("Kopieren");
            ms.Items[0].Click += new System.EventHandler(copyFromDGV);
            ms.Items.Add("Einfügen");
            ms.Items[1].Click += new System.EventHandler(copyIntoDGV);
            dataGridView4.ContextMenuStrip = ms;            
            panelCourses.BringToFront();
        }

        private void foo(object sender, EventArgs e)
        {
            ContextMenuStrip s = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            DataGridView dgv = (DataGridView)s.SourceControl;
            Console.WriteLine(sender.ToString());
            Console.WriteLine(dgv.Rows[0].Cells[1].Value);
        }

        private void copyFromDGV(object sender, EventArgs e)
        {
            ContextMenuStrip s = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            DataGridView dgv = (DataGridView)s.SourceControl;

            Clipboard.SetDataObject(dgv.GetClipboardContent());
        }

        private void copyIntoDGV(object sender, EventArgs e)
        {
            ContextMenuStrip s = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            DataGridView dgv = (DataGridView)s.SourceControl;
            DataGridViewCell topleft = dgv.CurrentCell;
            if (topleft == null)
                return;
            int col = topleft.ColumnIndex;
            int row = topleft.RowIndex;

            //Console.WriteLine("Zelle: {0}, {1}", row, col);            

            string[] lines = Clipboard.GetText().Split('\n');
            foreach (string line in lines)
            {
                if (row >= dgv.RowCount)
                {
                    break;
                }
                string[] cells = line.Split('\t');
                DataGridViewRow dgvRow = dgv.Rows[row];
                int y = col;
                foreach (string cell in cells)
                {
                    if (y < dgv.ColumnCount)
                    {
                        dgvRow.Cells[y].Value = cell;
                    }
                    else
                    {
                        break;
                    }
                    y++;
                }
                row++;
            }
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (focusedPanel)
            {
                case 0:                    
                    courseNames = getCourseNames();
                    foreach (string t in courseNames)
                    {                        
                        DataGridViewCheckBoxColumn course = new DataGridViewCheckBoxColumn();
                        course.HeaderText = t;
                        course.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        dgvTeachersCourses.Columns.Add(course);
                    }
                    panelTeachersCourses.BringToFront();                    
                    break;
                case 1:
                    teacherNames = getTeacherNames();
                    foreach (string t in courseNames)
                    {
                        DataGridViewCheckBoxColumn course = new DataGridViewCheckBoxColumn();
                        course.HeaderText = t;
                        course.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        dgvStudentsCourses.Columns.Add(course);
                    }
                    panelStudentsCourses.BringToFront();
                    break;
                case 2:
                    teacherDGVs(teacherNames);
                    panelTeacherTimespans.ColumnCount = 1;
                    panelTeacherTimespans.RowCount = teacherTimeSpans.Length + 1;
                    for (int i = 0; i < teacherTimeSpans.Length; i++)
                    {
                        panelTeacherTimespans.Controls.Add(teacherTimeSpans[i], 0, i + 1);
                        panelTeacherTimespans.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
                    }
                    panelTeacherTimespans.BringToFront();
                    break;
                default:
                    button1.Text = "Fertig";
                    break;
            }
            focusedPanel++;

            //if (focusedPanel < panels.Length)
            //{
            //    //label1.Text = "Hello wOrld";
            //    this.panels[focusedPanel++].SendToBack();
            //}
            //else
            //{
            //    focusedPanel = 0;
            //}
        }

        private string[] getCourseNames()
        {
            string[] courseNames = new string[dgvCourses.Rows.Count - 1];
            for (int i = 0; i < courseNames.Length; i++)
            {
                courseNames[i] = "" + dgvCourses.Rows[i].Cells[0].Value;
            }
            return courseNames;
        }

        private string[] getTeacherNames()
        {
            string[] teacherNames = new string[dgvTeachersCourses.Rows.Count - 1];
            for (int i = 0; i < teacherNames.Length; i++)
            {
                teacherNames[i] = "" + dgvTeachersCourses.Rows[i].Cells[0].Value;
            }
            return teacherNames;
        }

        private void teacherDGVs(string[] teacherNames)
        {
            teacherTimeSpans = new GroupBox[teacherNames.Length];            
            for (int i = 0; i < teacherNames.Length; i++)
            {
                DataGridView dgv = new DataGridView();

                dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
                dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv.AutoSize = true;
                dgv.Dock = DockStyle.Fill;
                dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dgv.Name = "dgvTeacher" + i;
                dgv.ContextMenuStrip = ms;
                dgv.CellValidating += new DataGridViewCellValidatingEventHandler(this.dgvTeacherTimespans_CellValidating);
                
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col1.HeaderText = DAY;
                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col2.HeaderText = "Beginn";
                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col3.HeaderText = "Ende";

                dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { col1, col2, col3 });

                GroupBox gb = new GroupBox();
                gb.Text = teacherNames[i];
                gb.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                       | AnchorStyles.Left)
                       | AnchorStyles.Right)));
                gb.Controls.Add(dgv);
                teacherTimeSpans[i] = gb;
            }
        }

        private int focusedPanel = 0;
        private string[] courseNames;
        private string[] teacherNames;
        private GroupBox[] teacherTimeSpans;
        private ContextMenuStrip ms;
        private const string DAY = "Tag";
        private const string BEGIN = "Beginn";
        private const string END = "Ende";

        private void dataGridView4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Taste!");
            Console.WriteLine(e.KeyChar);
        }

        private void dataGridView4_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Taste!");
        }

        private void dgvTeacherTimespans_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {            
            DataGridView dgv = (DataGridView) sender;
            DataGridViewColumn col = dgv.Columns[e.ColumnIndex];
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];           
            string value = e.FormattedValue.ToString();
            
            if (value.Equals(string.Empty))
            {
                return;
            }            
            
            if (col.HeaderText.Equals(DAY))
            {
                DateTime time;
                if (!DateTime.TryParseExact(value, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out time))
                {
                    MessageBox.Show(this, "Datumsformat muss 'dd.mm.yyyy' entsprechen.\nBsp: 04.12.1972");
                    e.Cancel = true;                    
                }
            }
            else if (col.HeaderText.Equals(BEGIN) || col.HeaderText.Equals(END))
            {                
                DateTime time;
                if (!DateTime.TryParseExact(value, "H:mm", null, System.Globalization.DateTimeStyles.None, out time))
                {
                    MessageBox.Show(this, "Zeitformat muss 'h:mm' entsprechen.\nBsp: 8:05");
                    e.Cancel = true;
                }
            }
        }

        private void dgvCourses_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewColumn col = dgv.Columns[e.ColumnIndex];            
            string value = e.FormattedValue.ToString();

            if (value.Equals(string.Empty))
            {
                return;
            }

            if (col == ExamTime || col == PrepareTime)
            {
                Regex number = new Regex(@"^\d*$");
                if (!number.IsMatch(value))
                {
                    MessageBox.Show(this, "Bitte geben Sie eine Zahl für die Zeit in Minuten an.");
                    e.Cancel = true;
                }
            }
        }
    }
}
