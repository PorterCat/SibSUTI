#include <stdio.h>
#include <stdlib.h>
#include <cstring>
#include <math.h>
#include <time.h>
#include <iostream>

using namespace std;

struct school
{
    int index;
    int n_grad;
    int n_VUZ;
    double percent_VUZ;
};

struct facultet
{
    char* name;
    int n_student = 0;
    int general_square = 0;
    int n_rooms = 0;
};

struct room
{
    char* facultet;
    int n = 0;
    int square = 0;
    int n_peop = 0;
};

void IndexSortSchool(school arr[], int n, int *B) 
{
    int i, j, t = 0;
    for (i = 0; i < n; i++)
    {
        B[i] = i;
    }
    for (i = 0; i < n - 1; i++)
    {
        for (j = i + 1; j < n; ++j)
        {
            if (arr[B[i]].percent_VUZ > arr[B[j]].percent_VUZ)
            {
                t = B[i];
                B[i] = B[j];
                B[j] = t;
            }
        }
    }
}

void randInputSchool(struct school* list, int n)
{  
    srand(time(NULL));
    for(int i = 0; i < n; i++)
    {
        list[i].index = 100 + i;
        list[i].n_grad = 20 + rand()%200;
        list[i].n_VUZ = rand() % (list[i].n_grad);

        list[i].percent_VUZ = (double)100*list[i].n_VUZ/list[i].n_grad;
    }
}

void randInputRoom(struct room* list, int n)
{  
    srand(time(NULL));
    char* facultets[] = {"Psychology", "Law", "Computer Science and Engineering", "Mathematics", "Sociology", "Medical", "Linguistic", "Pedagogical"};
    for(int i = 0; i < n; i++)
    {
        list[i].n = i+1;
        list[i].square = 5 + rand()%10;
        list[i].facultet = facultets[rand()%8];
        list[i].n_peop = 2 + rand()%4;
    }
}

void printListSchool(struct school* list, int n, int* B)
{
    printf("|%5s|%10s|%5s|%12s|\n", "Index", "Graduates", "VUZ", "Percent");
    printf("|");
    for(int i = 0; i < 35; i++)
    {
        printf("_");
    }
    printf("|\n");
    
    for(int i = 0; i < n; i++)
    {
        printf("|%5d|%10d|%5d|%10.2f %s|\n", list[B[i]].index, list[B[i]].n_grad, list[B[i]].n_VUZ, list[B[i]].percent_VUZ, "%");
    }
}

void printListRoom(struct room* list, int n)
{
    printf("|%5s|%10s|%35s|%12s|\n", "#", "Square", "Faculty", "Residents");
    for(int i = 0; i < 67; i++)
        printf("=");
    printf("\n");
    
    for(int i = 0; i < n; i++)
    {
         printf("|%5d|%10d|%35s|%12d|\n", list[i].n, list[i].square, list[i].facultet, list[i].n_peop);
    }
}

void printListFacultets(struct facultet* list, int n)
{
    printf("|%35s|%15s|%15s|%20s|\n", "Facultet name", "Num of students", "Num of rooms", "square/people");
    for(int i = 0; i < 90; i++)
        printf("=");
    printf("\n");

    for(int i = 0; i < n; i++)
    {
        float res = (float)list[i].general_square/list[i].n_student;
        printf("|%35s|%15d|%15d|%20.2f|\n", list[i].name, list[i].n_student, list[i].n_rooms, res);
    }
    printf("\n");
}

void checkFaculty(struct room* list, int n, facultet* list2)
{
    int sizef = 1;
    list2[0].name = list[0].facultet;
    list2[0].n_rooms = 1;
    list2[0].n_student = list[0].n_peop;
    list2[0].general_square = list[0].square;

    for(int i = 1; i < n; i++)
    {
        bool founded = false;
        int j = 0;
        for(; j < sizef; j++)
        {
            if(!(strcmp(list[i].facultet, list2[j].name)))
            {
                founded = true;
                break;
            }
        }
        if(founded)
        {
            list2[j].n_rooms ++;
            list2[j].n_student += list[i].n_peop;
            list2[j].general_square += list[i].square;
        }
        else
        {
            sizef++;
            list2 = (struct facultet*)realloc(list2, sizef * sizeof(struct facultet));
            list2[sizef-1].name = list[i].facultet;
            list2[sizef-1].general_square = list[i].square;
            list2[sizef-1].n_student = list[i].n_peop;
            list2[sizef-1].n_rooms = 1;
        }
    }

    printf("\n\n\n");
    printListFacultets(list2, sizef);
}

void task2()
{
    int n = 15;
    room* rooms = new room[n];
    facultet* facultets = (facultet*)malloc(sizeof(facultet));
    randInputRoom(rooms, n);
    printListRoom(rooms, n);
    checkFaculty(rooms, n, facultets);
}

void task1()
{
    int n = 15;
    school* schools = new school[n];
    int* B = new int[n];
    randInputSchool(schools, n);
    IndexSortSchool(schools, n, B);
    printListSchool(schools, n, B);
}

int main()
{
    int v = 0;
    printf("Eneter the task: ");
    scanf("%d", &v);

    switch(v)
    {
        case 1: 
            task1();
            break;
        case 2:
            task2();
            break;
    }
    
    return 0;
}

