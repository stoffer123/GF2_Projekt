namespace GF2_Projekt.Opgave
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Test userController
            UserController userController = new UserController();

            userController.showAllUsers();

            Console.ReadKey();
        }
    }
}
