using System;

namespace ConsoleApplicationCSharp
{



    class Solution
    {
        struct quoter
        {
            public quoter(int capacity)
            {
                seat = capacity;
                dwarf = 0;
            }
            public int seat;
            public int dwarf;
        };

        int GetQuoterInd(string A, int N, ref int str_ind)
        {
            int num = 0;
            if (char.IsLetter(A[str_ind + 1]))
            {
                num = A[str_ind] - 0x31;
                str_ind++;
            }
            else
            {
                num = (A[str_ind] - 0x30) * 10 + (A[str_ind + 1] - 0x31);
                str_ind += 2;
            }

            int bit1 = num >= N / 2 ? 1 : 0;
            int bit2 = (A[str_ind] - 0x41) >= N / 2 ? 1 : 0;
            int qw_ind = bit1 + bit2 * 2;
            str_ind += 2;
            return qw_ind;
        }



        public int solution(int N, string S, string T)
        {
            int cap = N * N / 4;
            quoter[] q = new quoter[4] { new quoter(cap), new quoter(cap), new quoter(cap), new quoter(cap) };

            var sum = 0;

            var ind = 0;
            while (ind < S.Length)
            {
                int qw_ind = GetQuoterInd(S, N, ref ind);
                q[qw_ind].seat--;
            }
            ind = 0;
            while (ind < T.Length)
            {
                int qw_ind = GetQuoterInd(T, N, ref ind);
                q[qw_ind].dwarf++;
            }

            int min_seat = Math.Min(q[0].seat, q[3].seat);

            if (min_seat < q[0].dwarf || min_seat < q[3].dwarf)
            {
                return -1;
            }
            sum += min_seat - q[0].dwarf;
            sum += min_seat - q[3].dwarf;

            min_seat = Math.Min(q[1].seat, q[2].seat);

            if (min_seat < q[1].dwarf || min_seat < q[2].dwarf)
            {
                return -1;
            }
            sum += min_seat - q[1].dwarf;
            sum += min_seat - q[2].dwarf;

            return sum;
        }
    }


    class Program
    {
        // caterpillar unique slices 

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string S = "1B 1C 4B 1D 2A";
            string T = "3B 2D";

            int i = sol.solution(4, S, T);


            string S1 = "";
            string T1 = "";

            int i1 = sol.solution(4, S1, T1);


        }
    }
}
