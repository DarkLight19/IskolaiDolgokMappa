// 3FeleTorony.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;
int JK(int N)
{
    vector<int> solution(N);
    solution[0] = 2;
    solution[1] = 4;
    solution[2] = 9;
    solution[3] = 21;
    for (size_t i = 4; i < N; i++)
    {
        solution[i] = 2 * solution[i - 1] + solution[i - 3] + solution[i - 4];
    }
    return solution[N - 1];
}
int main()
{
    int N;
    cin >> N;
    cout << JK(N);
}

