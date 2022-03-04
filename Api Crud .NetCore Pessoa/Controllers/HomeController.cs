using Api_Crud_.NetCore_Pessoa.Contexto;
using Api_Crud_.NetCore_Pessoa.Dominio.Entidade;
using Api_Crud_.NetCore_Pessoa.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud_.NetCore_Pessoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly DataContexto _contexto;

        public HomeController(DataContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public JsonResult Index()
        {
            int tipoPessoa = -1;

            string filtro = HttpContext.Request.Query["pfj"].ToString();
            if (!string.IsNullOrEmpty(filtro))
            {
                tipoPessoa = Convert.ToInt16(filtro);
            }

            var pessoaModel = new PessoaModel(_contexto);
            var resultado = pessoaModel.Listar(tipoPessoa);

            return Json(resultado);
        }

        [HttpGet("{pessoaId}")]
        public JsonResult ListarPorId(int pessoaId)
        {
            var pessoaModel = new PessoaModel(_contexto);
            var resultado = pessoaModel.ListarPorId(pessoaId);

            return Json(resultado);
        }

        [HttpPost]
        public ActionResult Salvar(Pessoa dados)
        {
            var pessoaModel = new PessoaModel(_contexto);
            bool retorno = pessoaModel.Salvar(dados);

            return Ok(pessoaModel._objetoRetornoRequest);
        }

        [HttpDelete("{pessoaId}")]
        public ActionResult Excluir(int pessoaId)
        {
            var pessoaModel = new PessoaModel(_contexto);
            bool retorno = pessoaModel.Excluir(pessoaId);

            return Ok(pessoaModel._objetoRetornoRequest);
        }        
    }
}
