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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<Cliente> Listaclientes = new List<Cliente>();
                Listaclientes = clientes.GetClientes();

                Cliente clienteexcluir = new Cliente();
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                clienteexcluir = Listaclientes[rowIndex];

                DataGridViewRow LinhaSelecionada = dataGridView1.SelectedRows[0];

                //string nome = LinhaSelecionada.Cells["Nome"].Value.ToString();
                //string email = LinhaSelecionada.Cells["Email"].Value.ToString();

                //MessageBox.Show(clienteexcluir.Nome +clienteexcluir.Email);

                clientes = new ClienteDAO();
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
    }
}