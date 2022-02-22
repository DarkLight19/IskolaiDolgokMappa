// Kerekparverseny.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;

int main()
{/*
    cout << "maxhely" << endl;
    int maxhely;
    cin >> maxhely;
    cout << "dolgok száma" << endl;
    int N;
    cin >> N;

    vector<int, int> x;
    for (size_t i = 0; i < N; i++)
    {
        int hely, ertek;
        cin >> hely;
        cin >> ertek;
        x[i] = hely;
        x[i, i] = ertek;
    }

    int temporary = maxhely;
    vector<vector<int>> y;
    for (size_t i = 0; i < x.size(); i++)
    {
        vector<int> temporary
        for (size_t j = 0; j < x.size(); j++)
        {
            if (j != i)
            {

            }
        }
        temporary = maxhely;
    }
    /*
    input :
    10
    4
    1 20
    6 100
    8 30
    4 25
    */

    int targyak, suly;
    cin >> targyak;
    cin >> suly;

    vector<vector<int>> x; //hasznossági, suly
    for (size_t i = 0; i < targyak; i++)
    {
        int temp;
        cin >> temp;
        x.push_back(vector<int>());
        x[i].push_back(temp);
    }
    for (size_t i = 0; i < targyak; i++)
    {
        int temp;
        cin >> temp;
        x[i].push_back(temp);
    }
    
    for (size_t i = 0; i < x.size(); i++)
    {
        cout << x[i][0] << " " << x[i][1] << endl;
    }

    vector<vector<int>> y;
    for (size_t i = 0; i < targyak; i++)
    {
        y.push_back(vector<int>(suly));
    }

    for (size_t j = 0; j < suly; j++)//elso sor
    {
        if (j >= x[0][1])
        {
            y[0][j] = x[0][0];
        }
    }
    for (size_t i = 0; i < y[0].size(); i++)
    {
        cout << y[0][i] << " ";
    }
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
