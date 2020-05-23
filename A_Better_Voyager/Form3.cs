using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace A_Better_Voyager
{
    public partial class Form3 : Form
    {
        private static Random random = new Random();
        private static int alpha = 3;
        private static int beta = 2;

        private static double rho = 0.01;
        private static double Q = 2.0;

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
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (!openFileDialog1.FileName.Contains(".txt"))
            {
                MessageBox.Show("Файл не текстовый");
                return;
                
            }
            else
            {
               // MessageBox.Show(newstr);
                ToArray(openFileDialog1.FileName);
               
            }
        }
        public void ToArray(string path)
        {
            double[][] dists;
            Regex re = new Regex(@"\s+");
            Regex re2 = new Regex(@"^\s+");
            List<string> tmp = new List<string>();
            StreamReader a = new StreamReader(@openFileDialog1.FileName);
            while (!a.EndOfStream)
            {
                string tmp2 = a.ReadLine();
                if(tmp2[0] == '#')
                {
                    continue;
                }
                tmp2 = re.Replace(tmp2, " ");
                tmp2 = re2.Replace(tmp2, "");
                tmp.Add(tmp2);
            }
            dists = new double[tmp.Count][];
            for (int i = 0; i < dists.Length; i++)
            {
                dists[i] = new double[dists.Length];
            }
            for (int i = 0; i < tmp.Count; i++)
            {
                string[] t = tmp[i].Split(' ');
                for (int j = 0; j < tmp.Count; j++)
                {
                    dists[i][j] = double.Parse(t[j]);
                }
            }
            string test = "";
            for (int i = 0; i < dists.Length; i++)
            {
                for (int j  = 0; j < dists.Length; j++)
                {
                    test += dists[i][j] + " ";
                }
                test += "\n";
            }
            Solve(dists);



        }
        public int FindMax(int[][] a)
         {
            int max = int.MinValue;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if(a[i][j] > max)
                    {
                        max = a[i][j];
                    }
                }
            }
            return max;

         }
        public static int FindAvergae(double[][] a)
        {
            double sum = 0;
            int amount = a.Length * a.Length;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    sum += a[i][j];
                }
            }
            return Convert.ToInt32(sum / amount);
        }

        public  void Solve(double [][] ds)
            {
                
                try
                {

                double[][] arr = new double[ds.Length][];
                ds.CopyTo(arr, 0);
                if (!uint.TryParse(Ants.Text, out uint aants) || !uint.TryParse(Iters.Text, out uint iters))
                {
                    return;
                }
                int avg = FindAvergae(ds);
                int coef = avg / 4;
                for (int i = 0; i < ds.Length; i++)
                {
                    for (int j = 0; j < ds.Length; j++)
                    {
                        ds[i][j] /= coef * 1.35;
                    }
                }


                listBox1.Items.Clear();
                    listBox1.Items.Add("Начало");

                    int numCities = ds.Length;
                    int numAnts = (int)aants;
                    int maxTime = (int)iters;

                    listBox1.Items.Add("Количество городов = " + numCities);

                    listBox1.Items.Add("\nКоличество муравьев = " + numAnts);
                    listBox1.Items.Add("Количество итераций = " + maxTime);

                    listBox1.Items.Add("Альфа(влияние ферамона) = " + alpha);
                    listBox1.Items.Add("Бета(влияние дистаниции) = " + beta);
                    listBox1.Items.Add("Коэфициент испарения ферамона= " + rho.ToString("F2"));
                    listBox1.Items.Add("Q(Коэфициент выделения ферамона) = " + Q.ToString("F2"));

                    double[][] dists = ds;

                    listBox1.Items.Add("Создание муравьев...");
                    int[][] ants = InitAnts(numAnts, numCities);

                    int[] bestTrail = BestTrail(ants, dists);
                    double bestLength = Length(bestTrail, dists);

                    listBox1.Items.Add("Изначальный лучший путь: " + (bestLength*1.35 * coef).ToString("F1"));

                    listBox1.Items.Add("Создание начальных ферамонов...");
                    double[][] pheromones = InitPheromones(numCities);

                    int time = 0;
                    listBox1.Items.Add("Начало цикла...");
                    while (time < maxTime)
                    {
                        UpdateAnts(ants, pheromones, dists);
                        UpdatePheromones(pheromones, ants, dists);

                        int[] currBestTrail = BestTrail(ants, dists);
                        double currBestLength = Length(currBestTrail, dists);
                        if (currBestLength < bestLength)
                        {
                            bestLength = currBestLength;
                            bestTrail = currBestTrail;
                            listBox1.Items.Add("Новый лучший путь " + (bestLength * 1.35 * coef).ToString("F1") + " Итерация:  " + time);
                        }
                        time += 1;
                    }


                    listBox1.Items.Add("\nЛучший путь:");
                    string asa = "";
                    for (int i = 0; i < bestTrail.Length; i++)
                    {
                    asa += bestTrail[i] + " ";
                    }
                    listBox1.Items.Add(asa);

                    listBox1.Items.Add("Длина лучшего пути " + (bestLength * 1.35 * coef).ToString("F1"));

                    listBox1.Items.Add("Конец");
                    

                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(ex.Message);
                }

            }


            private static int[][] InitAnts(int numAnts, int numCities)
            {
                int[][] ants = new int[numAnts][];
                for (int k = 0; k <= numAnts - 1; k++)
                {
                    int start = random.Next(0, numCities);
                    ants[k] = RandomTrail(start, numCities);
                }
                return ants;
            }

            private static int[] RandomTrail(int start, int numCities)
            {
                int[] trail = new int[numCities];

                
                for (int i = 0; i <= numCities - 1; i++)
                {
                    trail[i] = i;
                }

                for (int i = 0; i <= numCities - 1; i++)
                {
                    int r = random.Next(i, numCities);
                    int tmp = trail[r];
                    trail[r] = trail[i];
                    trail[i] = tmp;
                }

                int idx = IndexOfTarget(trail, start);
                int temp = trail[0];
                trail[0] = trail[idx];
                trail[idx] = temp;

                return trail;
            }

            private static int IndexOfTarget(int[] trail, int target)
            {
                for (int i = 0; i <= trail.Length - 1; i++)
                {
                    if (trail[i] == target)
                    {
                        return i;
                    }
                }
                throw new Exception("error");
            }

            private static double Length(int[] trail, double[][] dists)
            {
                double result = 0.0;
                for (int i = 0; i <= trail.Length - 2; i++)
                {
                    result += Distance(trail[i], trail[i + 1], dists);
                }
                return result;
            }


            private static int[] BestTrail(int[][] ants, double[][] dists)
            {
                double bestLength = Length(ants[0], dists);
                int idxBestLength = 0;
                for (int k = 1; k <= ants.Length - 1; k++)
                {
                    double len = Length(ants[k], dists);
                    if (len < bestLength)
                    {
                        bestLength = len;
                        idxBestLength = k;
                    }
                }
                int numCities = ants[0].Length;
                int[] bestTrail_Renamed = new int[numCities];
                ants[idxBestLength].CopyTo(bestTrail_Renamed, 0);
                return bestTrail_Renamed;
            }


            private static double[][] InitPheromones(int numCities)
            {
                double[][] pheromones = new double[numCities][];
                for (int i = 0; i <= numCities - 1; i++)
                {
                    pheromones[i] = new double[numCities];
                }
                for (int i = 0; i <= pheromones.Length - 1; i++)
                {
                    for (int j = 0; j <= pheromones[i].Length - 1; j++)
                    {
                        pheromones[i][j] = 0.01;
                    }
                }
                return pheromones;
            }


            private static void UpdateAnts(int[][] ants, double[][] pheromones, double[][] dists)
            {
                int numCities = pheromones.Length;
                for (int k = 0; k <= ants.Length - 1; k++)
                {
                    int start = random.Next(0, numCities);
                    int[] newTrail = BuildTrail(k, start, pheromones, dists);
                    ants[k] = newTrail;
                }
            }

            private static int[] BuildTrail(int k, int start, double[][] pheromones, double[][] dists)
            {
                int numCities = pheromones.Length;
                int[] trail = new int[numCities];
                bool[] visited = new bool[numCities];
                trail[0] = start;
                visited[start] = true;
                for (int i = 0; i <= numCities - 2; i++)
                {
                    int cityX = trail[i];
                    int next = NextCity(k, cityX, visited, pheromones, dists);
                    trail[i + 1] = next;
                    visited[next] = true;
                }
                return trail;
            }

            private static int NextCity(int k, int cityX, bool[] visited, double[][] pheromones, double[][] dists)
            {
                double[] probs = MoveProbs(k, cityX, visited, pheromones, dists);

                double[] cumul = new double[probs.Length + 1];
                for (int i = 0; i <= probs.Length - 1; i++)
                {
                    cumul[i + 1] = cumul[i] + probs[i];
                }

                double p = random.NextDouble();

                for (int i = 0; i <= cumul.Length - 2; i++)
                {
                    if (p >= cumul[i] && p < cumul[i + 1])
                    {
                        return i;
                    }
                }
                throw new Exception("fail");
            }

            private static double[] MoveProbs(int k, int cityX, bool[] visited, double[][] pheromones, double[][] dists)
            {
                int numCities = pheromones.Length;
                double[] taueta = new double[numCities];
                double sum = 0.0;
                for (int i = 0; i <= taueta.Length - 1; i++)
                {
                    if (i == cityX)
                    {
                        taueta[i] = 0.0;
                    }
                    else if (visited[i] == true)
                    {
                        taueta[i] = 0.0;
                    }
                    else
                    {
                        taueta[i] = Math.Pow(pheromones[cityX][i], alpha) * Math.Pow((1.0 / Distance(cityX, i, dists)), beta);
                        if (taueta[i] < 0.0001)
                        {
                            taueta[i] = 0.0001;
                        }
                        else if (taueta[i] > (double.MaxValue / (numCities * 100)))
                        {
                            taueta[i] = double.MaxValue / (numCities * 100);
                        }
                    }
                    sum += taueta[i];
                }

                double[] probs = new double[numCities];
                for (int i = 0; i <= probs.Length - 1; i++)
                {
                    probs[i] = taueta[i] / sum;
                }
                return probs;
            }


            private static void UpdatePheromones(double[][] pheromones, int[][] ants, double[][] dists)
            {
                for (int i = 0; i <= pheromones.Length - 1; i++)
                {
                    for (int j = i + 1; j <= pheromones[i].Length - 1; j++)
                    {
                        for (int k = 0; k <= ants.Length - 1; k++)
                        {
                            double length = Length(ants[k], dists);
                            double decrease = (1.0 - rho) * pheromones[i][j];
                            double increase = 0.0;
                            if (EdgeInTrail(i, j, ants[k]) == true)
                            {
                                increase = (Q / length);
                            }

                            pheromones[i][j] = decrease + increase;

                            if (pheromones[i][j] < 0.0001)
                            {
                                pheromones[i][j] = 0.0001;
                            }
                            else if (pheromones[i][j] > 100000.0)
                            {
                                pheromones[i][j] = 100000.0;
                            }

                            pheromones[j][i] = pheromones[i][j];
                        }
                    }
                }
            }

            private static bool EdgeInTrail(int cityX, int cityY, int[] trail)
            {
                int lastIndex = trail.Length - 1;
                int idx = IndexOfTarget(trail, cityX);

                if (idx == 0 && trail[1] == cityY)
                {
                    return true;
                }
                else if (idx == 0 && trail[lastIndex] == cityY)
                {
                    return true;
                }
                else if (idx == 0)
                {
                    return false;
                }
                else if (idx == lastIndex && trail[lastIndex - 1] == cityY)
                {
                    return true;
                }
                else if (idx == lastIndex && trail[0] == cityY)
                {
                    return true;
                }
                else if (idx == lastIndex)
                {
                    return false;
                }
                else if (trail[idx - 1] == cityY)
                {
                    return true;
                }
                else if (trail[idx + 1] == cityY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }



            

            private static double Distance(int cityX, int cityY, double[][] dists)
            {
                return dists[cityX][cityY];
            }


            


            

            
        private void Button3_Click(object sender, EventArgs e)
        {
            //Solve();
        }


    }
}
