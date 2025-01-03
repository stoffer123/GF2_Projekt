using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GF2_Projekt.Opgave
{
    public class CustomerMenu
    {
        private bool isRunning;
        private UserController userController;
        private string[] menuOptions;
        public CustomerMenu(UserController userController) 
        {
            this.userController = userController;
            isRunning = true;
            menuOptions = new string[] {"Tilmeld nyhedsbrev", "find bruger", "Vis alle brugere", "Vis gennemsnits alder"};
        }

        public void run()
        {

            while(isRunning)
            {
                
                printLogo(); //Intro logo
                //Print menu
                Console.WriteLine("Velkommen til CMIS infostander");
                for(int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine($"[{i+1}] {menuOptions[i]}");
                }
                Console.WriteLine("[0] Luk systemet");

                switch(getIntInRange("Vælg: > ", 0, menuOptions.Length))
                {
                    case 0:
                        shutdown();
                        break;
                    case 1:
                        userController.createUser();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        userController.findUser();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        userController.showAllUsers();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine($"Gennemsnits alderen for de tilmeldte brugere er: {userController.getAverageAge():N2}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }


            }
        }

        public void printLogo()
        {
            string logo = "\r\n" +
                " ██████╗███╗   ███╗██╗███████╗\r\n" +
                "██╔════╝████╗ ████║██║██╔════╝\r\n" +
                "██║     ██╔████╔██║██║███████╗\r\n" +
                "██║     ██║╚██╔╝██║██║╚════██║\r\n" +
                "╚██████╗██║ ╚═╝ ██║██║███████║\r\n" +
                " ╚═════╝╚═╝     ╚═╝╚═╝╚══════╝\r\n";

            Console.WriteLine(logo);
        }

        public void shutdown()
        {
            isRunning = false;
            Console.WriteLine("Farveller");
            Console.ReadKey();
        }

        // Method to validate integer input between min and max
        private int getIntInRange(string prompt, int min, int max) 
        {
            //Local variables
            int value;
            bool isValid = false;

            do
            {
                Console.Write(prompt); //Write the prompt
                string input = Console.ReadLine().Trim(); //Read the input, trimmed of whitespaces

                if (int.TryParse(input, out value)) //Try to parse the input as int into value, if success return true.
                {
                    if(value >= min &&  value <= max)
                    {
                        isValid = true;
                    }
                    else 
                    {
                        Console.WriteLine($"Please enter an integer between {min} and {max}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            } while (!isValid);

            return value;
        }
    }
}
