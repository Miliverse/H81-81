using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace H81_81
{
    public class Program
    {
        //Start of Full Screen Things, unsure how it works
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        //End of Full Screen Things

        public static void Main()
        {
            //More Full Screen Things           
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.Title = "H81-81";
            Game.StartGame();
            Console.ReadLine();
            //Console.ReadKey(); //Obtains the next character or function key pressed by the user
            
        }

       

    }

    public class Game
    {

        // Storage of Choice Bools
        // public bool TalkToDave = false; Not entirely sure why this is here but I'll roll with it
        public static int CommunityContributionScore;




        //Establish typewriting effect
        static void Typewrite(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(60);
            }
        }

        static void TypewriteSlower(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(90);
            }
        }
        //Establish faster typewriting effect
        static void TypewriteFaster(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(30);

            }

        }

        static void TypewriteSkip(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(0);
            }
        }

        static void TypewriteEvenFaster(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(5);
            }
        }

        public class Profile
        {
            // Establish the 'characterProfile' list
            public static List<string> characterProfile = new List<string>(); // Initalise a new list
            
            // Citizen ID generation

                // Randomly generate the number parts of the Citizen ID
                static public Random rnd = new Random();
                static int FirstCitizenID = rnd.Next(0,999);
                static int ThirdCitizenID = rnd.Next(000, 65000);
                public static int CitizenIDStatus = 0; //= rnd.Next(0,3); Leftover bit of code from when the suffix was randomly generated

           
                // Convert those numbers to a string
                static string FirstCitizenIDString = FirstCitizenID.ToString();
                static string ThirdCitizenIDString = ThirdCitizenID.ToString();
                public static string CitizenIDStatusString = CitizenIDStatus.ToString();

                // Establish the Random Letter Generation
                public static string GenerateCoupon(int length, Random random)
                {
                    string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    StringBuilder result = new StringBuilder(length);
                    for (int i = 0; i < length; i++)
                    {
                        result.Append(characters[random.Next(characters.Length)]);
                    }
                    return result.ToString();
                }

                // Place the result in a string
                public static string SecondCitizenIDString = GenerateCoupon(4, rnd);

                // Concatenate them in a public string called "CitizenID" 
                public static string CitizenID = "000" + FirstCitizenIDString + "-" + SecondCitizenIDString + "-" + ThirdCitizenIDString + "-" + CitizenIDStatusString;
            
            //public static string CitizenID = CitizenIDInt.ToString();
        }


        public static void StartGame()
        {
            Console.ForegroundColor = ConsoleColor.White;
            MainMenu();           
            //Whiplash();
        }




        /* //Old introduction code that I wrote after pulling an all nighter. Will likely leave in but will remain cut
        public static void Introduction()
        {
            //Chapter 0: Game Introduction
            Console.Title = "CYBERNET OS 1.423 SHELL";
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine();
            //Typewrite("Chapter 0: Alpha\n");
            //Typewrite("1981. London, UK.\n");

            // PrintUsername(); <- Leftover code from testing username function
            Typewrite("'Start report. Subject Report 31-C.'\n");
            Typewrite("'Subject is stable. Inhibitory neuron functioning as normal. Neural oscillation occuring at slightly unusual frequency.'\n");
            Typewrite("'No immediate cause for concern.'\n'Will now place endoscope into hibernation mode.'\n");
            

            Console.ForegroundColor = ConsoleColor.Green;
            Typewrite("CYBERNET OS 1.423\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Typewrite("WARNING: UNKNOWN DEVICE CONNECTING TO NETWORK. PLEASE CONTACT YOUR SYSTEM ADMINISTRATOR IF YOU DO NOT RECOGNISE THIS DEVICE.\n");
            Console.ForegroundColor = ConsoleColor.White;
            Typewrite("'Oh not again. That's probably just John accidentally hitting 'Forget Device' again. Probably nothing to worry about.'\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Typewrite("INITIATING HIBERNATION MODE....\n");
            Typewrite("PRESS ANY KEY TO CONTINUE.\n");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Red;
            Typewrite("\nHIBERNATION MODE FAILED\nSYSTEM ERROR: 0x0000001E KMODE_EXCEPTION_NOT_HANDLED\n");

            Console.ForegroundColor = ConsoleColor.White;
            Typewrite("'The endoscope has just generated an error. Huh, that's odd. I've never seen that before. I'll initiate a reboot and see if it goes away.'\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Typewrite("\nINITIATING REBOOT....\nPRESS ANY KEY TO CONTINUE.\n");
            Console.ReadKey();
            Typewrite("\nTERMINATING ALL PROCESSES...\nSHUTDOWN COMPLETE.\nCYBERNET OS 1.423\nINITIATING STARTUP...");

            Console.ForegroundColor = ConsoleColor.Red;
            Typewrite("\nSTARTUP FAILED\nSYSTEM ERROR: 0x00000028 CORRUPT_ACCESS_TOKEN\nSYSTEM ERROR: 0x0000007B INACCESSIBLE_BOOT_DEVICE\nSYSTEM ERROR: 0x0000005F SECURITY_INITIALIZATION_FAILED\nSYSTEM ERROR: 0x00000066 CACHE_INITIALIZATION_FAILED\nSYSTEM ERROR: 0x0000009F DRIVER_POWER_STATE_FAILURE\nSYSTEM ERROR: 0x000000A2 MEMORY_IMAGE_CORRUPT\n");

            Console.ForegroundColor = ConsoleColor.White;
            Typewrite("'This is bad. Very very bad. The Cybernetic Endoscope's systems seem to be failing all at once. Could this be something to do with the unknown device?'\n'I didn't want to have to do this but if I just give it a little jolt her-'\n");
            Console.ForegroundColor = ConsoleColor.Red;
            TypewriteFaster("SYSTEM È̟̠͎̰̥̜̺̥̳̯ͥ̋̆ͬ̏ͯͬ̊̀ͤ͊͐̀̕R̴̡͖̫̩̹͇̲̘̜̪̘̻̼͍̞̱̻͙̯ͦ̓̆ͩ̈ͣͤ̃̾͆̓̂̊͂̎ͨ̾͊̐͡R̡̛̩̟̬͍̦̝̜̈́́ͣ̊ͣ͊͒̀ͧ̍̎ͥO̤͓̭̖̲̖͕͈͍͉̠̍͒̋ͭ̍ͫ̀ͩͣ̊̄ͤ̽́̚̚͡ͅR̴͍̣̮͎̘̬̩̼͓͓͔̥̟̪̳̜͇̿̂̐͛̑̉ͦ̀̀͝\n");
            Typewrite("PRESS ANY KEY TO INITIATE SYSTEM RESET.");
            Console.ReadKey();
            Typewrite("\nINITIATING SYSTEM RESET...");
            Thread.Sleep(3000);
            Console.Clear();


        }
        */

        public static void MainMenu()
        {
            Console.Title = "H81-81";
            Console.ForegroundColor = ConsoleColor.White;
            Typewrite("Welcome to H81-81.");
            Typewrite("\nA: Start New Game\nB: Load Existing Save[FEATURE CURRENTLY BROKEN]\nC: Exit Game");
            string MainMenuChoice = "";
            while (MainMenuChoice != "A" || MainMenuChoice != "B" || MainMenuChoice != "C" || MainMenuChoice != "Debug")
            {
                MainMenuChoice = Console.ReadLine();
                if (MainMenuChoice == "A")
                {
                    Typewrite("\nStarting new game...");
                    Thread.Sleep(3000);
                    Console.Clear();
                    CharacterCreation();

                }
                else if (MainMenuChoice == "B")
                {
                    Typewrite("\nWhat part of feature currently broken didn't you understand?");
                    Thread.Sleep(1500);
                    Console.Clear();
                    MainMenu();

                }
                else if (MainMenuChoice == "C")
                {
                    Typewrite("\nClosing game...\n");
                    Thread.Sleep(1500);
                    Environment.Exit(1);

                }
                else if (MainMenuChoice == "Debug")
                {
                    Typewrite("\nFeature yet to be implemented");
                    Thread.Sleep(1500);
                    Console.Clear();
                    MainMenu();

                }
                else
                    Typewrite("\nPlease input a valid choice.\n");

                /*
                if (MainMenuChoice == "A" || MainMenuChoice == "B" || MainMenuChoice == "Debug")
                    break;
                */

            }
        }


        public static void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "H81-81: Chapter 0";
            Typewrite("Chapter 0.");
            Typewrite("\n2029. London, UK");
            /*
            Random rnd = new Random();
            int CitizenIDInt = rnd.Next(65000000, 72000000);
            string CitizenID = CitizenIDInt.ToString();
            */
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            TypewriteSlower("\nHappy 18th birthday, Citizen " + Profile.CitizenID + ".\nYou have now automatically become part of the UK's Community Contribution System(CCS). \nWithin 24 hours you will be issued a CCID where you can routinely check on your points total.\nYou start out with 1000 points. You increase or decrease it by doing good or bad things. \nIncrease it by a certain amount and you'll recieve rewards such as discounts on utilities, easier access to loans, etc.\nLet it drop too low and you'll lose access to basic services such as healthcare, police help, water, gas, electricity, etc.\nHave an acceptable day Citizen " + Profile.CitizenID + ".\n");
            Console.ForegroundColor = ConsoleColor.White;
            Typewrite("\nThe message closes. You lock your phone and place it back in your pocket, intially unsure about how to respound to the news. \nSurely the CCS can't be that bad, can it?\nEverywhere you look, you see people spouting about how good the system is. \nGovernment-sponsored interviews with those who've 'benefitted' from the System. \nBillboards reminding you to 'Act Pleasant and reap the rewards!' with the faces of So-Called 'Happy Customers' plastered all over it.\nSometimes you have to wonder if they've succeeded because of the System or in spite of it.");
            Typewrite("\n\nHorror stories regarding it circulate around though. \nRumours of mysterious disappearences after sudden and rapid decline of points. People being denied emergency care if the CCS deems them 'unworthy'.");
            // Go over - Healthcare,  spelling
        }


        public static void CharacterCreation()
        {
            //Character Creation

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "H81-81: Character Creation";
            Profile.characterProfile.Clear(); // Clear the list in case of a restart or whatever
            //List<string> characterProfile = new List<string>(); // Initalise a new list - this is an old list no longer used

            // Intro lore
            Typewrite("Welcome Citizen " + Profile.CitizenID + "\nLogging into your online profile now...\n");
            Thread.Sleep(3500);
            Console.ForegroundColor = ConsoleColor.Red;
            Typewrite("ERROR: Unable to access profile details. Data is corrupted.\nPlease re-confirm all of your details.\n\n");
            Console.ForegroundColor = ConsoleColor.Green;

            // Set Character Name
            Typewrite("Enter First Name: ");
            string characterFirstName = "";
            characterFirstName = Console.ReadLine();
            Profile.characterProfile.Add(characterFirstName); // Add characters name to the list
            Typewrite("First Name confirmed as " + Profile.characterProfile[0] + "."); // Print Character Name

            Typewrite("\nEnter Last Name: ");
            string characterLastName = "";
            characterLastName = Console.ReadLine();
            Profile.characterProfile.Add(characterLastName); // Add characters name to the list
            Typewrite("Last Name confirmed as " + Profile.characterProfile[1] + "."); // Print Character Name

            // Set Character Gender
            Typewrite("\nPlease confirm whether you are Male or Female: ");
            string characterGender = "";
            while (characterGender != "Male" || characterGender != "Female")
            {
                characterGender = Console.ReadLine();
                if (characterGender == "Male" || characterGender == "Female")
                {
                    Profile.characterProfile.Add(characterGender); // Add character gender to the list
                    Typewrite("Gender confirmed as " + Profile.characterProfile[2] + ".");
                    break;
                }
                else
                    Typewrite("\nPlease input a real gender. Please note that gender input is case sensitive. ");
               
            }

            // This whole section doesn't work for some reason - Fix Later
            // turns out i forgot to ask for the player to input the character hair
            // 10/10 programming
            // Set Character Hair Colour
            Typewrite("\nPlease confirm your hair colour out of the following options:\nBlack\nBlonde\nGinger\nBrown\n");
            string characterHair = "";
            while (characterHair != "Black" || characterHair != "Blonde" || characterHair != "Ginger" || characterHair != "Brown")
            {
                characterHair = Console.ReadLine();
                if (characterHair == "Black" || characterHair == "Blonde" || characterHair == "Ginger" || characterHair == "Brown")
                {
                    Profile.characterProfile.Add(characterHair);
                    Typewrite("Hair Colour confirmed as " + Profile.characterProfile[3] + ".\n");
                    break;
                }
                else
                    Typewrite("Please input a valid hair colour.\n");
            }

            Typewrite("Please confirm your eye colour out of the following options:\nBrown\nBlue\nHazel\nAmber\nGreen\n");
            string characterEyes = "";
            while (characterEyes != "Brown" || characterEyes != "Blue" || characterEyes != "Hazel" || characterEyes != "Amber" || characterEyes != "Green")
            {
                characterEyes = Console.ReadLine();
                if (characterEyes == "Brown" || characterEyes == "Blue" || characterEyes == "Hazel" || characterEyes == "Amber" || characterEyes == "Green")
                {
                    Profile.characterProfile.Add(characterEyes);
                    Typewrite("Eye Colour confirmed as " + Profile.characterProfile[4] + ".\n");
                    break;
                }
                else
                    Typewrite("Please input a valid eye colour.");    
            } 
            Typewrite("\nPrinting complete profile...");
            Typewrite("\nFull Name: " + Profile.characterProfile[0] + " " + Profile.characterProfile[1] + ".");
            Typewrite("\nGender: " + Profile.characterProfile[2] + ".");
            Typewrite("\nHair Colour: " + Profile.characterProfile[3] + ".");
            Typewrite("\nEye Colour: " + Profile.characterProfile[4] + ".");
            Typewrite("\nAre these correct?(Y or N)\n");
            string profileConfirmation = "";
            while (profileConfirmation != "Y" || profileConfirmation != "N")
            {
                profileConfirmation = Console.ReadLine();
                if (profileConfirmation == "Y")
                {
                    Typewrite("\nConfirming...");
                    //Typewrite("\nYou have come to the end of the early alpha build. Thanks for playtesting! ^_^");
                    //Environment.Exit(1);
                    break;
                }
                else if (profileConfirmation == "N")
                {
                    Typewrite("\nRestarting profile creation...\n");
                    Thread.Sleep(2000);
                    Console.Clear();
                    CharacterCreation();
                }
                else
                    Typewrite("Invalid input - Please try again.\n");
            }                    
            Thread.Sleep(3000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Introduction();

        }

        /*
        public static void Whiplash()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "H81-81: Chapter 1";
            //Chapter 1: 

            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "H81-81: Chapter 1";
            Console.ForegroundColor = ConsoleColor.White;

            Typewrite("CRASH! You slam the desk in anger.\n'What the HELL was that?' you think to yourself?.\nThe game you bought today ago keeps crashing during the introduction!\nYou've been troubleshooting for several hours and nothing's working.\n");
            Typewrite("Once you've calmed down, you notice that it's pitch black outside. \nIt's quiet enough you can hear the animals outside. 'Screw this, it's time for bed.'\nYou collapse into bed and fall asleep almost instantly.\n");
            // CharacterCreation();
            Console.Title = "H81-81: Chapter 1";
            //An alarm clock sound effect should ideally play here but I genuinely cannot be bothered to implement that right now. Maybe later
            Typewrite("\nYou're awoken by the sound of your alarm going off.\nYou reluctantly force yourself out of bed and into the bathroom to begin getting ready.");
            Console.ForegroundColor = ConsoleColor.White;
            if (Game.Profile.characterProfile[1] == "Male")
            {
                Typewrite("\nYou open the cabinet and take out a razor to start shaving.\nAfter that you brush your teeth, get dressed and leave for uni.");
                
            }
            else if (Game.Profile.characterProfile[1] == "Female")
            {
                Typewrite("\nYou do your morning skincare routine and then brush your teeth. You go back to your wardrobe, stick on the first clothes you see and bolt out the door for uni."); // To fix
                // Apparently skincare routine? Dunno really
            }

        }
        */

        public static void PrintUsername()
        {
            String Username = Environment.UserName;
            Typewrite(Username + " \n");
        }     
    }
}
