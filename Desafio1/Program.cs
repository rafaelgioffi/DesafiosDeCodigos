namespace Desafio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] matriz = new int[10, 10];
            Console.Write("Informe a posição que deseja calcular a média\nEx.: 5. Será calculado a média entre os vizinhos da posição [5,5]: ");
            int valor = int.Parse(Console.ReadLine());
            if (valor >= matriz.GetLength(0) - 1 || valor <= 0)
            {
                Console.WriteLine($"\nValor inválido!\nDigite um valor entre 1 e {matriz.GetLength(0) - 2}");
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        matriz[i, j] = rand.Next(1, 50);
                        Console.Write($"[{i},{j}]: {matriz[i,j]} ");
                    }
                    Console.WriteLine();
                }
                int linhaAnt = matriz[valor - 1, valor];
                int linhaProx = matriz[valor + 1, valor];
                int colAnt = matriz[valor, valor - 1];
                int colProx = matriz[valor, valor + 1];
                int media = (linhaAnt + linhaProx + colAnt + colProx) / 4;
                Console.WriteLine($"\n[{valor - 1},{valor}]: {linhaAnt}  |  [{valor + 1},{valor}]: {linhaProx} ");
                Console.WriteLine($"[{valor},{valor - 1}]: {colAnt}  |  [{valor},{valor + 1}]: {colProx}");
                Console.WriteLine($"Média: {media} ");
            }
        }
    }
}