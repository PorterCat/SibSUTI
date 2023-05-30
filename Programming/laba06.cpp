#include <stdio.h>
#include <math.h>

int checkingTriangle(int &a, int &b, int &c)
{
    if(((a+b) < c) || ((a+c) < b) || ((b+c) < a))
    {
        return 0;
    }

    return 1;
}

int SPtriangle(int &a, int &b, int &c, double &per, double &square)
{

    if(!checkingTriangle(a, b, c))
    {
        printf("Error. Triangle is not existing.\n");
        return 0;
    }

    per = (double) a + b + c;
    double p = per / 2;

    square = (double) sqrt(p*(p-a)*(p-b)*(p-c));
    return 1;
}

int factorial(int a)
{
    if(a < 2)
    {
        return 1;
    }
    else
    {
        return a * factorial(a-1);
    }
}

int combination(int m, int n)
{
    return factorial(n)/(factorial(m) * factorial(n - m));
}

int probability(int &n, int &m, float &Bprob, float &Gprob)
{   
    float p = 0.45, q = 1 - p;

    Bprob = combination(m, n) * pow(p, n-m) * pow(q, m); 
    Gprob = combination(m, n) * pow(p, m) * pow(q, n - m); 

    return 0;
}

int task1()
{
    int a, b, c;
    double per, square;
    printf("Enter a: "); scanf("%d", &a);
    printf("Enter b: "); scanf("%d", &b);
    printf("Enter c: "); scanf("%d", &c);
    if(!(SPtriangle(a, b, c, per, square)))
    {
        return 0;
    }

    printf("Perimetr: %f\nSquare: %f\n", per, square);
    return 1;
}

int task2()
{
    int n, m;
    float Bprob, Gprob;
    printf("Enter n. The number of kids: "); scanf("%d", &n);
    printf("Enter m The number of boys/girls: "); scanf("%d", &m);
    probability(n, m, Bprob, Gprob);
    printf("n = %d ; m = %d\n", n, m);
    printf("Boys probability: %f\nGirls probability: %f\n", Bprob, Gprob);
    return 1;


}

int main()
{
    int v;
    printf("Enter the key: "); scanf("%d", &v);

    switch(v)
    {
        case 1: 
            task1(); break;
        case 2: 
            task2(); break;
    }

    return 0;
}