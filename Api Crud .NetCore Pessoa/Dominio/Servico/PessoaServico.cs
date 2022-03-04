using Api_Crud_.NetCore_Pessoa.Contexto;
using Api_Crud_.NetCore_Pessoa.Dominio.Entidade;
using Api_Crud_.NetCore_Pessoa.Dominio.Entidade.Validacao.Dto;
using Api_Crud_.NetCore_Pessoa.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud_.NetCore_Pessoa.Dominio.Servico
{
    public class PessoaServico
    {
        public PessoaRepositorio _pessoaRepositorio;
        public DataContexto _contexto;
        public string _msgErro;
        public List<ErroEntidadeDto> _errosEntidade;

        public PessoaServico(DataContexto contexto)
        {            
            _contexto = contexto;
            _pessoaRepositorio = new PessoaRepositorio(_contexto);
        }

        public IEnumerable<Pessoa> Listar(int tipoPessoa)
        {
            return _pessoaRepositorio.Listar(tipoPessoa);
        }

        public Pessoa ListarPorId(int Id)
        {
            return _pessoaRepositorio.ListarPorId(Id);
        }

        public bool Inserir(Pessoa pessoa)
        {
            if (!pessoa.EValido())
            {
                _errosEntidade = pessoa._errosEntidade;
                return false;
            }

            bool retorno = _pessoaRepositorio.Inserir(pessoa);
            _msgErro = _pessoaRepositorio._erro;
            return retorno;
        }

        public bool Atualizar(Pessoa pessoa)
        {
            if (!pessoa.EValido())
            {
                _errosEntidade = pessoa._errosEntidade;
                return false;
            }

            bool retorno = _pessoaRepositorio.Atualizar(pessoa);
            _msgErro = _pessoaRepositorio._erro;
            return retorno;
        }

        public bool Excluir(int pessoaId)
        {
            bool retorno = _pessoaRepositorio.Excluir(pessoaId);
            _msgErro = _pessoaRepositorio._erro;
            return retorno;
        }
    }
}
