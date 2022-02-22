// Szánkó-hegyoldal.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <map>
#include <vector>
using namespace std;

int main()
{
	int N, M, K, G;
	cin >> N;
	cin >> M;
	cin >> K;
	cin >> G;

#pragma region mátrix
/*
	//map<int, int> map = { N, K };
	const int maxn = 1000; //feladatleírás szerint, memória lefoglalás
	const int maxm = 1000;
	int Matrix[maxn][maxm];

	for (size_t i = 0; i < N; i++)
	{
		for (size_t i = 0; i < M; i++)
		{
			Matrix[i][j] = 0;
		}
	}
*/
#pragma endregion
#pragma region listábna a lista mátrix
	vector<vector<int>> vv(N, vector<int>(M)); // N darab M hosszú 0 sorozattal töltjük fel

	for (size_t i = 0; i < K; i++) //kincsek beolvasása
	{
		int x, y;
		cin >> x >> y;

		vv[x-1][y-1] = 1;
	}

	for (size_t i = 0; i < G; i++) //gyűjtőhelyek beolvasása
	{
		int x, y;
		cin >> x >> y;
	}

	vector<vector<int>> kiszamolt(N, vector<int>(M));


	kiszamolt[0][0] = vv[0][0];
	for (size_t i = 1; i < M; i++) //1. sor
	{
		kiszamolt[0][i] = vv[0][i] + kiszamolt[0][i - 1];
	}

	for (size_t i = 1; i < N; i++) //2.sor
	{
		kiszamolt[i][0] = vv[i][0] + kiszamolt[i - 1][0];
	}

	for (size_t i = 1; i < N; i++) //3. minden más
	{
		for (size_t j = 1; j < M; j++)
		{
			kiszamolt[i][j] = vv[i][j] + kiszamolt[i - 1][j] < kiszamolt[i][j - 1] ? kiszamolt[i][j - 1] : kiszamolt[i - 1][j];
		}
	}

	for (size_t i = 0; i < N; i++)
	{
		for (size_t j = 0; j < M; j++)
		{
			cout << kiszamolt[i][j] << " ";
		}
		cout << endl;
	}

	vector<vector<int>> utvonal;

	int x = N - 1;
	int y = M - 1;
	while (x!=0 && y!=0)
	{
		if (kiszamolt[x - 1][y] < kiszamolt[x][y - 1])
		{
			x--;
		}
		else
		{
			y--;
		}
		utvonal.push_back(vector<int>{x, y});
	}
	if(x>y)
	{
		while (x != 0)
		{
			utvonal.push_back(vector<int>{x, y});
			--x;
		}
	}
	else
	{
		while (y != 0)
		{
			utvonal.push_back(vector<int>{x, y});
			--y;
		}
	}

	for (size_t i = 0; i < N; i++)
	{
		for (size_t j = 0; j < M; j++)
		{
			cout << utvonal[i][j] << " ";
		}
		cout << endl;
	}

#pragma endregion


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
