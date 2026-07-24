using System;

class Chess
{
    static char[,] board = new char[8, 8];
    static bool whiteTurn = true;

    static void Main()
    {
        InitBoard();

        while (true)
        {
            Console.Clear();
            DrawBoard();

            Console.WriteLine();
            Console.WriteLine($"{(whiteTurn ? "Bianco" : "Nero")} muove");
            Console.Write("Mossa (es: e2 e4) oppure q: ");

            string input = Console.ReadLine();

            if (input?.ToLower() == "q")
                break;

            string[] parts = input.Split(' ');
            if (parts.Length != 2)
                continue;

            if (TryMove(parts[0], parts[1]))
                whiteTurn = !whiteTurn;
        }
    }

    static void InitBoard()
    {
        string[] start =
        {
            "rnbqkbnr",
            "pppppppp",
            "........",
            "........",
            "........",
            "........",
            "PPPPPPPP",
            "RNBQKBNR"
        };

        for (int r = 0; r < 8; r++)
            for (int c = 0; c < 8; c++)
                board[r, c] = start[r][c];
    }

    static void DrawBoard()
    {
        Console.WriteLine("  a b c d e f g h");

        for (int r = 0; r < 8; r++)
        {
            Console.Write(8 - r + " ");

            for (int c = 0; c < 8; c++)
            {
                Console.Write(board[r, c] + " ");
            }

            Console.WriteLine();
        }
    }

    static bool TryMove(string from, string to)
    {
        if (!ParsePos(from, out int fr, out int fc))
            return false;

        if (!ParsePos(to, out int tr, out int tc))
            return false;

        char piece = board[fr, fc];

        if (piece == '.')
            return false;

        bool whitePiece = char.IsUpper(piece);

        if (whitePiece != whiteTurn)
            return false;

        if (!ValidMove(piece, fr, fc, tr, tc))
            return false;

        board[tr, tc] = piece;
        board[fr, fc] = '.';

        return true;
    }

    static bool ParsePos(string pos, out int row, out int col)
    {
        row = col = 0;

        if (pos.Length != 2)
            return false;

        col = pos[0] - 'a';
        row = 8 - (pos[1] - '0');

        return col >= 0 && col < 8 && row >= 0 && row < 8;
    }

    static bool ValidMove(char piece, int fr, int fc, int tr, int tc)
    {
        piece = char.ToUpper(piece);

        int dr = tr - fr;
        int dc = tc - fc;

        switch (piece)
        {
            case 'P':
                return Math.Abs(dr) == 1 && dc == 0;

            case 'R':
                return dr == 0 || dc == 0;

            case 'B':
                return Math.Abs(dr) == Math.Abs(dc);

            case 'Q':
                return dr == 0 || dc == 0 ||
                       Math.Abs(dr) == Math.Abs(dc);

            case 'N':
                return (Math.Abs(dr) == 2 && Math.Abs(dc) == 1) ||
                       (Math.Abs(dr) == 1 && Math.Abs(dc) == 2);

            case 'K':
                return Math.Abs(dr) <= 1 &&
                       Math.Abs(dc) <= 1;
        }

        return false;
    }
}