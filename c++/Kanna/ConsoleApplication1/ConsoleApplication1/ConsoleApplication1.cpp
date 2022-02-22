// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;
/*
3
8
5
3
6
*/
bool contains(vector<int> lista, int item)
{
	bool solution = false;
	for (auto& i : lista)
	{
		if (i == item)
		{
			solution = true;
			break;
		}
	}
	return solution;
}
vector<int> rekurzivkereses(vector<int> kapacitas, vector<int> lepesek, vector<int> mostani, int cel, int melyikpohar)
{
	vector<int> solution;

	if (contains(mostani, cel))
	{
		return lepesek;
	}
	else
	{
		vector<vector<int>> temp;
		//elso és masodik eset:
		for (int i = 0; i < kapacitas.size(); i++)
		{
			int megmaradtHELY = kapacitas[i] - mostani[i];
			if (i != melyikpohar && megmaradtHELY != 0)//ha nem ugynaaz és nincs a másik tele
			{
				
			}
		}
	}

	return solution;
}

int main()
{
    cout << "Hány szám lesz ?" << endl;
    int valamennyi;
	cin >> valamennyi;
	vector<int> kapacitas;
	for (size_t i = 0; i < valamennyi; i++)
	{
		int temp;
		cin >> temp;
		kapacitas.push_back(temp);
	}
	cout << "Kivánt végeredmény:" << endl;
	int cel;
	cin >> cel;
	
	vector<int> lepesek;
	lepesek.push_back(0);
	vector<int> mostani(valamennyi);
	mostani[0] = kapacitas[0];
	
	vector<int> megoldas = rekurzivkereses(kapacitas, lepesek, mostani, cel, 0);
}
