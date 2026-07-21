//enumMatches();
//switchMatch();

//--------PATTERN MATCHING----------
string bankRecords = """
    DEPOSIT,   10000, Initial balance
    DEPOSIT,     500, regular deposit
    WITHDRAWAL, 1000, rent
    DEPOSIT,    2000, freelance payment
    WITHDRAWAL,  300, groceries
    DEPOSIT,     700, gift from friend
    WITHDRAWAL,  150, utility bill
    DEPOSIT,    1200, tax refund
    WITHDRAWAL,  500, car maintenance
    DEPOSIT,     400, cashback reward
    WITHDRAWAL,  250, dining out
    DEPOSIT,    3000, bonus payment
    WITHDRAWAL,  800, loan repayment
    DEPOSIT,     600, stock dividends
    WITHDRAWAL,  100, subscription fee
    DEPOSIT,    1500, side hustle income
    WITHDRAWAL,  200, fuel expenses
    DEPOSIT,     900, refund from store
    WITHDRAWAL,  350, shopping
    DEPOSIT,    2500, project milestone payment
    WITHDRAWAL,  400, entertainment
    """;
/*prende il primo campo della riga CSV (fields[0]);
verifica se è "DEPOSIT" oppure "WITHDRAWAL";
usa il pattern matching tramite is;
se trova una corrispondenza, aggiorna il saldo del conto aggiungendo o sottraendo l'importo.*/
double currentBalance = 0.0;
var reader = new StringReader(bankRecords);

string? line;
while ((line = reader.ReadLine()) is not null)
{
    if (string.IsNullOrWhiteSpace(line)) continue;
    // Split the line based on comma delimiter and trim each part
    string[] parts = line.Split(',');

    string? transactionType = parts[0]?.Trim();
    if (double.TryParse(parts[1].Trim(), out double amount))
    {
        // Update the balance based on transaction type
        if (transactionType?.ToUpper() is "DEPOSIT")
            currentBalance += amount;
        else if (transactionType?.ToUpper() is "WITHDRAWAL")
            currentBalance -= amount;

        Console.WriteLine($"{line.Trim()} => Parsed Amount: {amount}, New Balance: {currentBalance}");
    }
}

//-------ENUM MATCHES----------
static IEnumerable<(TransactionType type, double amount)> TransactionRecords(string inputText)
{
    var reader = new StringReader(inputText);
    string? line;
    while ((line = reader.ReadLine()) is not null)
    {
        string[] parts = line.Split(',');

        string? transactionType = parts[0]?.Trim();
        if (double.TryParse(parts[1].Trim(), out double amount))
        {
            // Update the balance based on transaction type
            if (transactionType?.ToUpper() is "DEPOSIT")
                yield return (TransactionType.Deposit, amount);
            else if (transactionType?.ToUpper() is "WITHDRAWAL")
                yield return (TransactionType.Withdrawal, amount);
        }
        else {
            yield return (TransactionType.Invalid, 0.0);
        }
    }
}
currentBalance = 0.0;

void enumMatches(){
    foreach (var transaction in TransactionRecords(bankRecords))
    {
        if (transaction.type == TransactionType.Deposit)
            currentBalance += transaction.amount;
        else if (transaction.type == TransactionType.Withdrawal)
            currentBalance -= transaction.amount;
        Console.WriteLine($"{transaction.type} => Parsed Amount: {transaction.amount}, New Balance: {currentBalance}");
    }
}

//-----------MATCHES WITH 'SWITCH'------------
void switchMatch()
{
    foreach (var transaction in TransactionRecords(bankRecords))
    {
        currentBalance += transaction switch
        {
            (TransactionType.Deposit, var amount) => amount,
            (TransactionType.Withdrawal, var amount) => -amount,
            _ => 0.0,
        };
    }
}    

/*If you reorder the switch arms like this:
    currentBalance += transaction switch
    {
        (TransactionType.Deposit, var amount) => amount,
        _ => 0.0,
        (TransactionType.Withdrawal, var amount) => -amount,
    };
and type "dotnet 'patterns.cs'" in the terminal window, the compiler will report 
an error because the arm with _ matches every value. As a result, that final arm 
with TransactionType.Withdrawal never runs. The compiler tells you that something's 
wrong in your code.*/

//-----------TYPE PATTERNS-----------
currentBalance = 0.0;

foreach (var transaction in TransactionRecordType(bankRecords))
{
    currentBalance += transaction switch
    {
        Deposit d => d.Amount,
        Withdrawal w => -w.Amount,
        _ => 0.0,
    };
    Console.WriteLine($" {transaction} => New Balance: {currentBalance}");
}

static IEnumerable<object?> TransactionRecordType(string inputText)
{
    var reader = new StringReader(inputText);
    string? line;
    while ((line = reader.ReadLine()) is not null)
    {
        string[] parts = line.Split(',');

        string? transactionType = parts[0]?.Trim();
        if (double.TryParse(parts[1].Trim(), out double amount))
        {
            // Update the balance based on transaction type
            if (transactionType?.ToUpper() is "DEPOSIT")
                yield return new Deposit(amount, parts[2]);
            else if (transactionType?.ToUpper() is "WITHDRAWAL")
                yield return new Withdrawal(amount, parts[2]);
        }
    }
}

// end of your source file  
// (ENUM MATCHES)
public enum TransactionType
{
    Deposit,
    Withdrawal,
    Invalid
}

//(TYPE PATTERNS)
public record Deposit(double Amount, string description);
public record Withdrawal(double Amount, string description);