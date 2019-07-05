using Applicazioni.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Proxies.Temera
{
    public class TemeraTmr:IDisposable
    {
        public string GetToken(string user, string password, string url)
        {
            string method = @"topfinish-tmr-api/auth/login";
            string StatusDescription;
            Uri uri = new Uri(url + method);
            AuthenticationDto adto = new AuthenticationDto();
            adto.password = password;
            adto.username = user;
            string Json = JSonSerializer.Serialize<AuthenticationDto>(adto);
            object jsonObject = executeCall(uri, Json, out StatusDescription);
            string result = jsonObject as string;
            TokenDto o = JSonSerializer.Deserialize<TokenDto>(jsonObject as string);
            return o.value;
        }

        public string AssociazioneTelaio(string odl, string prodotto, string telaio, int qta, int stato, string url, string token)
        {
            string method = @"topfinish-tmr-api/custom/productionLot/createProductionLot";
            string StatusDescription;
            Uri uri = new Uri(url + method);
            AssociazioneTelaioDto adto = new AssociazioneTelaioDto();
            adto.odl = odl;
            adto.prodotto = prodotto;
            adto.telaio = telaio;
            adto.qty = qta;
            adto.stato = stato;
            string Json = JSonSerializer.Serialize<AssociazioneTelaioDto>(adto);
            object jsonObject = executeCall(uri, Json, token, out StatusDescription);
            string result = jsonObject as string;

            return result;
        }

        private object executeCall(Uri uri, string JSON, out string StatusDescription)
        {
            StatusDescription = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

            request.Method = "POST";
            request.ContentType = "application/json";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(JSON);

            request.ContentLength = bytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                // Send the data.
                requestStream.Write(bytes, 0, bytes.Length);
            }
            try
            {
                string jsonResult = String.Empty;
                string str = string.Empty;
                request.BeginGetResponse((x) =>
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(x))
                    {
                        str = response.StatusDescription;
                        Stream s = response.GetResponseStream();
                        StreamReader sr = new StreamReader(s);
                        jsonResult = sr.ReadToEnd();
                        sr.Close();
                    }
                }, null);
                StatusDescription = str;
                return jsonResult;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private object executeCall(Uri uri, string JSON, string token, out string StatusDescription)
        {
            StatusDescription = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

            request.Method = "POST";
            request.ContentType = "application/json";
            //            request.Headers["Authorization"] = "x-tmr-token: " + token;
            //            request.Headers["x-tmr-token"] = "token " + token;
            request.Headers["x-tmr-token"] = token;
            //```x-tmr-token: TOKEN```
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(JSON);

            request.ContentLength = bytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                // Send the data.
                requestStream.Write(bytes, 0, bytes.Length);
            }
            try
            {
                string jsonResult = String.Empty;
                string str = string.Empty;
                request.BeginGetResponse((x) =>
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(x))
                    {
                        str = response.StatusDescription;
                        Stream s = response.GetResponseStream();
                        StreamReader sr = new StreamReader(s);
                        jsonResult = sr.ReadToEnd();
                        sr.Close();
                    }
                }, null);
                StatusDescription = str;
                return jsonResult;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        void IDisposable.Dispose()
        {
            
        }
    }
}
