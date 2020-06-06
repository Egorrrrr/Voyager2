using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntColony;
using System.Diagnostics;

namespace A_Better_Voyager
{
    
    public partial class Form1 : Form
    {
        class Lines
        {
            public Color Color { get; set; }
            public List<Point> Pnts { get; set; }
            public Lines()
            {
                Color = Color.LightBlue;
                Pnts = new List<Point>();
            }
        }
        /// <summary>
        /// Тень
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        bool help = false;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
            cts = panel2.CreateGraphics();
            cts.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cnt = 0;
            F3 = new Form3();
        }
        Pen peen = new Pen(Brushes.LightBlue, 2);
        double[][] dists;
        Graphics cts;
        Dictionary<int, Point> Cities = new Dictionary<int, Point>();
        int cnt;
        Form3 F3;
        List<Lines> lines = new List<Lines>();
        private void Button1_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Gridpnt(object sender, PaintEventArgs e)
        {

            foreach (var s in Cities)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.FillEllipse(Brushes.LightGreen, s.Value.X - 3, s.Value.Y - 3, 8, 8);
            }
            foreach (var item in lines)
            {
                if (item.Pnts.Count > 1)
                {
                    Pen tmpen = new Pen(item.Color, 2);
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    e.Graphics.DrawLines(tmpen, item.Pnts.ToArray());
                    cts.FillEllipse(Brushes.Blue, item.Pnts[0].X - 7, item.Pnts[0].Y - 7, 15, 15);
                }
            }
            


        }


        private void Panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (help)
            {

                MessageBox.Show("Очистка карты и массива городов");
                return;
            }
            lines = new List<Lines>();
            Cities.Clear();
            panel2.Invalidate();
        }

        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.Location.ToString();

        }

        private void Random(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Создает на карте случайные города, количество которых, зависит от числа в поле выше\n");
                return;
            }
            Random a;
            int seed = 0;
            bool ok = int.TryParse(Seed.Text, out seed);
            if (ok)
            {
                a = new Random(seed);
            }
            else
            {
                a = new Random();
            }
            Cities.Clear();
            cnt = 0;
            try
            {
                lines = new List<Lines>();
                int count = int.Parse(textBox1.Text);
                for (int i = 0; i < count; i++)
                {
                    Point p = new Point(a.Next(0, 700), a.Next(0, 390));
                    Cities.Add(cnt++, p);

                }

                panel2.Invalidate();

            }
            catch (Exception)
            {
                return;
            }
        }

        
        private void Button5_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Запускает муравьиную колонию. Лучший маршрут из найденных отобразится на карте\n");
                return;
            }
            if (Cities.Count > 1)
            {
                //way = new List<Point>();
                ArrayBuild();
            }
            //NN.Show();

        }
        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
        public void ArrayBuild()
        {

            // int r = 0;
            string aa = "";
            dists = new double[Cities.Count][];
            for (int i = 0; i < dists.Length; i++)
            {
                dists[i] = new double[Cities.Count];
            }
            for (int i = 0; i < Cities.Count; i++)
            {
                Point one = Cities[i];
                for (int j = 0; j < Cities.Count; j++)
                {
                    Point two = Cities[j];
                    dists[i][j] = GetDistance(one.X, one.Y, two.X, two.Y);
                    if (i == j)
                    {
                        dists[i][j] = 0;
                    }
                    aa += dists[i][j].ToString() + " ";

                }
                aa += "\n";
            }
            int ll;
            int.TryParse(Iter.Text, out int iter);
            int.TryParse(Ants.Text, out int ants);
            int.TryParse(alpha.Text, out int al);
            int.TryParse(beta.Text, out int be);
            Stopwatch st = new Stopwatch();
            TimeSpan time = new TimeSpan();
            if (iter > 0 && ants > 0 && al>= 0 && be >=0)
            {
                st.Start();
                int[] trail = AntColonyProgram.Solve(dists, Cities.Count, ants, iter, al , be, out ll);
                st.Stop();
                time = st.Elapsed;
                label2.Text = OutPut(trail,time);
                
            }

        }
        public string OutPut(int[] a, TimeSpan time)
        {
            double dst = 0;

            string aa = "";
            Pen pp = new Pen(Brushes.Blue);
            Pen pp2 = new Pen(Brushes.Yellow);
            List<Point> way = new List<Point>();

            for (int i = 0; i < a.Length; i++)
            {
                Point p1;
                Cities.TryGetValue(a[i], out p1);
                //Cities.TryGetValue(a[i], out p2);
                //if (i == 1)
                //{
                //    cts.FillEllipse(Brushes.Blue, p1.X - 7, p1.Y - 7, 15, 15);

                //}
                //cts.DrawLine(peen, p1, p2);
                way.Add(p1);
                
                //dst += GetDistance(p1.X, p1.Y, p2.X, p2.Y);


            }
            Lines lns = new Lines();
            lns.Pnts.AddRange(way);
            lns.Color = peen.Color;
            lines.Add(lns);

            for (int i = 1; i < a.Length; i++)
            {

                    Point p1;
                    Point p2;
                    Cities.TryGetValue(a[i], out p1);
                    Cities.TryGetValue(a[i - 1], out p2);
                    dst += GetDistance(p1.X, p1.Y, p2.X, p2.Y);

            }
            

            aa = (Math.Round(dst, 0)).ToString();
            aa += "\n" + time.ToString();
            panel2.Invalidate();
            
            return aa;

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Запускает программу для работы с матрицами из файлов .txt\n");
                return;
            }
            F3.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Выбор цвета для проложенного пути\n Позволяет сравнить пути составленные с разными параметрами");
                return;
            }
            colorDialog1.ShowDialog();
            peen.Color = colorDialog1.Color;
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            if (!help)
            {
                foreach (Control item in Controls)
                {
                    if ((string)item.Tag != "dont")
                    {
                        item.BackColor = Color.LightGreen;
                    }
                }
                help = true;
                MessageBox.Show("Нажмите на интересующий элемент, чтобы получить информацию о нем\nЧтобы выйти из режима помощи снова нажмите на 'Help'");
            }
            else
            {
                help = false;
                foreach (Control item in Controls)
                {
                    if ((string)item.Tag != "dont")
                    {
                        item.BackColor = Color.Gray;
                    }
                }
            }

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Координаты курсора");
                return;
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Здесь указывается длина маршрута изображенного на карте\n");
                return;
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Количество муравьев за итерацию\n");
                return;
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Количество итераций\n");
                return;
            }
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("В поле ниже можно ввести ключ(или сид) генерации.\nЕсли в поле ниже введено какое-либо число, то при создании случайной карты будет генерироваться ожин и тот же вариант, соответствующий введеному ключу");
                return;
            }
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Привлекательнотсь феромонов\n");
            }

        }

        private void Label7_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Привлекательнотсь дистанции\n");
            }
        }
    }
}
