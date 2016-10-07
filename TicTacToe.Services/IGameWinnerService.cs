namespace TicTacToe.UnitTests
{
    public interface IGameWinnerService
    {
        char Validate(char[,] gameBoard);
        void SetStartingPlayer(char expected);
    }
}