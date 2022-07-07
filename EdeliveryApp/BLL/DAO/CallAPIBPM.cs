using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Newtonsoft.Json;

namespace BLL.DAO
{
    public class CallAPIBPM
    {
        public void CallComplate(string key, string IDEdelivery, string ListSO)
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                //"%7B%22params%22%3A%7B%22status%22%3A%22" + key + "%22%2C%22data%22%3A%22" + IDEdelivery + "%22%2C%20%22listSO%22%3A%20%5B%22_%22%2C%22_%22%5D%7D%7D";

                //"2C%22_%22%"

                //string a =  $"%7B%22params%22%3A%7B%22status%22%3A%22" + key +"%22%2C%22data%22%3A%22"+ IDEdelivery +
                //    "%22%2C%20%22listSO%22%3A%20%5B%22"+"_%22%2C%22"+"_%22%2C%22"+"_%22%2C%22"+"_%22%2C%22"+"_%22%2C%22"+"_%22%2C%22"+"_%22%2C%22"+"_%22%5D%7D%7D";


                var client = new RestClient("https://192.168.100.110:9443/rest/bpm/wle/v1/service/73a1d777-d47d-40c2-bb85-205a0daac90b?action=start&params=%7B%22params%22%3A%7B%22status%22%3A%22" + key + "%22%2C%22data%22%3A%22" + IDEdelivery + "%22%2C%20%22listSO%22%3A%20%5B%22" + ListSO);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("ContentType", "application/json");
                request.AddHeader("access_token", "");
                request.AddHeader("Authorization", "Basic VGh1eU5URF9OSVM6MTIzNDU2");
                request.AddHeader("Cookie", "JSESSIONID=00000GBw7jfAF40oLhSA8Sef0ZT:1fcns00f1; LtpaToken2=XUj15ZCzHecVs/TXUwsEm7vUkXyqbr185Q7bYi6kuUXfR2gtVfQvOgDtAe7POdtvwhCkQex2e5OQee0eazL2GOgv6aGtj/poEi7MNMZDRZKvUnL/pEk6+U1+fEPs9g0P8DuiPmwVLwhRpnzUH7aV9WsURAG9mTmIi3obwM8lVUH6knBqxro4RSDovHTE706OomGXGTk69QMGZ8bkX57zmRfJu8RR80dAbwj/bbmUSn9aL0CTy3R4wbhWHgzO8c2NWBpP8Xv0EJQO2B7FU4JfThy/W+NotO4De/Kwz+MVjgosCKhpIhnywwU8kikV4E7YOeFgxk0QKeDPYLL/uFxOej53mvx3OfswDgF0Q6mKXYX+PwUZH77TH0+tImcdruCQmaHCmfVzfGVnu5RESfUAyumiOvenGDeJ1P27O12rUcBEhlDkbtnJvvkNNeHxyb4w7jPaGNQ9HF3sPYgCBjkEI4iwfbGHePtlUG+2wcJJ7crOfvecEegKjPD+WoUSMsu3xXVg35Aff5eIJqp/+K5ZSDy8gF1hbZZ63jOV+E+WNM72T/Y8LFaQ07gC15UHIQRsdxwW+qpZZvW36VYxP3NbSi+zPI0uPiWboTX3sgoov4QDQBvS0C4hQ1F5wAC+Jz8l8+igzs7/S0mAKwkJhW8hR3wNyW9F01GTkEmkGDtOatOejjBfp6sEZxDe0ZGDp4aL");
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

            }
            catch (Exception)
            {

            }

        }

        public string ListSOTOParams(List<string> SONumber)
        {

            string result = "";

            for (int i = 0; i < SONumber.Count(); i++)
            {
                if (i == SONumber.Count() - 1)
                {
                    result += SONumber[i] + "%22%5D%7D%7D";
                    return result;
                }
                result += SONumber[i] + "%22%2C%22";

            }
            return result;

        }

        //////API UAT
        public string CallComplateUsingParams(string key, string IDEdelivery, string keyVehical, List<string> SONumber)
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                A paramater = new A(key, IDEdelivery, keyVehical, SONumber);

                var a = JsonConvert.SerializeObject(paramater);

                var client = new RestClient("https://192.168.100.115:9443/rest/bpm/wle/v1/service/73a1d777-d47d-40c2-bb85-205a0daac90b?action=start&params=" + a.Replace("params1", "params"));

                client.Timeout = -1;

                var request = new RestRequest(Method.POST);
                request.AddHeader("ContentType", "application/json");
                request.AddHeader("access_token", "");
                request.AddHeader("Authorization", "Basic YnBtYWRtaW46VkFTMTIzIUA=");
                request.AddHeader("Cookie", "JSESSIONID=0000i2axqE_v_jDCQmd7akNzvqO:1fdc4o5an; LtpaToken2=5QB++Tx6GgvCYVV1cooc6z1NCyrdB1lWpr5KH3s0FEJsvV3iajEVQeeuETWfqZI5fKDtYzw2yILggoC5/7HzgsoylcrytJKO5oj7PTqrq5UrT2tAplTeJ4TYu+AMz4I9vjNrROC0vpF5SROVRlTdDyVj7mjJu/a8ig8J1GAcxaBNbUp0bitFhPcKChjt8WDmGy2kJ4Npaoio+QhWp7XL/wY3PH2U5Kmewi6cl269eFdGPQtSoNvJtlXpKR9LkW8e3TaI3K6p7nZ69hBKYhJnZe0sA5e913MP2uQrq5cIX6jIAc1jGI45Cp4ikP/LeA/YDrDmKkxSdBFx70lPBYxlh/Gfe2AYczqAMBhrk0kEhE/FDJO/PLHIYUS5FLOhV1fvIW+/h5+0XMK8Em08rYAyW6Dr9GSI3uOXG3544G2LPP/2dzuF0R+droZvsWlnTe/9tTrQc/rIdqOxu8Dar4x9mnz2XHkTwxbEbt83/sYx4aocPRdifPdR/bHV8eYm8xHap+DxEd4ovIY7uPDRA+uVXig/26EEol6LPwuweYqnsmMCW+NV2gk0b7cboLCfWGxI8XWAZfUzGMp5B27hoJQBMnGDX2az4wdsQjsBbP1fokkZEx2+vVqUJrXxXr76a5HZh+63y4eOZsTPGtC4qmyT3rRsb4TlhYTvF1TMZ2kRx2L4DF0l1MTbZpH2N7FdzY3M");

                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);


                IRestResponse response = client.Execute(request);
                
                return @"\nResponse Status: "+response.ResponseStatus.ToString() + "\n Status Code: " + response.StatusCode + "\nRespose Content: " + response.Content
                    + "\n ResponUri: " + response.ResponseUri;
                

            }
            catch (Exception)
            {
                return "";
            }

        }

        /////// <summary>
        ///// API TEST
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="IDEdelivery"></param>
        ///// <param name="keyVehical"></param>
        ///// <param name="SONumber"></param>
        //public void CallComplateUsingParams(string key, string IDEdelivery, string keyVehical, List<string> SONumber)
        //{
        //    try
        //    {
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

        //        A paramater = new A(key, IDEdelivery, keyVehical, SONumber);

        //        var a = JsonConvert.SerializeObject(paramater);

        //        var client = new RestClient("https://192.168.100.110:9443/rest/bpm/wle/v1/service/73a1d777-d47d-40c2-bb85-205a0daac90b?action=start&params=" + a.Replace("params1", "params"));

        //        client.Timeout = -1;

        //        var request = new RestRequest(Method.POST);
        //        request.AddHeader("ContentType", "application/json");
        //        request.AddHeader("access_token", "");

        //        request.AddHeader("Authorization", "Basic VGh1eU5URF9OSVM6MTIzNDU2");
        //        request.AddHeader("Cookie", "JSESSIONID=00007eXVmqGLAwSbZsJZ52Eu34y:1fcns00f1; LtpaToken2=/KIsWVHp3YP+NU4PfvBSeLPYDaEbgVv7oPUBqCZRN3sdSv7GcCyZZUUJ88shea2TAplHZV6EO4XasOLb6GoSgVSgBzSb7zmu5w72xMARn8yr8lhwz65fDUKgZzMjD8fVC1Q3WCAizbvxexAoVFZtoHJSdGEj+WTjmxjPaMVq6PfgouV+jnmwpbFjAxeNGWStr/v3q67QzmWkh49GXBH7fu3wDhajE2Zkx3/k09qTVMZKrvPZ4v0cceM2tYU18hvlpBaHVrzsj7VftG4upXWEMG12KW8R1ONcnnYrCReqLWAJQmjfgzrWM8akJ+6gFrSjVufJaFDkVxiPcxIaDf1EIzlpiLlIt1KCi0LwtQ/+K/ln4ykzmZwlXO/ylgxCgFONj2qRc3aQoW5gCVinCkXeS4TkC52nYUz1ufVNChv5uxT5lR0A99QNH1Lu+UESkzYSLNboxtYE07DTbAogZlFKSZGEJOLD8AD5gpqLdn3tDff/1KAtK6SxSZEZ8VlQ/E3sIJGrfRn8kQGpaIVdGyi5x1vnKaP56LFBoRttahI7FNzPlMpPINY4LvKp4sGUvKlHkqwq/uq89VeVOWSZALRO3EY/KOBw/3KA1ixuVNUNG1GKNc3i9s45BGwmWjrqnVVnnFiRiJyF0FccrBXCw7NWlaeqsgO4RKXjI0VZ3VIIBBTtj6lJxbHDNJzhP3lnyvo2");


        //        var body = @"";
        //        request.AddParameter("text/plain", body, ParameterType.RequestBody);

        //        IRestResponse response = client.Execute(request);

        //        Console.WriteLine(response.Content);

        //    }
        //    catch (Exception)
        //    {

        //    }

        //}
    }

    public class Paramater
    {
        public string status { get; set; }

        public string data { get; set; }

        public string idCar { get; set; }

        public List<string> listSO { get; set; }
    }

    public class A
    {
        public Paramater params1 { get; set; }

        public A(string status, string data, string vehicle, List<string> listSO)
        {
            params1 = new Paramater();
            params1.status = status;
            params1.data = data;
            params1.idCar = vehicle;
            params1.listSO = listSO;

        }
    }
}