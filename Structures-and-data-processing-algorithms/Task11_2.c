#include<stdio.h>
#include<stdlib.h>
#include<time.h>

struct Node
{
    int data;               // целочисленные данные
    struct Node* Next;      // указатель на следующий узел
};


struct Queue
{
    struct Node *Head;
    struct Node *Tail;
};

struct Queue* initQueue()
{
    struct Queue *q;
    q = (struct Queue*)malloc(sizeof(struct Queue));
    struct Node *Head;
    struct Node *Tail;
    q->Head = (struct Node*)malloc(sizeof(struct Node));
    q->Tail = (struct Node*)malloc(sizeof(struct Node));

    q->Head->Next = q->Tail; 
    q->Tail->Next = q->Head;

    return q;
}

struct Node* enqueue(struct Queue *q, int a)
{
    if(q == NULL)
    {
        q = initQueue();
    }
    else
    {
        struct Node *temp, *p;
        temp = (struct Node*)malloc(sizeof(struct Node));

        p = q->Tail->Next;

        p->Next = temp;
        q->Tail->Next = temp;
        temp->Next = NULL;
        temp->data = a;
    }
}

struct Node* dequeue(struct Queue *q)
{
    struct Node *temp = q->Head->Next;      
    q->Head->Next = temp->Next;
    free(temp);
}

void printNode(struct Queue *q)
{
    struct Node *p;
    p = q->Head->Next;
    int sum = 0;
    int temp = 0;
    int series = 0;

    while (p != NULL)
    {
        sum += p->data;
        temp = p->data;
        printf("%d ", p->data); 
        p = p->Next; 
        if(p == NULL)
        {
            break;
        }
        if(temp < p->data)
        {
            series++;
        }
    } 

    if(p == NULL)
    {
        sum += q->Head->data;
    }

    if(temp < q->Head->data)
    {
        series++;
    }

    printf("| Sum: %d | Series: %d", sum, series); 
    printf("\n");
}

int series(struct Queue *q)
{   
    struct Node *p;
    int temp = 0;
    int series = 1;
    p = q->Head->Next;
    temp = p->data;

    while (p != NULL)
    {
        temp = p->data;
        p = p->Next;
        if(p == NULL)
        {
            break;
        }
        if(temp < p->data)
        {
            series++;
        }
    }

    if(temp < q->Head->data)
    {
        series++;
    }
    
    return series;
}

int summa(struct Queue *q)
{   
    struct Node *p;
    int sum = 0;
    p = q->Head->Next;

    while (p != NULL)
    {
        sum += p->data;
        p = p->Next;
    }

    return sum;
}

int main()
{
    struct Queue *q1 = initQueue(); 
    enqueue(q1, 5);
    enqueue(q1, 3);
    enqueue(q1, 1);
    printNode(q1);

    struct Node *p = q1->Head->Next;

    printf("%d\n", p->data);
    dequeue(q1);
    printf("%d\n", p->data);
}