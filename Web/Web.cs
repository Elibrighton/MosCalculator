using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebInterface;

namespace Web
{
    public class Web : IWeb
    {
        private const int AllowedAttempts = 3;

        public Stream Stream { get; set; }
        public string Response { get; set; }
        
        public void ConvertStringToStream(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Stream = new MemoryStream();
                var writer = new StreamWriter(Stream);
                writer.Write(text);
                writer.Flush();
                Stream.Position = 0;
            }
        }

        public void RequestUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Response = string.Empty;

                var attempts = 0;

                while (attempts <= AllowedAttempts)
                {
                    try
                    {
                        var request = WebRequest.Create(url);
                        request.Credentials = CredentialCache.DefaultCredentials;
                        var responseFromServer = request.GetResponse();
                        var dataStream = responseFromServer.GetResponseStream();
                        var reader = new StreamReader(dataStream);
                        Response = reader.ReadToEnd();
                        reader.Close();
                        responseFromServer.Close();
                        break;
                    }
                    catch (Exception)
                    {
                        attempts++;
                    }
                }
            }
        }
    }
}
