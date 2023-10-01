#include<stdio.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>


struct note
{
    int index;
    char* firstname;
    char* lastname;
    char* phone_num;
};

int compareStrings(char* A, char* B)
{
    printf("\n%s %s\n", A, B);
    if(!(strcmp(A, B)))
    {
        return 0;
    }

    for(int i = 0; i < strlen(A) || i < strlen(B); i++)
    {
        if(A[i] == B[i])
        {
            continue;
        }
        else
        {
            if(A[i] < B[i])
            {
                return 1;
            }
            else 
            {
                return 0;
            }
        }
    }
}

void indexSort(struct note arr[], int n, int *B) 
{
    int i, j, l, k, t = 0;

    l = 0;
    
    for (i = 0; i < n - 1; i++)
    {
        k = i;
        for (j = i + 1; j < n; ++j)
        {
            if(!(strcmp(arr[B[k]].firstname, arr[B[j]].firstname)))
            {
                continue;
            }

            while(arr[B[k]].firstname[l] == arr[B[j]].firstname[l])
            {
                l++;
            }

            if(arr[B[k]].firstname[l] > arr[B[j]].firstname[l])
            {
                k = j;
            }
            l = 0;
        }
        if(k != i)
        {
            t = B[k];
            B[k] = B[i];
            B[i] = t;
        }
    }
}

void indexSort2(struct note arr[], int n, int *B) 
{
    int i, j, l, k, t = 0;

    l = 0;
    
    for (i = 0; i < n - 1; i++)
    {
        k = i;
        for (j = i + 1; j < n; ++j)
        {
            if(!(strcmp(arr[B[k]].lastname, arr[B[j]].lastname)))
            {
                continue;
            }

            while(arr[B[k]].lastname[l] == arr[B[j]].lastname[l])
            {
                l++;
            }

            if(arr[B[k]].lastname[l] > arr[B[j]].lastname[l])
            {
                k = j;
            }
            l = 0;
        }
        if(k != i)
        {
            t = B[k];
            B[k] = B[i];
            B[i] = t;
        }
    }
}



void printBook(struct note* line, int n, int* B)
{  
    printf("%5s| %15s| %15s| %15s|\n", "Index", "Fisrtname", "Lastname", "Phone Number");
    printf("________________________________________________________\n");
    for(int i = 0; i < n; i++)
    {
        printf("%5i| %15s| %15s| %15s|\n", line[B[i]].index, line[B[i]].firstname, line[B[i]].lastname, line[B[i]].phone_num);
    }
}

void randomInput(struct note* line, int n)
{   
    srand(time(NULL));

    char* Names[] = 
    {
        "Apple", "Pinkie", "Rarity", "Twilight", "Derpy", "Fluttershy", "Celestia", "Crimson", "Izzy", "Sunny", "Hitch", "Pipp", "Zipp"
    };

    char* LastNames[] = 
    {
        "Sparkle", "Pie", "Dash", "Moondancer", "Jack", "Moonbow", "Starscout", "Petals", "Thunderlane"
    };

    char num[] = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

    for(int i = 0; i < n; i++)
    {
        line[i].index = i+1;
        line[i].firstname = Names[rand()%13];
        line[i].lastname = LastNames[rand()%9];
        line[i].phone_num = malloc(9 * sizeof(char));
        for(int j = 0; j < 9; j++)
        {
            if(j == 8)
            {
                 line[i].phone_num[j] = '\0';
            }
            line[i].phone_num[j] = num[rand()%10];
        }
    }
}



int main()
{
    int n = 10;
    struct note* phoneBook = malloc(n * sizeof(struct note));
    int* B = malloc(n * sizeof(int));
    int* C = malloc(n * sizeof(int));

    for(int i = 0; i < n; i++)
    {
        B[i] = i;
        C[i] = i;
    }

    randomInput(phoneBook, n);
    printBook(phoneBook, n, B);
    indexSort(phoneBook, n, B);
    indexSort2(phoneBook, n, C);
    printf("\n\n");
    printBook(phoneBook, n, B);
    printf("\n\n");
    printBook(phoneBook, n, C);

}

