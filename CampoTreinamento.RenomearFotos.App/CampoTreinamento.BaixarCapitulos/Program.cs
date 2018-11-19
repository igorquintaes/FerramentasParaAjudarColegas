using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CampoTreinamento.BaixarCapitulos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Este programa baixa um capítulo do site tapas.io na pasta em execução.");
            Console.WriteLine("Dê um CTRL + V aqui do link referente ao capítulo que você quer baixar,");
            Console.WriteLine("Após isso pressione ENTER.");

            var link = Console.ReadLine();

            try
            {
                var web = new HtmlWeb();
                var document = web.Load(link);

                var pageNodes = document.DocumentNode.SelectNodes("//*[@class='art-image']");
                var count = 0;
                foreach(var node in pageNodes)
                {
                    count++;

                    var imageLink = node.GetAttributeValue("src", null);
                    if (imageLink == null)
                    {
                        Console.WriteLine("Erro ao baixar página " + count);
                        continue;
                    }

                    var extension = imageLink.Split('.').Last();
                    var fileName = count + "." + extension;
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(imageLink, fileName);
                    }

                    Console.WriteLine("Página " + count + " baixada!");
                }


                Console.WriteLine("ACABOOOU!! :)");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro durante o processo.");
                Console.WriteLine("Para mais informações, mostre este LOG para quem desenvolveu a aplicação:");
                Console.WriteLine("");
                Console.WriteLine(e);
                Console.WriteLine("");
            }

            Console.WriteLine("Pressione qualquer tecla para finalizar!");
            Console.ReadKey();
        }
    }
}
