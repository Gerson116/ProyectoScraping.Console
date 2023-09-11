
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;

namespace ProyectoScraping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //.... BUSCAR LAS ULTIMAS NOTICIAS DE LA POLICIA PUBLICADA POR LA POLICIA NACIONAL
            //.... DE LA REPUBLICA DOMINICANA.
            string urlBase = "https://www.policianacional.gob.do/noticias/";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument html = web.Load(url: urlBase);

            var nodoTituloNoticia = html.DocumentNode.CssSelect("[class='w-post-elm post_title usg_post_title_1 entry-title color_link_inherit']")
                .Select(x => x.InnerText).Distinct();
            var nodoTiempoDePublicacion = html.DocumentNode.CssSelect("[class='w-post-elm post_date usg_post_date_1 entry-date published']")
                .Select(x => x.InnerText).Distinct();
            var nodoDetalleNoticia = html.DocumentNode.CssSelect("[class='w-post-elm post_content usg_post_content_1']")
                .Select(x => x.InnerText).Distinct();

            string[] titularesDeLaNoticia = nodoTituloNoticia.ToArray();
            string[] tiempoDePublicacion = nodoTiempoDePublicacion.ToArray();
            string[] detalleDeLasNoticias = nodoDetalleNoticia.ToArray();

            Console.WriteLine("Noticias Policia Nacional Dominicana.");

            for (int i = 0; i < titularesDeLaNoticia.Count(); i++)
            {
                if (tiempoDePublicacion[i].Contains("Ayer") == false) 
                {
                    Console.WriteLine($"titular: {titularesDeLaNoticia[i]}");
                    Console.WriteLine($"{detalleDeLasNoticias[i]}");
                }
            }
        }
    }
}