#include <iostream>
#include <algorithm>
#include <vector>
#include <stack>
#include <queue>
using namespace std;
/*
class CsucslistasGraf
{
public:

    vector<vector<int>>* csucslista; //lehessen new-olni
    int N;
    int M;

    CsucslistasGraf()
    {
        cin >> N >> M;

        csucslista = new vector<vector<int>>(N+1, vector<int>()); // létrehoz egy listát és a csucslista igazából csak rámutat, ahelyett hogy teljesen lemásolná


        for (int i = 0; i < M; i++)
        {
            int honnan;
            int hova;
            cin >> honnan >> hova;

            csucslista->at(honnan).push_back(hova);
            if (honnan != hova)
            {
                (*csucslista)[hova].push_back(honnan);
            }
        }
    }

    void diagnostics()
    {
        for (int i = 0; i < N; i++)
        {
            cout << i << ": [ ";
            for (auto& szomszed : csucslista->at(i))
            {
                cout << szomszed << " ";
            }
            cout << "]\n";
        }
    }

    bool van_el(int a, int b)
    {
        for (size_t i = 0; i < (*csucslista)[a].size(); i++)
        {
            if ((*csucslista)[a][i] == b)
                return true;
        }
        return false;
    }
    void add_edge(int a, int b)
    {
        if (!van_el(a, b))
        {
            (*csucslista)[a].push_back(b);
            (*csucslista)[b].push_back(a);
        }
    }
    pair<int, int> helye(int csucs, bool (*predicate)(int))
    {
        vector<string> szin(N, "fehér");
        stack<int> verem;
        verem.push(csucs);

        while (!verem.empty())
        {
            int temp = verem.top();
            verem.pop();
            szin[temp] = "fekete";

            for (auto& i : csucslista-> at(temp))
            {
                if (szin[i] == "feher")
                {
                    verem.push(i);
                    szin[i] = "szurke";
                }
            }
        }
        /*
        int i = 0;
        while (i < (*csucslista)[a].size() && (*csucslista)[a][i] != b)
            ++i;

        j = 0;
        while (j < (*csucslista)[b].size() && (*csucslista)[b][j] != a)
            ++j;
        return pair<int, int>(i, j);
    }
    void remove_edge(int a, int b)
    {
        if (van_el(a, b))
        {
            --M;
            pair<int, int> hely(helye(a, b));
            if (a != b)
            {

            }
        }
        csucslista->at(a) = remove(csucslista->at(a).begin(), csucslista->at(a).end(), b);
    }
    void add_node()
    {
        (*csucslista).push_back(vector<int>());
    }
    //void remove_node_with_edges(int a);
    int degree(int a)
    {
        return (*csucslista)[a].size();
    }
    bool loop(int a) //ennek van e hzurokélje
    {
        for (size_t i = 0; i < (*csucslista)[a].size(); i++)
        {
            if ((*csucslista)[a][i] = a)
                return true;
        }
        return false;
    }
    bool isolated(int a)
    {
        if ((*csucslista)[a].size() == 0)
            return true; //izolált
        return false;
    }
    bool connected()
    {
        if ((*csucslista)[a].size() == 0)
            return false; //izolált
        return true;
    }
    vector<int> shortest_path(int a, int b)
    {

    }
    //int find





    ~CsucslistasGraf()
    {
    }

private:

};

*/
int main()
{
    /*
    CsucslistasGraf cslgraf;

    cslgraf.diagnostics();
    */
    

}