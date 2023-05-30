#include <iostream>
#include <string>

using namespace std;

struct Student {
    string Name;
    int grades[4];
    Student* left;
    Student* right;
};

void insert(Student*& root, string Name, int grades[]) 
{
    if (root == NULL) 
	{
        root = new Student;
        root->Name = Name;
        for (int i = 0; i < 4; i++) 
		{
            root->grades[i] = grades[i];
        }
        root->left = NULL;
        root->right = NULL;
    }
    else if (Name < root->Name) 
	{
        insert(root->left, Name, grades);
    }
    else 
	{
        insert(root->right, Name, grades);
    }
}

void printIncreasing(Student* root) 
{
    if (root) 
	{
        printIncreasing(root->left);
        cout << root->Name << endl;
        printIncreasing(root->right);
    }
}

void printDecreasing(Student* root) 
{
    if (root) 
	{
        printDecreasing(root->right);
        cout << root->Name << endl;
        printDecreasing(root->left);
    }
}

Student* search(Student* root, string Name) 
{
    if (root == NULL || root->Name == Name) 
	{
        return root;
    }
    if (Name < root->Name) 
	{
        return search(root->left, Name);
    }
    else 
	{
        return search(root->right, Name);
    }
}

int main() 
{
    Student* root = NULL;
    srand(time(NULL));
    string Names[] = {
        "Michel", "Walter", "Mike", "Gustavo", "Jessie", "Mikkie", "Karl", "Roxy", "Natasha"
    };
    for(int i = 0; i < 10; i++)
    {
        insert(root, Names[rand()%8], new int[4]{ 1+rand()%5, 1+rand()%5, 1+rand()%5, 1+rand()%5 });
    }

    cout << "Increasing order:" << endl;
    printIncreasing(root);
    cout << endl;
    
    cout << "Decreasing order:" << endl;
    printDecreasing(root);
    cout << endl;
    
    string searchName;
    cout << "Type name for search in the tree: ";
    cin >> searchName;

    Student* found = search(root, searchName);
    if (found) 
	{
        cout << "Found student with name " << searchName << endl;
    }
    else 
	{
        cout << "Student with name " << searchName << " not found" << endl;
    }
    return 0;
}

