using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;



namespace AntColony
{
  public  class AntColonyProgram
    {
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

        private static Random random = new Random();
        private static int alpha = 3;
        private static int beta = 2;

        private static double Decay = 0.01;
        private static double Q = 3.0;

        public static int[] Solve(double[][] dsts, int cts,int numberants, int iterations, out int best)
        {
            try
            {

                int avg = FindAvergae(dsts);
                int coef = avg / 4;
                for (int i = 0; i < dsts.Length; i++)
                {
                    for (int j = 0; j < dsts.Length; j++)
                    {
                        dsts[i][j] /=  coef * 1.35;
                    }
                }
                int numCities = cts;
                int numAnts = numberants;
                int maxTime = iterations;
                

                double[][] dists = dsts;

                // Задает муравьям случайные маршруты
                int[][] ants = InitAnts(numAnts, numCities);
                
                int[] bestTrail = BestTrail(ants, dists);
                // лучший маршрут
                double bestLength = Length(bestTrail, dists);
                // Длина лучшего
                double[][] pheromones = InitPheromones(numCities);

                int time = 0;
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
                    }
                    time += 1;
                }

                best = (int)bestLength;
                return bestTrail;

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                throw new Exception("error");
            }

        }
       
        /// <summary>
        /// Выставляет муравьев
        /// </summary>
        /// <param name="numAnts"></param>
        /// <param name="numCities"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Случайный маршрут
        /// </summary>
        /// <param name="start"></param>
        /// <param name="numCities"></param>
        /// <returns></returns>
        private static int[] RandomTrail(int start, int numCities)
        {
            
            int[] trail = new int[numCities];

            for (int i = 0; i <= numCities - 1; i++)
            {
                trail[i] = i;
            }
            //перемешиваем
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
            //trail[trail.Length - 1] = trail[0];

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
            throw new Exception("ошибка");
        }
        /// <summary>
        /// Длина маршурта
        /// </summary>
        /// <param name="trail"></param>
        /// <param name="dists"></param>
        /// <returns></returns>
        private static double Length(int[] trail, double[][] dists)
        {
            
            double result = 0.0;
            for (int i = 0; i <= trail.Length - 2; i++)
            {
                result += Distance(trail[i], trail[i + 1], dists);
            }
            return result;
        }

        /// <summary>
        /// Выдает лучший маршрут из пройденных
        /// </summary>
        /// <param name="ants"></param>
        /// <param name="dists"></param>
        /// <returns></returns>
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
            int[] bestTrail = new int[numCities];
            ants[idxBestLength].CopyTo(bestTrail, 0);
            return bestTrail;
        }

        /// <summary>
        /// Распыляет феромоны
        /// </summary>
        /// <param name="numCities"></param>
        /// <returns></returns>
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

        
        /// <summary>
        /// обновление муравьев
        /// </summary>
        /// <param name="ants"></param>
        /// <param name="pheromones"></param>
        /// <param name="dists"></param>
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
            //trail[trail.Length - 1] = trail[0]; 
            return trail;
        }
        /// <summary>
        /// Выбор следующего города с учетом вероятности
        /// </summary>
        /// <param name="k"></param>
        /// <param name="cityX"></param>
        /// <param name="visited"></param>
        /// <param name="pheromones"></param>
        /// <param name="dists"></param>
        /// <returns></returns>
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
            throw new Exception("Error");
        }
        /// <summary>
        /// Возвращает вероятность путешествия в город Х
        /// </summary>
        /// <param name="k"></param>
        /// <param name="cityX"></param>
        /// <param name="visited"></param>
        /// <param name="pheromones"></param>
        /// <param name="dists"></param>
        /// <returns></returns>
        private static double[] MoveProbs(int k, int cityX, bool[] visited, double[][] pheromones, double[][] dists)
        {
            int numCities = pheromones.Length;
            double[] taueta = new double[numCities];
            double sum = 0.0;
            // сумма всех вероятностей
            //  i  - следующий город
            for (int i = 0; i <= taueta.Length - 1; i++)
            {
                if (i == cityX)
                {
                    taueta[i] = 0.0;
                    
                }
                else if (visited[i] == true)
                {
                    taueta[i] = 0.0;
                    // нулевая вероятность
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

        /// <summary>
        /// Обновление феромона
        /// </summary>
        /// <param name="pheromones"></param>
        /// <param name="ants"></param>
        /// <param name="dists"></param>
        private static void UpdatePheromones(double[][] pheromones, int[][] ants, double[][] dists)
        {
            for (int i = 0; i <= pheromones.Length - 1; i++)
            {
                for (int j = i + 1; j <= pheromones[i].Length - 1; j++)
                {
                    for (int k = 0; k <= ants.Length - 1; k++)
                    {
                        double length = AntColonyProgram.Length(ants[k], dists);
                        double decrease = (1.0 - Decay) * pheromones[i][j];
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
        /// <summary>
        /// Проверяте находится ли пункт Х и пункт У друг за другом на предолженном пути
        /// </summary>
        /// <param name="cityX"></param>
        /// <param name="cityY"></param>
        /// <param name="trail">предложенный путь</param>
        /// <returns></returns>
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
    }
   
}
