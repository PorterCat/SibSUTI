#include<iostream>
#include<stdlib.h>
#include<time.h>
#include<cstdlib> //стандартная бибилиотека С для выделения памяти


using namespace std;

class Stack
{
public:

    int *arr;
    int head;
    int capacity;
    Stack(int size) //Конструктор
    {
        arr = new int[size];
        capacity = size;
        head = -1;  
    }

    ~Stack() //Деструктор
    {
    delete[] arr;
    }

    void push(int x)
    {
        if(isFull())
        {
            cout << "Stack is overflowed\nExiting..." << endl;
            exit(EXIT_FAILURE);
        }

        arr[++head] = x;
    }

    int pop()
    {
        if(isEmpty())
        {
            cout << "Stack is underflow\nExiting..." << endl;
            exit(EXIT_FAILURE);
        }

        return arr[head--];
    }

    int peek()
    {
        if (isEmpty()) 
        {
            exit(EXIT_FAILURE);
        }
        else 
        {
            return arr[head];
        }
    }

    void print()
    {
        if (isEmpty()) 
        {
            exit(EXIT_FAILURE);
        }

        for(int i = 0; i < head+1; i++)
        {
            cout << Stack::arr[i] << " ";
        }
        cout << endl;
    } 

    int checkSum()
    {
        int sum = 0;
        if (isEmpty()) 
        {
            exit(EXIT_FAILURE);
        }

        for(int i = 0; i < head+1; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    int checkSeries()
    {
        int n_series = 1;
        for(int i = 1; i < head+1; i++)
        {
            if(arr[i] < arr[i-1])
            {
                n_series++;
            }
        }
        return n_series;
    }


    int size() //Возвращает размер стека
    {
    return head + 1;
    }

    bool isFull() //Проверка на то, заполнен ли стек или нет
    {
    return head == capacity - 1;     
    }

    bool isEmpty() //Проверка на то, пусть ли стек или нет
    {
    return head == -1;       
    }

};
class Queue
{
public:

    int *arr; //Массив для хранения элементов очереди
    int capacity; //Ёмкость очереди
    int front; // Указывает на первый элемент очереди
    int back; //Указывает на последний элемент очереди
    int count; //Текцщий размер очереди

    Queue(int size) //Конструктор
    {
        arr = new int[size];
        capacity = size;
        count = 0;
        front = 0;
        back = -1; 
    }

    ~Queue() //Деструктор
    {
        delete[] arr;
    }

    void enqueue(int x)
    {
        if(isFull())
        {
            cout << "Queue is overflow\n";
            exit(EXIT_FAILURE);
        }
        count++;
        back = back + 1;
        arr[back] = x;
    }

    int dequeue()
    {
        if(isEmpty())
        {
            cout << "Queue is overflowed\nExiting..." << endl;
            exit(EXIT_FAILURE);
        }

        int x = arr[front];

        int* buffer = new int[count];

        for(int i = 0; i < count; i++)
        {
            buffer[i] = arr[i];
        }

        arr = new int[--count];
        for(int i = 0; i < count; i++)
        {
            arr[i] = buffer[i+1];
        }
        back--;
        delete buffer;
        return x;
    }


    int peek()
    {
        if (isEmpty()) 
        {
            exit(EXIT_FAILURE);
        }
        else 
        {
            return arr[front];
        }
    }

    void print()
    {
        if (isEmpty()) 
        {
            exit(EXIT_FAILURE);
        }

        for(int i = 0; i < count; i++)
        {
            cout << arr[i] << " ";
        }
        cout << endl;
    } 

    int checkSum()
    {
        int sum = 0;
        if (isEmpty()) 
        {
            exit(EXIT_FAILURE);
        }

        for(int i = 0; i < count; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    int checkSeries()
    {
        int n_series = 1;
        for(int i = 1; i < count; i++)
        {
            if(arr[i] < arr[i-1])
            {
                n_series++;
            }
        }
        return n_series;
    }


    int size() //Возвращает размер стека
    {
        return count;
    }

    bool isFull() //Проверка на то, заполнен ли стек или нет
    {
        return (size() == capacity);        
    }

    bool isEmpty() //Проверка на то, пусть ли стек или нет
    {
        return (size() == 0);       
    }

};

void print1()
{
    int size = 10;
    Stack pt_inc(size); 
    Stack pt_dec(size);
    Stack pt_rand(size);  
    

    int i = 0;
    size++;
    srand(time(NULL));
    while(!(pt_inc.isFull()))
    {
        i++;
        pt_inc.push(i);
        pt_dec.push(size - i);
        pt_rand.push(1 + rand()%(size - 1));
    }

    pt_inc.print();
    cout << "Check sum: " << pt_inc.checkSum() << " Number of series: " << pt_inc.checkSeries() << endl;
    pt_dec.print();
    cout << "Check sum: " << pt_dec.checkSum() << " Number of series: " << pt_dec.checkSeries() << endl;
    pt_rand.print();
    cout << "Check sum: " << pt_rand.checkSum() << " Number of series: " << pt_rand.checkSeries() << endl;
}

void print2()
{
    int size = 6;
    Queue pt_inc(size); 
    Queue pt_dec(size); 
    Queue pt_rand(size); 

    int i = 0;
    size++;
    srand(time(NULL));
    while(!(pt_inc.isFull()))
    {
        i++;
        pt_inc.enqueue(i);
        pt_dec.enqueue(size - i);
        pt_rand.enqueue(1 + rand()%(size - 1));
    }

    pt_inc.print();
    cout << "Check sum: " << pt_inc.checkSum() << " Number of series: " << pt_inc.checkSeries() << endl;
    pt_dec.print();
    cout << "Check sum: " << pt_dec.checkSum() << " Number of series: " << pt_dec.checkSeries() << endl;
    pt_rand.print();
    cout << "Check sum: " << pt_rand.checkSum() << " Number of series: " << pt_rand.checkSeries() << endl;
   
}

int main(int argc, char* argv[])
{
    print2();
    
    return 0;
}

