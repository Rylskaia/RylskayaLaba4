using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Converter.Model;

namespace Converter.Repository
{
    internal class ValutConverterImpl : IValuteConverter
    {
        private static readonly string BaseUrl;

        static ValutConverterImpl()
        {
            BaseUrl = @"http://www.cbr.ru/scripts/XML_daily.asp";
        }

        public async Task<ValCurs> GetCurse()
        {
            
            return await GetCurse(null);
        }

        public async Task<ValCurs> GetCurse(DateTime? selectedDate)
        {
            var url = selectedDate == null ?
                BaseUrl : $"{BaseUrl}?date_req={selectedDate.Value:d}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse) await request.GetResponseAsync();
            using (var responseStream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(responseStream 
                                                           ?? throw new InvalidOperationException(),
                    Encoding.GetEncoding(1251)))
                {
                    var result = await streamReader.ReadToEndAsync();
                    var xmlSerializer = new XmlSerializer(typeof(ValCurs));
                    using (var textStream = new StringReader(result))
                    {
                        var valCurs = (ValCurs) xmlSerializer.Deserialize(textStream);
                        return valCurs;
                    }
                }
            }
        }
    }
}