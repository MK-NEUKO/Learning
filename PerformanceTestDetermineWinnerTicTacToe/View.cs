using System.Diagnostics;

namespace PerformanceTestDetermineWinnerTicTacToe;

public class View
{
    public void ShowGameBoardList(IReadOnlyList<GameBoard> gameBoardList)
    {
        var gameBoardsTotal = Convert.ToString(gameBoardList.Count());
        foreach (var gameBoard in gameBoardList)
        {
            WriteHeadline(gameBoard, gameBoardsTotal);
            WriteGameBoard(gameBoard);
        }
    }

    private void WriteHeadline(GameBoard gameBoard, string gameBoardsTotal)
    {
        var headlinePartOne = $"  Generation {gameBoard.GenerationNumber} GameBoards | ";
        var headlinePartTwo = $"SerialNumber = {gameBoard.SerialNumber} | Total {gameBoardsTotal} GameBoards ";
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.Write(headlinePartOne);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(headlinePartTwo);
        Console.ResetColor();
        Console.WriteLine("\n-".PadRight((headlinePartOne.Length + headlinePartTwo.Length), '-') + "-");
    }

    private void WriteGameBoard(GameBoard gameBoard)
    {
        var indexesFirstRow = new int[3] { 0, 1, 2 };
        var indexesSecondRow = new int[3] { 3, 4, 5 };
        var indexesThirdRow = new int[3] { 6, 7, 8 };
        Console.WriteLine();
        WriteGameBoardRow(gameBoard, indexesFirstRow);
        WriteFirstInterline();
        WriteGameBoardRow(gameBoard, indexesSecondRow);
        WriteSecondInterline();
        WriteGameBoardRow(gameBoard, indexesThirdRow);
        Console.WriteLine();

    }

    private void WriteFirstInterline()
    {
        Console.Write("    ---+---+---    X,O = Normal Token | ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("X,O = IsWinArea\n");
        Console.ResetColor();
    }

    private void WriteSecondInterline()
    {
        Console.Write("    ---+---+---    ");
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Write("   ");
        Console.ResetColor();
        Console.Write(" = IsRememberingX | ");
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Write("   ");
        Console.ResetColor();
        Console.Write(" = IsRememberingO\n");
    }

    private void WriteGameBoardRow(GameBoard gameBoard, int[] rowIndexes)
    {
        Console.Write($"    ");
        WriteToken(gameBoard.Areas[rowIndexes[0]]);
        Console.Write($"|");
        WriteToken(gameBoard.Areas[rowIndexes[1]]);
        Console.Write($"|");
        WriteToken(gameBoard.Areas[rowIndexes[2]]);
        Console.WriteLine();
        
    }

    private void WriteToken(GameBoardArea gameBoardArea)
    {
        if (gameBoardArea.IsWinArea)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" {gameBoardArea.Token} ");
            Console.ResetColor();
            return;
        }
        if (gameBoardArea.IsRememberingO)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write($" {gameBoardArea.Token} ");
            Console.ResetColor();
            return;
        }
        if (gameBoardArea.IsRememberingX)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($" {gameBoardArea.Token} ");
            Console.ResetColor();
            return;
        }
        else
        {
            Console.Write($" {gameBoardArea.Token} ");
        }
    }
}