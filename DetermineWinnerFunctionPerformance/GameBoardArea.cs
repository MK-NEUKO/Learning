namespace DetermineWinnerFunctionPerformance;

public class GameBoardArea
{
    public GameBoardArea(int areaId, string area)
    {
        this.AreaId = areaId;
        this.Area = area;
    }

    public string Area { get; set; }
    public int AreaId { get; set; }
    public bool IsWinArea { get; set; }
}