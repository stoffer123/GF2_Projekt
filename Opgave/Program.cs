namespace GF2_Projekt.Opgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string targetDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\Opgave\UserDatabase"));
            Console.WriteLine(targetDirectory);
            
            
            
            Console.ReadKey();
        }
    }
}
