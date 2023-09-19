#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <iostream>
#include <iomanip>

void FillRand(int*, int);
void FillInc(int*, int);
void FillDec( int*, int);
int CheckSum(int* , int);
int RunNumber(int*, int);
int printMas(int*, int);

void selectSort(int* , int);
void bubbleSort(int* , int);
void shakerSort(int *, int);
void swap(int*, int*);


void clearCountMC();
void printTable();

int p_mix_count = 0, p_compare_count = 0;
int t_mix_count = 0, t_compare_count = 0;

int main()
{
	
	/*int *A;
	int n; scanf("%d", &n);
	A = new int [n];
	FillRand(A, n);
	printMas(A, n);
	shakerSort(A, n);
	printMas(A, n);*/
	
	printTable();

}

void printTable()
{
	
	int i, j;
	
    std::cout << std::setw( 5 ) << std::left << " n   |" 
                        << std::setw( 30 ) << "              M + C Bubble                  |"
                        << std::setw( 30 ) << "              M + C Shaker                  |"
                        << std::endl;
    std::cout << "_____|____________________________________________|____________________________________________|\n"

                        << std::setw( 5 ) << std::left << "     |"
                        << std::setw( 15 ) << " M + C Dec    |" 
                        << std::setw( 14 ) << " M + C Rand   |"
                        << std::setw( 15 ) << " M + C Inc    |" 

                        << std::setw( 15 ) << " M + C Dec    |" 
                        << std::setw( 14 ) << " M + C Rand   |"
                        << std::setw( 15 ) << " M + C Inc    |" 
                        << std::endl;
     std::cout << "_____|______________|______________|______________|______________|______________|______________|\n";
    
                
                        

	for (i = 1; i < 6; i++)
	{
        int* A;
        int n = i * 100;
        A = new int [n];
        std::cout << std::setw( 5 ) << std::left << n << "|";

        FillDec(A, n);
		bubbleSort(A,n); 
        std::cout << std::setw( 14 ) <<  p_mix_count + p_compare_count << "|";
        clearCountMC();

        FillRand(A, n);
		bubbleSort(A,n); 
        std::cout << std::setw( 14 ) <<  p_mix_count + p_compare_count << "|";
        clearCountMC();

        FillInc(A, n);
		bubbleSort(A,n); 
        std::cout << std::setw( 14 ) <<  p_mix_count + p_compare_count << "|";
        clearCountMC();

        FillDec(A, n);
		shakerSort(A,n); 
        std::cout << std::setw( 14 ) <<  p_mix_count + p_compare_count << "|";
        clearCountMC();

        FillRand(A, n);
		shakerSort(A,n); 
        std::cout << std::setw( 14 ) <<  p_mix_count + p_compare_count << "|";
        clearCountMC();

        FillInc(A, n);
		shakerSort(A,n); 
        std::cout << std::setw( 14 ) <<  p_mix_count + p_compare_count << "|";
        clearCountMC();

		
        printf("\n");
		
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

void clearCountMC()
{
	p_mix_count = 0, p_compare_count = 0;
	t_mix_count = 0, t_compare_count = 0;
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
