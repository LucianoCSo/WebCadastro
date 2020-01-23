using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webCadastro.Models;

namespace webCadastro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string ApiBaseUrl = "https://localhost:44358/"; 
            string MetodoPath = "api/pessoa"; 

            var model = new Cadastro();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + MetodoPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                IList<Cadastro> lista = new List<Cadastro>();
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<List<Cadastro>>(streamReader.ReadToEnd());
                    return View(retorno);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return View(model);
        }
    }
}