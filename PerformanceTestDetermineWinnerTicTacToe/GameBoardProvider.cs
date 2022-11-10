using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;

namespace PerformanceTestDetermineWinnerTicTacToe;

public class GameBoardProvider
{
    private List<GameBoard> _gen1GameBoardList;
    private List<GameBoard> _gen1WithoutSwappedTokens;
    private List<GameBoard> _gen2GameBoardList;
    private List<GameBoard> _gen3GameBoardList;
    private readonly int[,] _winConstellations;

    public GameBoardProvider()
    {
        _gen1GameBoardList = new List<GameBoard>();
        _gen1WithoutSwappedTokens = new List<GameBoard>();
        _gen2GameBoardList = new List<GameBoard>();
        _gen3GameBoardList = new List<GameBoard>();
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

    public IReadOnlyList<GameBoard> Gen1GameBoardList => _gen1GameBoardList.AsReadOnly();

    public IReadOnlyList<GameBoard> Gen2GameBoardList => _gen2GameBoardList.AsReadOnly();

    public IReadOnlyList<GameBoard> Gen3GameBoardList => _gen3GameBoardList.AsReadOnly();

    public void CreateGen1GameBoardList()
    {
        for (int i = 0; i < 9; i++)
        {
            var gameBoard = new GameBoard
            {
                GenerationNumber = 1,
                SerialNumber = (i + 1)
            };
            gameBoard.Areas[i].Area = "X";
            gameBoard.Areas[i].IsRememberingX = true;
            _gen1WithoutSwappedTokens.Add(gameBoard);
            _gen1GameBoardList.Add(gameBoard);
        }
        SwapTokens(_gen1GameBoardList);
    }

    public void CreateGen2GameBoardList()
    {
        var counter = 1;
        foreach (var gameBoard in _gen1WithoutSwappedTokens)
        {
            foreach (var area in gameBoard.Areas)
            {
                if (area.Area == " ")
                {
                    var newGameBoard = new GameBoard
                    {
                        GenerationNumber = 2,
                        SerialNumber = counter,
                    };
                    gameBoard.Areas.ForEach(area => newGameBoard.Areas[area.Id].Area = area.Area);
                    newGameBoard.Areas[area.Id].Area = "O";
                    _gen2GameBoardList.Add(newGameBoard);
                    counter++;
                }
            }
        }
    }

    public void CreateGen3GameBoardList()
    {
        var counter = 1;
        foreach (var gameBoard in _gen2GameBoardList)
        {
            foreach (var area in gameBoard.Areas)
            {
                if (area.Area == " ")
                {
                    var newGameBoard = new GameBoard
                    {
                        GenerationNumber = 3,
                        SerialNumber = counter,
                    };
                    gameBoard.Areas.ForEach(area => newGameBoard.Areas[area.Id].Area = area.Area);
                    newGameBoard.Areas[area.Id].Area = "X";
                    _gen3GameBoardList.Add(newGameBoard);
                    counter++;
                }
            }
        }
    }

    private void SwapTokens(List<GameBoard> toSwapGameBoard)
    {
        var swappedGameBoardList = new List<GameBoard>();
        foreach (var gameBoard in toSwapGameBoard)
        {
            var swappedGameBoard = new GameBoard();
            swappedGameBoard.GenerationNumber = gameBoard.GenerationNumber;
            swappedGameBoard.SerialNumber = gameBoard.SerialNumber + toSwapGameBoard.Count;
            foreach (var area in gameBoard.Areas)
            {
                if (area.Area == "X")
                {
                    swappedGameBoard.Areas[area.Id].Area = "O";
                    swappedGameBoard.Areas[area.Id].IsRememberingO = true;
                }

                if (area.Area == "O")
                {
                    swappedGameBoard.Areas[area.Id].Area = "X";
                    swappedGameBoard.Areas[area.Id].IsRememberingX = true;
                }
            }
            swappedGameBoardList.Add(swappedGameBoard);
        }
        swappedGameBoardList.ForEach(item => toSwapGameBoard.Add(item));
    }


    private void IsGameOpen(GameBoard gameBoard)
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