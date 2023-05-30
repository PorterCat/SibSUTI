#include <iostream>
#include <stdio.h>
#include <time.h>

using namespace std;

void freeMatrix(int**A, int n) // A[n][m]
{
    for (int i = 0; i < n; i++)
    {
        delete A[i];
    }

    delete A;
}

void fillMatrix(int**A, int n, int m)
{
    srand(time(NULL));
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            A[i][j] = 1 + rand()%100;
        }
    }
}

void fillRandArray(int*A, int n)
{
    srand(time(NULL));

    for (int i = 0; i < n; i++)
    {
        A[i] = 1 + rand()%100;
    } 
}

void printArray(int*A, int n)
{
    printf("[");
    for (int i = 0; i < n-1; i++)
    {
        printf("%d, ", A[i]);
    } 
    printf("%d", A[n-1]);
    printf("]");
}

void printMatrix(int**A, int n, int m)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout.width(4);
            cout << A[i][j];
        }
        cout << endl;
    }
    cout << endl;
}

void quickSort(int* A, int L, int R)
{
    int x = A[(L+R)/2];
    int i = L;
    int j = R;
    while (i <= j)
    { 
        while (A[i] > x)
        {  
            i++;
        }
        
        while (A[j] < x)
        {  
            j--;
        }
        if (i <= j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
            i++;
            j--;
        }
    }
     
    if (L < j)
    {
        quickSort(A, L, j);
    }

    if (i < R)
    {
        quickSort(A, i, R);
    }
}

int binSearch(int* A, int n, int x)
{
    int L = 0, R = n-1;
    bool _founded = false;
    
    while(L<R)
    {
        int m = (L+R)/2;
        if(A[m] >= x)
        {
            L = m + 1;
        }
        else
        {
            R = m;
        }
    }

    if(A[R] = x)
    {
        printf("The searching elemnt is under index: %d", R);
        return R;
    }
    else
    {
        printf("there's no such element");
        return -1;
    }
}

int OverSearch(int* A, int n, int x)
{
    int i = 0;
    while(A[i] != x)
    {
        if(i == n)
        {
            printf("there's no such element");
            return -1;
        }
        i++;
    }
    if(A[i] == x)
    {
        printf("The searching elemnt is under index: %d", i);
        return i;
    }
    printf("there's no such element");
    return -1;
}

void task1()
{
    int n, m;
    cin >> n >> m;

    int** A = new int*[n];
    for (int i = 0; i < n; i++)
    {
        A[i] = new int[m];
    }

    fillMatrix(A, n, m);
    printMatrix(A, n, m);

    int *min1 = NULL;
    int *min2 = NULL;

    min1 = &A[0][0];
    min2 = &A[0][1];

    for(int i = 0; i < n; i++)
    {
        for(int j = 0; j < m; j++)
        {
            if(A[i][j] < *min1)
            {
                min1 = &A[i][j];
            }
        }
    }

    for(int i = 0; i < n; i++)
    {
        for(int j = 0; j < m; j++)
        {
            if(A[i][j] < *min2)
            {
                if(&A[i][j] != min1)
                {
                    min2 = &A[i][j];
                }
            }
        }
    }

    printf("\nMinimal elements: %d %d\n\n", *min1, *min2);

    bool flag = false;

    for(int i = 0; i < n; i++)
    {
        for(int j = 0; j < m; j++)
        {
            if(&A[i][j] == min2 || &A[i][j] == min1)
            {
                if(flag)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
                continue;;
            }

            if(flag)
            {
                A[i][j] = 0;
            }
        }
    }

    printMatrix(A, n, m);
    freeMatrix(A, n);
}

void task2()
{
    srand(time(NULL));
    int n = 2+rand()%10;

    int** A = new int*[n];
    
    for (int i = 0; i < n; i++)
    {
        int sum = 0;
        int m = 2+rand()%10;
        A[i] = new int[m];
        A[i][0] = m-1;
        printf("%d\t |", A[i][0]);
        for (int j = 1; j < m; j++)
        {
            A[i][j] = 1 + rand()%10;
            sum += A[i][j];
            printf("%d\t|", A[i][j]);
        }

        for(int k = 0; k < 11 - A[i][0]; k++)
        {
            printf("\t");
        }
        printf(" |Sum: %d\n", sum);
        delete A[i];
    }

    delete A;
}

void task3() //Задание 3
{

    int n = 10;
    int* A = new int[n];
    fillRandArray(A, n);
    printf(" Array: ");
    printArray(A, n);
    printf("\nSorted: ");
    //сортировка
    quickSort(A, 0, n-1);
    printArray(A, n);

    int x;
    printf("\n Type key for OverSearch and Bin Search: ");
    cin >> x;
    printf("\n");
    if(binSearch(A, n, x) != -1)
    {
        printf("\n");
        OverSearch(A, n, x);
    }
    delete A;
}


int main(int argc, char** argv)
{
    task3();

    


}