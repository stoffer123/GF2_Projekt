
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
            users = loadUsers(); //load users and store the returned list as users
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory; //Sets baseDirectory to the full path of this application.
            /*
             * sets databasePath to be the UserDatabase folder. 
             * ..\ means to jump back one folder.
             * @ means verbatim string, meaning it reads it literally. /n for example does not create a new line.
             */
            userDatabasePath = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\Opgave\UserDatabase\userDB.csv"));
            adminPassword = "admin";
        }

        public void createUser()
        {
            //Read phonenumber and check if a user with that number already exist.
            string phoneNumber = getInput("Please enter your phonenumber: > ");
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
                string firstName = getInput("Please enter your first name: > ");
                string lastName = getInput("Please enter your last name: > ");
                int age = getValidatedInt("Please enter your age: > ");
                string address = getInput("Please enter your address (Street name and number): > ");
                string zipCode = getInput("Please enter your ZIP Code: > ");
                string city = getInput("Please enter your city: > ");
                string email = getInput("Please enter your email: > ");

                //Provide an array of acceptable options for the getValidatedInt method.
                int newsLetterFrequency = getValidatedInt("Please enter annual frequency of newsletter(1,4,12): > ", new[] {1, 4, 12});


                //Instantiate the user and add it to the user list.
                User user = new User(phoneNumber, firstName, lastName, age, address, zipCode, city, email, newsLetterFrequency);
                users.Add(user);
                saveUsers();
                Console.WriteLine("User with was created!");
            }
            else //Else tell the user that the number already exists
            {
                Console.WriteLine("PhoneNumber already exist");
            }



        }

        public void findUser() 
        {
            //Login
            string input = getInput("Please enter admin password: > ");

            if(input.Equals(adminPassword)) //If authorized do this shit
            {
                //prompt for phonenumber to search
                string numberToSearch = getInput("Enter the phonenumber you would like to search for: > ");
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
                Console.WriteLine("Wrong password, you are not authorized to Find user.");
            }



        }

        public List<User> getUsers()
        {
            throw new NotImplementedException();
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
                    Console.WriteLine($"{user.phoneNumber}{user.firstName},{user.lastName},{user.age},{user.address},{user.zipCode},{user.city},{user.email},{user.newsLetterFrequency}");
                }

                startIndex += maxUserLines;

                if(startIndex < userArray.Length) //If there is more users to display do this stuff
                {
                    Console.WriteLine("Press any key to see next page...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            //When there is no more users to display the while loop while exit and end here:
            Console.WriteLine("Last page, press any key to continue...");
            Console.ReadKey();

        }

        public void showAllUsers()
        {
            //Login
            string input = getInput("Please enter admin password: > ");

            if(input.Equals(adminPassword))
            {
                User[] userArray = users.ToArray(); //Array of users
                printUsers(userArray);
            }
            else
            {
                Console.WriteLine("Wrong password, you are not authorized to show all users.");
            }
        }
        private void saveUsers()
        {
            throw new NotImplementedException();
        }

        private List<User> loadUsers()
        {
            List<User> tempUsers = new List<User>(); //Create local users list in this method.

            //If the file exists load the data into tempUsers else create a new .csv file and tell the user no DB was found.
            if (File.Exists(userDatabasePath))
            {
                string[] lines = File.ReadAllLines(userDatabasePath); //Read all lines of the csv into string array.

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
            throw new NotImplementedException();
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
                        Console.WriteLine($"Invalid value. Allowed values: {string.Join(", ", validValues)}");
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
