using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using webContato.Models;

namespace webContato.Controllers
{
    public class HomeController : Controller
    {
        public object HttpClient { get; private set; }

        public IActionResult Index()
        {
            string ApiBaseUrl = "https://localhost:44358/";
            string MetodoPath = "api/pessoa";

            var model = new Contato();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + MetodoPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                IList<Contato> lista = new List<Contato>();
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<List<Contato>>(streamReader.ReadToEnd());
                    return View(retorno);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult ContatoId(int Id)
        {
            string ApiBaseUrl = "https://localhost:44358/";
            string MetodoPath = $"api/pessoa/{Id}";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + MetodoPath);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "GET";
                IList<Contato> lista = new List<Contato>();
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<List<Contato>>(streamReader.ReadToEnd());
                    return View(retorno);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contato contatos)
        {
            try
            {
                string ApiBaseUrl = "https://localhost:44358/";
                string MetodoPath = $"api/pessoa";
                using (var pessoa = new HttpClient())
                {
                    pessoa.BaseAddress = new Uri(ApiBaseUrl);
                    var response = pessoa.PostAsync("api/pessoa", new StringContent(
                        new JavaScriptSerializer().Serialize(contatos), Encoding.UTF8, "application/json")).Result;
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}