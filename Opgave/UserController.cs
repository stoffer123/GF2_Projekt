using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GF2_Projekt.Opgave
{
    public class UserController
    {
        List<User> users;
        string baseDirectory;
        string userDatabasePath;

        public UserController()
        {
            users = loadUsers(); //load users and store the returned list as users
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory; //Sets baseDirectory to the full path of this application.
            /*
             * sets databasePath to be the UserDatabase folder. 
             * ..\ means to jump back one folder.
             * @ means verbatim string, meaning it reads it literally. /n for example does not create a new line.
             */
            userDatabasePath = Path.GetFullPath(baseDirectory, @"..\..\..\Opgave\UserDatabase\userDB.csv");
        }

        public void createUser()
        {
            throw new NotImplementedException();
        }

        public User findUser() 
        {
            throw new NotImplementedException();
        }

        public List<User> getUsers()
        {
            throw new NotImplementedException();
        }

        private void saveUser()
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
    }
}
