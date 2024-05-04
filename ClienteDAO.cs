using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Alunos: Higor Antônio
namespace CRUDClientes
{
    internal class ClienteDAO
    {
        //manipulação em memória primária
        private List<Cliente> clientes;

        public ClienteDAO() {
            this.clientes = new List<Cliente>();
        
        }

        public void Adicionar(Cliente cliente)
        {
            if(this.clientes.Exists(c => c.Email.Equals(cliente.Email))) {

                throw new Exception("Já existe esse cliente na base");
            }
            else
            {
                this.clientes.Add(cliente);
            }
        }

        public void Remover(Cliente cliente)
        {
            clientes.Remove(cliente);
        }

        public List<Cliente> GetClientes()
        {
            return this.clientes;
        }

        //manipulação em arquivo XML

        public void Salvar() {

            XmlSerializer ser = new XmlSerializer(typeof(List<Cliente>));
            FileStream fs = new FileStream("C://temp//Clientes.xml", FileMode.OpenOrCreate);

            ser.Serialize(fs, this.clientes);
            fs.Close();

        }

        public void Carregar()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Cliente>));
            FileStream fs = new FileStream("C://temp//Clientes.xml", FileMode.OpenOrCreate);

            try
            {
                this.clientes = ser.Deserialize(fs) as List<Cliente>;

            }catch (InvalidOperationException ex)
            {
                ser.Serialize(fs, this.clientes);

            }
            fs.Close();

        }
    }
}
