using Microsoft.EntityFrameworkCore;
using BornToMove.DAL;
using System.Linq;
using System.Collections.Generic;

namespace BornToMove.DAL
{
    public class MoveCrud
    {
        private MoveContext Context;
        public MoveCrud(MoveContext context)
        {
            Context = context;
        } 

        //Create move 
        public void CreateMove(Move newMove)
        {
            Context.Moves.Add(newMove);
            Context.SaveChanges();     
        }

        //Update move by id
        public void UpdateMoveById(Move move)
        {
            Move? moveToUpdate = Context.Moves?.FirstOrDefault(m => m.Id == move.Id);                     //Tussen Moves en First... Include(m => m.Ratings).
            if (moveToUpdate != null)
            {
                moveToUpdate.Name = move.Name;
                moveToUpdate.Description = move.Description;
                moveToUpdate.SweatRate = move.SweatRate;
                //moveToUpdate.Ratings = move.Ratings;

                Context.SaveChanges();
            }
        }

        //Delete move by id
        public void DeleteMoveById(int moveId)
        {
            Move? moveToDelete = Context.Moves?.FirstOrDefault(m => m.Id == moveId);
            if (moveToDelete != null)
            {
                Context.Moves?.Remove(moveToDelete);
                Context.SaveChanges();
            }
        }

        //Read one random move
        public Move? ReadRandomMove()
        {
            Move? move = Context.Moves?.OrderBy(m => Guid.NewGuid()).FirstOrDefault();
            return move;
        }

        //Read one move by id
        public Move? ReadMoveById(int moveId)
        {   
            Move? move = Context.Moves?.FirstOrDefault(m => m.Id == moveId);               //Tussen Moves en Firts.. > Include(m => m.Ratings).
            return move;
        }

        //Read move by name
        public Move? ReadMoveByName(string name)
        {   
            Move? move = Context.Moves?.FirstOrDefault(m => m.Name == name);               //Tussen Moves en Firts.. > Include(m => m.Ratings).
            return move;
        }

        //Read all moves
        public List<Move> ReadAllMoves()
        {
            List<Move> allMoves = Context.Moves.ToList();                               //Tussen Moves en Firts.. > Include(m => m.Ratings).
            return allMoves;
        }
    }
}