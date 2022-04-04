// Fizeto.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <cmath>
using namespace std;

pair<int,vector<string>> szanko(vector<vector<int>> alap)
{
    pair<int, vector<string>> y;
    vector<vector<int>> solution(alap.size(), vector<int>(alap[0].size()));
    for (size_t i = 1; i < solution.size(); i++)
    {
        for (size_t j = 1; j < solution[0].size(); j++)
        {
            if (i == 1 && j == 1)
                solution[i][j] = alap[i][j];
            else
                solution[i][j] = max(max(solution[i - 1][j], solution[i][j - 1]), solution[i - 1][j - 1]) + alap[i][j] - 1; // a "max" csak 2 inputra mûködik
        }
    }
    y.first = solution[solution.size() - 1][solution[0].size() - 1];
    int localI = solution.size()-1;
    int localJ = solution[0].size()-1;
    while (localI > 1 && localJ > 1)
    {
        int legnagyobb = max(max(solution[localI - 1][localJ], solution[localI - 1][localJ - 1]), solution[localI][localJ - 1]); // a "max" csak 2 inputra mûködik
        if (legnagyobb == solution[localI - 1][localJ])
        {
            y.second.push_back("L");
            --localI;
        }
        else if (legnagyobb == solution[localI - 1][localJ - 1])
        {
            y.second.push_back("A");
            --localI;
            --localJ;
        }
        else
        {
            y.second.push_back("J");
            --localJ;
        }
    }
    while (localI > 1)
    {
        y.second.push_back("L");
    }
    while (localJ > 1)
    {
        y.second.push_back("J");
    }
    return y;
}
int main()
{
    int N, M;
    cin >> N >> M;
    vector<vector<int>> x(N + 1, vector<int>(M + 1));
    for (size_t i = 1; i < N+1; i++)
    {
        for (size_t j = 1; j < M + 1; j++)
        {
            cin >> x[i][j];
        }
    }
    pair<int, vector<string>> y(szanko(x));
    cout << y.first << endl;
    for (size_t i = y.second.size(); i > 0 ; i--)
    {
        cout << y.second[i-1];
    }
}
