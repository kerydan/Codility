/*
Write a function:

int solution(vector<int> &A);

that, given a non-empty zero-indexed array A of N integers, returns the minimal positive integer (greater than 0) that does not occur in A.

For example, given:

  A[0] = 1
  A[1] = 3
  A[2] = 6
  A[3] = 4
  A[4] = 1
  A[5] = 2
the function should return 5.

Assume that:

N is an integer within the range [1..100,000];
each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].
Complexity:

expected worst-case time complexity is O(N);
expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
Elements of input arrays can be modified.
*/

#include <vector>
#include <unordered_set>

using namespace std;

int solution(const int X, vector<int> &A) {
    unordered_set<int> s{ A.begin(), A.end() };
    for (int i = 1; i <= A.size(); i ++ ){
        if (s.count(i) == 0)
            return i;
    }
    return A.size() + 1;
    return -1;
}

int main()
{
    vector<int> A{  1, 3, 6, 4, 1, 2 };
    int res = solution(A); // expected 5

    return 0;
}


