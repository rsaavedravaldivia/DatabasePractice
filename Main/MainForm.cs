using Main.Libraries;
using System;
using System.Data;
using System.Windows.Forms;

namespace Main
{
    public partial class MainForm : Form
    {

        SQLiteAccess sqliteHandler;
        DataTable dataTable;
        public MainForm()
        {

            InitializeComponent();


        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            // creating database handler object
            sqliteHandler = new SQLiteAccess();
            // getting the data from sql and putting it into a datatable
            dataTable = ClientTableHandler.GetClientDataTablefromSQLite(sqliteHandler);
            // adding the datatable to the datagridview
            clientDatagrid.DataSource = dataTable;


        }

        private void btnAddClient_Click(object sender, System.EventArgs e)
        {
            Client client = new Client(tbFirstName.Text, tbLastName.Text, tbPhone.Text,
            tbEmail.Text, tbAddress.Text);
            ClientTableHandler.InsertClient(sqliteHandler, client);
            MainForm_Load(sender, e);


        }





        private DataGridViewRow selectedRow;


        private void btnDeleteClient_Click(object sender, EventArgs e)
        {

            if (selectedRow != null)
            {
                ClientTableHandler.DeleteClient(sqliteHandler, int.Parse(selectedRow.Cells[0].Value.ToString()));
                Console.WriteLine(int.Parse(selectedRow.Cells[0].Value.ToString()));
                dataTable = ClientTableHandler.GetClientDataTablefromSQLite(sqliteHandler);
                clientDatagrid.DataSource = dataTable;
                MainForm_Load(sender, e);
            }
        }

        private void clientDatagrid_SelectionChanged(object sender, EventArgs e)
        {
            selectedRow = clientDatagrid.CurrentRow;
            Console.WriteLine(selectedRow.Cells[0].Value);
        }
    }
}
