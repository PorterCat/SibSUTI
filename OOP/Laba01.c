#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int* genRandArray(int, int);
void print(int*);

int** genRandMatrix(int, int);
void printMatrix(int**);

void task1();
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
            case 1: 
                task1();
                break;
            case 2:
                task2();
                break;
            default:
                return 0;
        }
    }
}

void task1()
{
    srand(time(NULL));
    int size = rand()%10;
    int maxValue = 100;
    int* arr = genRandArray(size, maxValue);
    print(arr);
    free(arr);
}

int* genRandArray(int size, int maxValue)
{
    int* arr = malloc((size+1)*sizeof(int));
    arr[0] = size;
    for(int i = 1; i < size+1; i++)
    {
        arr[i] = rand()%maxValue;
    }
    return arr;
}

void print(int* arr)
{
    printf("%i: ", arr[0]);
    for(int i = 1; i <= arr[0]; i++)
    {
        printf("%i ", arr[i]);
    }
}

void task2()
{
    srand(time(NULL));
    int size = rand()%10;
    int maxValue = 100;
    int** matrix = genRandMatrix(size, maxValue);
    printMatrix(matrix);
    
    for(int i = 0; i < size + 1; i++)
    {
        free(matrix[i]);
    }
    free(matrix);
}

int** genRandMatrix(int size, int maxValue)
{
    int** mat = malloc((size + 1) * sizeof(int*));
    mat[0] = malloc(1 * sizeof(int));
    mat[0][0] = size;
    int l_size;

    for(int i = 1; i < size + 1; i++)
    {
        l_size = rand()%10;
        mat[i] = malloc((l_size+1) * sizeof(int));
        mat[i][0] = l_size;
        for(int j = 1; j < l_size + 1; j++)
        {
            mat[i][j] = rand()%maxValue;
        }
    }

    return mat;
}

void printMatrix(int** matrix)
{
    printf("%i\n", matrix[0][0]);
    for(int i = 1; i <= matrix[0][0]; i++)
    {
        printf("%i: ", matrix[i][0]);
        for(int j = 1; j <= matrix[i][0]; j++)
        {
            printf("%i ", matrix[i][j]);
        }
        printf("\n");
    }
}
