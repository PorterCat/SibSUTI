#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int M, C;

struct spis
{
    spis *next;
    int data;
};
struct tle
{
    spis *head;
    spis *tail;
};



void Split(spis *S, spis *&a, spis *&b, int &n)
{
    spis *p, *q;
    a = S,
    b = S->next,
    n = 1;
    p = a,
    q = b;
    while (q)
    {
        n++;
        p->next = q->next;
        p = q;
        q = q->next;
    }
}

int Merge(spis *&a, spis *&b, int q, int r, tle *c, int i)
{
    int c_ = 0, m = 0;
    while (q && r)
    {
        c_++;
        if (a->data <= b->data)
        {
            // Перемещение элемента из списка a в очередь c
            m++;
            c[i].tail->next = a;
            c[i].tail = a;
            a = a->next;
            q--;
        }
        else
        {
            // Перемещение элемента из списка b в очередь c
            m++;
            c[i].tail->next = b;
            c[i].tail = b;
            b = b->next;
            r--;
        }
    }
    while (q > 0)
    {
        // Перемещение элемента из списка a в очередь c
        m++;
        c[i].tail->next = a;
        c[i].tail = a;
        a = a->next;
        q--;
    }
    while (r > 0)
    {
        // Перемещение элемента из списка b в очередь c
        m++;
        c[i].tail->next = b;
        c[i].tail = b;
        b = b->next;
        r--;
    }
    return c_ + 2 * m;
}

int MergeSort(spis *&S)
{
    int m, n;
    spis *a, *b;
    tle c[2];
    int C = 0, M = 0;
    int K = 0;
    int p, q, r, i;
    if (S == 0)
        return (0);
    Split(S, a, b, n);
    p = 1;
    while (p < n)
    {
        c[0].tail = (spis *)&c[0].head;
        c[1].tail = (spis *)&c[1].head;

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
            K += Merge(a, b, q, r, c, i);
            i = 1 - i;
        }
        a = c[0].head;
        b = c[1].head;
        p = 2 * p;
    }
    c[0].tail->next = NULL;
    S = c[0].head;
    return C + (2 * M) + K;
}

spis *Spis_inc_stack(int n)
{
    spis *p = NULL, *head = NULL;
    int i, S;
    for (i = 0; i < n; i++)
    {
        S = n - i;
        p = new spis;
        p->data = S;
        p->next = head;
        head = p;
    }
    return head;
}

spis *Spis_dec_stack(int n)
{
    spis *p = NULL, *head = NULL;
    int i, S;
    for (i = 0; i < n; i++)
    {
        S = i;
        p = new spis;
        p->data = S;
        p->next = head;
        head = p;
    }
    return head;
}

spis *Spis_rand_stack(int n)
{
    spis *p = NULL, *head = NULL;
    int i, S;
    for (i = 0; i < n; i++)
    {
        S = rand() % 100;
        p = new spis;
        p->data = S;
        p->next = head;
        head = p;
    }
    return head;
}

void PrintSpis(spis *head)
{
    spis *p;
    printf("\n\n");
    for (p = head; p; p = p->next)
        printf("%d ", p->data);
    printf("\n\n");
}

int main()
{
    srand(time(NULL));
    struct spis *q;
    int n, i, M = 0, C = 0;
    printf("_______________________________________\n");
    printf("|___n___|_________Merge_Sort__________|\n");
    printf("|_______|___Dec___|___Inc___|___Rnd___|\n");
    for (i = 1; i <= 5; i++)
    {
        int y, m, a;
        spis *p, *t, *q;
        n = i * 100;
        y = MergeSort(p = Spis_inc_stack(n));
        m = MergeSort(t = Spis_dec_stack(n));
        a = MergeSort(q = Spis_rand_stack(n));
        printf("|%7d|%9d|%9d|%9d|", n, y, m, a);
        printf("\n");
    }
    printf("|_______|_________|_________|_________|\n");
    return 0;
}