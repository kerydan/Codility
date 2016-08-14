/*
A company of dwarfs is travelling across the New Zealand. On reaching the Clutha River the dwarfs need to get across, but recent storms have washed away the bridge. Luckily, a small ferry, in the form of a square raft, is operating.

The raft is square and has N rows of seats, numbered from 1 to N. Each row contains N seats, labeled with consecutive letters (A, B, C, etc.). Each seat is identified by a string composed of its row number followed by its column number; for example, "9C" denotes the third seat in the 9th row.

The raft has already been loaded with barrels in some seat positions, and other seats are already occupied by dwarfs. Our company of dwarfs may only take the remaining unoccupied seats. The ferryman wants to accommodate as many dwarfs as possible, but the raft needs to be stable when making the crossing. That is, the following conditions must be satisfied:

the front and back halves of the raft (in terms of the rows of seats) must each contain the same number of dwarfs;
similarly, the left and right sides of the raft (in terms of the columns of seats) must each contain the same number of dwarfs.
You do not have to worry about balancing the barrels; you can assume that their weights are negligible.

For example, a raft of size N = 4 is shown in the following illustration:



Barrels are marked as brown squares, and seats that are already occupied by dwarfs are labeled d.

The positions of the barrels are given in string S. The occupied seat numbers are given in string T. The contents of the strings are separated by single spaces and may appear in any order. For example, in the diagram above, S = "1B 1C 4B 1D 2A" and T = "3B 2D".

In this example, the ferryman can accommodate at most six more dwarfs, as indicated by the green squares in the following diagram:



The raft is then balanced: both left and right halves have the same number of dwarfs (four), and both front and back halves have the same number of dwarfs (also four).

Write a function:

class Solution { public int solution(int N, string S, string T); }
that, given the size of the raft N and two strings S, T that describes the positions of barrels and occupied seats, respectively, returns the maximum number of dwarfs that can fit on the raft. If it is not possible to balance the raft with dwarfs, your function should return -1.

For instance, given N = 4, S = "1B 1C 4B 1D 2A" and T = "3B 2D", your function should return 6, as explained above.

Assume that:

N is an even integer within the range [2..26];
strings S, T consist of valid seat numbers, separated with spaces;
each seat number can appear no more than once in the strings;
no seat number can appear in both S and T simultaneously.
In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.

*/
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
