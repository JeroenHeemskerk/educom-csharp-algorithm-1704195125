using System;
using System.Transactions;
using BornToMove.Business;
using BornToMove.DAL;

namespace BornToMove
{
    class Program
    {
        static void Main(string[] args)
        {
            MoveContext moveContext = new MoveContext();
            MoveCrud moveCrud = new MoveCrud(moveContext);
            BuMove buMove = new BuMove(moveCrud);
            
            Console.WriteLine("It's time to move!");
            Console.WriteLine("Do you want a random move or pick a move?");
            Console.WriteLine("Type 'random' or 'pick':");
            string answer;
            int moveId;
            string input;
            do
            {
                answer = Console.ReadLine()?.ToLower();
                if (answer == "random") 
                {
                    
                    Console.WriteLine("---------------");
                    Console.WriteLine("Picking random move");
                    Console.WriteLine("---------------");
                    var randomMove = buMove.GetRandomMove();
                    moveId = randomMove.Id;
                    PrintResult(randomMove);
                    //RateMove(moveId, buMove.GetRatingCrud());
                }
                else if (answer == "pick")
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Reading all moves...");
                    Console.WriteLine("---------------");
                    var allMoves = buMove.GetAllMoves();
                    PrintResults(allMoves);
                    while (true)
                    { 
                        Console.WriteLine("Pick a move by typing the id nummer here:");
                        Console.WriteLine("If you want to add a move type 0.");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out moveId))
                        {
                            if (moveId == 0)
                            {
                                Console.WriteLine("Enter the name of the move:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Checking if a move already exists...");
                                var result = buMove.GetMoveByName(name);
                                if (result != null)
                                {
                                    Console.WriteLine("This move already exist");
                                }
                                else 
                                {
                                    Console.WriteLine("Enter a description of the move:");
                                    string description = Console.ReadLine();
                                    Console.WriteLine("Enter the sweatrate of the move from 1-5:");
                                    if (int.TryParse(Console.ReadLine(), out int sweatRate)&& sweatRate >= 1 && sweatRate <= 5)
                                    {
                                        buMove.SaveMove(name, description, sweatRate);
                                        Console.WriteLine("Move created successfully.");
                                        break;
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Invalid input for sweat rate. Please enter a valid number.");
                                    }
                                }
                            } 
                            else 
                            {
                                Console.WriteLine("---------------");
                                Console.WriteLine("Getting move with id: " + moveId);
                                Console.WriteLine("---------------");
                                Console.WriteLine("Reading the move you picked...");
                                Console.WriteLine("---------------");
                                var moveById = moveCrud.ReadMoveById(moveId);
                                if (moveById != null)
                                {
                                    PrintResult(moveById);
                                    Console.WriteLine("---------------");
                                    Console.WriteLine("Please add your rating for this move.");
                                    Console.WriteLine("Pick a number from 1-5 for the review:");
                                    int review = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Now, pick a number from 1-5 for the intensity:");
                                    int intensity = int.Parse(Console.ReadLine());
                                } 
                                else 
                                {
                                    continue;
                                }
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Something wend wrong, you have to pick a number from the list.");
                        }
                    }
                } 
                else {
                    Console.WriteLine("Typ 'random' or 'pick'. ");
                } 

            } while (answer != "random" && answer != "pick");
            
            // Sluit de toepassing
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void PrintResults(dynamic results)
        {
            foreach (var result in results)
            {
                PrintResult(result);
            }
        }

        static void PrintResult(dynamic result)
        {
            if (result != null)
            {
                foreach (var property in result)
                {
                    Console.WriteLine($"{property.Key}: {property.Value}");
                }
                Console.WriteLine("---------------");
            }
            else
            {
                Console.WriteLine("No results found for this id number.");
            }
        }
    }
}
