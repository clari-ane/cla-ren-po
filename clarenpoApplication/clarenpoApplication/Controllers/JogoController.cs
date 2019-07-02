using clarenpoApplication.Models.DTOs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace clarenpoApplication.Controllers
{
    public class JogoController : Controller
    {
        // GET: Jogo
        public ActionResult Regras()
        {
            return View();
        }

        public ActionResult OJogo()
        {
            return View();
        }

        public ActionResult Torneio()
        {
            return View();
        }

        public JsonResult ExecutaJogo(string Jogadas, string N1, string N2)
        {
            Models.BLLs.Jogo bllJogo = new Models.BLLs.Jogo();
            Models.DTOs.RetornoJogada objRetorno = new RetornoJogada();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Jogada[] arrJoadasRealizadas = js.Deserialize<Jogada[]>(Jogadas);

            objRetorno = bllJogo.VerificaGanhador(arrJoadasRealizadas, N1, N2);

            return Json(objRetorno);
        }
    }
}