internal class Program
{
    public class ContaBancaria
    {
        public string Titular;
        private decimal Saldo;

        public ContaBancaria(string Titular, decimal Saldo)
        {
            this.Titular = Titular;
            this.Saldo = Saldo;
        }

        public decimal Depositar(decimal valor)
        {
            if (valor < 0)
            {
                Console.WriteLine("\nO valor do depósito deve ser positivo!\n");
                return 0;
            }
            else
            {
                Saldo += valor;
                Console.WriteLine($"\nDepósito de R$ {valor} realizado com sucesso!\n");
                return Saldo;
            }
        }

        public decimal Sacar(decimal valor)
        {
            if (Saldo < valor)
            {
                Console.WriteLine($"\nTentativa de saque: R$ {valor}\n");
                Console.WriteLine("\nSaldo insuficiente para realizar o saque!\n");
                return 0;
            }
            else
            {
                Saldo -= valor;
                Console.WriteLine($"\nSaque de R$ {valor} realizado com sucesso!\n");
                return Saldo;
            }
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual: R$ {this.Saldo}");
        }
    }

    private static void Main(string[] args)
    {
        ContaBancaria contaTeste = new("Pedro", 500);

        Console.WriteLine($"Titular: {contaTeste.Titular}");
        //Console.WriteLine($"Titular: {contaTeste.Saldo}");

        contaTeste.Depositar(100);

        contaTeste.ExibirSaldo();

        contaTeste.Sacar(700);

        contaTeste.Sacar(200);

        contaTeste.ExibirSaldo();
    }
}