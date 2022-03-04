using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud_.NetCore_Pessoa.Dominio.Entidade
{
    public class Telefone
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
