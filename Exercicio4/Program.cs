using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        DateTime today = DateTime.Today;
        int todayYear = today.Year;

        bool dateWrong = true;

        while (dateWrong)
        {
            Console.WriteLine("Digite a data do seu aniversário no formato dd/mm/yyyy");
            string entradaUsuario = Console.ReadLine();
            DateTime dateBirthday;

            if (DateTime.TryParseExact(entradaUsuario, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateBirthday))
            {
                Console.WriteLine($"\nVocê digitou a data: {dateBirthday.ToString("dd/MM/yyyy")}");

                DateTime nextBirthday = new DateTime(todayYear, dateBirthday.Month, dateBirthday.Day);

                TimeSpan difference = nextBirthday - today;

                if (difference.Days < 0)
                {
                    nextBirthday = new DateTime((todayYear + 1), dateBirthday.Month, dateBirthday.Day);
                    difference = nextBirthday - today;
                }

                if (difference.Days >= 7)
                {
                    Console.WriteLine($"\nFaltam {difference.Days} dias para seu aniversário");
                }
                else
                {
                    Console.WriteLine($"\nFaltam {difference.Days} dias para seu aniversário. Já já ta chegando!");
                }

                    dateWrong = false;
            }
            else
            {
                Console.WriteLine("\nFormato de data inválido. Tente Novamente.");
            }
        }
    }
}