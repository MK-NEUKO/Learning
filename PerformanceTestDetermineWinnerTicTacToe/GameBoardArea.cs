namespace PerformanceTestDetermineWinnerTicTacToe;

public class GameBoardArea
{
    public GameBoardArea(int areaId)
    {
        this.AreaId = areaId;
        this.Area = " ";
    }

    public string Area { get; set; }
    public int AreaId { get; set; }
    public bool IsWinArea { get; set; }
}