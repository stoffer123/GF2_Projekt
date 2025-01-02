namespace GF2_Projekt.Opgave
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Test targetDirectory
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string targetDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\Opgave\UserDatabase\userDB.csv"));
            Console.WriteLine(targetDirectory);
            
            //Test userController
            UserController userController = new UserController();

            User user1 = new User("12345678", "Jens", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user2 = new User("12345678", "Lars", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user3 = new User("12345678", "Jens", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user4 = new User("12345678", "Lars", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user5 = new User("12345678", "Jens", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user6 = new User("12345678", "Lars", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user7 = new User("12345678", "Jens", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user8 = new User("12345678", "Lars", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user9 = new User("12345678", "Jens", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user10 = new User("12345678", "Lars", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user11 = new User("12345678", "Jens", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user12 = new User("12345678", "Lars", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user13 = new User("12345678", "Jens", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user14 = new User("12345678", "Lars", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user15 = new User("12345678", "Jens", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);
            User user16 = new User("12345678", "Lars", "Jensen", 12, "Lortevej2", "2230", "lorteBy", "Lorte@mail.dk", 4);

            User[] userArr = new User[] {user1, user2, user3, user4, user5, user6, user7, user8, user9, user10, user11, user12, user13, user14, user15, user16};

            userController.showAllUsers();

            Console.ReadKey();
        }
    }
}
