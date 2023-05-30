#include <stdio.h>
#include <time.h>
#include <string.h>
#include <malloc.h>




char* names[] = {
        "Michel", "Walter", "Mike", "Gustavo", "Jessie", "Mikkie", "Karl", "Roxy", "Natasha"
};


struct Node
{
    char* name;
    int* marks;
    struct Node* next;
};



void push(struct Node* Head, char* name, int* marks)
{
    struct Node *temp, *p;

    temp = (struct Node*)malloc(sizeof(struct Node));
    temp->name = (char*)malloc(sizeof(strlen(name)*sizeof(char)));
    temp->marks = (int*)malloc(4 * sizeof(int));

    p = Head->next; 
    Head->next = temp; 
    strcpy(temp->name, name); 
    for(int i = 0; i < 4; i++)
    {
        temp->marks[i] = marks[i];
    }
    temp->next = p; 
}

void showList(struct Node *Head)
{
    struct Node *p = Head->next;

    while(p != NULL)
    {
        printf("%10s | ", p->name);
        for(int i = 0; i < 4; i++)
        {
            printf("%3d ", p->marks[i]);
        }
        p = p->next;
        printf("\n");
    }
    printf("\n");
}

struct Node* init()
{
    struct Node *Head;
    Head = (struct Node*)malloc(sizeof(struct Node));
    Head->next = NULL; 
    return Head;
}

void swapNodes(struct Node* p1, struct Node* p2)
{
    struct Node* temp = (struct Node*)malloc(sizeof(struct Node));
    temp->marks = (int*)malloc(4 * sizeof(int));
    temp->name = (char*)malloc(strlen(p1->name) * sizeof(char));

    temp->name = p1->name;
    for(int i = 0; i < 4; i++)
        temp->marks[i] = p1->marks[i];
    p1->name = p2->name;
    for(int i = 0; i < 4; i++)
        p1->marks[i] = p2->marks[i];
    p2->name = temp->name;
    for(int i = 0; i < 4; i++)
        p2->marks[i] = temp->marks[i];
}

void sortList(struct Node* head)
{
    struct Node* p1 = head->next; //Define the first node
    struct Node* p2;
    struct Node* min;
    while(p1 != NULL)
    {
        p2 = p1;
        min = p2;
        while(p2 != NULL)
        {
            if(strcmp(p2->name, min->name) < 0)
            {
                min = p2;
            }
            p2 = p2->next;
        }
        swapNodes(p1, min);
        p1 = p1->next;
    }
}

int main()
{
    srand(time(NULL));
    struct Node* Head = init();
    

    for(int i = 0; i < 10; i++)
    {
        int marks[4];
        
        for(int j = 0; j < 4; j++)
        {
            marks[j] = 1 + rand()%5;
        }
        char* buffer = names[rand()%9];
        char* name = (char*)malloc(strlen(buffer) * sizeof(char));
        strcpy(name, buffer);
        push(Head, name, marks);
    }

    showList(Head);
    sortList(Head);
    showList(Head);
}