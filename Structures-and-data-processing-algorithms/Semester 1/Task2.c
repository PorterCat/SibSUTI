
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

void FillRand(int*, int);
void FillInc(int*, int);
void FillDec( int*, int);
int CheckSum(int* , int);
int RunNumber(int*, int);
int PrintMas(int*, int);
void selectSort(int* , int);
void swap(int*, int*);
void clearCountMC();

int p_mix_count = 0, p_compare_count = 0;
int t_mix_count = 0, t_compare_count = 0;

int main()
{

	
    int n;
    scanf("%d", &n);
    int A[n];
    
    

	printf("\tRandom array sorting: \n\t________________________\n");
    FillRand(A, n);
    PrintMas(A, n);
    t_compare_count = (pow(n,2) - n)/2;
	t_mix_count = (3 * (n-1));
	printf("[Sum : %d; Number of series: %d]", CheckSum(A, n), RunNumber(A, n));
	selectSort(A, n);
	PrintMas(A, n);
	printf("[Sum : %d; Number of series: %d]\n", CheckSum(A, n), RunNumber(A, n));
	printf("\n| Theory  | M: %d, C: %d M+C: %d\n| Practic | M: %d, C: %d M+C: %d\n\n", t_mix_count, t_compare_count, t_mix_count + t_compare_count, p_mix_count, p_compare_count, p_mix_count + p_compare_count);
	clearCountMC();

	printf("\tIncreasing array sorting: \n\t________________________\n");
    FillInc(A, n);
    PrintMas(A, n);
    t_compare_count = (pow(n,2) - n)/2;
	t_mix_count = (3 * (n-1));
	printf("[Sum : %d; Number of series: %d]", CheckSum(A, n), RunNumber(A, n));
	selectSort(A, n);
	PrintMas(A, n);
	printf("[Sum : %d; Number of series: %d]\n", CheckSum(A, n), RunNumber(A, n));
	printf("\n| Theory  | M: %d, C: %d M+C: %d\n| Practic | M: %d, C: %d M+C: %d\n\n", t_mix_count, t_compare_count, t_mix_count + t_compare_count, p_mix_count, p_compare_count, p_mix_count + p_compare_count);
	clearCountMC();

	printf("\tDicreasing array sorting: \n\t________________________\n");
	t_compare_count = (pow(n,2) - n)/2;
	t_mix_count = (3 * (n-1));
    FillDec(A, n);
    PrintMas(A, n);
	printf("[Sum : %d; Number of series: %d]", CheckSum(A, n), RunNumber(A, n));
	selectSort(A, n);
	PrintMas(A, n);
	printf("[Sum : %d; Number of series: %d]\n", CheckSum(A, n), RunNumber(A, n));
	printf("\n| Theory  | M: %d, C: %d M+C: %d\n| Practic | M: %d, C: %d M+C: %d\n\n", t_mix_count, t_compare_count, t_mix_count + t_compare_count, p_mix_count, p_compare_count, p_mix_count + p_compare_count);
	clearCountMC();

	
}



void selectSort(int *A, int n)
{
	t_mix_count = 3 * (n-1);
	t_compare_count = (pow(n,2) - n)/2;
    int i, j, k;
 
    for (i = 0; i < n-1; i++)
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

void clearCountMC()
{
	p_mix_count = 0, p_compare_count = 0;
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

int PrintMas(int *A, int n)
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
