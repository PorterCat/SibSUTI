#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <iostream>
#include <iomanip>
#include <time.h>


void FillRand(int*, int);
void FillInc(int*, int);
void FillDec( int*, int);
int CheckSum(int* , int);
int RunNumber(int*, int);
int printMas(int*, int);

void selectSort(int* , int);
void shellSort2(int* , int);
void bubbleSort(int* , int);
void shakerSort(int *, int);
void insertSort(int*, int);
void shellSort(int *, int);
void heapSort(int *, int);
int buildHeap(int *, int, int);
void heapSort(int *, int);

void swap(int*, int*);


void clearCountMC();
void printTable();

int p_mix_count = 0, p_compare_count = 0;
int t_mix_count = 0, t_compare_count = 0;
int e = 0;

int main()
{
    srand(time(NULL));
	
	// int *A;
    // int n = 10;
    // A = new int[n];
    // FillRand(A, n);
    // printMas(A, n);
    // heapSort(A, n);
    // printMas(A, n);

    printTable();

}

void printTable()
{
	
	int i;
	
    printf("%5s|%32s|\n", "  n  ", "HeapSort           ");

    printf("______________________________________\n");


    printf("%5s|%10s|%10s|%10s|\n", " ", "Inc   ", "Dec   ", "Rand   ");
                
    printf("______________________________________\n");                    

	for (i = 1; i < 6; i++)
	{
        int* A;
        int n = i * 100;
        A = new int [n];

        std::cout << std::setw( 5 ) << std::left << n << "|";

        


        FillInc(A, n);
		heapSort(A,n); 
        std::cout << std::setw( 10 ) <<  p_mix_count + p_compare_count + e << "|";
        clearCountMC();

        FillDec(A, n);
		heapSort(A,n); 
        std::cout << std::setw( 10 ) <<  p_mix_count + p_compare_count + e << "|";
        clearCountMC();

        FillRand(A, n);
		heapSort(A,n); 
        std::cout << std::setw( 10 ) <<  p_mix_count + p_compare_count + e << "|";
        clearCountMC();

		
        printf("\n"); 
		
	}
}

int buildHeap(int *A, int n, int i)
{
    int c = 0; 
    int m = 0;
    int x = A[i];
    m++;
    while(1)
    {
        int j = 2 * i;
        if (j > n)
        {
            break;
        }
        c++;
        if ((j < n - 1) && (A[j + 1] >= A[j]))
        {
            j++;
        }
        c++;
        if (x >= A[j])
        {
            break;
        }
        m++;
        A[i] = A[j];
        i = j;
    }
    m++;
    A[i] = x;
    return c+m;
}

void heapSort(int *A, int n) 
{
    int L = floor(n / 2);
    while (L >= 0)
    {
        e += buildHeap(A, n, L);
        L--;
    }
    int R = n - 1;
    while(R > 1)
    {
        p_mix_count+=3;
        swap(&A[0], &A[R]);
        R--;
        e += buildHeap(A, R, 0);
    }
}


void bubbleSort(int *A, int n)
{
	
	int i, j;
	for (i = 0; i < n - 1; i++)
	{
		for(j = i + 1; j < n; j++)
		{
			p_compare_count++;
			if(A[i] > A[j])
			{
				swap(&A[i], &A[j]);
			}
		}
	}
}

void shakerSort(int *A, int n)
{
	int L = 0, R = n-1, k = 0, i, j;
	while(L < R)
	{
		for(j = R; j > L ; )
		{
			p_compare_count++;
			if(A[j] < A[j - 1])
			{
				swap(&A[j], &A[j-1]);
				k = j;
			}	
			j--;
		}
		if(p_mix_count == 0)
		{
			break;
		}
		L = k;
		for (j = L; j < R; )
		{
			p_compare_count++;
			if(A[j] > A[j+1])
			{
				swap(&A[j], &A[j+1]);
				k = j;
			}
			j++;
		}
		R = k;
	}
	
}

void insertSort(int* A, int n)
{
    int t, j;
    for(int i = 1; i < n; i++)
    {
        t = A[i];
        p_mix_count++;
        j = i - 1;
		p_compare_count ++;
        while((j > 0 && t < A[j]))
        {
			p_compare_count ++;
            A[j+1] = A[j];
             p_mix_count++;
            j = j - 1;
        }
        A[j + 1] = t;
        p_mix_count ++;
    }
}



void selectSort(int *A, int n)
{
	t_mix_count = 3 * (n-1);
	t_compare_count = (pow(n,2) - n)/2;
    int i, j, k;
 
    for (i = 1; i < n-1; i++)
	{
		k = i;
		for (j = i + 1; j < n; j++)
		{
			p_compare_count ++;
			if(A[j] < A[k])
			{
				k = j;
			}
		}
		swap(&A[i], &A[k]);
	}
}

void shellSort(int *A, int n) {
	int i, j, k, t;
	e = log(n) - 1;
	for(i = 1; i < e; i++) {
		k = 3  * k + 1;
	}
	for(; k > 0; k = (k - 1) / 3) {
		for(i = k; i < n; ++i) {
			p_mix_count ++;
			t = A[i];
			j = i - k;
			p_compare_count ++;
			while(j >= 0 && t < A[j]) {
				p_mix_count ++;
				A[j + k] = A[j];
				j = j - k;
				p_compare_count ++;
			}
			p_mix_count += 1;
			A[j + k] = t;
		}
	}
}


void clearCountMC()
{
	p_mix_count = 0, p_compare_count = 0;
	t_mix_count = 0, t_compare_count = 0;
	e = 0;
}



void FillInc(int *A, int n)
{
	int i = 0;
	A[i] = 1;
	
	for (i = 1; i < n; )
    {
    	A[i] = 1 + i;
    	if (A[i-1] < A[i])
    	{
    		i++;
    	}
    }
}

void FillDec( int *A, int n)
{
	int i = 0;
	A[i] = 1000;

	
	for (i = 1; i < n; )
    {
    	A[i] = 1000 - i;
    	
    	if (A[i-1] > A[i])
    	{
    		i++;
    	}
    }
}



void FillRand(int *A, int n)
{
	int i = 0;
	for (i = 0; i < n; i++)
    {
    	A[i] = 1 + rand()% 1000;
    }
}

int CheckSum(int *A, int n)
{
	int i = 0, sum = 0; 
	for (i = 0; i < n; i++)
	{
		sum += A[i];
	}
	
	return sum;
}

int RunNumber(int *A, int n)
{
	int i = 0;
	int series = 1;
	for (i = 0; i <= n - 2; i++)
    {
    	if (A[i] > A[i + 1])
    	{
    		series ++;
    	}
    }
	return series;
}

int printMas(int *A, int n)
{
	printf("\n");
	int i;
	for (i = 0; i < n; i++)
	{
		printf("%d ", A[i]);
	} 
	return 0;
}

void swap(int *xp, int *yp)
{
    int temp = *xp;
    *xp = *yp;
    *yp = temp;
    p_mix_count += 3;
}
