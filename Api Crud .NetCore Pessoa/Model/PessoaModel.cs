using Api_Crud_.NetCore_Pessoa.Contexto;
using Api_Crud_.NetCore_Pessoa.Dominio.Entidade;
using Api_Crud_.NetCore_Pessoa.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud_.NetCore_Pessoa.Model
{
    public class PessoaModel : BaseModel
    {
        public DataContexto _contexto;
        public PessoaServico _pessoaServico;

        public PessoaModel(DataContexto dataContexto)
        {
            _contexto = dataContexto;
        }

        public IEnumerable<Pessoa> Listar(int tipoPessoa)
        {
            var pessoaServico = new PessoaServico(_contexto);

            return pessoaServico.Listar(tipoPessoa);
        }

        public Pessoa ListarPorId(int id)
        {
            var pessoaServico = new PessoaServico(_contexto);
            return pessoaServico.ListarPorId(id);
        }

        public bool Salvar(Pessoa pessoa)
        {
            bool retorno = false;
            var pessoaServico = new PessoaServico(_contexto);

            if (pessoa.Id <= 0)
            {
                retorno = pessoaServico.Inserir(pessoa);
            }
            else
            {
                retorno = pessoaServico.Atualizar(pessoa);
            }

            validaRetorno(retorno, pessoaServico._msgErro, pessoaServico._errosEntidade);
            return retorno;
        }

        public bool Excluir(int pessoaId)
        {
            bool retorno = false;
            var pessoaServico = new PessoaServico(_contexto);
            retorno = pessoaServico.Excluir(pessoaId);

            validaRetorno(retorno, pessoaServico._msgErro, pessoaServico._errosEntidade);
            return retorno;
        }
    }
}
