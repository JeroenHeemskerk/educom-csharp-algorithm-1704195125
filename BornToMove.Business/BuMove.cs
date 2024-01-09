using System.Collections.Generic;
using BornToMove.DAL;

namespace BornToMove.Business
{
    public class BuMove
    {
        private MoveCrud MoveCrud;

        public BuMove(MoveCrud moveCrud)
        {
            MoveCrud = moveCrud;
        }

        //Willekeurige Move 
        public Move? GetRandomMove()
        {
            return MoveCrud.ReadRandomMove();
        }

        //Lijst met alle moves
        public List<Move> GetAllMoves()
        {
            return MoveCrud.ReadAllMoves();
        }

        //Move by id
        public Move? GetMoveById(int moveId)
        {
            return MoveCrud.ReadMoveById(moveId);
        }

        //Move by name
        public Move? GetMoveByName(string name)
        {
            return MoveCrud.ReadMoveByName(name);
        }

        //Move controleren en opslaan
        public void SaveMove(string name, string description, int sweatRate)
        {
            Move move = new Move()
            {
                Name = name, 
                Description = description, 
                SweatRate = sweatRate
            };
            MoveCrud.CreateMove(move);
        }

        //Move controleren en updaten
        public void UpdateMove(Move move)       
        {
            MoveCrud.UpdateMoveById(move);
        }
    }
}