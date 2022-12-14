using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;

namespace PerformanceTestDetermineWinnerTicTacToe;

public class GameBoardProvider
{
    private List<GameBoard> _gameBoardList;
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

    public IReadOnlyList<GameBoard> GameBoardList => _gameBoardList.AsReadOnly();

    public void CreateGameBoardList()
    {
        var genDepth = 1;
        var currentGameBoardList = new List<GameBoard>();
        var currentToken = "X";
        for (int i = 0; i < 9; i++)
        {
            var gameBoard = new GameBoard
            {
                GenerationNumber = genDepth,
                SerialNumber = Convert.ToString(i + 1)
            };
            gameBoard.Areas[i].Token = currentToken;
            currentGameBoardList.Add(gameBoard);
        }
        _gameBoardList.AddRange(currentGameBoardList);
        SwapTokens(currentGameBoardList);
        currentToken = ChangeToken(currentToken);
        CreateNextGenGameBoards(currentGameBoardList, genDepth + 1, currentToken);
    }


    public void CreateNextGenGameBoards(List<GameBoard> currentGameBoardList,int genDepth, string currentToken)
    {
        if (genDepth > 9)
        {
            return;
        }
        var counter = 1;
        var nextGenGameBoardList = new List<GameBoard>();
        foreach (var currentGameBoard in currentGameBoardList)
        {
            if(currentGameBoard.IsOWinner || currentGameBoard.IsXWinner || currentGameBoard.IsTie)
                continue;
            foreach (var currentArea in currentGameBoard.Areas)
            {
                if (currentArea.Token == " ")
                {
                    var newGameBoard = new GameBoard
                    {
                        GenerationNumber = genDepth,
                        SerialNumber = Convert.ToString(counter),
                    };
                    currentGameBoard.Areas.ForEach(currentArea => newGameBoard.Areas[currentArea.Id].Token = currentArea.Token);
                    newGameBoard.Areas[currentArea.Id].Token = currentToken;
                    if(genDepth == 5)
                        EvaluateGameBoard(newGameBoard);
                    nextGenGameBoardList.Add(newGameBoard);
                    _gameBoardList.Add(newGameBoard);
                    counter++;
                }
            }
        }
        currentToken = ChangeToken(currentToken);
        CreateNextGenGameBoards(nextGenGameBoardList, genDepth + 1, currentToken);
    }

    private string ChangeToken(string currentToken)
    {
        if (currentToken == "X")
        {
            return "O";
        }
        else
        {
            return "X";
        }
    }

    private void SwapTokens(List<GameBoard> toSwapGameBoardList)
    {
        var counter = 1;
        var swappedGameBoardList = new List<GameBoard>();
        foreach (var gameBoard in toSwapGameBoardList)
        {
            var swappedGameBoard = new GameBoard
            {
                GenerationNumber = gameBoard.GenerationNumber,
                SerialNumber = Convert.ToString(toSwapGameBoardList.Count + counter)
            };
            foreach (var area in gameBoard.Areas)
            {
                if (area.Token == "X")
                {
                    swappedGameBoard.Areas[area.Id].Token = "O";
                    swappedGameBoard.Areas[area.Id].IsRememberingO = true;
                }

                if (area.Token == "O")
                {
                    swappedGameBoard.Areas[area.Id].Token = "X";
                    swappedGameBoard.Areas[area.Id].IsRememberingX = true;
                }
            }
            counter++;
            swappedGameBoardList.Add(swappedGameBoard);
        }
        _gameBoardList.AddRange(swappedGameBoardList);
    }


    private void EvaluateGameBoard(GameBoard gameBoard)
    {
        CheckForWinner(gameBoard);
        CheckForGameIsTie(gameBoard);
    }

    private void CheckForWinner(GameBoard gameBoard)
    {
        var numberOfConstellations = _winConstellations.GetLength(0);
        for (int i = 0; i < numberOfConstellations; i++)
        {
            var actualContent = gameBoard.Areas[_winConstellations[i, 0]].Token;
            actualContent += gameBoard.Areas[_winConstellations[i, 1]].Token;
            actualContent += gameBoard.Areas[_winConstellations[i, 2]].Token;

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
            if (area.Token == " ")
            {
                return;
            }
        }
        gameBoard.IsTie = true;
    }
}