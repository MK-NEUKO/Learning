﻿using System.Windows.Markup;

namespace PerformanceTestDetermineWinnerTicTacToe;

public class GameBoardProvider
{
    private List<GameBoard> _gen1GameBoardList;
    private List<GameBoard> _gen2GameBoardList;
    private readonly int[,] _winConstellations;

    public GameBoardProvider()
    {
        _gen1GameBoardList = new List<GameBoard>();
        _gen2GameBoardList = new List<GameBoard>();
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

    public IReadOnlyList<GameBoard> Gen1GameBoards => _gen1GameBoardList.AsReadOnly();

    public IReadOnlyList<GameBoard> Gen2GameBoardList => _gen2GameBoardList.AsReadOnly();

    public void CreateGen1GameBoardList()
    {
        for (int i = 0; i < 9; i++)
        {
            var gameBoard = new GameBoard();
            gameBoard.GenerationNumber = "1";
            gameBoard.SerialNumber = Convert.ToString(i + 1);
            gameBoard.Areas[i].Area = "X";
            gameBoard.Areas[i].IsRememberingX = true;
            _gen1GameBoardList.Add(gameBoard);
        }
    }

    public void CreateGen2Board()
    {
        var counter = 0;
        foreach (var gameBoard in _gen1GameBoardList)
        {
            var indexOfX = 1;
            foreach (var area in gameBoard.Areas)
            {
                if (area.IsRememberingX)
                {
                    indexOfX = area.Id;
                }
            }

            foreach (var area in gameBoard.Areas)
            {
                if (area.Area != "X" && !area.IsRememberingO)
                {
                    var newGameBoard = new GameBoard();
                    counter++;
                    newGameBoard.GenerationNumber = "2";
                    newGameBoard.SerialNumber = Convert.ToString(counter);
                    newGameBoard.Areas[indexOfX].Area = "X";
                    newGameBoard.Areas[indexOfX].IsRememberingX = true;
                    newGameBoard.Areas[area.Id].Area = "O";
                    newGameBoard.Areas[area.Id].IsRememberingO = true;
                    _gen2GameBoardList.Add(newGameBoard);
                }
            }
        }
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