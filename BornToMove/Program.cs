using System;
using System.Collections.Generic;
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
            
            Console.WriteLine("Het is tijd om te bewegen!");
            Console.WriteLine("Wilt u een suggestie of zelf een oefening kiezen uit de lijst?");
            Console.WriteLine("Typ 'suggestie' of 'lijst':");
            string answer;
            int moveId;
            string input;
            do
            {
                answer = Console.ReadLine()?.ToLower();
                if (answer == "suggestie") 
                {
                    
                    Console.WriteLine("---------------");
                    Console.WriteLine("Er wordt een willekeurige oefening gekozen...");
                    Console.WriteLine("---------------");
                    var randomMove = buMove.GetRandomMove();
                    moveId = randomMove.Id;
                    PrintResult(randomMove);
                    GiveReview();
                }
                else if (answer == "lijst")
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Alle oefeningen worden opgehaald...");
                    var allMoves = buMove.GetAllMoves();
                    PrintResults(allMoves);
                    while (true)
                    { 
                        Console.WriteLine("Kies een oefening en geef hier het id:");
                        Console.WriteLine("Als u een oefening wilt toevoegen, typ 0.");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out moveId))
                        {
                            if (moveId == 0)
                            {
                                Console.WriteLine("Geef de naam van de oefening:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Controleren of deze oefening nog niet bestaat in het systeem...");
                                var result = buMove.GetMoveByName(name);
                                if (result != null)
                                {
                                    Console.WriteLine("Deze oefening bestaat al.");
                                }
                                else 
                                {
                                    Console.WriteLine("Geef de omschrijving van de oefening:");
                                    string description = Console.ReadLine();
                                    Console.WriteLine("Geef het inspanningsniveau op van 1-5:");
                                    if (int.TryParse(Console.ReadLine(), out int sweatRate)&& sweatRate >= 1 && sweatRate <= 5)
                                    {
                                        buMove.SaveMove(name, description, sweatRate);
                                        Console.WriteLine("De oefening is succesvol aangemaakt.");
                                        break;
                                    }
                                    else 
                                    {
                                        Console.WriteLine("U gaf een ongeldige invoer, kies een id uit de lijst.");
                                    }
                                }
                            } 
                            else 
                            {
                                Console.WriteLine("---------------");
                                Console.WriteLine("U koos de oefening met id: " + moveId + ". Deze oefening wordt opgehaald...");
                                Console.WriteLine("---------------");
                                var moveById = moveCrud.ReadMoveById(moveId);
                                if (moveById != null)
                                {
                                    PrintResult(moveById);
                                    GiveReview();
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
                            Console.WriteLine("Er ging iets mis, kies een id uit de lijst.");
                        }
                    }
                } 
                else {
                    Console.WriteLine("Typ 'suggestie' of 'lijst. ");
                } 

            } while (answer != "suggestie" && answer != "lijst");
            
            // Sluit de toepassing
            Console.WriteLine("Druk op een toets om af te sluiten...");
            Console.ReadKey();
        }

        static void PrintResults(List<Move> moves)
        {
            foreach (var result in moves)
            {
                PrintResult(result);
            }
        }

        static void PrintResult(Move move)
        {
            if (move != null)
            {
                Console.WriteLine("---------------");
                Console.WriteLine($"Id: {move.Id}");
                Console.WriteLine($"Naam: {move.Name}");
                Console.WriteLine($"Omschrijving: {move.Description}");
                Console.WriteLine($"Inspanningsniveau: {move.SweatRate}");
                Console.WriteLine("---------------");
            }
            else
            {
                Console.WriteLine("Geen resultaten voor dit id nummer.");
            }
        }

        static void GiveReview()
        {
            Console.WriteLine("Geef alstublieft nog even uw mening over de oefening.");
            Console.WriteLine("Beoordeling, kies een getal van 1-5:");
            int review = int.Parse(Console.ReadLine());
            Console.WriteLine("Intensiteit, kies een getal van 1-5:");
            int intensity = int.Parse(Console.ReadLine());
            Console.WriteLine("U gaaf deze oefening een " + review + " en voor intensiteit een " + intensity + ". Bedankt voor uw beoordeling!");
        }
    }
}
