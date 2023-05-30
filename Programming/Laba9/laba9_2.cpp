#include <iostream>
#include <time.h>
#include <string>

using namespace std;

struct Student {
    string surname;
    int grades[4];
    Student* previous;
    Student* next;
};

void addNode(Student*& head, Student*& tail, string surname, int grades[]) 
{
    Student* newStudent = new Student;
    newStudent->surname = surname;
    for (int i = 0; i < 4; i++) 
	{
        newStudent->grades[i] = grades[i];
    }
    newStudent->previous= NULL;
    newStudent->next = NULL;
    if (head == NULL) 
	{
        head = newStudent;
        tail = newStudent;
    }
    else 
	{
        newStudent->previous= tail;
        tail->next = newStudent;
        tail = newStudent;
    }
}

void deleteStudent(Student*& head, Student*& tail, Student* student) 
{
    if (student == head && student == tail) 
	{
        head = NULL;
        tail = NULL;
    }
    else if (student == head) 
    {
        head = student->next;
        head->previous= NULL;
    }
    else if (student == tail) 
	{
        tail = student->previous;
        tail->next = NULL;
    }
    else 
	{
        student->previous->next = student->next;
        student->next-> previous= student-> previous;
    }
    delete student;
}

void removeFailedStudents(Student*& head, Student*& tail) 
{
    Student* current = head;
    while (current) 
	{
        bool hasFailed = false;
        for (int i = 0; i < 4; i++) 
		{
            if (current->grades[i] < 3) 
			{
                hasFailed = true;
                break;
            }
        }
        if (hasFailed) 
		{
            Student* temp = current;
            current = current->next;
            deleteStudent(head, tail, temp);
        }
        else 
		{
            current = current->next;
        }
    }
}

void printList(Student* head) 
{
    while (head) {
        cout << head->surname << ": ";
        for (int i = 0; i < 4; i++) 
		{
            cout << head->grades[i] << " ";
        }
        cout << endl;
        head = head->next;
    }
}

int main() 
{
    Student* head = NULL;
    Student* tail = NULL;
    srand(time(NULL));
    string surnames[] = {
        "Michel", "Walter", "Mike", "Gustavo", "Jessie", "Mikkie", "Karl", "Roxy", "Natasha"
    };
    
    for(int i = 0; i < 10; i++)
    {
        addNode(head, tail, surnames[rand()%8], new int[4]{ 1+rand()%5, 1+rand()%5, 1+rand()%5, 1+rand()%5 });
    }
    printList(head);
    removeFailedStudents(head, tail);
    cout << endl;
    cout << "After removing failed students:" << endl;
    printList(head);
    return 0;
}



