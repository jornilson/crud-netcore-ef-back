using Api_Crud_.NetCore_Pessoa.Dominio.Entidade.Validacao;
using Api_Crud_.NetCore_Pessoa.Dominio.Entidade.Validacao.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud_.NetCore_Pessoa.Dominio.Entidade
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Razao { get; set; }
        public int Pfj { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public int Classificacao { get; set; }
        public string CnpjCpf { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }

        public List<ErroEntidadeDto> _errosEntidade;
        public bool EValido()
        {
            PessoaValido pessoaValido = new PessoaValido();
            bool retorno = pessoaValido.Validar(this);
            _errosEntidade = pessoaValido.errosEntidade;
            return retorno;
        }
    }
}
