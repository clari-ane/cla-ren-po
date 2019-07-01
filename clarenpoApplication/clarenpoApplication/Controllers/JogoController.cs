using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}