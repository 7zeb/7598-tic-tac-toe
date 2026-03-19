using System;

class Program
{
    static char[] board = { '1','2','3','4','5','6','7','8','9' };
    static char currentPlayer = 'X';

    static void Main()
    {
        Console.Title = "Cursed Tic Tac Toe - Windows 8 Build 7958 Edition";
        int moves = 0;
        bool gameOver = false;

        while (!gameOver)
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine();
            Console.Write("Player {0}, choose a position (1-9): ", currentPlayer);

            string input = Console.ReadLine();
            int pos;
            if (!int.TryParse(input, out pos) || pos < 1 || pos > 9)
            {
                InvalidMove("Invalid input. Press any key to try again...");
                continue;
            }

            if (board[pos - 1] == 'X' || board[pos - 1] == 'O')
            {
                InvalidMove("That spot is already taken. Press any key to try again...");
                continue;
            }

            board[pos - 1] = currentPlayer;
            moves++;

            if (CheckWin())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine();
                Console.WriteLine("Player {0} wins!", currentPlayer);
                gameOver = true;
            }
            else if (moves == 9)
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine();
                Console.WriteLine("It's a draw!");
                gameOver = true;
            }
            else
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void DrawBoard()
    {
        Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
    }

    static bool CheckWin()
    {
        int[,] wins = new int[,]
        {
            {0,1,2}, {3,4,5}, {6,7,8}, // rows
            {0,3,6}, {1,4,7}, {2,5,8}, // cols
            {0,4,8}, {2,4,6}           // diagonals
        };

        for (int i = 0; i < wins.GetLength(0); i++)
        {
            int a = wins[i,0], b = wins[i,1], c = wins[i,2];
            if (board[a] == board[b] && board[b] == board[c])
                return true;
        }

        return false;
    }

    static void InvalidMove(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
