using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HuntTheWumpus
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRooms;
            Room[] Caves;
            string[] initializationFileString;
            string[] roomNumbersOnSingleLine;
            string[] separator = {" "};
            char wannaPlayMore = 'Y';


            initializationFileString = File.ReadAllLines(@"CavesInitialisationFile.txt");



            /* foreach(string s in initializationFileString)
               Console.WriteLine(s);*/
            
            numberOfRooms = Convert.ToInt32(initializationFileString[0]);

            Caves = new Room[numberOfRooms];

            int j = 0;

            Console.WriteLine("Game Initializing . . . ."); 

           for (int i = 1; i <= numberOfRooms * 2; i++ )
            {
                Room cave = new Room();
                string temporary = initializationFileString[i];
                roomNumbersOnSingleLine = temporary.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                //Console.WriteLine(roomNumbersOnSingleLine.Length);

                cave.RoomNumber = roomNumbersOnSingleLine[0];
                cave.AdjacentRoomOne = roomNumbersOnSingleLine[1];
                cave.AdjacentRoomTwo = roomNumbersOnSingleLine[2];
                cave.AdjacentRoomThree = roomNumbersOnSingleLine[3];
                           
               
               /* foreach (string p in roomNumbersOnSingleLine)
                {
                        Console.WriteLine("\n" + p);
                }*/
                
                cave.CharacteristicOfTheRoom = initializationFileString[++i];

                Caves[j] = cave;

               //Console.WriteLine(Caves[j].RoomNumber + Caves[j].AdjacentRoomOne + Caves[j].AdjacentRoomTwo + Caves[j].AdjacentRoomThree + Caves[j].CharacteristicOfTheRoom);

               j++;
              // Console.WriteLine("Room {0} being intialized", j);
            }

           Console.Clear();
           Console.WriteLine("\n\n\nGame Initialised!!!\n");
           Console.WriteLine("Press any key to Enter the caves...");
           Console.ReadKey();
           
            


            do
            {
                Console.Clear();

                Console.WriteLine("Welcome to **Hunt The Wumpus!**");

                Random randomGenerator = new Random();
                bool alive= true;
                int arrows = 3;
                
                Room currentRoom = new Room();
                currentRoom = Caves[0];

                string optionTaskRoom = " ";

                 string wumpusLocation = " ";
                 string pitOneLocation = " ";
                 string pitTwoLocation= " ";
                 string spiderOneLocation= " ";
                 string spiderTwoLocation= " ";
                
            Randomize:
                {
                wumpusLocation = Convert.ToString(randomGenerator.Next(2, numberOfRooms));
                pitOneLocation = Convert.ToString(randomGenerator.Next(2, numberOfRooms));
                pitTwoLocation = Convert.ToString(randomGenerator.Next(2, numberOfRooms));
                spiderOneLocation = Convert.ToString(randomGenerator.Next(2, numberOfRooms));
                spiderTwoLocation = Convert.ToString(randomGenerator.Next(2, numberOfRooms));
                
            
                if (wumpusLocation == pitOneLocation || wumpusLocation == pitTwoLocation || wumpusLocation == spiderOneLocation || wumpusLocation == spiderTwoLocation || pitOneLocation == pitTwoLocation || pitOneLocation == spiderOneLocation || pitOneLocation == spiderTwoLocation || pitTwoLocation == spiderOneLocation || pitTwoLocation == spiderTwoLocation || spiderOneLocation == spiderTwoLocation)
                {
                    goto Randomize;

                }
            }

                 //Console.WriteLine("Wumpus  " + wumpusLocation);
                 //Console.WriteLine("Pit1  " + pitOneLocation);
                 //Console.WriteLine("Pit2  " + pitTwoLocation);
                 //Console.WriteLine("Spider1  " + spiderOneLocation);
                 //Console.WriteLine("Spider2  " + spiderTwoLocation);


                Caves[0] = currentRoom;

                do
                {
                   

                    
                    char taskOption = ' ';


                optionSelect:
                    {
                        if (arrows <= 0)
                        {
                            Console.WriteLine("\n\n\nYou are out of arrows! \n\n **You Lost the game**");
                            break;
                        }
                    
                    Console.WriteLine("You are in the Room {0}", currentRoom.RoomNumber);
                    Console.WriteLine(currentRoom.CharacteristicOfTheRoom);
                    Console.WriteLine("There tunnels to the rooms: {0} , {1}  and {2}", currentRoom.AdjacentRoomOne, currentRoom.AdjacentRoomTwo, currentRoom.AdjacentRoomThree);

                    if (currentRoom.AdjacentRoomOne == wumpusLocation || currentRoom.AdjacentRoomTwo == wumpusLocation || currentRoom.AdjacentRoomThree == wumpusLocation)
                        Console.WriteLine("You smell some nasty Wumpus!");

                    if (currentRoom.AdjacentRoomOne == pitOneLocation || currentRoom.AdjacentRoomTwo == pitOneLocation || currentRoom.AdjacentRoomThree == pitOneLocation || currentRoom.AdjacentRoomOne == pitTwoLocation || currentRoom.AdjacentRoomTwo == pitTwoLocation || currentRoom.AdjacentRoomThree == pitTwoLocation)
                        Console.WriteLine("You smell a dank odor.");

                    if (currentRoom.AdjacentRoomOne == spiderOneLocation || currentRoom.AdjacentRoomTwo == spiderOneLocation || currentRoom.AdjacentRoomThree == spiderOneLocation || currentRoom.AdjacentRoomOne == spiderTwoLocation || currentRoom.AdjacentRoomTwo == spiderTwoLocation || currentRoom.AdjacentRoomThree == spiderTwoLocation)
                        Console.WriteLine("You hear a faint clicking noise.");
                    
                    
                    

                            Console.WriteLine("Total Number of arrows left: {0}", arrows); 
                            Console.WriteLine("(M)ove or (S)hoot");
                            taskOption = Convert.ToChar(Console.ReadLine());
                            taskOption = Char.ToUpper(taskOption);
                         

                            switch (taskOption)
                            {
                                case 'S':
                                    {
                                        Console.WriteLine("Which Room?");
                                        optionTaskRoom = Console.ReadLine();
                                        if (optionTaskRoom == currentRoom.AdjacentRoomOne || optionTaskRoom == currentRoom.AdjacentRoomTwo || optionTaskRoom == currentRoom.AdjacentRoomThree)
                                        {

                                            if (optionTaskRoom == wumpusLocation)
                                            {
                                                Console.WriteLine("You shot Wumpus! \n **You Won!**");
                                                alive = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Your arrow goes down the tunnel and is Lost. You missed.");
                                                arrows--;
                                                goto optionSelect;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("DimWit! You cant shoot there from here. You Lost an Arrow");
                                            arrows--;
                                            goto optionSelect;
                                        }

                                        break;
                                    }

                                case 'M':
                                    {
                                        Console.WriteLine("Which Room?");
                                        optionTaskRoom = Console.ReadLine();
                                        if (optionTaskRoom == currentRoom.AdjacentRoomOne || optionTaskRoom == currentRoom.AdjacentRoomTwo || optionTaskRoom == currentRoom.AdjacentRoomThree)
                                        { 
                                           if (optionTaskRoom == wumpusLocation)
                                           {
                                               Console.WriteLine("You stepped on a Wumpus! \n\n **You Lost**");
                                               goto playAgain;

                                           }
                                           else if (optionTaskRoom == pitOneLocation || optionTaskRoom == pitTwoLocation)
                                           {
                                               Console.WriteLine("You fell in a Bottomless Pit! \n\n **You Lost**");
                                               goto playAgain;
                                           }
                                           else if (optionTaskRoom == spiderOneLocation || optionTaskRoom == spiderTwoLocation)
                                           {
                                               Console.WriteLine("You stepped in a room filled with spiders! \n\n **You Lost**");
                                               goto playAgain;
                                           }

                                            foreach(Room r in Caves)
                                            {
                                                if (r.RoomNumber == optionTaskRoom)
                                                {
                                                    currentRoom = r;
                                                    break;
                                                }
                                            }
                                        
                                        }
                                        else
                                        {
                                            Console.WriteLine("DimWit! You can't get to there form here.");
                                            goto optionSelect;
                                        }

                                        break;
                                    }

                                default:
                                    {
                                        Console.WriteLine("Invalid Choice!");
                                        goto optionSelect;

                                    }

                            }


                        }
                    

                   
                } while (alive == true);



            playAgain:
                {
                    Console.WriteLine("Play Again??  (Y/N)");
                    wannaPlayMore = Convert.ToChar(Console.ReadLine());
                    wannaPlayMore = Char.ToUpper(wannaPlayMore);
                }
            } while (wannaPlayMore == 'Y');


           Console.Clear();
           Console.WriteLine("Thanks for playing!");
              
           Console.ReadKey();

           
        }
    }
}
