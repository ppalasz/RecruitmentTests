using DiamondKata.Services.Interfaces;
namespace DiamondKata.Services
{
    public class DiamondService : IDiamondService
    {
        public void PrintDiamond(char inputChar)
        {
            inputChar = char.ToUpper(inputChar);
                        
            if (!char.IsLetter(inputChar) || inputChar < 'A' || inputChar > 'Z')
            {
                throw new ArgumentException($"'{inputChar}' is not a latin character");                
            }

            int n = inputChar - 'A';

            for (int i = -n; i <= n; i++)
            {
                int currentLine = n - Math.Abs(i);
                PrintSpaces(Math.Abs(i));
                Console.Write((char)('A' + currentLine));
                if (currentLine > 0)
                {
                    PrintSpaces(2 * currentLine - 1);
                    Console.Write((char)('A' + currentLine));
                }
                Console.WriteLine();
            }
        }

        private void PrintSpaces(int count)
        {
            Console.Write(new string(' ', count));
        }
    }
}