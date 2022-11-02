namespace PerformanceTestDetermineWinnerTicTacToe;

public class GameBoardProvider
{
    private List<GameBoard> _gameBoardList;
    private GameBoard _gameBoard;
    private readonly int[,] _winConstellations;

    public GameBoardProvider()
    {
        _gameBoardList = new List<GameBoard>();
        _winConstellations = new int[8, 3]
        {
            {0,1,2}, /*  +---+---+---+  */
            {3,4,5}, /*  | 0 | 1 | 2 |  */
            {6,7,8}, /*  +---+---+---+  */
            {0,3,6}, /*  | 3 | 4 | 5 |  */
            {1,4,7}, /*  +---+---+---+  */
            {2,5,8}, /*  | 6 | 7 | 8 |  */
            {0,4,8}, /*  +---+---+---+  */
            {2,4,6},
        };
    }

    public List<GameBoard> GameBoardList => _gameBoardList;

    public void CreateGameBoards()
    {
        
        for (int i = 0; i < 9; i++)
        {
            var gameBoard = new GameBoard();
            gameBoard.Areas[i].Area = "X";
            GameBoardList.Add(gameBoard);
        }
    }

    private void CheckGameBoardState(GameBoard gameBoard)
    {
        CheckForWinner(gameBoard);
        CheckForGameIsTie(gameBoard);
    }

    private void CheckForWinner(GameBoard gameBoard)
    {
        var numberOfConstellations = _winConstellations.GetLength(0);
        for (int i = 0; i < numberOfConstellations; i++)
        {
            var actualContent = gameBoard.Areas[_winConstellations[i, 0]].Area;
            actualContent += gameBoard.Areas[_winConstellations[i, 1]].Area;
            actualContent += gameBoard.Areas[_winConstellations[i, 2]].Area;

            if (actualContent == "XXX")
            {
                gameBoard.IsXWinner = true;
                gameBoard.Areas[_winConstellations[i, 0]].IsWinArea = true;
                gameBoard.Areas[_winConstellations[i, 1]].IsWinArea = true;
                gameBoard.Areas[_winConstellations[i, 2]].IsWinArea = true;
            }

            if (actualContent == "OOO")
            {
                gameBoard.IsOWinner = true;
                gameBoard.Areas[_winConstellations[i, 0]].IsWinArea = true;
                gameBoard.Areas[_winConstellations[i, 1]].IsWinArea = true;
                gameBoard.Areas[_winConstellations[i, 2]].IsWinArea = true;
            }
        }
    }

    private void CheckForGameIsTie(GameBoard gameBoard)
    {
        if (gameBoard.IsXWinner || gameBoard.IsOWinner)
        {
            return;
        }

        foreach (var area in gameBoard.Areas)
        {
            if (area.Area == " ")
            {
                return;
            }
        }
        gameBoard.IsTie = true;
    }
}

public class View
{
    public void ShowGameBoardList(List<GameBoard> gameBoardList)
    {
        foreach (var gameBoard in gameBoardList)
        {
            foreach (var area in gameBoard.Areas)
            {
                Console.WriteLine();
                Console.WriteLine(area.Area);
                Console.WriteLine();
            }
        }
    }
}