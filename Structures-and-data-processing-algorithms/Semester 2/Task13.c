#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

struct Node
{
    char data; 
    struct Node *Next; 
};

struct Node* addElement(struct Node* head, char element)
{
    struct Node* tmp = (struct Node*)malloc(sizeof(struct Node));
    tmp->data = element;
    tmp->Next = head;
    head = tmp;
}

void showList(struct Node* head)
{
    struct Node* p = head;
    int flag = 0;
    while (p != NULL)
    {
        flag = 1;
        printf("%c -> ", p->data); 
        p = p->Next; 
    } 
    if(flag)
    {
        printf("%s", "NULL "); 
        printf("\n");
    }
}


int directSearch(char key, int m, struct Node** List)
{
    int h = 0;
    h = (int)(key % m);
    
    if(List[h] == NULL)
    {
        printf("No such element\n");
        return 0;
    }
    else
    {
        while(List[h] != NULL)
        {
            if(List[h]->data == key)
            {
                printf("Founded!\n");
                return 1;
            }
            List[h] = List[h]->Next;
        }
        printf("No such element!\n");
        return 0;
    }
}

int direct_hash(char* str, int m) //Хэш-функция
{

    struct Node **List = (struct Node**)malloc(m * sizeof(struct Node*));;
    for(int i = 0; i < m; i++)
    {
        List[i] = (struct Node*)malloc(sizeof(struct Node));
        List[i] = NULL;
    } 

    size_t length = strlen(str);
    int h = 0;
    for(int i = 0; i < length; i++)
    {
        h = (int)(str[i] % m); 
        List[h] = addElement(List[h], str[i]);
    }
    printf("\n");
    for(int i = 0; i < m; i++)
    {
        showList(List[i]);
    }
    char key;
    printf("Eneter the key for serch: ");
    scanf("%c", &key);
    directSearch(key, m, List);

    for(int i = 0; i < m; i++)
    {
        free(List[i]);
    }
    free(List);
}

void showHashTable(char* T, int n)
{
    printf("|");
    for(int i = 0; i < n; i++)
    {

        printf("%2d|", i);
    }

    printf("\n|");
    for(int i = 0; i < n; i++)
    {
        if(T[i] == -1 || T[i] == 0) 
        {
            printf("  |");
        }
        else
        {
            printf("%2c|", T[i]);
        }
    }
    printf("\n");
}

// int g1(int i)
// {
//     return i;
// }

// int g2(int i)
// {
//     return (int)i*i;
// }

// int hash(char k, int m, int i, int version)
// {
//     switch(version)
//     {
//         case 1: 
//         return (int)((k + g1(i))%m);
//         break;

//         case 2:
//         return (int)((k + g2(i))%m);
//         break;
//     }
// }

int Hash_insert(char* T, int m, char k, int version)
{
    int h = (int)(k % m); 
    int d = 1;
    int collizium = 0;

    while(1)
    {

        if(T[h] == -1)
        {
            T[h] = k;
            return collizium;
        }

        collizium++;

        if(d>=m)
        {
            return collizium;
        }

        h = h + d;

        if(h >= m)
        {
            h = h - m;
        }
        
        switch(version)
        {
            case 1:
                continue;
    
            case 2:
                d = d + 2;
                continue;
        }   
    }
}

int showTable(char* str, int size, int col1, int col2)
{
    printf("%5s|%5s|%21s|\n", "Size", "Symb", "Num of Colliziums");
    printf("%11s|%10s|%10s|\n", "  ", "Line", "Square");
    printf("==================================\n");
    printf("%5d|%5d|%10d|%10d|\n", size, strlen(str), col1, col2);
}

int openAdress_hash(char* str, int m)
{
    int size = m;
    char* T1 = malloc(size * sizeof(char));
    char* T2 = malloc(size * sizeof(char));

    int col1 = 0, col2 = 0;


    for(int i = 0; i < size; i++)
    {
        T1[i] = -1;
        T2[i] = -1;
    }
    
    for(int i = 0; i < size; i++)
    {
        col1 += Hash_insert(T1, m, str[i], 1);
        col2 += Hash_insert(T2, m, str[i], 2);
    }

    showHashTable(T1, size); //printf(" |Collisions: %d|\n", col1);
    printf("\n");
    showHashTable(T2, size);  //printf(" |Collisions: %d|\n", col2);
    printf("\n");
    showTable(str, size, col1, col2);
    
}

int main()
{
    char *str1 = "VladimirPutin";
    
    // direct_hash(str1, 5);
    openAdress_hash(str1, strlen(str1));
}