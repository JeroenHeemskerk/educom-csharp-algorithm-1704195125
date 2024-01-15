using Microsoft.EntityFrameworkCore;
using BornToMove.DAL;
using System;
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

        //Controleren of er iets in de tabel move staat
        public bool IsAnyMove()
        {
            return Context.Moves.Any();
        }

        //Create move 
        public void CreateMove(Move newMove)
        {
            Context.Moves.Add(newMove);
            Context.SaveChanges();     
        }

        //Create MoveRating
        public void CreateMoveRating(MoveRating newMoveRating)
        {
            Context.MoveRating.Add(newMoveRating);
            Context.SaveChanges();
        }

        //Update move by id
        public void UpdateMoveById(Move move)
        {
            Move? moveToUpdate = Context.Moves?.FirstOrDefault(m => m.Id == move.Id);                     
            if (moveToUpdate != null)
            {
                moveToUpdate.Name = move.Name;
                moveToUpdate.Description = move.Description;

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

        //Read random move
        public MoveRating ReadRandomMove()
        {
            Move randomMove = Context.Moves
                .Include(m => m.Ratings)
                .OrderBy(m => Guid.NewGuid())
                .FirstOrDefault();
            if (randomMove != null)
            {
                MoveRating moveRating = new MoveRating()
                {
                    Move = randomMove,
                    Rating = randomMove.Ratings != null && randomMove.Ratings.Any() ? randomMove.Ratings.Average(r => r.Rating) : 0,
                    Vote = randomMove.Ratings != null && randomMove.Ratings.Any() ? randomMove.Ratings.Average(r => r.Vote) : 0
                };
                return moveRating;
            }
            return null;
        }

        //Read one move by id
        public MoveRating ReadMoveById(int moveId)
        {   
            MoveRating moveById = Context.Moves
                .Include(m => m.Ratings)
                .Where(m => m.Id == moveId)
                .Select(move => new MoveRating()
                {
                    Move = move,
                    Rating = move.Ratings != null && move.Ratings.Any() ? move.Ratings.Average(r => r.Rating) : 0,
                    Vote = move.Ratings != null && move.Ratings.Any() ? move.Ratings.Average(r => r.Vote) : 0
                })
                .First();
            return moveById;
        }

        //Read move by name
        public Move? ReadMoveByName(string name)
        {   
            Move? move = Context.Moves?
                .Include(m => m.Ratings)
                .FirstOrDefault(m => m.Name == name);               
            return move;
        }

        //Read all moves
        public List<MoveRating> ReadAllMoves()
        {
            List<MoveRating> allMoves = Context.Moves
                .Include(m => m.Ratings)
                .Select(move => new MoveRating()
                {
                    Move = move,
                    Rating = move.Ratings != null && move.Ratings.Any() ? move.Ratings.Average(r => r.Rating) : 0,
                    Vote = move.Ratings != null && move.Ratings.Any() ? move.Ratings.Average(r => r.Vote) : 0
                })
                .ToList();
            allMoves.Sort(new RatingsConverter());
            return allMoves;
        }
    }
}