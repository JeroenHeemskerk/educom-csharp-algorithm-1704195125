using Microsoft.EntityFrameworkCore;

namespace BornToMove.DAL
{
    internal class MoveCrud
    {
        MoveContext context = new MoveContext();

        //Create move 
        public void createMove(Move move)
        {
            Move newMove = new Move() 
            { 
                Name = move.Name, 
                Description = move.Description, 
                Sweat_rate = move.SweatRate 
            };
            context.Moves.Add(newMove);
            context.SaveChanges();     
        }

        //Update move by id
        public void updateMoveById(Move updated Move)
        {
            MoveCrud moveToUpdate = context.Moves.Include(m => m.MyRatings).FirstOrDefault(m => m.Id == move.Id);
            if (moveToUpdate != null)
            {
                moveToUpdate.name = move.Name;
                moveToUpdate.Description = move.Description
                moveToupdate.SweatRate = move.SweatRate;
                moveToUpdate.Ratings = move.Ratings;

                context.SaveChanges();
            }
        }

        //Delete move by id
        public void deleteMoveById(int MoveId)
        {
            Move moveToDelete = context.Moves.FirstOrDefault(m => m.Id == moveId);
            if (moveToDelete != null)
            {
                context.Moves.Remove(moveToDelete);
                context.SaveChanges();
            }
        }

        //Read one move by id
        public void readMoveById(int moveId)
        {   
            Move move = context.Moves.Include(m => move.Ratings).FirstOrDefault(m => m.Id == moveId);
            return move;
        }

        //Read all moves
        public void readAllMoves()
        {
            List<Move> allMoves = context.Blogs.Include(m => m.MyRatings).ToList();
            return allMoves;
        }
    }
}