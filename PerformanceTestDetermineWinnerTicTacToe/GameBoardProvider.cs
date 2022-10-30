namespace PerformanceTestDetermineWinnerTicTacToe;

public class GameBoardProvider
{
    private Dictionary<string, GameBoard> gameBoardList;
    private GameBoard gameBoard;

    public GameBoardProvider()
    {
            
    }

    public void CreateGameBoards(bool isXInitialToken)
    {
        var curentGameBoard = new GameBoard();
    }
}

public class GameBoard
{
    private List<GameBoardArea> gameBoardAreaList;
    private bool isXWinner;
    private bool isOWinner;
    private bool isTie;

    public GameBoard()
    {
        
    }
}