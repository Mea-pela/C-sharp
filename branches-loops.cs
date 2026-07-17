//-------INDICE--------
//ExploreIf();
//ExploreLoops();

//-------START: CONDITIONS--------

using System.ComponentModel;

void ExploreIf()
{
    int a = 5;
    int b = 3;
    if (a + b > 10)
    {
        Console.WriteLine("The answer is greater than 10");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
    }
    //mettere le graffe {} è un'opzione, ma è una buona pratica metterle
    int c = 4;
    if ((a + b + c > 10) && (a > b))
    {
        Console.WriteLine("The answer is greater than 10");
        Console.WriteLine("And the first number is greater than the second");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
        Console.WriteLine("Or the first number is not greater than the second");
    }

    if ((a + b + c > 10) || (a > b))
    {
        Console.WriteLine("The answer is greater than 10");
        Console.WriteLine("Or the first number is greater than the second");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
        Console.WriteLine("And the first number is not greater than the second");
    }
}


//--------LOOPS---------
void ExploreLoops(){
    //The 'while' loop tests the condition before executing the code following the while.
    int counter = 0;
    while (counter < 10)
    {
        Console.WriteLine($"Hello World! The counter is {counter}");
        counter++;
    }
    //This 'do' loop and the earlier 'while' loop produce the same output.
    int count = 0;
    do
    {
        Console.WriteLine($"Hello World! The count is {count}");
        count++;
    } while (count < 8);
    /*The preceding for loop does the same work as the while loop and the do loop you 
    already used. The for statement has three parts that control how it works*/
    for (int conto = 2; conto < 10; conto++)
    //(first=initializer; middle=condition; final=iterator)
    {
        Console.WriteLine($"Ciao mondo! Il conto è {conto}");
    }
    /*CI SAREBBE ANCHE IL 'foreach-loop':  The foreach statement repeats its statement 
    for every item in a sequence of items. You most often use it with collections.*/

    //--------LOOPS: NESTED LOOPS------------
    for (int row = 1; row < 11; row++)
    {
        for (char column = 'a'; column < 'k'; column++)
        {
            Console.WriteLine($"The cell is ({row}, {column})");
        }
    }
}

//write C# code to find the sum of all integers 1 through 20 that are divisible by 3
int sum = 0;
for (int number = 1; number < 21; number++)
{
    if (number % 3 == 0)
    {
        sum = sum + number;
    }
}
Console.WriteLine($"The sum is {sum}");
//---fatto con obiettivo diverso perchè non so leggere--
int conta=0;
int somma = 0;
for(int i = 1; i < 21; i++)//20 è compreso così
{
    for(int j=1; j<21; j++){ 
        somma = j + i;
        if (somma%3==0)
        {
            conta++;
            //Console.WriteLine($"The sum ({sum}) between ({i}) and ({j}) is divisible by 3");
        }
    }
}
Console.WriteLine($"Ci sono ({conta}) somme (tra 1 e 20) divisibili per 3");