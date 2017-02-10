using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using HtmlAgilityPack;


namespace sberbank
{

  

    
    class Program
    {
       static public string Post() {
           String Ans="";
           List<long> list = new List<long>();
           string imms = Console.ReadLine();
           string[] INNs = imms.Split(' ');
           foreach (string arg in INNs)
               list.Add(Int64.Parse(arg));

          // Console.WriteLine(list[0].ToString());
           long INN = list[0];
            
            string url = "http://kad.arbitr.ru/Kad/SearchInstances";     
            
             WebRequest request = WebRequest.Create(url);
           //  long INN = 6679056597;
            request.Method = "POST";
            request.ContentType = "application/json";
            string postData = "{'Page':1,'Count':25,'Courts':[],'DateFrom':null,'DateTo':null,'Sides':[{'Name':"+INN+",'Type':-1,'ExactMatch':false}],'Judges':[],'CaseNumbers':[],'WithVKSInstances':false}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
           

            using (WebResponse response = request.GetResponse())
            {
                
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            Ans += line;
                            Console.WriteLine(line);
                        }
                    }
                }
                response.Close();
            }
            StreamWriter write_text;  //Класс для записи в файл
            FileInfo file = new FileInfo("t.txt");
            write_text = file.AppendText(); //Дописываем инфу в файл, если файла не существует он создастся
            write_text.Write(Ans); //Записываем в файл текст из текстового поля
            write_text.Close(); // Закрываем файл
           
            return Ans;

        }


      static void Pars(string ansewer) {
          HtmlDocument htmlSnippet = new HtmlDocument();
          htmlSnippet.LoadHtml(ansewer);

          List<string> hrefTags = new List<string>();

          foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//div"))
          {
              HtmlAttribute att = link.Attributes["class"];
              hrefTags.Add(att.Value);
          }
       }

      static void CreateXLS() {
            
      }
        static void Main(string[] args)
        {
            string Ans=Post();
           // Pars(Ans);

        }
    }
}
