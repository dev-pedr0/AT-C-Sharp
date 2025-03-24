internal class Program
{
    public class Funcionario
    {
        protected string Nome;
        protected string Cargo;
        protected double SalarioBase;

        public Funcionario(string nome, string cargo, double salarioBase)
        {
            this.Nome = nome;
            this.Cargo = cargo;
            this.SalarioBase = salarioBase;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}.");
            Console.WriteLine($"Cargo: {Cargo}.");
            Console.WriteLine($"Salário Base: {SalarioBase}.");
        }
    }

    public class Gerente:Funcionario
    {
        public Gerente(string nome, string cargo, double salarioBase)
            : base(nome, cargo, salarioBase * 1.20)
        {
        }

    }

    private static void Main(string[] args)
    {
        Funcionario auxiliar = new("Carlos", "Auxiliar", 2000.00);
        Gerente gerente = new("José", "Gerente", 2000.00);

        auxiliar.ExibirInformacoes();
        Console.WriteLine("");
        gerente.ExibirInformacoes();
    }
}