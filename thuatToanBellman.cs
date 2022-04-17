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
            for (Step = 1; Step <= AM.n; Step++) //step k
            {
                for (int k = 0; k < AM.n; k++) //duyệt từng đỉnh i
                {
                    Cost[Step, k] = Cost[Step - 1, k];
                    Prev[Step, k] = Prev[Step - 1, k];
                    for(int v = 0; v < AM.n; v++) //duyệt từng đỉnh j
                    {
                        if(AM.maTran[v, k] != 0)
                        {

                        }
                    }
                }
                bool kiemTra = true;
                for (int k = 0; k < AM.n; k++) //duyệt từng đỉnh i
                {
                    if(Cost[Step, k] != Cost[Step - 1, k])
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
        }
    }
}
