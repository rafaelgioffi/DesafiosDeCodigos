using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Desafio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Fazer um programa em C para cadastro de alunos . Cada aluno deverá ser representado
             * por uma struct com os campos matrícula (int), n1, n2 e n3(notas) (float). 
             * O usuário deve poder cadastrar quantos usuários desejar, através de um 
             * menu (1 - cadastrar, 2 - listar 3 - sair). Ao sair, o programa deverá gravar 
             * os dados em um arquivo texto onde cada aluno ocupará uma linha. 
             * Ao abrir, caso o arquivo exista, o programa deverá preencher os dados previamente 
             * gravados e continuar funcionando como de costume.
            */

            List<Matricula> matricula = new List<Matricula>();
            int opcao;

            string arq = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\matricula.csv");

            void fillList(List<Matricula> list, string nomeArq)
            {
                matricula.Clear();
                StreamReader sr = new StreamReader(arq, Encoding.UTF8);
                do
                {
                    string linha = sr.ReadLine();
                    string[] dados = linha.Split(";");
                    int matArq = int.Parse(dados[0]);
                    float n1Arq = float.Parse(dados[1]);
                    float n2Arq = float.Parse(dados[2]);
                    float n3Arq = float.Parse(dados[3]);

                    Matricula m;
                    m = new Matricula(matArq, n1Arq, n2Arq, n3Arq);
                    matricula.Add(m);                    
                } while (!sr.EndOfStream);
                sr.Close();
                Console.WriteLine($"Alunos cadastrados: {matricula.Count()}\n");
            }

            if (File.Exists(arq))
            {
                fillList(matricula, arq);
            }
            
                do
                {
                    Console.WriteLine("1 - Cadastrar Aluno");
                    Console.WriteLine("2 - Listar Alunos");
                    Console.WriteLine("3 - Sair");
                    Console.Write("\nOpção: ");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            try
                            {
                                Console.Clear();
                                Console.Write("Informe a matricula (apenas números): ");
                                int mat = int.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.Write("Informe a primeira nota (Ex.: 9,5): ");
                                float n1 = float.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.Write("Informe a segunda nota (Ex.: 9,5): ");
                                float n2 = float.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.Write("Informe a terceira nota (Ex.: 9,5): ");
                                float n3 = float.Parse(Console.ReadLine());

                                Matricula m = new Matricula(mat, n1, n2, n3);
                                matricula.Add(m);

                                StreamWriter sw = new StreamWriter(arq, append: true);
                                sw.WriteLine($"{mat};{n1};{n2};{n3}");
                                sw.Close();
                                
                                fillList(matricula, arq);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\nFormato inválido!\nInforme apenas números inteiros para matricula e números decimais nas notas\n");
                            }
                            break;
                    case 2:
                        fillList(matricula, arq);
                        Console.Clear();
                        Console.WriteLine("\n*** Alunos cadastrados ***\n");
                        foreach(var m in matricula)
                        {                            
                            Console.WriteLine($"Matricula => {m.Mat}  |  Notas: N1 => {m.N1}  |  N2 => {m.N2}  |  N3 => {m.N3}");                            
                        }
                        Console.WriteLine();
                        break;
                    }
                } while (opcao != 3);
            

        }
    }
}