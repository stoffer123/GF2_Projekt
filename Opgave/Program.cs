namespace GF2_Projekt.Opgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            CustomerMenu customerMenu = new CustomerMenu(new UserController());
            customerMenu.run();
        }
    }
}
