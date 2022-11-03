
using PerformanceTestDetermineWinnerTicTacToe;

var gameBoardProvider = new GameBoardProvider();
gameBoardProvider.CreateGen1GameBoardList();

var view = new View();
view.ShowGameBoardList(gameBoardProvider.Gen1GameBoards);

gameBoardProvider.CreateGen2Board();
view.ShowGameBoardList(gameBoardProvider.Gen2BoardList);
