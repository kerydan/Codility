/*
Write a function:

int solution(int A, int B, int K);

that, given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K, i.e.:

{ i : A ≤ i ≤ B, i mod K = 0 }

For example, for A = 6, B = 11 and K = 2, your function should return 3, because there are three numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.

Assume that:

A and B are integers within the range [0..2,000,000,000];
K is an integer within the range [1..2,000,000,000];
A ≤ B.
Complexity:

expected worst-case time complexity is O(1);
expected worst-case space complexity is O(1).
*/

using namespace std;

int solution(int A, int B, int K) {
    long long high = K*(B / K);
    if (high < A)
        return 0;
    long long low = A % K + K*(A / K);
    return (high - low) / K + 1;
}

int main()
{
    auto res1 = solution(6, 11, 2);
    auto res2 = solution(11, 20, 17);
    auto res3 = solution(11, 345, 17);
    auto res4 = solution(0, 0, 11);
    auto res5 = solution(1, 1, 11);
    auto res6 = solution(10, 10, 20);

    return 0;
}


