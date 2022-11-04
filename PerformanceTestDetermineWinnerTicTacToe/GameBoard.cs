namespace PerformanceTestDetermineWinnerTicTacToe;

public class GameBoard
{

    public GameBoard()
    {
        Areas = CreateAreas();
        IsXWinner = false;
        IsOWinner = false;
        IsTie = false;
        SerialNumber = string.Empty;
        GenerationNumber = string.Empty;
    }

    public List<GameBoardArea> Areas { get; set; }
    public bool IsXWinner { get; set; }
    public bool IsOWinner { get; set; }
    public bool IsTie { get; set; }
    public string SerialNumber { get; set; }
    public string GenerationNumber { get; set; }

    private List<GameBoardArea> CreateAreas()
    {   
        var list = new List<GameBoardArea>();
        for (int i = 0; i < 9; i++)
        {
            list.Add(new GameBoardArea(i));
        }
        return list;
    }
}