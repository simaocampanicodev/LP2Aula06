using System;
using System.IO;

namespace FileStreams
{
    public class Program
    {
        // Nomes dos ficheiros
        private const string filenameText = "dados.txt";
        private const string filenameBinary = "dados.bin";
        // Dados a escrever e ler nos ficheiros
        private const string dataString = "Hello world!";
        private const int dataInt = 18;
        private const float dataFloat = 3.1415f;

        private static void Main()
        {
            // String para onde ler opção inserida pelo utilizador
            string option;
            // Ciclo do menu principal
            do
            {
                // Apresentar menu principal
                Console.WriteLine("==== Que programa devo executar? ==== \n");
                Console.WriteLine("\t1. Escreve ficheiro em modo de texto");
                Console.WriteLine("\t2. Lê ficheiro em modo de texto");
                Console.WriteLine("\t3. Escreve ficheiro em modo binário");
                Console.WriteLine("\t4. Lê ficheiro em modo binário");
                Console.WriteLine("\t5. Sair");
                Console.Write("\n>");
                // Solicitar opção ao utilizador
                option = Console.ReadLine();
                // Tratar opção do utilizador
                switch (option)
                {
                    case "1":
                        EscreverTexto(); break;
                    case "2":
                        LerTexto(); break;
                    case "3":
                        EscreverBin(); break;
                    case "4":
                        LerBin(); break;
                    case "5":
                        Console.WriteLine("Obrigado e até à próxima!");
                        break;
                    default:
                        Console.WriteLine("**** Opção inválida! ****");
                        break;
                }
                Console.WriteLine(
                    "Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != "5");
        }

        // 1. Escreve ficheiro em modo de texto
        private static void EscreverTexto()
        {
            using (StreamWriter writer = File.CreateText(filenameText))
            {
                writer.WriteLine(dataString);
                writer.WriteLine(dataInt);
                writer.WriteLine(dataFloat);
            }
            Console.WriteLine($"Dados escritos em '{filenameText}' com sucesso!");
        }

        // 2. Lê ficheiro em modo de texto
        private static void LerTexto()
        {
            if (!File.Exists(filenameText))
            {
                Console.WriteLine($"Ficheiro '{filenameText}' não encontrado!");
                return;
            }

            using (StreamReader reader = File.OpenText(filenameText))
            {
                string dataString = reader.ReadLine();
                int dataInt = int.Parse(reader.ReadLine());
                float dataFloat = float.Parse(reader.ReadLine());

                Console.WriteLine($"String lida: {dataString}");
                Console.WriteLine($"Int lido: {dataInt}");
                Console.WriteLine($"Float lido: {dataFloat}");
            }
        }

        // 3. Escreve ficheiro em modo binário
        private static void EscreverBin()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(filenameBinary)))
            {
                writer.Write(dataString);
                writer.Write(dataInt);
                writer.Write(dataFloat);
            }
            Console.WriteLine($"Dados escritos em '{filenameBinary}' com sucesso!");
        }

        // 4. Lê ficheiro em modo binário
        private static void LerBin()
        {
            if (!File.Exists(filenameBinary))
            {
                Console.WriteLine($"Ficheiro '{filenameBinary}' não encontrado!");
                return;
            }

            using (BinaryReader reader = new BinaryReader(File.OpenRead(filenameBinary)))
            {
                string dataString = reader.ReadString();
                int dataInt = reader.ReadInt32();
                float dataFloat = reader.ReadSingle();

                Console.WriteLine($"String lida: {dataString}");
                Console.WriteLine($"Int lido: {dataInt}");
                Console.WriteLine($"Float lido: {dataFloat}");
            }
        }
    }
}