// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;
int main()
{
    int N = 0;
    int M = 0;
    cin >> N;
    cin >> M;

    vector<int> lista;

    for (size_t i = 0; i < M * 2; i++) // beolvasom
    {
        int a = 0;
        cin >> a;
        lista.push_back(a);
    }

    vector<int> szamol; // üres listán helyet csinálok a számok megszámolásához
    for (size_t i = 0; i < lista.size(); i = i++)
    {
        szamol.push_back(0);
    }
    for (size_t i = 0; i < lista.size(); i = i++) // meg is számolom
    {
        szamol[lista[i]]++;
    }
    //megoldás
    int darab = 0; //hány zsákutca van
    int max = szamol[0]; // maximum utak
    int sorszam = 0; // melyik ketrecé
    for (size_t i = 0; i < szamol.size(); i++)
    {
        if (szamol[i] > max)
        {
            max = szamol[i];
            sorszam = i;
        }
        if (szamol[i] == 1 && i != 0)
        {
            darab++;
        }
    }

    cout << darab << " " << sorszam;
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
