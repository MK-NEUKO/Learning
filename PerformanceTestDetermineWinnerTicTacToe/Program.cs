
using PerformanceTestDetermineWinnerTicTacToe;

var gameBoardProvider = new GameBoardProvider();
gameBoardProvider.CreateGameBoards();

var view = new View();
view.ShowGameBoardList(gameBoardProvider.GameBoardList);

gameBoardProvider.CreateGen2Board();
view.ShowGameBoardList(gameBoardProvider.Gen2BoardList);
