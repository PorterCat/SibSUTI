#include<stdio.h>
#include<stdlib.h>
#include<time.h>

struct Node
{
    int data; 
    struct Node *next; 
};

struct Node* push(struct Node *head, int number)
{
    struct Node* temp = (struct Node*)malloc(sizeof(struct Node));
    if(head == NULL)
    {
        temp->data = number;
        temp->next = NULL;
        head = temp;
    }
    else
    {
        struct Node* p = head;
        temp->data = number;
        temp->next = p;
        head = temp;
    }

    return head;
}

struct Node* pop(struct Node *head)
{
    if(head == NULL)
    {
        printf("Error. Stack is empty\n");
        exit(-1);
    }
    struct Node *temp = head;
    head = head->next;
    temp = NULL;
    free(temp);
    return head;
}

void printN(struct Node *head)
{
    struct Node* p = head;
    while(p)
    {
        printf("%d ", p->data);
        p = p->next;
    }
    printf("\n");
}

int series(struct Node *head)
{   
    
}

int summa(struct Node *head)
{   
    
}

int main()
{
    struct Node* head = NULL;
    head = push(head, 1);
    head = push(head, 2);
    head = push(head, 3);
    printN(head);
    head = pop(head);
    head = pop(head);
    printN(head);
}