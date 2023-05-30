#include <iostream>
#include <string.h>
#include <stdio.h>
#include <iomanip>
#include <locale>

using namespace std;

int BSearch1(char*, char);
int BSearch2(char*, char);
void bubbleSort(char*, int);
void swap(char*, char*);
void FillRand(char *, int);
void printTable();
void clearCountMC();

int compare = 0;

int main()
{
    setlocale(LC_ALL, "Russian");
   char a[] = "мищукандррей";
   for(int i = 0; i < strlen(a); i++)
   {
    printf("%c ", a[i]);
   }





}     

void printTable()
{
    int i, j;
	
    std::cout << std::setw( 5 ) << std::left << " n   |" 
                        << std::setw( 15 ) << "M + C BinSearch1 |"
                        << std::setw( 15 ) << "M + C BinSearch2 |"
                        << std::endl;
    std::cout << "_________________________________________|" << std::endl;

    for (i = 1; i < 6; i++)
	{
        char * line;
        int m;
        int n = i * 100;
        line = new char [n];
        std::cout << std::setw( 5 ) << std::left << n << "|";
        srand(time(NULL));
        FillRand(line, n);
		bubbleSort(line, n); 
        m = BSearch1(line, line[n]);
        std::cout << std::setw( 15 ) << compare << " "<< line[m] << "  |";
        clearCountMC();

        FillRand(line, n);
		bubbleSort(line, n); 
        m = BSearch2(line, line[n]);
        std::cout << std::setw( 15 ) << compare << "  |";
        clearCountMC();


        printf("\n");
    }
}

int BSearch1(char* line, char key)
{


    int L = 0, R = strlen(line)-1 ; 
    int m;
    bool f_found = false;
    while(L <= R)
    {
        m = (L+R)/2;
        compare++;
        if(line[m] == key)
        {
            f_found = true;
            return m;
        }
        compare++;
        if(line[m] < key)
        {
            L = m + 1;
        }
        else 
        {
            R = m - 1;
        }
    }
    if(f_found == true)
    {
        return m;
    }
    else
    {
        return -1;
    }
    
}

int BSearch2(char* line, char key)
{
    int L = 0, R = strlen(line)-1 ; 
    int m;
    bool f_found = false;
    while(L < R)
    {
        m = (L+R)/2;
        compare++;
        if(line[m] < key)
        {
            L = m + 1;
        }
        else 
        {
            R = m;
        }
    }
    compare++;
    if(line[R] == key)
    {
        f_found = true;
        return m;
    }
    else
    {
        return -1;
    }
}

void FillRand(char *A, int n)
{
	int i = 0;
	for (i = 0; i < n; i++)
    {
    	A[i] = (char) rand()%127;
    }
}

void bubbleSort(char *A, int n)
{
	
	int i, j;
	for (i = 0; i < n - 1; i++)
	{
		for(j = i + 1; j < n; j++)
		{
			if(A[i] > A[j])
			{
				swap(&A[i], &A[j]);
			}
		}
	}
}

void clearCountMC()
{
	compare = 0;
}

void swap(char *xp, char *yp)
{
    char temp = *xp;
    *xp = *yp;
    *yp = temp;
}