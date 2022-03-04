using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud_.NetCore_Pessoa.Model
{
    public class BaseModel
    {
        public string _msgRetorno = "Concluido com sucesso!";
        public object _objetoRetornoRequest;

        protected void validaRetorno(bool status, string msgErro, dynamic listaErroValidaEntidade)
        {
            if (!status)
            {
                _msgRetorno = "Não foi possível realizar a operação, por favor tente novamente!";

                if (!string.IsNullOrEmpty(msgErro))
                {
                    _msgRetorno = Traduzir(msgErro);
                }

                if (listaErroValidaEntidade != null && listaErroValidaEntidade.Count > 0)
                {
                    _msgRetorno = "Preencha todos os campos corretamente!";
                }                
            }

            _objetoRetornoRequest = new
            {
                status = status,
                msgRetorno = _msgRetorno,
                listaErroEntidade = listaErroValidaEntidade
            };
        }

        private string Traduzir(string msg)
        {
            if (msg.ToUpper().Contains("VIOLATION OF PRIMARY") || msg.ToUpper().Contains("CANNOT INSERT DUPLICATE") || msg.ToUpper().Contains("Não é possível inserir uma linha de chave duplicada no objeto".ToUpper()) || msg.ToUpper().Contains("Não é possível inserir a chave duplicada no objeto ".ToUpper()))
            {
                return "Já exite um cadastro com esses dados!";
            }
            else
            {
                return "Ocorreu um erro inesperado";
            }
        }
    }
}
