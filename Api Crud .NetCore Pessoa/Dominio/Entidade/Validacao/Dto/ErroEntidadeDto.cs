using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud_.NetCore_Pessoa.Dominio.Entidade.Validacao.Dto
{
    public class ErroEntidadeDto
    {
        public string Campo { get; set; }
        public string Msg { get; set; }
    }
}
