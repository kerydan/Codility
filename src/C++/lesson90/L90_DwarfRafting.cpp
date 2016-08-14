#include <string>
#include <algorithm>
using namespace std;


struct quoter {
	quoter(int capacity) {
		seat = capacity;
		dwarf = 0;
	}
	int seat;
	int dwarf;
};

int GetQuoterInd(string &A, int N, int& str_ind) {
	int num = 0;
	if (iswalpha(A[str_ind + 1]))
	{
		num = A[str_ind] - 0x31;
		str_ind++;
	}
	else
	{
		num = (A[str_ind] - 0x30) * 10 + (A[str_ind + 1] - 0x31);
		str_ind += 2;
	}

	int bit1 = (num >= N / 2);
	int bit2 = ((A[str_ind] - 0x41) >= N / 2);
	int qw_ind = bit1 + bit2 * 2;
	str_ind += 2;
	return qw_ind;
}

int solution(int N, string &S, string &T) {
	int cap = N * N / 4;
	quoter q[4] = { cap, cap, cap, cap };

	auto sum = 0;

	auto ind = 0;
	while (ind < S.size()) {
		int qw_ind = GetQuoterInd(S, N, ind);
		q[qw_ind].seat--;
	}
	ind = 0;
	while (ind < T.size()) {
		int qw_ind = GetQuoterInd(T, N, ind);
		q[qw_ind].dwarf++;
	}

	int min_seat = min(q[0].seat, q[3].seat);

	if (min_seat < q[0].dwarf || min_seat < q[3].dwarf) {
		return -1;
	}
	sum += min_seat - q[0].dwarf;
	sum += min_seat - q[3].dwarf;

	min_seat = min(q[1].seat, q[2].seat);

	if (min_seat < q[1].dwarf || min_seat < q[2].dwarf) {
		return -1;
	}
	sum += min_seat - q[1].dwarf;
	sum += min_seat - q[2].dwarf;

	return sum;
}

int main()
{
	string S("1B 1C 4B 1D 2A");
	string T("3B 2D");

	int i = solution(4, S, T);


	string S1("");
	string T1("");

	int i1 = solution(4, S1, T1);

	string S2("");
	string T2("");

	int i2 = solution(2, S2, T2);

	string S3("1B 1C 4B 1D 2A");
	string T3("3B 2D");

	int i3 = solution(26, S3, T3);

	string S4("");
	string T4("");

	int i4 = solution(26, S4, T4);

	string S5("");
	string T5("1A 1B");

	int i5 = solution(26, S5, T5);

	string S6("");
	string T6("25A 26B");

	int i6 = solution(26, S6, T6);


    return 0;
}
