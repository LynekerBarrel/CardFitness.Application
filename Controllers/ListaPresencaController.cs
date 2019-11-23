using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdmSimposio.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using jsreport.AspNetCore;
using jsreport.Types;
using CardFitness.CrossCutting;

namespace AdmSimposio.Controllers
{
    public class ListaPresencaController : Controller
    {
        //public IActionResult MenuPrincipal(string Ambiente)
        //{
        //    bool Ativo = false;
        //    var simposio = Session.Get<Simposio>("AdmSimposio/SimposioAtivo");
        //    if (simposio != null)
        //    {
        //        Ativo = true;
        //        ViewBag.SimposioAtivo = simposio.TituloReduzido;
        //    }
        //    ViewBag.ProfileUser = Session.Get<PessoaModelo>("AdmSimposio/Pessoa").Pessoa.Nome;
        //    var lista = MenuItem.ListarMenu(Ambiente, Ativo);
        //    return PartialView("MenuPrincipal", lista);
        //}
        //public IActionResult Index(string Ambiente, int? CodListaPresenca)
        //{
        //    var simposio = Session.Get<Simposio>("AdmSimposio/SimposioAtivo");
        //    if (simposio == null || simposio != null && simposio.CodSimposio == null)
        //    {
        //        TempData["Aviso"] = "Não há simpósio ativo! Você foi redirecionado para página inicial.";
        //        return RedirectToAction("Index", "Home");
        //    }
        //    if (CodListaPresenca != null && CodListaPresenca > 0)
        //        TempData["CodListaPresenca"] = (int)CodListaPresenca;

        //    TempData["Ambiente"] = Ambiente;
        //    return View();
        //}

        //public async Task<IActionResult> LoadConfigurar()
        //{

        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompleta", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodSimposio", Session.Get<Simposio>("AdmSimposio/SimposioAtivo").CodSimposio, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else if (response.Code == 404)
        //        ListaPresenca = new List<ListaPresenca>();
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar as listas de presenças, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });


        //    return PartialView("PConfigurar", ListaPresenca);
        //}
        //public IActionResult LoadCriarLista()
        //{
        //    return PartialView("PCriarLista", new ListaPresenca());
        //}
        //public async Task<IActionResult> CriarLista(ListaPresenca ListaPresenca)
        //{
        //    ListaPresenca.CodSimposio = (int)Session.Get<Simposio>("AdmSimposio/SimposioAtivo").CodSimposio;
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/Criar", ListaPresenca);
        //    if (response.Code == 200)
        //    {
        //        TempData["Sucesso"] = response.Result;
        //        return Json(new { erro = false });
        //    }
        //    else
        //    {
        //        TempData["Erro"] = response.Result;
        //        return Json(new { erro = false });
        //    }
        //}
        //public async Task<IActionResult> LoadEditarLista(int CodListaPresenca)
        //{
        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompleta", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodListaPresenca", CodListaPresenca, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista escolhida, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });

        //    return PartialView("PEditarLista", ListaPresenca.First());
        //}
        //public async Task<IActionResult> EditarLista(ListaPresenca ListaPresenca)
        //{
        //    var response = await HttpGeneric.Put(APIUrl.Url() + "ListaPresenca/Alterar", ListaPresenca);
        //    if (response.Code == 200)
        //    {
        //        TempData["Sucesso"] = response.Result;
        //        return Json(new { erro = false });
        //    }
        //    else
        //    {
        //        TempData["Erro"] = response.Result;
        //        return Json(new { erro = false });
        //    }
        //}

        //public async Task<IActionResult> LoadImprimirLista(int CodListaPresenca)
        //{
        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompletaAutores", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodListaPresenca", CodListaPresenca, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else if (response.Code == 404)
        //        ListaPresenca = new List<ListaPresenca>();
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista de presença, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });

        //    ListaPresenca.First().ListaPresencaTrabalhos = ListaPresenca.First().ListaPresencaTrabalhos.OrderBy(x => x.Trabalho.CodSimposioTematico).ThenBy(x => x.Trabalho.Titulo).ToList();
        //    ListaPresenca.First().ListaPresencaSimposioTematicos = ListaPresenca.First().ListaPresencaSimposioTematicos.OrderBy(x => x.CodSimposioTematico).ToList();

        //    return PartialView("RListaPresenca", ListaPresenca.First());
        //}
        //[MiddlewareFilter(typeof(JsReportPipeline))]
        //public async Task<IActionResult> ImprimirLista(int CodListaPresenca)
        //{
        //    HttpContext.JsReportFeature()
        //        .Recipe(Recipe.ChromePdf)
        //        .Configure((r) => r.Template.Chrome = new Chrome { Landscape = true, MarginTop = "20", MarginBottom = "20", Format = "A4"}); ;


        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompletaAutores", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodListaPresenca", CodListaPresenca, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else if (response.Code == 404)
        //        ListaPresenca = new List<ListaPresenca>();
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista de presença, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });

        //    ListaPresenca.First().ListaPresencaTrabalhos = ListaPresenca.First().ListaPresencaTrabalhos.OrderBy(x => x.Trabalho.CodSimposioTematico).ThenBy(x => x.Trabalho.Titulo).ToList();
        //    ListaPresenca.First().ListaPresencaSimposioTematicos = ListaPresenca.First().ListaPresencaSimposioTematicos.OrderBy(x => x.CodSimposioTematico).ToList();

        //    return View("RListaPresenca", ListaPresenca.First());
        //}

        //[MiddlewareFilter(typeof(JsReportPipeline))]
        //public async Task<IActionResult> ImprimirListaOuvinte(int CodListaPresenca)
        //{
        //    HttpContext.JsReportFeature()
        //        .Recipe(Recipe.ChromePdf)
        //        .Configure((r) => r.Template.Chrome = new Chrome { Landscape = false, MarginTop = "20", MarginBottom = "20", Format = "A4" }); ;


        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompletaAutores", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodListaPresenca", CodListaPresenca, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else if (response.Code == 404)
        //        ListaPresenca = new List<ListaPresenca>();
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista de presença, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });

        //    ListaPresenca.First().ListaPresencaTrabalhos = ListaPresenca.First().ListaPresencaTrabalhos.OrderBy(x => x.Trabalho.CodSimposioTematico).ThenBy(x => x.Trabalho.Titulo).ToList();
        //    ListaPresenca.First().ListaPresencaSimposioTematicos = ListaPresenca.First().ListaPresencaSimposioTematicos.OrderBy(x => x.CodSimposioTematico).ToList();

        //    return View("RListaPresencaOuvinte", ListaPresenca.First());
        //}

        //public async Task<IActionResult> LoadAdicionarTrabalho()
        //{
        //    int CodListaPresenca = 0;
        //    if (TempData["CodListaPresenca"] != null)
        //        CodListaPresenca = (int)TempData["CodListaPresenca"];
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista escolhida, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });


        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompleta", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodListaPresenca", CodListaPresenca, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista escolhida, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });


        //    List<Trabalho> lTrabalhos = new List<Trabalho>();
        //    response = await HttpGeneric.Post(APIUrl.Url() + "Trabalho/BuscaDinamicaRigidaCompletaAutorListaPresenca", BuscaDinamica.AddList(BuscaDinamica.Add("Trabalho.CodSituacaoTrabalho", "2", true),
        //            BuscaDinamica.Add("InscricaoSimposio.CodSimposio", Session.Get<Simposio>("AdmSimposio/SimposioAtivo").CodSimposio, true)));

        //    if (response.Code == 200)
        //        ListaPresenca.First().Trabalhos = JsonConvert.DeserializeObject<List<Trabalho>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista de trabalhos, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });

        //    return PartialView("PAdicionarTrabalho", ListaPresenca.First());
        //}
        //public async Task<IActionResult> AdicionarNaLista(int CodTrabalho, int CodListaPresenca)
        //{

        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompleta", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodListaPresenca", CodListaPresenca, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista escolhida, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });


        //    List<Trabalho> lTrabalhos = new List<Trabalho>();
        //    response = await HttpGeneric.Post(APIUrl.Url() + "Trabalho/BuscaDinamicaRigidaCompletaAutor", BuscaDinamica.Add(new List<BuscaDinamica>(), "Trabalho.CodTrabalho", CodTrabalho, true));

        //    if (response.Code == 200)
        //        ListaPresenca.First().Trabalhos = JsonConvert.DeserializeObject<List<Trabalho>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar o trabalho, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });

        //    ListaPresenca.First().CodTrabalho = CodTrabalho;
        //    ListaPresenca.First().CodSimposioTematico = (int)ListaPresenca.First().Trabalhos.First().CodSimposioTematico;


        //    ListaPresencaTrabalho listaPresencaTrabalho = new ListaPresencaTrabalho()
        //    {
        //        CodListaPresenca = ListaPresenca.First().CodListaPresenca,
        //        CodTrabalho = ListaPresenca.First().CodTrabalho
        //    };
        //    ListaPresencaSimposioTematico listaPresencaSimposioTematico = new ListaPresencaSimposioTematico()
        //    {
        //        CodListaPresenca = ListaPresenca.First().CodListaPresenca,
        //        CodSimposioTematico = ListaPresenca.First().CodSimposioTematico
        //    };

        //    response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/Vincular_Auxiliares", new { listaPresencaTrabalho, listaPresencaSimposioTematico });
        //    if (response.Code == 200)
        //    {
        //        TempData["Sucesso"] = response.Result;
        //        return Json(new { erro = false });
        //    }
        //    else
        //    {
        //        TempData["Erro"] = response.Result;
        //        return Json(new { erro = false });
        //    }
        //}
        //public async Task<IActionResult> AdicionarNaListaEmLote(int CodListaPresenca, string[] CodTrabalho)
        //{
        //    if (CodTrabalho.Length == 0 || CodTrabalho == null)
        //        return Json(new { erro = true, message = "Selecione pelo menos um trabalho para ser adicionado." });

        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompleta", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodListaPresenca", CodListaPresenca, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista escolhida, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });


        //    List<Trabalho> lTrabalhos = new List<Trabalho>();
        //    var buscaDinamica = new List<BuscaDinamica>();
        //    foreach (var item in CodTrabalho)
        //    {
        //        buscaDinamica = BuscaDinamica.Add(buscaDinamica, "Trabalho.CodTrabalho", item, true);
        //    }
        //    response = await HttpGeneric.Post(APIUrl.Url() + "Trabalho/BuscaDinamicaFlexivel", buscaDinamica);
        //    if (response.Code == 200)
        //        lTrabalhos = JsonConvert.DeserializeObject<List<Trabalho>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar o trabalho, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });

        //    List<ListaPresencaTrabalho> listaPresencaTrabalho = new List<ListaPresencaTrabalho>();
        //    foreach (var item in lTrabalhos)
        //    {
        //        listaPresencaTrabalho.Add(new ListaPresencaTrabalho()
        //        {
        //            CodListaPresenca = CodListaPresenca,
        //            CodTrabalho = item.CodTrabalho
        //        });
        //    }

        //    List<ListaPresencaSimposioTematico> listaPresencaSimposioTematico = new List<ListaPresencaSimposioTematico>();
        //    List<int> STs = lTrabalhos.Select(x => (int)x.CodSimposioTematico).Distinct().ToList();

        //    foreach (var item in STs)
        //    {
        //        listaPresencaSimposioTematico.Add(new ListaPresencaSimposioTematico()
        //        {
        //            CodListaPresenca = CodListaPresenca,
        //            CodSimposioTematico = item
        //        });
        //    }


        //    response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/VincularLote_Auxiliares", new { listaPresencaTrabalho, listaPresencaSimposioTematico });
        //    if (response.Code == 200)
        //    {
        //        TempData["Sucesso"] = response.Result;
        //        return Json(new { erro = false });
        //    }
        //    else
        //    {
        //        TempData["Erro"] = response.Result;
        //        return Json(new { erro = false });
        //    }
        //}
        //public async Task<IActionResult> RemoverDaLista(int CodTrabalho, int CodListaPresenca)
        //{
        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompleta", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodListaPresenca", CodListaPresenca, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista escolhida, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });


        //    List<Trabalho> lTrabalhos = new List<Trabalho>();
        //    response = await HttpGeneric.Post(APIUrl.Url() + "Trabalho/BuscaDinamicaRigidaCompletaAutor", BuscaDinamica.Add(new List<BuscaDinamica>(), "Trabalho.CodTrabalho", CodTrabalho, true));

        //    if (response.Code == 200)
        //        ListaPresenca.First().Trabalhos = JsonConvert.DeserializeObject<List<Trabalho>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar o trabalho, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });

        //    ListaPresenca.First().CodTrabalho = CodTrabalho;
        //    ListaPresenca.First().CodSimposioTematico = (int)ListaPresenca.First().Trabalhos.First().CodSimposioTematico;


        //    ListaPresencaTrabalho listaPresencaTrabalho = new ListaPresencaTrabalho()
        //    {
        //        CodListaPresenca = ListaPresenca.First().CodListaPresenca,
        //        CodTrabalho = ListaPresenca.First().CodTrabalho
        //    };
        //    ListaPresencaSimposioTematico listaPresencaSimposioTematico = new ListaPresencaSimposioTematico()
        //    {
        //        CodListaPresenca = ListaPresenca.First().CodListaPresenca,
        //        CodSimposioTematico = ListaPresenca.First().CodSimposioTematico
        //    };

        //    response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/RemoverVinculo_Auxiliares", new { listaPresencaTrabalho, listaPresencaSimposioTematico });
        //    if (response.Code == 200)
        //    {
        //        TempData["Sucesso"] = response.Result;
        //        return Json(new { erro = false });
        //    }
        //    else
        //    {
        //        TempData["Erro"] = response.Result;
        //        return Json(new { erro = false });
        //    }

        //}

        //public async Task<IActionResult> LoadAdicionarTrabalhoRemover()
        //{
        //    int CodListaPresenca = 0;
        //    if (TempData["CodListaPresenca"] != null)
        //        CodListaPresenca = (int)TempData["CodListaPresenca"];
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista escolhida, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });


        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompleta", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodListaPresenca", CodListaPresenca, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista escolhida, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });


        //    ListaPresenca.First().Trabalhos = new List<Trabalho>();
        //    response = await HttpGeneric.Post(APIUrl.Url() + "Trabalho/BuscaDinamicaRigidaCompletaAutorListaPresenca", BuscaDinamica.AddList(BuscaDinamica.Add("Trabalho.CodSituacaoTrabalho", "2", true),
        //            BuscaDinamica.Add("InscricaoSimposio.CodSimposio", Session.Get<Simposio>("AdmSimposio/SimposioAtivo").CodSimposio, true),
        //            BuscaDinamica.Add("ListaPresencaTrabalho.CodListaPresenca", CodListaPresenca, true)));

        //    if (response.Code == 200)
        //        ListaPresenca.First().Trabalhos = JsonConvert.DeserializeObject<List<Trabalho>>(response.Result.ToString());
            
        //    return PartialView("PRemoverTrabalho", ListaPresenca.First());
        //}
        //public async Task<IActionResult> RemoverDaListaEmLote(int CodListaPresenca, string[] CodTrabalho)
        //{
        //    if (CodTrabalho.Length == 0 || CodTrabalho == null)
        //        return Json(new { erro = true, message = "Selecione pelo menos um trabalho para ser adicionado." });

        //    var ListaPresenca = new List<ListaPresenca>();
        //    var response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/BuscaDinamicaRigidaCompleta", BuscaDinamica.Add(new List<BuscaDinamica>(), "CodListaPresenca", CodListaPresenca, true));
        //    if (response.Code == 200)
        //        ListaPresenca = JsonConvert.DeserializeObject<List<ListaPresenca>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar a lista escolhida, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });


        //    List<Trabalho> lTrabalhos = new List<Trabalho>();
        //    var buscaDinamica = new List<BuscaDinamica>();
        //    foreach (var item in CodTrabalho)
        //    {
        //        buscaDinamica = BuscaDinamica.Add(buscaDinamica, "Trabalho.CodTrabalho", item, true);
        //    }
        //    response = await HttpGeneric.Post(APIUrl.Url() + "Trabalho/BuscaDinamicaFlexivel", buscaDinamica);
        //    if (response.Code == 200)
        //        lTrabalhos = JsonConvert.DeserializeObject<List<Trabalho>>(response.Result.ToString());
        //    else
        //        return Json(new { erro = true, message = "Ocorreu erro no momento de buscar o trabalho, atualize a página e tente novamente. Caso permanecer o problema, entre em contato com o suporte." });

        //    List<ListaPresencaTrabalho> listaPresencaTrabalho = new List<ListaPresencaTrabalho>();
        //    foreach (var item in lTrabalhos)
        //    {
        //        listaPresencaTrabalho.Add(new ListaPresencaTrabalho()
        //        {
        //            CodListaPresenca = CodListaPresenca,
        //            CodTrabalho = item.CodTrabalho
        //        });
        //    }

        //    List<ListaPresencaSimposioTematico> listaPresencaSimposioTematico = new List<ListaPresencaSimposioTematico>();
        //    List<int> STs = lTrabalhos.Select(x => (int)x.CodSimposioTematico).Distinct().ToList();

        //    foreach (var item in STs)
        //    {
        //        listaPresencaSimposioTematico.Add(new ListaPresencaSimposioTematico()
        //        {
        //            CodListaPresenca = CodListaPresenca,
        //            CodSimposioTematico = item
        //        });
        //    }

        //    response = await HttpGeneric.Post(APIUrl.Url() + "ListaPresenca/RemoverVinculoLote_Auxiliares", new { listaPresencaTrabalho, listaPresencaSimposioTematico });
        //    if (response.Code == 200)
        //    {
        //        TempData["Sucesso"] = response.Result;
        //        return Json(new { erro = false });
        //    }
        //    else
        //    {
        //        TempData["Erro"] = response.Result;
        //        return Json(new { erro = false });
        //    }

        //}
    }
}