using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace libwebsvcprod
{
    public class GoogleSuggester
    {
        private const string SUGGESTION_API_URL = "http://clients1.google.com/complete/search?hl=en&output=toolbar&q={0}";

        public GoogleSuggester()
        {
        }

        private static string GetURLSource(string url)
        {
            string data = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return data;
        }

        public string[] GetSuggestionsList(string keyword)
        {
            string source;
            string[] splitWord;
            List<string> sList;
            XmlTextReader reader;

            source = GetURLSource(String.Format(SUGGESTION_API_URL, keyword));

            // Parse XML
            reader = new XmlTextReader(new StringReader(source));
            sList = new List<string>();


            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "suggestion":
                            //splitWord = reader.GetAttribute("data").Split(' ');
                            sList.Add(reader.GetAttribute("data"));

                            /*
                            foreach (string s in splitWord)
                            {
                                sList.Add(s);
                            }*/
                            
                            break;
                        default:
                            break;
                    }
                }
            }

            return sList.ToArray();
        }
    }
}
