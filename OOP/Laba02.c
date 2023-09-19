#include <stdio.h>
#include <stdlib.h>
#include <time.h>


int** genRandMatrix(int);
void printMatrix(int**, int);
void printArray(int*, int);
void leftDiagonal(int**, int, int*);


void task2();

int main()
{
    int v;
    while(1)
    {
        printf("\nEnter the task:");
        scanf("%i", &v);
        switch(v)
        {

            case 2:
                task2();
                break;
            default:
                return 0;
        }
    }
}

void task2()
{
    srand(time(NULL));
    int n;
    printf("Enter the n: ");
    scanf("%i", &n);
    int** matrix = genRandMatrix(n);
    int* array = (int*)malloc(n*n*sizeof(int));
    printMatrix(matrix, n);
    leftDiagonal(matrix, n, array);
    printArray(array, n*n);
    
    for(int i = 0; i < n; i++)
    {
        free(matrix[i]);
    }
    free(matrix);
}

int** genRandMatrix(int n)
{
    int** mat = (int**)malloc(n * sizeof(int*));

    for(int i = 0; i < n; i++)
    {
        mat[i] = (int*)malloc(n * sizeof(int));

        for(int j = 0; j < n; j++)
        {
            mat[i][j] = 1 + rand()%20;
        }
    }

    return mat;
}

void printMatrix(int** matrix, int n)
{
    for(int i = 0; i < n; i++)
    {
        for(int j = 0; j < n; j++)
        {
            printf("\t%i ", matrix[i][j]);
        }
        printf("\n");
    }
}

void printArray(int* array, int n)
{
    for(int i = 0; i < n; i++)
    {
        printf("%i ", array[i]);
    }
}

void leftDiagonal(int** matrix, int n, int* array)
{
    int temp; //Размер 3
    int k = 0; //Счётчик массива
    int iterations = 2*n - 1; //5

    for(int i = 0; i < iterations; i++)
    {
        if(i < n)
        {
            temp = 0;
            for(int j = i; j >= 0; j--)
            {
                array[k] = matrix[temp][j];
                k++;
                temp++;
            }
        }
        else
        {
            temp = i - n + 1; // 1 2 3 
            for(int j = n; temp <= iterations - i + 1; j--)
            {
                array[k] = matrix[temp][j];
                k++;
                temp++;
            }
        }
    }

}
