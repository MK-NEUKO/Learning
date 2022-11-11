namespace PerformanceTestDetermineWinnerTicTacToe;

public class GameBoard
{
    private string _serialNumber = string.Empty;

    public GameBoard()
    {
        Areas = CreateAreas();
        IsXWinner = false;
        IsOWinner = false;
        IsTie = false;
        GenerationNumber = 0;
    }

    public List<GameBoardArea> Areas { get; set; }
    public bool IsXWinner { get; set; }
    public bool IsOWinner { get; set; }
    public bool IsTie { get; set; }

    public string SerialNumber
    {
        get => $"Gen{GenerationNumber}-{_serialNumber}";
        set => _serialNumber = value;
    }
    public int GenerationNumber { get; set; }
    

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