using System; //'using' is a directive che si riferisce al namespace 'System'
namespace TourOfCsharp; // I 'namespaces' forniscono un mezzo gerarchico per organizzare programmi e librerie C#.
//I 'namespaces contengono a loro volta 'namespaces' e 'types'
class Program
{
    static void Main()
    {
        // This line prints "Hello, World" 
        Console.WriteLine("Hello, World"); //la 'console-class' è un 'type' 
    }
}// senza 'using' avremmo dovuro scrivere 'System.Console.WriteLine();'

/*Main era (ed è ancora) il punto di ingresso tradizionale di un programma C#; 
i top-level statements sono una scorciatoia moderna che il compilatore 
converte automaticamente in un metodo Main nascosto.*/

//però funziona anche questo codice:
/* 
//This line prints "Hello, World"
Console.WriteLine("Hello, World");
*/
