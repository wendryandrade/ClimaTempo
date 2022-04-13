using ClimaTempoSimples.DAO;
using ClimaTempoSimples.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClimaTempoSimples.Controllers
{
    public class HomeController : Controller
    {
        private EFContext db = new EFContext();

        public ActionResult Index()
        {
            List<PrevisaoClima> previsaoMaisQuente = db.PrevisaoClima
                .Include(x => x.Cidade)
                .Where(x => DbFunctions.TruncateTime(x.DataPrevisao) == DateTime.Today)
                .OrderByDescending(x => x.TemperaturaMaxima)
                .Take(3)
                .ToList();

            List<PrevisaoClima> previsaoMaisFria = db.PrevisaoClima
                .Include(x => x.Cidade)
                .Where(x => DbFunctions.TruncateTime(x.DataPrevisao) == DateTime.Today)
                .OrderBy(x => x.TemperaturaMinima)
                .Take(3)
                .ToList();

            List<Cidade> cidades = db.Cidade.OrderBy(x => x.Nome).ToList();

            ViewBag.PrevisaoMaisQuente = previsaoMaisQuente;
            ViewBag.PrevisaoMaisFria = previsaoMaisFria;
            ViewBag.SelectCidades = new SelectList(cidades, "Id", "Nome");

            return View();
        }

        [HttpGet]
        public ActionResult CarregarPrevisoesDaSemana(int id)
        {
            DateTime dataInicio = DateTime.Today;
            DateTime dataFim = dataInicio.AddDays(7);
            List<PrevisaoClima> previsoes = db.PrevisaoClima
                .Include(x => x.Cidade)
                .Where(x => 
                    x.CidadeId == id &&
                    (DbFunctions.TruncateTime(x.DataPrevisao) >= dataInicio &&
                    DbFunctions.TruncateTime(x.DataPrevisao) <= dataFim)
                )
                .OrderBy(x => x.DataPrevisao)
                .ToList();

            return Json(new { data = previsoes },
                        JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}