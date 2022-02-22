// 3byN.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;
long double rekurzioval(int n)
{
    vector<int> alap (n);
    vector<int> karoly (n);
    
    alap[0] = 0;
    for (size_t i = 0; i < length; i++)
    {

    }
}
long double ThreeByNBoard(int n)
{
    vector<vector<long double>> solution(8, vector<long double>(n + 1)); //8 sor (n+1) oszlop
    solution[7][0] = 1;
    for (size_t i = 1; i < n + 1; i++)
    {
        solution[0][i] += solution[7][i - 1];

        solution[1][i] += solution[6][i - 1];

        //solution[2][i] += solution[5][i - 1]; sehogysme lehet kihozni a 2. pozíciót

        solution[3][i] += solution[7][i - 1];
        solution[3][i] += solution[4][i - 1];

        solution[4][i] += solution[3][i - 1];

        //solution[5][i] += solution[2][i - 1]; sehogysme lehet kihozni a 5. pozíciót

        solution[6][i] += solution[7][i - 1];
        solution[6][i] += solution[1][i - 1];

        solution[7][i] += solution[3][i - 1];
        solution[7][i] += solution[6][i - 1];
        solution[7][i] += solution[0][i - 1];
    }
    return solution[7][n];
}
int main()
{
    /*
    int N = 1;
    while (N % 2 != 0 && N >= 0)
    {
        cout << "2-vel oszthato pozitiv szam :" << endl;
        cin >> N;
    }
    if (N != 0)
        cout << ThreeByNBoard(N);
    else
        cout << "0";*/
    int N = 1;
    while (N % 2 != 0 && N <= 0)
    {
        cout << "2-vel oszthato pozitiv szam :" << endl;
        cin >> N;
    }
    if (N != 0)
        cout << ThreeByNBoard(N);
    else
        cout << "0";
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
