namespace CRUDClientes
{
    public partial class Form1 : Form
    {
        private ClienteDAO clientes;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clientes = new ClienteDAO();
            clientes.Carregar();
            dataGridView1.DataSource = clientes.GetClientes();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos da tela.");
            }
            else
            {
                Cliente cliente = new Cliente()
                {
                    Nome = textBox1.Text,
                    Email = textBox2.Text

                };

                clientes.Adicionar(cliente);
                clientes.Salvar();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = clientes.GetClientes();
            }


        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //verifica se há linha selecionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<Cliente> Listaclientes = new List<Cliente>();
                Listaclientes = clientes.GetClientes();

                Cliente clienteexcluir = new Cliente();

                //capturando id da posição da linha que desejo excluir
                int linhaIndex = dataGridView1.SelectedRows[0].Index;

                //jogando para variável o objeto cliente que desejo exlcuir
                clienteexcluir = Listaclientes[linhaIndex];

                DataGridViewRow LinhaSelecionada = dataGridView1.SelectedRows[0];

                //chamando o método remover de clienteDAO
                clientes.Remover(clienteexcluir);
                clientes.Salvar();


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = clientes.GetClientes();

            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada.");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            clientes.Salvar();
        }
    }
}