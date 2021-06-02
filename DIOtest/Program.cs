using System.Linq;
using static System.Console;
namespace CShp_StringReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = ReadLine();
            WriteLine(texto.Reverse().ToArray());
        }
    }
}