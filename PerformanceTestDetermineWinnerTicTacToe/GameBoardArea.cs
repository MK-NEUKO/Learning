namespace PerformanceTestDetermineWinnerTicTacToe;

public class GameBoardArea
{
    public GameBoardArea(int areaId)
    {
        this.Id = areaId;
        this.Area = " ";
        this.IsRememberingX = false;
        this.IsRememberingO = false;
    }

    public string Area { get; set; }
    public int Id { get; set; }
    public bool IsWinArea { get; set; }
    public bool IsRememberingX { get; set; }
    public bool IsRememberingO { get; set; }
}