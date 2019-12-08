using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardFitness.CrossCutting;
using CardFitness.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Controllers
{
    public class FichaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var Model = new List<FichaExercicio>();
            var response = await HttpGeneric.Get(APIUrl.Url() + "FilaFicha/ListarFila");
            if (response.Code == 200)
            {
                Model = JsonConvert.DeserializeObject<List<FichaExercicio>>(response.Result.ToString());
                Model = Model.OrderBy(x => x.Exercicio.Descricao).ToList();
            }
            return View(Model);
        }
        [HttpGet]
        public async Task<IActionResult> ControlarFicha()
        {
            var lFicha = new List<Ficha>();
            var response = await HttpGeneric.Get(APIUrl.Url() + "Ficha/ListarTodos");
            if (response.Code == 200)
            {
                lFicha = JsonConvert.DeserializeObject<List<Ficha>>(response.Result.ToString());
            }

            lFicha = lFicha.OrderBy(x => x.DiaSeq).ToList();
            return View(lFicha);
        }
        private static async Task<List<int>> PopularDiaSeq(int IDFicha = 0)
        {
            int[] sequenciaisPossiveis = new int[] { 1, 2, 3, 4, 5 };

            var lFicha = new List<Ficha>();
            var response = await HttpGeneric.Get(APIUrl.Url() + "Ficha/ListarTodos");
            if (response.Code == 200)
            {
                lFicha = JsonConvert.DeserializeObject<List<Ficha>>(response.Result.ToString());
            }

            return sequenciaisPossiveis.Except(lFicha.Where(x => x.IDFicha != IDFicha).Select(x => x.DiaSeq).ToList()).ToList();
        }

        [HttpGet]
        public IActionResult CadastrarFicha()
        {
            ViewBag.ListaDiaSeq = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(PopularDiaSeq().Result);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarFicha(Ficha Ficha)
        {
            Ficha.DataCriacao = DateTime.Now;
            Ficha.Status = 1;
            var response = await HttpGeneric.Post(APIUrl.Url() + "Ficha/Criar", Ficha);
            if (response.Code == 200)
            {
                TempData["Sucesso"] = response.Result;
                return RedirectToAction("ControlarFicha", "Ficha");
            }
            else
            {
                TempData["Erro"] = response.Result;
                return View(Ficha);
            }
        }

        [HttpGet]
        public IActionResult EditarFicha(int IDFicha)
        {
            var Ficha = BuscarFichaPorId(IDFicha).Result;
            ViewBag.ListaDiaSeq = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(PopularDiaSeq(IDFicha).Result);
            return View(Ficha);
        }
        [HttpPost]
        public async Task<IActionResult> EditarFicha(Ficha Ficha)
        {
            var response = await HttpGeneric.Put(APIUrl.Url() + "Ficha/Alterar", Ficha);
            if (response.Code == 200)
            {
                TempData["Sucesso"] = response.Result;
                return RedirectToAction("ControlarFicha", "Ficha");
            }
            else
            {
                TempData["Erro"] = response.Result;
                return View(Ficha);
            }
        }

        public async Task<IActionResult> AlterarSituacao(int IDFicha)
        {
            var Ficha = BuscarFichaPorId(IDFicha).Result;

            if (Ficha != null)
            {
                if (Ficha.Status == 1)
                    Ficha.Status = 0;
                else
                    Ficha.Status = 1;
                var response = await HttpGeneric.Put(APIUrl.Url() + "Ficha/Alterar", Ficha);
                if (response.Code == 200)
                {
                    if (Ficha.Status == 1)
                        TempData["Sucesso"] = "Ficha foi ativada com sucesso!";
                    else
                        TempData["Sucesso"] = "Ficha foi desativada com sucesso!";

                    return RedirectToAction("ControlarFicha", "Ficha");
                }
                else
                {
                    TempData["Erro"] = response.Result;
                    return View(Ficha);
                }
            }
            else
            {
                TempData["Erro"] = "Ficha não encontrado para alteração!";
                return View(Ficha);
            }
        }

        private async Task<Ficha> BuscarFichaPorId(int IDFicha)
        {
            var Ficha = new Ficha();
            var response = await HttpGeneric.Post(APIUrl.Url() + "Ficha/BuscaDinamicaRigida", BuscaDinamica.Add(new List<BuscaDinamica>(), "IDFicha", IDFicha, true));
            if (response.Code == 200)
            {
                List<Ficha> lFicha = JsonConvert.DeserializeObject<List<Ficha>>(response.Result.ToString());
                Ficha = lFicha.First();
            }

            return Ficha;
        }

        public async Task<IActionResult> FichaExercicio(int IDFicha)
        {
            var Model = new FichaExercicioVM();
            Model.Ficha = BuscarFichaPorId(IDFicha).Result;
            Model.FichaExercicio = new List<FichaExercicio>();

            var lModel = new List<Ficha>();
            var response = await HttpGeneric.Post(APIUrl.Url() + "FichaExercicio/BuscaDinamicaRigida", BuscaDinamica.Add(new List<BuscaDinamica>(), "IDFicha", IDFicha, true));
            if (response.Code == 200)
            {
                Model.FichaExercicio = JsonConvert.DeserializeObject<List<FichaExercicio>>(response.Result.ToString());
                Model.FichaExercicio = Model.FichaExercicio.OrderBy(x => x.Exercicio.Descricao).ToList();
            }
            Model.FichaExercicio = Model.FichaExercicio.OrderBy(x => x.Exercicio.Descricao).ToList();
            return View(Model);
        }

        [HttpGet]
        public async Task<IActionResult> VincularExercicio(int IDFicha)
        {
            var Model = new FichaExercicio();
            Model.Ficha = BuscarFichaPorId(IDFicha).Result;
            Model.IDFicha = Model.Ficha.IDFicha;
            Model.Exercicios = new List<Exercicio>();
            var response = await HttpGeneric.Get(APIUrl.Url() + "Exercicio/ListarTodos");
            if (response.Code == 200)
            {
                Model.Exercicios = JsonConvert.DeserializeObject<List<Exercicio>>(response.Result.ToString());
            }
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFichaExercicio(FichaExercicio FichaExercicio)
        {
            var response = await HttpGeneric.Post(APIUrl.Url() + "FichaExercicio/Criar", FichaExercicio);
            if (response.Code == 200)
            {
                TempData["Sucesso"] = response.Result;
                return RedirectToAction("FichaExercicio", "Ficha", new { IDFicha = FichaExercicio.IDFicha });
            }
            else
            {
                TempData["Erro"] = response.Result;
                return View(FichaExercicio);
            }
        }

        public async Task<IActionResult> DeletarFichaExercicio(int IDFichaExercicio)
        {
            var FichaExercicio = new FichaExercicio();
            var response = await HttpGeneric.Post(APIUrl.Url() + "FichaExercicio/BuscaDinamicaRigida", BuscaDinamica.Add(new List<BuscaDinamica>(), "IDFichaExercicio", IDFichaExercicio, true));
            if (response.Code == 200)
            {
                List<FichaExercicio> lFichaExercicio = JsonConvert.DeserializeObject<List<FichaExercicio>>(response.Result.ToString());
                FichaExercicio = lFichaExercicio.First();
            }

            response = await HttpGeneric.Delete(APIUrl.Url() + "FichaExercicio/Deletar?IDFichaExercicio=" + FichaExercicio.IDFichaExercicio);
            if (response.Code == 200)
            {
                TempData["Sucesso"] = "Ficha foi desativada com sucesso!";
                return RedirectToAction("FichaExercicio", "Ficha", new { IDFicha = FichaExercicio.IDFicha });
            }
            else
            {
                TempData["Erro"] = response.Result;
                return View(FichaExercicio);
            }
        }

        public async Task<IActionResult> Executado(int IDFicha)
        {
            var FilaFicha = new FilaFicha();
            var response = await HttpGeneric.Post(APIUrl.Url() + "FilaFicha/BuscaDinamicaRigida", BuscaDinamica.Add(new List<BuscaDinamica>(), "IDFicha", IDFicha, true));
            if (response.Code == 200)
            {
                List<FilaFicha> lFilaFicha = JsonConvert.DeserializeObject<List<FilaFicha>>(response.Result.ToString());
                FilaFicha = lFilaFicha.First();
            }

            response = await HttpGeneric.Post(APIUrl.Url() + "FilaFicha/Executado", FilaFicha);
            if (response.Code == 200)
            {
                TempData["Sucesso"] = response.Result;
                return RedirectToAction("Index", "Ficha");
            }
            else
            {
                TempData["Erro"] = response.Result;
                return View();
            }
        }
    }
}