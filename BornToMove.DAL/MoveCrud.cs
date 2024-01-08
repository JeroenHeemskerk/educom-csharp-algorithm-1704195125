using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BornToMove.DAL
{
    internal class MoveCrud
    {
        private MoveContext context;
        public MoveCrud()
        {
            context = new MoveContext();
        } 

        //Create move 
        public void createMove(Move move)
        {
            Move newMove = new Move() 
            { 
                Name = move.Name, 
                Description = move.Description, 
                Sweat_rate = move.SweatRate
                Ratings = move.Ratings 
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
        public Move readMoveById(int moveId)
        {   
            Move move = context.Moves.Include(m => m.Ratings).FirstOrDefault(m => m.Id == moveId);
            return move;
        }

        //Read all moves
        public List<Move> readAllMoves()
        {
            List<Move> allMoves = context.Moves.Include(m => m.Ratings).ToList();
            return allMoves;
        }
    }
}