using System;
using System.IO;
using System.Linq;

namespace CampoTreinamento.RenomearFotos.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Este programa altera o nome de todos arquivos de uma determinada pasta");
            Console.WriteLine("deixando-os em ordem numérica, e opcionalmente com sufixos/prefixos.");
            Console.WriteLine("");
            Console.WriteLine("1) Assegure-se que as imagens não estejam abertas em outro aplicativo.");
            Console.WriteLine("3) Assegure-se que este programa esteja na pasta em que deseja renomear os arquivos.");
            Console.WriteLine("");
            Console.WriteLine("Estando tudo de acordo, pressione ENTER para prosseguir.");

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter);
            Console.Clear();

            Console.WriteLine("Muito bem! Você deseja que seu arquivo tenha algum PREFIXO?");
            Console.WriteLine("O que é um prefixo? Qualquer tipo de combinação de letras,");
            Console.WriteLine("números ou símbolos que virá ANTES da numeração a ser aplicada.");
            Console.WriteLine("");
            Console.WriteLine("Exemplos:");
            Console.WriteLine("Com prefixo 'minha_scan_'     Sem prefixo");
            Console.WriteLine("minha_scan_01.png             01.png");
            Console.WriteLine("minha_scan_02.png             02.png");
            Console.WriteLine("minha_scan_03.png             03.png");
            Console.WriteLine("");
            Console.WriteLine("Caso queira, escreva seu prefixo e pressione ENTER.");
            Console.WriteLine("Caso não, apenas pressione ENTER.");


            var prefixo = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Muito bem! Você deseja que seu arquivo tenha algum SUFIXO?");
            Console.WriteLine("O que é um sufixo? Qualquer tipo de combinação de letras,");
            Console.WriteLine("números ou símbolos que virá DEPOIS da numeração a ser aplicada.");
            Console.WriteLine("");
            Console.WriteLine("Exemplos:");
            Console.WriteLine("Com sufixo '_minha_scan'      Sem sufixo");
            Console.WriteLine("01_minha_scan.png             01.png");
            Console.WriteLine("02_minha_scan.png             02.png");
            Console.WriteLine("03_minha_scan.png             03.png");
            Console.WriteLine("");
            Console.WriteLine("Caso queira, escreva seu sufixo e pressione ENTER.");
            Console.WriteLine("Caso não, apenas pressione ENTER.");

            var sufixo = Console.ReadLine();
            Console.Clear();

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
                    File.Move(f.FullName, Path.Combine(dir, $"{prefixo}{numeroArquivo}{sufixo}{f.Extension}"));
                }

                Console.WriteLine("Processo finalizado com êxito. Pode fechar o programa.");
                Console.ReadKey();
            }
            catch (Exception e)
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
