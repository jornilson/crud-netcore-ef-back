using Api_Crud_.NetCore_Pessoa.Contexto;
using Api_Crud_.NetCore_Pessoa.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud_.NetCore_Pessoa.Dominio.Repositorio
{
    public class PessoaRepositorio
    {
        public DataContexto _contexto;
        public string _erro;
        
        public PessoaRepositorio(DataContexto contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Pessoa> Listar(int tipoPessoa)
        {
            if (tipoPessoa == 0 || tipoPessoa == 1)
            {
                return _contexto.Pessoas.Include(x => x.Telefones).OrderByDescending(x => x.Id).Where(p => p.Pfj == tipoPessoa).ToList();
            }

            return _contexto.Pessoas.Include(x => x.Telefones).OrderByDescending(x => x.Id).ToList();
        }

        public Pessoa ListarPorId(int Id)
        {
            return _contexto.Pessoas
                .Include(x => x.Telefones)
                .Where(p => p.Id == Id)
                .FirstOrDefault();
        }

        public bool Inserir(Pessoa pessoa)
        {
            try
            {
                _contexto.Add(pessoa);
                int retornoTransacao = _contexto.SaveChanges();

                if (retornoTransacao > 0)
                {
                    return true;
                }

                return false;
            }
            catch (DbUpdateException e)
            {
                if (e != null)
                {
                    _erro = e.InnerException.Message;
                }

                return false;
            }            
        }

        public bool Atualizar(Pessoa pessoa)
        {
            try
            {
                _contexto.Update(pessoa);
                int retornoTransacao = _contexto.SaveChanges();

                if (retornoTransacao > 0)
                {
                    return true;
                }

                return false;
            }
            catch (DbUpdateException e)
            {
                if (e != null)
                {
                    _erro = e.InnerException.Message;
                }

                return false;
            }            
        }

        public bool Excluir(int pessoaId)
        {
            try
            {
                Pessoa pessoa = _contexto.Pessoas.Find(pessoaId);

                _contexto.Remove(pessoa);
                int retornoTransacao = _contexto.SaveChanges();

                if (retornoTransacao > 0)
                {
                    return true;
                }

                return false;
            }
            catch (DbUpdateException e)
            {
                if (e != null)
                {
                    _erro = e.InnerException.Message;
                }

                return false;
            }            
        }
    }
}
