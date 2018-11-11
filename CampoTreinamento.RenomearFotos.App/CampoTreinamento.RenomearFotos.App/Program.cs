using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CampoTreinamento.RenomearFotos.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Este programa pega todos os arquivos de uma pasta e, em ordem alfabética, os enumera.");
            Console.WriteLine("");
            Console.WriteLine("Assegure-se que as imagens não estejam abertas em outro aplicativo.");
            Console.WriteLine("Assegure-se que não existam arquivos na pasta que possam dar conflito na nova enumeração.");
            Console.WriteLine("Assegure-se que este programa esteja na pasta em que deseja reenumerar os aqruivos.");
            Console.WriteLine("Caso não esteja, feche o programa e mude seu diretório.");
            Console.WriteLine("Caso esteja, Aperte ENTER para prosseguir");

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter);

            Console.Clear();
            Console.WriteLine("Iniciando...");

            try
            {
                var dir = Directory.GetCurrentDirectory();
                var fnames = Directory.GetFiles(dir).Select(Path.GetFileName);

                var d = new DirectoryInfo(dir);
                var finfo = d.GetFiles().Where(x => x.Extension != ".exe");

                var i = 0;
                var zeroPadding = finfo.Count().ToString().Length;

                foreach (var f in finfo)
                {
                    i++;

                    var numeroArquivo = i.ToString().PadLeft(zeroPadding, '0');
                    Console.WriteLine($"Renomeando arquivo número: {i}");
                    File.Move(f.FullName, Path.Combine(dir, $"{numeroArquivo}{f.Extension}"));
                }

                Console.WriteLine("Processo finalizado com êxito. Pode fechar o programa.");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Ocorreu um erro durante o processo de renomear arquivos.");
                Console.WriteLine("Verifique se eles não estão abertos ou sendo usados por outros programas");
                Console.WriteLine("Para mais informações, mostre este LOG para quem desenvolveu a aplicação:");
                Console.WriteLine("");
                Console.WriteLine(e);
            }
        }
    }
}
