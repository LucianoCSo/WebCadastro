using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using webContato.Models;

namespace webContato.Controllers
{
    public class TelefoneController : Controller
    {
        public IActionResult Index()
        {
            string ApiBaseUrl = "https://localhost:44358/";
            string MetodoPath = "api/telefone";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + MetodoPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                IList<Telefones> lista = new List<Telefones>();
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var strimReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<List<Telefones>>(strimReader.ReadToEnd());
                    return View(retorno);
                }
                return View(null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}