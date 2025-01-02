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

            userController.showAllUsers();

            Console.ReadKey();
        }
    }
}
