// Jardakovezes.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <cmath>
using namespace std;
int Jk(int n)
{
	vector<int> solution(n+1);
	solution[0] = 0;
	solution[1] = 2;
	solution[2] = 4;
	solution[3] = 10;
	for (size_t i = 4; i < n+1; i++)
	{
		solution[i] = (i % 3) * solution[1] + floor(i / 3) * solution[i];
	}
	return solution[n-1];
}
int main()
{
	int N;
	cin >> N;
	cout << Jk(N);
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
