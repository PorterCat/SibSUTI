#include <stdio.h>
#include <stdlib.h>
#include <time.h>


int** genRandMatrix(int);
void printMatrix(int**, int);
void printArray(int*, int);
void leftDiagonal(int**, int, int*);
void rightDiagonal(int**, int, int*);
void centralSpiral(int**, int, int*);
void leftSpiral(int**, int, int*);
void swap(int*, int*);

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
    int n;
    printf("Enter the n: ");
    scanf("%i", &n);
    int** matrix = genRandMatrix(n);
    int* array = (int*)malloc(n*n*sizeof(int));
    printMatrix(matrix, n);

    rightDiagonal(matrix, n, array);
    printArray(array, n*n);
    leftDiagonal(matrix, n, array);
    printArray(array, n*n);
    centralSpiral(matrix, n, array);
    printArray(array, n*n);
    leftSpiral(matrix, n, array);
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
    printf("\n");
}

void leftDiagonal(int** matrix, int n, int* array)
{
    int k = 0;
    for (int d = 0; d < n; d++) 
    {
        for (int i = 0, j = d; j >= 0; i++, j--) 
        {
            array[k] = matrix[i][j];
            k++;
        }
    }
    for (int d = 1; d < n; d++) 
    {
        for (int i = d, j = n - 1; i < n; i++, j--) 
        {
            array[k] = matrix[i][j];
            k++;
        }
    }
}

void rightDiagonal(int** matrix, int n, int* array)
{
    int k = 0;
    for (int d = 0; d < n; d++)
    {
        for (int i = 0, j = n - d - 1; j < n; i++, j++) 
        {
            array[k] = matrix[i][j];
            k++;
        }
    }
    for (int d = 1; d < n; d++) 
    {
        for (int i = d, j = 0; i < n; i++, j++)
        {
            array[k] = matrix[i][j];
            k++;
        }
    }
}

void centralSpiral(int** matrix, int n, int* array)
{
    leftSpiral(matrix, n, array);
    int size = n * n;
    for(int i = 0; i < size/2; i++)
    {
        swap(&array[i], &array[size-1-i]);
    }

}

void leftSpiral(int** matrix, int n, int* array)
{
    int top = 0, bottom = n - 1;
    int left = 0, right = n - 1;
    int k = 0;

    while (top <= bottom && left <= right) 
    {

        for (int j = left; j <= right; j++) 
        {
            array[k] = matrix[top][j];
            k++;
        }
        top++;

        for (int i = top; i <= bottom; i++) 
        {
            array[k] = matrix[i][right];
            k++;
        }
        right--;

        if (top <= bottom) 
        {
            for (int j = right; j >= left; j--) 
            {
                array[k] = matrix[bottom][j];
                k++;
            }
            bottom--;
        }

        if (left <= right) 
        {
            for (int i = bottom; i >= top; i--) 
            {
                array[k] = matrix[i][left];
                k++;
            }
            left++;
        }
    }
}

void swap(int* a, int* b)
{
    int temp;
    temp = *a;
    *a = *b;
    *b = temp;
}

void task2()
{
    srand(time(NULL));
    int n;
    printf("Enter the n: ");
    scanf("%i", &n);

    int m;
    
    int** mat = (int**)malloc(n * sizeof(int*));
    int lines[n];

    for(int i = 0; i < n; i++)
    {
        m = 1 + rand()%10;
        lines[i] = m;
        mat[i] = (int*)malloc(m * sizeof(int));

        for(int j = 0; j < m; j++)
        {
            mat[i][j] = 1 + rand()%20;
        }
    }

    for(int i = 0; i < n; i++)
    {
        m = lines[i];
        for(int j = 0; j < m; j++)
        {
            printf("\t%i ", mat[i][j]);
        }
        printf("\n");
    }

    for(int i = 0; i < n; i++)
    {
        free(mat[i]);
    }
    free(mat);
}