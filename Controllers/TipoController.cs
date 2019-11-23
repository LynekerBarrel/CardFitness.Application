using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardFitness.CrossCutting;
using CardFitness.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CardFitness.Controllers
{
    public class TipoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var lTipo = new List<Tipo>();
            var response = await HttpGeneric.Get(APIUrl.Url() + "Tipo/ListarTodos");
            if (response.Code == 200)
                lTipo = JsonConvert.DeserializeObject<List<Tipo>>(response.Result.ToString());

            return View(lTipo);
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Tipo Tipo)
        {
            Tipo.Status = 1;
            var response = await HttpGeneric.Post(APIUrl.Url() + "Tipo/Criar", Tipo);
            if (response.Code == 200)
            {
                TempData["Sucesso"] = response.Result;
                return RedirectToAction("Index", "Tipo");
            }
            else
            {
                TempData["Erro"] = response.Result;
                return View(Tipo);
            }
        }

        [HttpGet]
        public IActionResult Editar(int IDTipo)
        {
            var Tipo = BuscarTipoPorId(IDTipo).Result;
            return View(Tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Tipo Tipo)
        {
            var response = await HttpGeneric.Put(APIUrl.Url() + "Tipo/Alterar", Tipo);
            if (response.Code == 200)
            {
                TempData["Sucesso"] = response.Result;
                return RedirectToAction("Index", "Tipo");
            }
            else
            {
                TempData["Erro"] = response.Result;
                return View(Tipo);
            }
        }

        public async Task<IActionResult> AlterarSituacao(int IDTipo)
        {
            var Tipo = BuscarTipoPorId(IDTipo).Result;

            if (Tipo != null)
            {
                if (Tipo.Status == 1)
                    Tipo.Status = 0;
                else
                    Tipo.Status = 1;
                var response = await HttpGeneric.Put(APIUrl.Url() + "Tipo/Alterar", Tipo);
                if (response.Code == 200)
                {
                    if (Tipo.Status == 1)
                        TempData["Sucesso"] = "Tipo foi ativado com sucesso!";
                    else
                        TempData["Sucesso"] = "Tipo foi desativado com sucesso!";

                    return RedirectToAction("Index", "Tipo");
                }
                else
                {
                    TempData["Erro"] = response.Result;
                    return View(Tipo);
                }
            }
            else
            {
                TempData["Erro"] = "Tipo não encontrado para alteração!";
                return View(Tipo);
            }
        }

        private async Task<Tipo> BuscarTipoPorId(int IDTipo)
        {
            var Tipo = new Tipo();
            var response = await HttpGeneric.Post(APIUrl.Url() + "Tipo/BuscaDinamicaRigida", BuscaDinamica.Add(new List<BuscaDinamica>(), "IDTipo", IDTipo, true));
            if (response.Code == 200)
            {
                List<Tipo> lTipo = JsonConvert.DeserializeObject<List<Tipo>>(response.Result.ToString());
                Tipo = lTipo.First();
            }

            return Tipo;
        }
    }
}