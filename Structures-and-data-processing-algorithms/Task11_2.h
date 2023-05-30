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

void printQueue(struct Queue *q)
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

struct Node* init(int a) 
{
    struct Node *Head;
    Head = (struct Node*)malloc(sizeof(struct Node));
    Head->data = a;
    Head->Next = NULL; 
    return Head;
}


struct Node* push(struct Node *Head, int number)
{

    struct Node *temp, *p;
    temp = (struct Node*)malloc(sizeof(struct Node));

    p = Head->Next; 
    Head->Next = temp; 
    temp->data = number; 
    temp->Next = p; 

}

struct Node* pop(struct Node *Head)
{
    struct Node *p;
    p = Head->Next;
    Head->Next = p->Next;
    p = NULL;   
}

void printNode(struct Node *Head)
{
    struct Node *p;
    p = Head->Next;
    int sum = 0;
    int temp = 0;
    int series = 1;

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

    if(temp < Head->data)
    {
        series++;
    }

    printf("%d | Sum: %d | Series: %d", Head->data, sum, series); 
    printf("\n");
}

int series(struct Node *Head)
{   
    struct Node *p;
    int temp = 0;
    int series = 1;
    p = Head->Next;
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

    if(temp < Head->data)
    {
        series++;
    }
    
    return series;
}

int summa(struct Node *Head)
{   
    struct Node *p;
    int sum = 0;
    p = Head->Next;

    while (p != NULL)
    {
        sum += p->data;
        p = p->Next;
    }

    return sum;
}