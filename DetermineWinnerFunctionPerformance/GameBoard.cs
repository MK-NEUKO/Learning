﻿using DetermineWinnerFunctionPerformance;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore
{
    public class GameBoard
    {
        private List<GameBoardArea> _gameBoardAreaList;
        private bool _isPlayerXWinner;
        private bool _isPlayerOWinner;
        private bool _isGameTie;
        private readonly int[,] _winConstellations;

        public GameBoard(IGameBoardRepository gameBoardRepository)
        {
            _gameBoardRepository = gameBoardRepository ?? throw new ArgumentNullException(nameof(gameBoardRepository));
            _gameBoardAreaList = _gameBoardRepository.LoadNewGameBoard();
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

        public bool IsPlayerXWinner => _isPlayerXWinner;
        public bool IsPlayerOWinner => _isPlayerOWinner;
        public bool IsGameTie => _isGameTie;
        public List<GameBoardArea> GameBoardAreaList => _gameBoardAreaList;


        public void ShowStartAnimation(bool isNewGame)
        {
            if (isNewGame)
            {
                _gameBoardAreaList.ForEach(area => area.IsStartNewGameAnimation = true);
                return;
            }
            _gameBoardAreaList.ForEach(area => area.IsStartLastGameAnimation = true);
        }

        public void ResetAnimationValue() => _gameBoardAreaList.ForEach(area =>
        {
            area.IsStartNewGameAnimation = false;
            area.IsStartLastGameAnimation = false;
        });

        public void LoadLastGameBoard() => _gameBoardAreaList = _gameBoardRepository.LoadLastGameBoard();

        public void CheckGameBoardState()
        {
            CheckForWinner();
            CheckForGameIsTie();
            if (_isPlayerXWinner || _isPlayerOWinner)
                ShowWinner();
        }

        private void CheckForWinner()
        {
            var numberOfWinnconstellations = _winConstellations.GetLength(0);
            for (int i = 0; i < numberOfWinnconstellations; i++)
            {
                string actualContent = _gameBoardAreaList[_winConstellations[i, 0]].Area;
                actualContent += _gameBoardAreaList[_winConstellations[i, 1]].Area;
                actualContent += _gameBoardAreaList[_winConstellations[i, 2]].Area;

                if (actualContent == "XXX")
                {
                    _isPlayerXWinner = true;
                    _gameBoardAreaList[_winConstellations[i, 0]].IsWinArea = true;
                    _gameBoardAreaList[_winConstellations[i, 1]].IsWinArea = true;
                    _gameBoardAreaList[_winConstellations[i, 2]].IsWinArea = true;
                }

                if (actualContent == "OOO")
                {
                    _isPlayerOWinner = true;
                    _gameBoardAreaList[_winConstellations[i, 0]].IsWinArea = true;
                    _gameBoardAreaList[_winConstellations[i, 1]].IsWinArea = true;
                    _gameBoardAreaList[_winConstellations[i, 2]].IsWinArea = true;
                }
            }
        }

        private void CheckForGameIsTie()
        {
            if (_isPlayerXWinner || _isPlayerOWinner)
            {
                return;
            }

            foreach (var area in _gameBoardAreaList)
            {
                if (area.Area == " ")
                {
                    return;
                }
            }
            _isGameTie = true;
        }

        private void ShowWinner()
        {
            foreach (var area in _gameBoardAreaList)
            {
                if (!area.IsWinArea)
                {
                    area.IsStartNewGameAnimation = false;
                }
            }
        }

        public void PlaceAToken(int areaID, string token)
        {
            _gameBoardAreaList[areaID].Area = token;
            _gameBoardAreaList[areaID].IsOccupied = true;
        }

        public void ResetGameBoard()
        {
            foreach (var area in _gameBoardAreaList)
            {
                area.Area = " ";
                area.IsOccupied = false;
                area.IsWinArea = false;
            }
            _isPlayerXWinner = false;
            _isPlayerOWinner = false;
            _isGameTie = false;
        }
    }
}