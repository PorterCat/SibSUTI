#include <iostream>
#include <fstream>
#include <string>
#include <math.h>
#include <stack>

using namespace std;
// void showMatrix(int**, int);
int strong_componenta(int**, int);
void DFS(int**, int, int*, int, bool*);
void DFS2(int**, int, int*);
int** inverMatrix(int**, int);
void selectSort(int*, int*, int);

int main()
{
    const char* file_path = "Matrix.txt";

    ifstream file(file_path);
    char ch;
    int** Matrix; //Матрица смежности
    int matrix_size; // Размер матрицы NxN 

    if (file.is_open())
    {
        string buffer;
        while ((ch = file.get()) != EOF)
        {
            if (ch == '1' || ch == '0')
            {
                buffer.push_back(ch); //В буффер заносятся только 1 и 0. Счетчик размера матрицы (проверки нет, поэтому важно передавать сразу корректную матрицу NxN)
            }
        }

        matrix_size = sqrt(buffer.size());

        Matrix = new int* [matrix_size];
        int k = 0;
        for (int i = 0; i < matrix_size; i++)
        {
            Matrix[i] = new int[matrix_size];
            for (int j = 0; j < matrix_size; j++)
            {
                Matrix[i][j] = buffer[k] - '0';
                k++;
            }
        }

        strong_componenta(Matrix, matrix_size);

    }
}

void selectSort(int* mas, int* indexmas, int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        int max = i;
        for (int j = i + 1; j < n; j++)
        {
            if (mas[indexmas[j]] > mas[indexmas[max]])
            {
                max = j;
            }
        }
        if (max != i)
        {
            int temp = indexmas[max];
            indexmas[max] = indexmas[i];
            indexmas[i] = temp;
        }
    }
}


void DFS(int** mat, int n, int* ord, int v, int counter, bool* visited) //Матрица, её размер, массив для DFS, индекс начальной вершины
{
    int head = v; //Индекс просмаотриваемой вершины 
    stack<int> Stack; //Инициализируем стек
    Stack.push(head); //Вставляем переданный элемент
    counter++;
    ord[head] = counter;
    visited[head] = true;
    int j = 0;
    
    for (j = 0; j < n;)
    {
        if (mat[head][j] == 1 && visited[j] == false)
        {
            cout << head << "->" << j << endl;
            head = j;
            Stack.push(head);
            counter++;
            j = 0;
            ord[head] = counter;
            visited[head] = true;
            continue;
        }
        j++;
    }
    
    //если программа вышла из цикла, значит соседей больше нет
    while (!Stack.empty())
    {
        int temp = Stack.top();
        Stack.pop();
        if (Stack.empty())
        {
            break;
        }
        cout << temp << "->";

        head = Stack.top();

        cout << head << endl;

        counter++;
        ord[head] = counter;

        for (j = 0; j < n; j++)
        {
            if (mat[head][j] == 1 && visited[j] == false)
            {
                cout << head << "->" << j << endl;
                head = j;
                Stack.push(head);
                counter++;
                j = 0;
                ord[head] = counter;
                visited[head] = true;
            }
        }
    }

}

void DFS2(int** mat, int n, int* ord)
{
    int* index_Mas = new int[n];
    for (int i = 0; i < n; i++)
        index_Mas[i] = i;
    
    selectSort(ord, index_Mas, n); //Индексный массив теперь хранит вершины в порядке убывания значений DFS

    bool* visited = new bool[n];
    for (int i = 0; i < n; i++)
        visited[i] = false;

    cout << endl;
    cout << "Strong components of conection: " << endl;
    cout << "==============================" << endl;

    int componenta = 1;

    for (int i = 0; i < n; i++)
    {
        if (visited[index_Mas[i]] == false)
        {
            cout << componenta << " componenta: " << index_Mas[i];
            componenta++;
            int head = index_Mas[i];
            for (int j = 0; j < n;)
            {
                if (mat[head][j] == 1 && visited[j] == false && ord[j] < ord[index_Mas[i]])
                {
                    head = j;
                    j = 0;
                    visited[head] = true;
                    cout << ", " << head;
                    continue;
                }
                j++;
            }
            cout << endl;
        }
    }
}

int** inverMatrix(int** mat, int n)
{
    int** iMatrix;
    iMatrix = new int* [n];
    for (int i = 0; i < n; i++)
    {
        iMatrix[i] = new int[n];
        for (int j = 0; j < n; j++)
        {
            iMatrix[i][j] = mat[j][i];
        }
    }

    return iMatrix;
}

int strong_componenta(int** mat, int n)
{
    cout << endl;

    //Начинаем поиск компонент связаности 
    int* comp_nodes = new int[n]; //Массив вершин графа (узлов)

    bool* visited = new bool[n]; //Массив посещаемости вершины
    for (int i = 0; i < n; i++)
        visited[i] = false;

    for (int i = 0; i < n; i++)
    {
        comp_nodes[i] = 0; //Задаём компоненту связности везде 0
    }

    int count = 0;
    int i = 0;

    cout << "Analizint pathes..." << endl;
    while (i < n)
    {
        if (comp_nodes[i] == 0)
        {
            DFS(mat, n, comp_nodes, i, count, visited); //(матрица, рассматриваемая вершина)
        }
        i++;
    }

    //Инвертируеи исходную матрицу 
    int** iMat = inverMatrix(mat, n); // Строится транспонированная матрица

    DFS2(iMat, n, comp_nodes);

    return 0;
}

// void showMatrix(int** matrix, int n)
// {
//     for (int i = 0; i < n; i++)
//     {
//         for (int j = 0; j < n; j++)
//         {
//             cout << matrix[i][j] << ' ';
//         }
//         cout << endl;
//     }
// }
