using Api_Crud_.NetCore_Pessoa.Dominio.Entidade.Validacao.Dto;
using Api_Crud_.NetCore_Pessoa.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud_.NetCore_Pessoa.Dominio.Entidade.Validacao
{
    public class PessoaValido
    {
        public List<ErroEntidadeDto> errosEntidade = new List<ErroEntidadeDto>();

        public bool Validar(Pessoa pessoa)
        {
            bool retorno = true;

            if (string.IsNullOrEmpty(pessoa.Nome))
            {
                errosEntidade.Add(new ErroEntidadeDto()
                {
                    Campo = "nome",
                    Msg = "Preencha o campo nome"
                });

                retorno = false;
            }

            if (string.IsNullOrEmpty(pessoa.Razao))
            {
                errosEntidade.Add(new ErroEntidadeDto()
                {
                    Campo = "razao",
                    Msg = "Preencha o campo razão"
                });
                retorno = false;
            }

            if (pessoa.Pfj != 0 && pessoa.Pfj != 1)
            {
                errosEntidade.Add(new ErroEntidadeDto()
                {
                    Campo = "pfj",
                    Msg = "Preencha o campo pessoa física ou jurídica"
                });
                retorno = false;
            }

            if (string.IsNullOrEmpty(pessoa.Cep))
            {
                errosEntidade.Add(new ErroEntidadeDto()
                {
                    Campo = "cep",
                    Msg = "Preencha o campo CEP"
                });
                retorno = false;
            }

            if (string.IsNullOrEmpty(pessoa.Email))
            {
                errosEntidade.Add(new ErroEntidadeDto()
                {
                    Campo = "email",
                    Msg = "Preencha o campo email"
                });
                retorno = false;
            }

            if (!Utils.ValidarEmail(pessoa.Email))
            {
                errosEntidade.Add(new ErroEntidadeDto()
                {
                    Campo = "email",
                    Msg = "O email informado é inválido"
                });
                retorno = false;
            }

            if (pessoa.Classificacao != 0 && pessoa.Classificacao != 1 && pessoa.Classificacao != 2)
            {
                errosEntidade.Add(new ErroEntidadeDto()
                {
                    Campo = "classificacao",
                    Msg = "Preencha o campo classificacao"
                });
                retorno = false;
            }

            if (string.IsNullOrEmpty(pessoa.CnpjCpf))
            {
                errosEntidade.Add(new ErroEntidadeDto()
                {
                    Campo = "cnpjCpf",
                    Msg = "Preencha o campo cnpj ou cpf"
                });
                retorno = false;
            }

            return retorno;
        }
    }
}
