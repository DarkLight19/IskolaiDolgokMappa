// fibonacci.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;

long long int fib(int n)
{
	if (n < 2)
	{
		return n;
	}
	return fib(n - 2) + fib(n-1); 
}

long long int okosabb(long long int n)
{
	if (n < 2)
	{
		return n;
	}
	vector<long long int> lista(n+1);

	lista[0] = 0;
	lista[1] = 1;
	for (int i = 2; i < n+1; i++)
	{
		lista[i] = lista[i - 2] + lista[i - 1];
	}
	return lista[n];
}


int main()
{
	for (size_t i = 0; i < 100; i++)
	{
		cout << okosabb(i) << " " << i << endl;
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
