
namespace GF2_Projekt.Opgave
{
    public class UserController
    {
        List<User> users;
        string baseDirectory;
        string userDatabasePath;
        string adminPassword;

        public UserController()
        {
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory; //Sets baseDirectory to the full path of this application.
            /*
             * sets databasePath to be the UserDatabase folder. 
             * ..\ means to jump back one folder.
             * @ means verbatim string, meaning it reads it literally. /n for example does not create a new line.
             */
            userDatabasePath = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\Opgave\UserDatabase\userDB.csv"));
            users = loadUsers(); //load users and store the returned list as users
            adminPassword = "admin";
        }

        public void createUser()
        {
            //Read phonenumber and check if a user with that number already exist.
            string phoneNumber = getInput("Indtast dit telefonnummer: > ");
            bool phoneNumberExists = false;

            foreach (User user in users)
            {
                if (phoneNumber == user.phoneNumber)
                {
                    phoneNumberExists = true;
                }
            }

            //If phoneNumber does not exist on any user, start the creation and ask for the rest of the data.
            if (!phoneNumberExists)
            {
                string firstName = getInput("Indtast dit fornavn: > ");
                string lastName = getInput("Indtast dit efternavn: > ");
                int age = getValidatedInt("Indtast din alder: > ");
                string address = getInput("Indtast din adresse(vej og nummer): > ");
                string zipCode = getInput("Indtast postnummer: > ");
                string city = getInput("Indtast by: > ");
                string email = getInput("Indtast email: > ");

                //Provide an array of acceptable options for the getValidatedInt method.
                int newsLetterFrequency = getValidatedInt("Hvor mange gange ønsker du nyhedsbrevet, årligt?(1,4,12): > ", new[] {1, 4, 12});


                //Instantiate the user and add it to the user list.
                User user = new User(phoneNumber, firstName, lastName, age, address, zipCode, city, email, newsLetterFrequency);
                users.Add(user);
                saveUsers();
                Console.WriteLine($"{firstName} {lastName} er blevet tilmeldt nyhedsbrevet!");
            }
            else //Else tell the user that the number already exists
            {
                Console.WriteLine($"En bruger findes allerede med telefonnummer: {phoneNumber}");
            }



        }

        public void findUser() 
        {
            //Login
            string input = getInput("Indtast admin password: > ");

            if(input.Equals(adminPassword)) //If authorized do this shit
            {
                //prompt for phonenumber to search
                string numberToSearch = getInput("Søg efter telefonnummer: > ");
                List<User> matchingUsers = new List<User>();

                foreach(User user in users)
                {
                    if(user.phoneNumber.Equals(numberToSearch))
                    {
                        matchingUsers.Add(user);
                    }
                }

                User[] userArr = matchingUsers.ToArray(); //Array to feed into printUsers

                printUsers(userArr); //Print the matching users.


            }else //if not authorized do this
            {
                Console.WriteLine("Det indtaste password er forkert! Du har ikke tilladelse til at søge.");
            }



        }

        public void printUsers(User[] userArray)
        {
            int maxUserLines = 12;
            int startIndex = 0;

            while (startIndex < userArray.Length)
            {
                for(int i = startIndex; i < startIndex + maxUserLines && i < userArray.Length; i++)
                {
                    User user = userArray[i];
                    Console.WriteLine($"{user.phoneNumber} - {user.firstName} - {user.lastName} - {user.age} - {user.address} - {user.zipCode} - {user.city} - {user.email} - {user.newsLetterFrequency}");
                }

                startIndex += maxUserLines;

                if(startIndex < userArray.Length) //If there is more users to display do this stuff
                {
                    Console.WriteLine("Tryk på en vilkårlig tast for at se næste side...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            //When there is no more users to display the while loop while exit and end here:
            Console.WriteLine("Sidste side, tryk på en vilkårlig tast...");
            

        }

        public void showAllUsers()
        {
            //Login
            string input = getInput("Indtast admin password: > ");

            if(input.Equals(adminPassword))
            {
                User[] userArray = users.ToArray(); //Array of users
                printUsers(userArray);
            }
            else
            {
                Console.WriteLine("Forkert password, du har ikke tilladelse til at se alle brugere!");
            }
        }
        private void saveUsers()
        {
            string[] csvUsers = new string[users.Count];

            //fyld arrayet med Users i csv format
            int counter = 0;
            foreach (User user in users)
            {
                csvUsers[counter] = $"{user.phoneNumber},{user.firstName},{user.lastName},{user.age},{user.address},{user.zipCode},{user.city},{user.email},{user.newsLetterFrequency}";
                counter++;
            }
            //Overskriv csv fil.
            try
            {
                File.WriteAllLines(userDatabasePath, csvUsers);
            }
            catch (Exception e)
            {
                //Catch evt problemer med at skrive til filen, for eksempel at filen er åben i et andet program.
                Console.WriteLine($"Error saving users to .csv with message: {e}");
            }
        }

        private List<User> loadUsers()
        {
            List<User> tempUsers = new List<User>(); //Create local users list in this method.

            //If the file exists load the data into tempUsers else create a new .csv file and tell the user no DB was found.
            if (File.Exists(userDatabasePath))
            {
                string[] lines = File.ReadAllLines(userDatabasePath, System.Text.Encoding.UTF8); //Read all lines of the csv into string array.

                //Loop through the line array and instantiate new users to the tempUsers list.

                foreach(string line in lines)
                {
                    string[] splitArr = line.Split(','); //Split each line at ',' and store in array.

                    //Create a user with the values from the split array
                    User user = new User(
                        splitArr[0], //phoneNumber
                        splitArr[1], //firstName
                        splitArr[2], //lastName
                        Convert.ToInt32(splitArr[3]), //age converted from string to int
                        splitArr[4], //address
                        splitArr[5], //zipCode
                        splitArr[6], //city
                        splitArr[7], //email
                        Convert.ToInt32(splitArr[8])); //newsletterFrequency, .csv stores strings so we convert it to an int.

                    tempUsers.Add(user); //Add the instantiated user to the tempUsers List.

                }
            }
            else
            {
                //Tell the user what path was searched and that a new file is being created.
                Console.WriteLine($"No database was found at path: {userDatabasePath} \n creating a new .csv file");
            }

            //A List should be returned no matter what, so we return outside of the if/else.
            //The if/else block only decides what is in the list we return.
            return tempUsers;
            
        }

        public double getAverageAge()
        {
            //List for the ages
            List<int> userAges = new List<int>();
            
            //populate list
            foreach(User user in users)
            {
                userAges.Add(user.age);
            }

            //Return average of values in userAges.
            return userAges.Average();
        }

        // Reusable method for string input
        private string getInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().Trim(); //Trim whitespaces of input and return it.
        }

        // Method to validate integer input
        private int getValidatedInt(string prompt, int[] validValues = null) //Int array with default value of null.
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
                    if (validValues == null || validValues.Contains(value)) //if no validValues array was provided OR value is a valid value
                    { 
                        isValid = true;
                    }else
                    {
                        //string.join concatenates all members of the array(second parameter) seperated by the first parameter,in this case ","
                        Console.WriteLine($"Ugyldig indtastning, gyldige værdier: {string.Join(", ", validValues)}");
                    }
                }
                else
                {
                    Console.WriteLine("Ugyldig indtastning! Indtast en integer værdi");
                }
            } while (!isValid);

            return value;
        }
    }
}
