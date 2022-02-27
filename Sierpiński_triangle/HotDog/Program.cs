// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");

double count = 0;
double va = 1, vb = 2, v = 5;
double length = 1000, dog_length = 10;

double temp;

int xA, xB;

double xa = 0, xb = length;

while (xb - xa > dog_length)
{

    temp = xa;

    if (count++ % 2 == 0)
    {
        xa += va * (xb - xa) / (v + vb);
        xb -= vb * (xb - temp) / (v + vb);
    }

    else
    {
        xa += va * (xb - xa) / (v + va);
        xb -= vb * (xb - temp) / (v + va);
    }

    xA = (int)xa;
    xB = (int)xb;

    Console.WriteLine("xa = " + xA + " xb = " + xB);
}

Console.WriteLine("Counter equals " + count);
