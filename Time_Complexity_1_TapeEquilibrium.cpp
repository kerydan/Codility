// Time_Complexity_1_TapeEquilibrium.cpp : Defines the entry point for the console application.
//
#include <iostream>
#include <vector>
#include <numeric>
using namespace std;

int solution(vector<int> &A) {
    int rightSum = accumulate(A.begin(), A.end(), 0)-A[0];
    int leftSum = A[0];
    int minDiff = abs(rightSum - leftSum);
    for (auto i = 1; i + 1 < A.size(); i++){
        leftSum += A[i];
        rightSum -= A[i];
        int diff = abs(rightSum - leftSum);
        minDiff = diff < minDiff ? diff : minDiff;
    }
    return minDiff;
}

int main()
{
    vector<int> A{ 3, 1, 2, 4, 3 };
    solution(A);

	return 0;
}

