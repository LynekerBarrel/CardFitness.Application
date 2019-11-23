using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmSimposio.Models
{
    //public class Trabalho
    //{
    //    public int CodTrabalho { get; set; }
    //    public int CodInscricaoSimposio { get; set; }
    //    public int CodSimposio { get; set; }
    //    public int? CodSimposioTematico { get; set; }
    //    public List<SimposioTematico> SimposioTematicos { get; set; }
    //    public string TituloSimposioTematico { get; set; }
    //    public int? CodAvaliador { get; set; }
    //    public int CodSituacaoTrabalho { get; set; }
    //    public string DescSituacaoTrabalho { get; set; }
    //    public int CodModalidade { get; set; }
    //    public string DescModalidade { get; set; }
    //    public List<Modalidade> Modalidades { get; set; }
    //    public int? CodCurso { get; set; }
    //    public string DescCurso { get; set; }
    //    public List<Cursos> Cursos { get; set; }
    //    public int? CodFormacao { get; set; }
    //    public List<Formacao> Formacoes { get; set; }
    //    public int? CodInstituicaoEnsino { get; set; }
    //    public string DescInstituicaoEnsino { get; set; }
    //    public string OutrosInstituicaoEnsino { get; set; }
    //    public List<InstituicaoEnsino> InstituicaoEnsinos { get; set; }
    //    public string OutrosApoio { get; set; }
    //    public int? Periodo { get; set; }
    //    public string Titulo { get; set; }
    //    public string PalavraChave { get; set; }
    //    public string Introducao { get; set; }
    //    public string Objetivo { get; set; }
    //    public string Metodologia { get; set; }
    //    public string Resultado { get; set; }
    //    public string Conclusao { get; set; }
    //    public string NomeArquivoCompleto { get; set; }
    //    public IFormFile ArquivoCompleto { get; set; }
    //    public IFormFile ArquivoCompletoPersistir { get; set; }
    //    public string Discussao { get; set; }
    //    [DisplayName("Data Criação")]
    //    public DateTime DataCriacao { get; set; }
    //    public bool Excluido { get; set; }
    //    public DateTime? DataExclusao { get; set; }
    //    public List<AutorTrabalho> Autores { get; set; }
    //    public List<AutorTrabalho> AutoresModelo { get; set; }
    //    public string CPFCoautor { get; set; }
    //    public int? CodTipoTrabalhoAutor { get; set; }
    //    public string DescTipoTrabalhoAutor { get; set; }
    //    public List<TipoTrabalhoAutor> TipoTrabalhoAutores { get; set; }
    //    public byte? QtdMaxTrabalhos { get; set; }
    //    public byte? QtdMaxCoautores { get; set; }
    //    public List<Apoio> Apoios { get; set; }
    //    public string CodApoioJoined { get; set; }
    //    public int[] CodApoio { get; set; }
    //    public List<Bolsa> Bolsas { get; set; }
    //    public int[] CodBolsa { get; set; }
    //    public bool AlunoAtivo { get; set; }
    //    public int CodEtapa { get; set; }
    //    public string DescEtapa { get; set; }
    //    public DateTime DataInicioEtapa { get; set; }
    //    public string Historico { get; set; }
    //    public string Comentario { get; set; }


    //    public string TituloPersistir { get; set; }
    //    public string PalavraChavePersistir { get; set; }
    //    public string IntroducaoPersistir { get; set; }
    //    public string ObjetivoPersistir { get; set; }
    //    public string MetodologiaPersistir { get; set; }
    //    public string ResultadoPersistir { get; set; }
    //    public string ConclusaoPersistir { get; set; }
    //    public string NomeArquivoCompletoPersistir { get; set; }
    //    public string DiscussaoPersistir { get; set; }

    //    public int CodListaPresenca { get; set; }
    //    public string TituloListaPresenca { get; set; }
    //    public TimeSpan HoraApresentacao { get; set; }
    //}
    //public class TrabalhoAutor
    //{
    //    public int CodTrabalhoAutor { get; set; }
    //    public int CodTrabalho { get; set; }
    //    public int CodPessoa { get; set; }
    //    public int CodTipoTrabalhoAutor { get; set; }
    //}
    //public class TrabalhoApoio
    //{
    //    public int CodTrabahoApoio { get; set; }
    //    public int CodTrabalho { get; set; }
    //    public int CodApoio { get; set; }

    //}
    //public class TrabalhoBolsa
    //{
    //    public int CodTrabahoBolsa { get; set; }
    //    public int CodTrabalho { get; set; }
    //    public int CodBolsa { get; set; }

    //}
}
