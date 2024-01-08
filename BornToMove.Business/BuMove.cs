using System.Collections.Generic;
using BornToMove.DAL.MoveCrud;

namespace BornToMove.Business

public class BuMove
{
    private MoveCrud moveCrud;

    public BuMove()
    {
        moveCrud = new MoveCrud();
    }

    //Willekeurige Move 
    public Move GetRandomMove()
    {

    }

    //Lijst met alle moves
    public List<Move> GetAllMoves()
    {
        return moveCrud.ReadAllMoves();
    }

    //Move by id
    public Move GetMoveById(int moveId)
    {
        return moveCrud.ReadMoveById(moveId);
    }

    //Move controleren en opslaan
    public void SaveMove(Move move)
    {
        moveCrud.CreateMove(move);
    }

    //Move controleren en updaten
    public void UpdateMove(Move move)
    {
        moveCrud.UpdateMoveById(move);
    }
}
