using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDClientes
{
    public class Cliente
    {
        private string nome;
        private string email;

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public string Email
        {
            get { return this.email; }   
            set { email = value; }
        }
    }
}
