//----------TUPLES----------
/*Tuples are easy to create: You declare multiple members enclosed 
in parentheses. All the following declarations define different tuples 
with different arities and member types.*/
var pt = (X: 1, Y: 2);

var slope = (double)pt.Y / (double)pt.X;
Console.WriteLine($"A line from the origin to the point {pt} has a slope of {slope}.");

pt.X = pt.X + 5; //this code to modifies a tuple member
Console.WriteLine($"The point is now at {pt}.");

var pt2 = pt with { Y = 10 }; //we used 'with' to create a new tuple that's a modified copy of the original 
Console.WriteLine($"The point 'pt2' is at {pt2}.");

var subscript = (A: 0, B: 0);
subscript = pt;
Console.WriteLine(subscript);


/*While tuples are easy to create, they're limited in their capabilities. 
Tuple types don't have names, so you can't convey meaning to the set of 
values. Tuple types can't add behavior.*/
//EXAMPLE:
/*
var namedData = (Name: "Morning observation", Temp: 17, Wind: 4);
var person = (FirstName: "", LastName: "");
var order = (Product: "guitar picks", style: "triangle", quantity: 500, UnitPrice: 0.10m);
*/

//----------TUPLES: RECORD TYPES----------
Point pt3 = new Point(1, 1);
var pt4 = pt3 with { Y = 10 };
Console.WriteLine($"The two points are {pt3} and {pt4}");

double slopeResult = pt4.Slope();
Console.WriteLine($"The slope of {pt4} is {slopeResult}");

public record struct Point(int X, int Y){ //DICHIARAZIONE 'RECORD': Type declarations like record declarations must follow executable statements in a file-based app.
    public double Slope() => (double)Y / (double)X;
}
