namespace PerformanceTestDetermineWinnerTicTacToe;

public class View
{
    public void ShowGameBoardList(List<GameBoard> gameBoardList)
    {
        foreach (var gameBoard in gameBoardList)
        {
            Console.WriteLine("---------------------------------");
            foreach (var area in gameBoard.Areas)
            {
                if (area.IsRememberingX)
                {
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(area.Area);
                    Console.ResetColor();
                }

                if (area.IsRememberingO)
                {
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write(area.Area);
                    Console.ResetColor();
                }
                if(area.Area == " ")
                    Console.Write(" -");
            }

            Console.WriteLine();
        }
    }
}