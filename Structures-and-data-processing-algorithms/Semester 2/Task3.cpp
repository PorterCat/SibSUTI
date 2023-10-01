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
void printTable(int);

int p_mix_count = 0, p_compare_count = 0;
int t_mix_count = 0, t_compare_count = 0;

int main()
{
	printf("\tBubbleSort table:\n\t-----------------\n");
	printTable(1);

}

void printTable(int type)
{
	
	int i, j;
	
    std::cout << std::setw( 5 ) << std::left << " n   |" 
                        << std::setw( 16 ) << " M + C Theory  |"
                        << std::setw( 14 ) << " M + C Dec    |"
                        << std::setw( 14 ) << " M + C Rand   |"
                        << std::setw( 15 ) << " M + C Inc    |" 
                        << std::endl;
    std::cout << "_____|_______________|______________|______________|______________|\n";

	for (i = 1; i < 6; i++)
	{
        int* A;
        int n = i * 100;
        A = new int [n];
        FillDec(A, n);
		switch(type)
		{
			case 1: 
				bubbleSort(A,n); 
				t_compare_count = (pow(n,2) - n)/2;
	    		t_mix_count = (3 * t_compare_count);
				break;
			case 2: 
				shakerSort(A,n); 
				t_compare_count = (pow(n,2) - n)/2;
	    		t_mix_count = ((3 * (pow(n,2) - n))/4 );
				break;
		}

		


        std::cout << std::setw( 5 ) << std::left << n << "|"
                        << std::setw( 15 ) << t_mix_count + t_compare_count << "|"
                        << std::setw( 14 ) <<  p_mix_count + p_compare_count << "|";
        clearCountMC();
        FillRand(A, n);
		switch(type)
		{
			case 1: 
				bubbleSort(A,n); 
				t_compare_count = (pow(n,2) - n)/2;
        		t_mix_count = (3 * t_compare_count)/2;
				break;
			case 2: 
				shakerSort(A,n); 
				t_compare_count = (pow(n,2) - n)/2;
	    		t_mix_count = ((3 * (pow(n,2) - n))/4 );
				break;
		}


        std::cout << std::setw( 14 ) << p_mix_count + p_compare_count << "|";
        clearCountMC();  
        FillInc(A, n);
		switch(type)
		{
			case 1: 
				bubbleSort(A,n); 
				t_compare_count = (pow(n,2) - n)/2;
       			t_mix_count = 0;
				break;
			case 2: 
				shakerSort(A,n); 
				t_compare_count = (pow(n,2) - n)/2;
	    		t_mix_count = ((3 * (pow(n,2) - n))/4 );
				break;
		}  


        std::cout << std::setw( 14 ) << p_mix_count + p_compare_count << "|";
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
	int i, j, k;
   	for(i = 0; i < n;) 
   	{
      	for(j = i+1; j < n; j++) 
	  	{
			p_compare_count ++;
         	if(A[j] < A[j-1])
			{
				swap(&A[j], &A[j-1]);
			}
      	}
      	n--;
      	for(k = n-1; k > i; k--) 
		{
			p_compare_count ++;
        	if(A[k] < A[k-1])
			{
				swap(&A[k], &A[k-1]);
			}
      	}
      	i++;
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
