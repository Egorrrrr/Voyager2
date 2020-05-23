using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Better_Voyager
{
    public partial class Form2 : Form
    {
        
        
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form2()
        {
            InitializeComponent();
        }
         int CountC = 0;
         int CountR = 0;

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Hide();
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public void AddFromMap(int[][] a)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            CountC = 0;
            CountR = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    label1.Text += a[i][j].ToString();
                }
            }
            int sz = a.Length * a.Length;
            DataTable b = new DataTable();
            for (int i = 0; i < sz; i++)
            {
                CountC += 1;
                CountR += 1;
                dataGridView1.ColumnCount = CountC;
                dataGridView1.Rows.Add();
                dataGridView1.Columns[CountC - 1].Width =30;
                dataGridView1.Rows[CountR - 1].Height = 30;
                dataGridView1.Columns[CountR - 1].HeaderCell.Value = (CountC -1 ).ToString();
                dataGridView1.Rows[CountR - 1].HeaderCell.Value = (CountR- 1).ToString();

            }
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    dataGridView1[i,j].Value = a[i][j];
                }
            }


        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
