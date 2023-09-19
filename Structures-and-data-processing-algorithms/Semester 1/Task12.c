#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "Task11.h"



struct Queue
{
    struct Node* Head;
    struct Node* Tail;
};

void Divide(struct Node *S, struct Node *a, struct Node *b, int n)
{
    struct Node *k, *p;
    a = S, b = S->Next, n = 1;
    k = a;
    p = b;
    while(p)
    {
        n++;
        k->Next = p->Next;
        k = p;
        p = p->Next;
    }
}

int Merge(struct Node* a, struct Node* b, int q, int r, struct Queue* c, int i)
{
    int compare_count = 0, mix_count = 0;
    printN(b);
    printN(a);
    while (q != 0 && r != 0)
    {
        compare_count++;
        if (a->data <= b->data)
        {
            // Перемещение элемента из списка a в очередь c
            mix_count++;
            c[i].Tail->Next = a;
            c[i].Tail = a;
            a = a->Next;
            q--;
            
        }
        else
        {
            // Перемещение элемента из списка   b в очередь c
            mix_count++;
            c[i].Tail->Next = b;
            c[i].Tail = b;
            b = b->Next;
            r--;
        }
    }
    

    while (q > 0)
    {
        // Перемещение элемента из списка a в очередь c
        mix_count++;
        c[i].Tail->Next = a;
        c[i].Tail = a;
        a = a->Next;
        q--;
    }
    while (r > 0)
    {
        // Перемещение элемента из списка b в очередь c
        mix_count++;
        c[i].Tail->Next = b;
        c[i].Tail = b;
        b = b->Next;
        r--;
    }
    return compare_count + 2 * mix_count;
}

int MergeSort(struct Node* S)
{
    int m, n;
    int CM = 0;
    struct Node *a = NULL, *b = NULL;
    int p, q, r, i;
    struct Queue c[2];
    c[0].Head = NULL; 
    c[0].Tail = NULL;

    c[1].Head = NULL;
    c[1].Tail = NULL;

    int compare_count = 0, mix_count = 0;

    if(S == NULL)
    {
        exit(-1);
    }

    Divide(S, a, b, n);
    p = 1;

    while (p < n)
    {
        c[0].Tail = c[0].Head;
        c[1].Tail = c[1].Head;
        
        i = 0;
        m = n;
        while (m > 0)
        {
            if (m >= p)
                q = p;
            else
                q = m;
            m -= q;
            if (m >= p)
                r = p;
            else
                r = m;
            m -= r;
            // Merging
            
            CM += Merge(a, b, q, r, c, i);
            
            i = 1 - i;
        }
        a = c[0].Head;
        b = c[1].Head;
        p = 2 * p;
    }
    c[0].Tail->Next = NULL;
    S = c[0].Head;
    return compare_count + (2 * mix_count) + CM;

}

int main()
{
    srand(time(NULL));
    for(int i = 1; i <= 1; i++)
    {
        struct Node *Dec, *Inc, *Rand;

        int IncCM, DecCM, RandCM;

        int n = i * 10;
        for(int j = 0; j < n; j++) // Заполняем списки подобно массивам
        {
            Inc = push(Inc, j+1);
            Dec = push(Dec, n - j);
            Rand = push(Rand, 1 + rand()%10);
        }

        RandCM = MergeSort(Rand);
        printf("%d", RandCM);
    }

}

