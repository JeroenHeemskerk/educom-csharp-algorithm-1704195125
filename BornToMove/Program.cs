using System;

class Program
{
    static void Main()
    {
        Crud crud = new Crud();
        MoveCrud moveCrud = new MoveCrud(crud);
        //RatingCrud ratingCrud = new RatingCrud(crud);
        
        Console.WriteLine("It's time to move!");
        Console.WriteLine("Do you want a random move or pick a move?");
        Console.WriteLine("Typ 'random' or 'pick':");
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
                var randomMove = moveCrud.ReadRandomMove();
                PrintResult(randomMove);
            }
            else if (answer == "pick")
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Reading all moves...");
                Console.WriteLine("---------------");
                var allMoves = moveCrud.ReadAllMoves();
                PrintResults(allMoves);
                while (true)
                { 
                    Console.WriteLine("Pick a move by typing the id nummer here:");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out moveId))
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
                        } 
                        else 
                        {
                            continue;
                        }
                        break;
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

        

        /*
        Console.WriteLine("Checking if a move already exists...");
        var result = moveCrud.ReadMoveByName("Test Move");
        PrintResult(result);
        */
        
        /*/Rating
        static void RateMove(int moveId)
        {
            Console.WriteLine("Please add your rating for this move.");
            Console.WriteLine("Pick a number from 1-5 for the review:");

            int review;
            if (int.TryParse(Console.ReadLine(), out review) && review >= 1 && review <= 5)
            {
                Console.WriteLine("Your review rating is " + review);

                Console.WriteLine("Now, pick a number from 1-5 for the intensity:");
                
                int intensity;
                if (int.TryParse(Console.ReadLine(), out intensity) && intensity >= 1 && intensity <= 5)
                {
                    Console.WriteLine("Your intensity rating is " + intensity);
                    var rating = ratingCrud.CreateRating(moveId, review, intensity);
                }
                else
                {
                    Console.WriteLine("Something went wrong. Choose a number 1-5 for intensity.");
                }
            }
            else
            {
                Console.WriteLine("Something went wrong. Choose a number 1-5 for the review.");
            }
        }*/


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
