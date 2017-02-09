using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sberbank
{

  

    public struct Message
    {
        public string Guid { get; set; }
        public string Token { get; set; }
    }
    
    class Program
    {
        public void Post() {
            Message message = new Message { };
            string json = JsonConvert.SerializeObject(message);
            body = Encoding.UTF8.GetBytes(json);
            request = (HttpWebRequest)WebRequest.Create(url);ax

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = body.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
                stream.Close();
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                response.Close();
            }
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            string number  = Console.ReadLine();
            string [] INN = number.Split(' ');
            foreach (string arg in INN)
                list.Add(Int32.Parse(arg));
        }
    }
}
