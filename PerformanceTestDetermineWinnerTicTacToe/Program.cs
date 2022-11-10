
using System.ComponentModel;
using PerformanceTestDetermineWinnerTicTacToe;

var gameBoardProvider = new GameBoardProvider();
gameBoardProvider.CreateGen1GameBoardList();
gameBoardProvider.CreateGen2GameBoardList();
gameBoardProvider.CreateGen3GameBoardList();



var view = new View();
//view.ShowGameBoardList(gameBoardProvider.Gen1GameBoardList);
//view.ShowGameBoardList(gameBoardProvider.Gen2GameBoardList);
view.ShowGameBoardList(gameBoardProvider.Gen3GameBoardList);

