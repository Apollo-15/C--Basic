namespace Tic_tac_toe
{
    public interface IPlayer
    {
        char Symbol { get; }
        string Name { get; }
        int ChooseCell(Board board);
        void MakeMove(Board board);
    }
}