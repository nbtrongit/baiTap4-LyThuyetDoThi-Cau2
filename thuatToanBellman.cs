using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT4_LTDT_Cau2
{
    class thuatToanBellman
    {
        public static void Bellman(maTranKe AM, int dinhBatDau)
        {
            int[,] Cost = new int[AM.n + 1, AM.n];
            int[,] Prev = new int[AM.n + 1, AM.n];
            int Step = 1;
            const int voCuc = int.MaxValue;
            for(int i = 0; i < AM.n; i++)
            {
                for(int j = 0; j < AM.n; j++)
                {
                    Cost[i, j] = voCuc;
                    Prev[i, j] = -1;
                }
            }
            Cost[0, dinhBatDau] = 0;
            for (Step = 1; Step <= AM.n; Step++) //step i
            {
                for (int i = 0; i < AM.n; i++) //duyệt từng đỉnh i
                {
                    Cost[Step, i] = Cost[Step - 1, i];
                    Prev[Step, i] = Prev[Step - 1, i];
                    for(int v = 0; v < AM.n; v++) //duyệt từng đỉnh j
                    {
                        if(AM.maTran[v, i] != 0 && Cost[Step - 1, v] != voCuc)
                        {
                            if(Cost[Step, i] == voCuc || (Cost[Step - 1, v] + AM.maTran[v, i]) < Cost[Step, i])
                            {
                                Cost[Step, i] = Cost[Step - 1, v] + AM.maTran[v, i];
                                Prev[Step, i] = v;
                            }
                        }
                    }
                }
                bool kiemTra = true;
                for (int i = 0; i < AM.n; i++) //duyệt từng đỉnh i
                {
                    if(Cost[Step, i] != Cost[Step - 1, i])
                    {
                        kiemTra = false;
                        break;
                    }
                }
                if (kiemTra)
                {
                    break;
                }
            }
            if(Step == AM.n + 1)
            {
                Console.WriteLine("Đồ thị có mạch âm");
            }
            else
            {
                for(int i = 0; i < Prev.GetLength(1); i++)
                {
                    if(i != dinhBatDau)
                    {
                        Console.Write($"Đường đi ngắn nhất từ {dinhBatDau} đến {i}: ");
                        if(Prev[Step, i] >= 0)
                        {
                            int index = i;
                            int tong = 0;
                            Console.Write(index);
                            while (index != dinhBatDau)
                            {
                                Console.Write($" <- {Prev[Step, index]}");
                                tong += Cost[Step, index];
                                index = Prev[Step, index];
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Chi phí đường đi ngắn nhât: {Cost[Step, i]}"); ;
                        }
                        else
                        {
                            Console.Write("Không có đường đi");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
