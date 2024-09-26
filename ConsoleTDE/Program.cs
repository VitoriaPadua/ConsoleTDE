using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cadastroCliente
{
    internal class cadastroCliente
    {
        public class Cliente
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public int Idade { get; set; }
            public string Email { get; set; }
            public string CPF { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
        }

        public class Cadastro
        {
            private List<Cliente> _cadastro = new List<Cliente>();
            private int contadorId = 1;


            public void AdicionarCadastro(Cliente cliente)
            {
                cliente.Id = contadorId++;
                _cadastro.Add(cliente);
            }

            public void AtualizarCadastro(int id, string nome, int idade, string email, string cpf, string cidade, string estado)
            {
                var itemToUpdate = _cadastro.FirstOrDefault(i => i.Id == id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Nome = nome;
                    itemToUpdate.Idade = idade;
                    itemToUpdate.Email = email;
                    itemToUpdate.CPF = cpf;
                    itemToUpdate.Cidade = cidade;
                    itemToUpdate.Estado = estado;
                }
            }


            public void RemoverCadastro(int itemId)
            {
                var itemToRemove = _cadastro.FirstOrDefault(i => i.Id == itemId);
                if (itemToRemove != null)
                {
                    _cadastro.Remove(itemToRemove);
                }
            }


            

            public List<Cliente> GetItens()
            {
                return _cadastro;
            }
        }
    }
}
