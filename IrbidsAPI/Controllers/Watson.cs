using IrbidsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace IrbidsAPI.Controllers
{
    /// <summary>
    /// This is a class used to invoke Watson to recognize
    /// </summary>
    public class Watson
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly WebClient WebClient = new WebClient();
        /// <summary>
        /// Invoke the recognize web service.
        /// curl -s http://recordings.telapi.com/RBb8d28cfe1744448fab6d26b6f3b96708/RE777c3e3256ab2746b9284f26a62a40c7.mp3 | 
        ///  curl -X POST -u "apikey:RuS8YFAysX8SjxK__olfIPpRwQt288WRQ8zHsGNxpQu8" --header "Content-Type: audio/mp3" 
        ///  --data-binary @- "https://api.au-syd.speech-to-text.watson.cloud.ibm.com/instances/96029d60-608c-4d0c-a130-3b2213fd9cba/v1/recognize?model=es-CO_BroadbandModel"
        /// </summary>
        /// <param name="attempt"></param>
        /// <returns></returns>
        public async Task<float> RecognizeAsync(Attempt attempt)
        {
            byte[] data = WebClient.DownloadData(attempt.RecordedURL);
            string authString = Convert.ToBase64String(Encoding.UTF8.GetBytes("apikey:RuS8YFAysX8SjxK__olfIPpRwQt288WRQ8zHsGNxpQu8"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);
            
            ByteArrayContent content = new ByteArrayContent(data);
            content.Headers.ContentType = new MediaTypeHeaderValue("audio/mp3");
            HttpResponseMessage response = await client.PostAsync("https://api.au-syd.speech-to-text.watson.cloud.ibm.com/instances/96029d60-608c-4d0c-a130-3b2213fd9cba/v1/recognize?model=en-US_NarrowbandModel", content);
            response.EnsureSuccessStatusCode();
            String jsonString = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(jsonString);
            /*
             { 
                "results": [
                {
                    "alternatives": [
                    {
                        "confidence": 0.7,
                        "transcript": "I don't know what I'm saying "
                    }
                    ],
                    "final": true
               }
                ],
               "result_index": 0
            }*/
            
            JToken token = json.SelectToken("$.results[0].alternatives[0].confidence");
            if (token!=null && token.HasValues)
            {
                return token.Value<float>();
            } else
            {
                return 0;
            }
        }
        /*
        public static void Main(string[] args) {
            Watson Watson = new Watson();
            User u = new User();
            u.Id = 1;
            u.Ani = "1234";
            u.Score = 0;
            Word word = new Word();
            word.Id = 1447;
            word.TextEnglish = "Be careful";
            word.TextSpanish = "Ten cuidado";
            word.AudioURL = "http://dcgm6jfwtvdqr.cloudfront.net/instantspeak/english/phrases/slow/beCareful.mp3";
            word.Level = 1;
            word.Language = "Spanish";
            word.Area = 1;
            word.Number = 1;
            Attempt attempt = new Attempt();
            attempt.Id = 1;
            attempt.User = u;
            attempt.Word = word;
            attempt.Created = DateTime.Now;
            attempt.RecordedURL = "http://recordings.telapi.com/RBb8d28cfe1744448fab6d26b6f3b96708/RE777c3e3256ab2746b9284f26a62a40c7.mp3";
            attempt = Watson.RecognizeAsync(attempt).Result;
        }
        */

    }
}
