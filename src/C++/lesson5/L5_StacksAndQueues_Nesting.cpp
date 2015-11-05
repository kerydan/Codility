/*
A string S consisting of N characters is called properly nested if:

S is empty;
S has the form "(U)" where U is a properly nested string;
S has the form "VW" where V and W are properly nested strings.
For example, string "(()(())())" is properly nested but string "())" isn't.

Write a function:

int solution(char *S);

that, given a string S consisting of N characters, returns 1 if string S is properly nested and 0 otherwise.

For example, given S = "(()(())())", the function should return 1 and given S = "())", the function should return 0, as explained above.

Assume that:

N is an integer within the range [0..1,000,000];
string S consists only of the characters "(" and/or ")".
Complexity:

expected worst-case time complexity is O(N);
expected worst-case space complexity is O(1) (not counting the storage required for input arguments).
*/

#include <iostream>
#include <string>
using namespace std;

int solution(string &S) {
    int i = 0;
    for(auto c:S){
	if (c=='(')
	    i++;
	else 
	    i--;
	if (i<0)
	    return 0;
    }
    return i==0 ? 1: 0;
}

int main()
{
    string S1{"(()(())())"};	
    auto res1 = solution(S1);
    string S2{"())"};	
    auto res2 = solution(S2);
    string S3{"()(()()(((()())(()()))"};	
    auto res3 = solution(S3);

    cout << "res1 = " << res1 << ", res2 = " << res2 << ", res3 = "<< res3 << endl;

    return 0;
}


