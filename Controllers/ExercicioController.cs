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
    public class ExercicioController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var lExercicio = new List<Exercicio>();
            var response = await HttpGeneric.Get(APIUrl.Url() + "Exercicio/ListarTodos");
            if (response.Code == 200)
            {
                lExercicio = JsonConvert.DeserializeObject<List<Exercicio>>(response.Result.ToString());
            }

            return View(lExercicio);
        }
        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            Exercicio Exercicio = new Exercicio();
            Exercicio.Tipos = new List<Tipo>();
            var response = await HttpGeneric.Post(APIUrl.Url() + "Tipo/BuscaDinamicaRigida", BuscaDinamica.Add(new List<BuscaDinamica>(), "Status", 1, true));
            if (response.Code == 200)
                Exercicio.Tipos = JsonConvert.DeserializeObject<List<Tipo>>(response.Result.ToString());

            return View(Exercicio);
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Exercicio Exercicio)
        {
            Exercicio.Status = 1;
            var response = await HttpGeneric.Post(APIUrl.Url() + "Exercicio/Criar", Exercicio);
            if (response.Code == 200)
            {
                TempData["Sucesso"] = response.Result;
                return RedirectToAction("Index", "Exercicio");
            }
            else
            {
                TempData["Erro"] = response.Result;
                return View(Exercicio);
            }
        }

        [HttpGet]
        public IActionResult Editar(int IDExercicio)
        {
            var Exercicio = BuscarExercicioPorId(IDExercicio).Result;
            return View(Exercicio);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Exercicio Exercicio)
        {
            var response = await HttpGeneric.Put(APIUrl.Url() + "Exercicio/Alterar", Exercicio);
            if (response.Code == 200)
            {
                TempData["Sucesso"] = response.Result;
                return RedirectToAction("Index", "Exercicio");
            }
            else
            {
                TempData["Erro"] = response.Result;
                return View(Exercicio);
            }
        }

        public async Task<IActionResult> AlterarSituacao(int IDExercicio)
        {
            var Exercicio = BuscarExercicioPorId(IDExercicio).Result;

            if (Exercicio != null)
            {
                if (Exercicio.Status == 1)
                    Exercicio.Status = 0;
                else
                    Exercicio.Status = 1;
                var response = await HttpGeneric.Put(APIUrl.Url() + "Exercicio/Alterar", Exercicio);
                if (response.Code == 200)
                {
                    if (Exercicio.Status == 1)
                        TempData["Sucesso"] = "Exercicio foi ativado com sucesso!";
                    else
                        TempData["Sucesso"] = "Exercicio foi desativado com sucesso!";

                    return RedirectToAction("Index", "Exercicio");
                }
                else
                {
                    TempData["Erro"] = response.Result;
                    return View(Exercicio);
                }
            }
            else
            {
                TempData["Erro"] = "Exercicio não encontrado para alteração!";
                return View(Exercicio);
            }
        }

        private async Task<Exercicio> BuscarExercicioPorId(int IDExercicio)
        {
            var Exercicio = new Exercicio();
            var response = await HttpGeneric.Post(APIUrl.Url() + "Exercicio/BuscaDinamicaRigida", BuscaDinamica.Add(new List<BuscaDinamica>(), "IDExercicio", IDExercicio, true));
            if (response.Code == 200)
            {
                List<Exercicio> lExercicio = JsonConvert.DeserializeObject<List<Exercicio>>(response.Result.ToString());
                Exercicio = lExercicio.First();
            }

            Exercicio.Tipos = new List<Tipo>();
            response = await HttpGeneric.Post(APIUrl.Url() + "Tipo/BuscaDinamicaRigida", BuscaDinamica.Add(new List<BuscaDinamica>(), "Status", 1, true));
            if (response.Code == 200)
                Exercicio.Tipos = JsonConvert.DeserializeObject<List<Tipo>>(response.Result.ToString());


            return Exercicio;
        }
    }
}