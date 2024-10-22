namespace tic_tac_toe;
using System;

class Program
{
    // 3x3 სათამაშო მაგიდა
    static char[,] board = new char[3, 3];
    static char currentPlayer = 'X'; // პირველი მოთამაშე
    static bool isGameOver = false;
    static int movesCount = 0;

    static void Main(string[] args)
    {
        InitializeBoard();
        while (!isGameOver)
        {
            Console.Clear();
            DrawBoard();
            PlayerMove();
            CheckForWinner();
            SwitchPlayer();
        }
    }

    // სათამაშო მაგიდის ინიციალიზაცია
    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {


            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    // სათამაშო მაგიდის დახატვა
    static void DrawBoard()
    {
        Console.WriteLine("   0   1   2");
        Console.WriteLine("  -----------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " | ");

            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " | ");
            }
            Console.WriteLine("\n  -----------");
        }
    }

    // მოთამაშის სვლა
    static void PlayerMove()
    {
        int row = -1, col = -1;
        bool validInput = false;
        while (!validInput)
        {
            Console.WriteLine($"Player {currentPlayer}, Enter your move (row and column): ");
            Console.Write("Row (0-2): ");
            row = int.Parse(Console.ReadLine());
            Console.Write("Column (0-2): ");
            col = int.Parse(Console.ReadLine());

            // შემოწმება თუ მითითებული ინდექსები სწორია და ადგილი თავისუფალია
            if (row >= 0 && row <= 2 && col >= 0 && col <= 2 && board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                validInput = true;
                movesCount++;
            }
            else
            {
                Console.WriteLine("Invalid move, try again.");
            }
        }
    }

    // თამაში დასრულდა თუ არა (გამარჯვება ან ფრაგმა)
    static void CheckForWinner()
    {
        // სტრიქონების შემოწმება
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
            {
                DeclareWinner();
                return;
            }
        }

        // სვეტების შემოწმება
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
            {
                DeclareWinner();
                return;
            }
        }

        // დიაგონალების შემოწმება
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
        {
            DeclareWinner();
            return;
        }

        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
        {
            DeclareWinner();
            return;
        }

        // თუ თამაში დასრულებულია
        if (movesCount == 9)
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine("The game is a tie!");
            isGameOver = true;
        }
    }

    // გამარჯვებულის გამოცხადება
    static void DeclareWinner()
    {
        Console.Clear();
        DrawBoard();
        Console.WriteLine($"Player {currentPlayer} wins!");
        isGameOver = true;
    }

    // მოთამაშის შეცვლა
    static void SwitchPlayer()
    {
        if (!isGameOver)
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }
}
