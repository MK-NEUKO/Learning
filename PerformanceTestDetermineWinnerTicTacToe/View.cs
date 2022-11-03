namespace PerformanceTestDetermineWinnerTicTacToe;

public class View
{
    public void ShowGameBoardList(List<GameBoard> gameBoardList)
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
        var headline = $"  Generation 1 GameBoard List: SerialNumber = {gameBoard.SerialNumber} from {gameBoardsTotal} GameBoards ";
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.Write($"{headline}");
        Console.ResetColor();
        Console.WriteLine("\n-".PadRight(headline.Length, '-') + "-");
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
        Console.Write("X,O = WinnerArea\n");
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
            Console.Write($" {gameBoardArea.Area} ");
            Console.ResetColor();
            return;
        }
        if (gameBoardArea.IsRememberingO)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write($" {gameBoardArea.Area} ");
            Console.ResetColor();
            return;
        }
        if (gameBoardArea.IsRememberingX)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($" {gameBoardArea.Area} ");
            Console.ResetColor();
            return;
        }
        else
        {
            Console.Write($" {gameBoardArea.Area} ");
        }
    }
}