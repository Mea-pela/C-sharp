List<string> names = ["<name>", "Ana", "Felipe"];
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!"); //quando una stringa è preceduta da '$' puoi inserire pari di codice C# nella dichiarazione
}
//Alle liste tipo 'List<T>' puoi aggiungere o togliere roba
Console.WriteLine();
names.Add("Maria");
names.Add("Bill");
names.Remove("Ana");
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}
//Puoi puntare/accedere ad un determinato punto della lista usando le parentesi quadre []
Console.WriteLine($"My name is {names[0]}.");
Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");
//per controllare quanti elementi ci sono in una lista puoi usare 'nomeLista.Count'
Console.WriteLine($"The list has {names.Count} people in it");

//----RICERCA NELLE LISTE-------
//Per trovare elementi in queste raccolte più grandi, è necessario cercare nella lista 
// i diversi elementi. Il metodo IndexOf cerca un elemento e restituisce l’indice dell’elemento.

var index = names.IndexOf("Felipe");
if (index == -1)
{
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
}
else
{
    Console.WriteLine($"The name {names[index]} is at index {index}");
}

index = names.IndexOf("Not Found");
if (index == -1)
{
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
}
else
{
    Console.WriteLine($"The name {names[index]} is at index {index}");
}
/*Puoi anche ordinare gli elementi nella tua lista. 
Il metodo 'Sort' ordina tutti gli elementi della lista nel loro ordine normale 
(alfabeticamente per le stringhe).*/
names.Sort();
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}

//-----LIST OF NUMBERS-------
List<int> fibonacciNumbers = [1, 1];

var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

fibonacciNumbers.Add(previous + previous2);

foreach (var item in fibonacciNumbers)
{
    Console.WriteLine(item);
}

//-------ESERCIZIO--------
/*Try to write the code to generate the first 20 numbers in the sequence. 
(As a hint, the 20th Fibonacci number is 6765.)*/
List<int> sequenzaFibonacci = [1, 1];

while (sequenzaFibonacci.Count < 20)
{
    var F1 = sequenzaFibonacci[sequenzaFibonacci.Count - 1];
    var F2 = sequenzaFibonacci[sequenzaFibonacci.Count - 2];

    sequenzaFibonacci.Add(F1 + F2);
}
foreach (var item in sequenzaFibonacci)
{
    Console.WriteLine(item);
}
/*Ad ogni iterazione del ciclo, prendi gli ultimi due interi della lista, 
li sommi e aggiungi quel valore alla lista. Il ciclo si ripete finché non 
aggiungi 20 elementi alla lista.*/