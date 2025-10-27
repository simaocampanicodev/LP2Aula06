using System;
using System.IO;
using System.IO.Compression;

namespace Descompressor
{
    public class Program
    {
        // Ficheiro onde guardar dados
        private string ficheiro;

        // Programa começa aqui
        private static void Main(string[] args)
        {
            // Criar uma instância de Program para não estarmos sempre a usar
            // métodos de teste static
            Program p = new Program();

            // Executar o programa, embora preparado para tratar alguma
            // excepção que possa ocorrer
            try
            {
                // Executar programa
                p.Executar();
            }
            catch (Exception e)
            {
                // Pelos vistos aconteceu um problema, dizer qual
                Console.WriteLine($"Ocorreu o seguinte erro: {e}");
            }
            finally
            {
                // Dizer obrigado, quer tenha havido uma excepção ou não
                Console.WriteLine("Obrigado por ter utilizado este programa!");
            }
        }

        // Inicializa uma nova instância da classe Program
        private Program()
        {
            // Definir nome ("dados.txt.gz") e localização ("My Documents") do
            // ficheiro onde guardar os dados comprimidos
            ficheiro = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "dados.txt.gz");
        }

        // Este método começa a execução do programa de
        // compressão/descompressão
        private void Executar()
        {
            // String onde colocar resposta do utilizador
            string resposta;

            // Perguntar ao utilizador se quer comprimir ou descomprimir
            Console.Write("(C)omprimir ou (D)escomprimir? ");
            resposta = Console.ReadLine().ToLower();

            // Verificar resposta do utilizador
            switch (resposta)
            {
                // Comprimir
                case "c": Comprime(); break;
                // Descomprimir
                case "d": Descomprime(); break;
                // Resposta desconhecida, lançar excepção
                default:
                    throw new FormatException(
                        $"Resposta inválida '{resposta}', apenas 'c' ou 'd'");
            }
        }

        // Comprimir um texto para dentro de um ficheiro
        private void Comprime()
        {
            // Linhas de texto inseridas pelo utilizador
            string line;

            // Usar blocos using para garantir o fecho automático dos streams
            using (FileStream fs = new FileStream(
                ficheiro, FileMode.Create, FileAccess.Write))
            using (GZipStream gzs = new GZipStream(fs, CompressionLevel.Optimal))
            using (StreamWriter sw = new StreamWriter(gzs))
            {
                // Pedir ao utilizador para inserir várias linhas de texto que
                // serão guardadas no ficheiro comprimido
                Console.WriteLine("Insere várias linhas de texto "
                    + "(linha vazia termina inserção):");

                while ((line = Console.ReadLine()).Length > 0)
                {
                    sw.WriteLine(line);
                }
            } // Os streams são fechados automaticamente aqui
        }

        // Descomprimir texto no ficheiro e mostrar no ecrã
        private void Descomprime()
        {
            string line;

            // Verificar se o ficheiro existe
            if (!File.Exists(ficheiro))
            {
                throw new FileNotFoundException(
                    $"O ficheiro '{ficheiro}' não existe. Comprima dados primeiro.");
            }

            // Usar blocos using para garantir o fecho automático dos streams
            using (FileStream fs = new FileStream(
                ficheiro, FileMode.Open, FileAccess.Read))
            using (GZipStream gzs = new GZipStream(fs, CompressionMode.Decompress))
            using (StreamReader sr = new StreamReader(gzs))
            {
                Console.WriteLine("Conteúdo do ficheiro descomprimido:");
                Console.WriteLine("--------------------------------");

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("--------------------------------");
            } // Os streams são fechados automaticamente aqui
        }
    }
}