internal class Program
{
    public class Aluno
    {
        protected string nome;
        protected string matricula;
        protected string curso;
        protected double mediaNotas;

        public Aluno(string nome, string matricula, string curso, double mediaNotas)
        {
            this.nome = nome;
            this.matricula = matricula;
            this.curso = curso;
            this.mediaNotas = mediaNotas;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Nome do Aluno: {this.nome}.");
            Console.WriteLine($"Matrícula do Aluno: {this.matricula}.");
            Console.WriteLine($"Curso do Aluno: {this.curso}.");
            Console.WriteLine($"Média de notas do Aluno: {this.mediaNotas}.");
        }

        public string VerificarAprovacao()
        {
            if (this.mediaNotas >= 7)
            {
                return "Aprovado";
            }
            else
            {
                return "Reprovado";
            }
        }
    }
    private static void Main(string[] args)
    {
        Aluno alunoTeste = new("Pedro", "37596594734", "ADS", 9.6);
        
        alunoTeste.ExibirDados();

        string resultado = alunoTeste.VerificarAprovacao();
        Console.WriteLine( resultado );
    }
}