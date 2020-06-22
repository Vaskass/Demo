using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        public reg()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updTable();
        }

        void updTable()
        {
            using (DataContext db = new DataContext(Properties.Settings.Default.connectionString))
            {
                clientTable.ItemsSource = db.GetTable<Client>().OrderBy(u=> u.fam);
            }
        }

        private void addBTN_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext db = new DataContext(Properties.Settings.Default.connectionString))
            {
                Client newClient = new Client()
                {
                    fam = famTB.Text,
                    name = nameTB.Text,
                    otch = otchTB.Text,
                    serPas = int.Parse(serPasTB.Text),
                    numPas = int.Parse(numPasTB.Text),
                    birth = birthDate.DisplayDate,
                    pol = polCB.Text
                };
                db.GetTable<Client>().InsertOnSubmit(newClient);
                db.SubmitChanges();
            }
            updTable();
        }

        private void changeBTN_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext db = new DataContext(Properties.Settings.Default.connectionString))
            {
                Client selectedClient = db.GetTable<Client>().Where(client => client.ID == (clientTable.SelectedItem as Client).ID).FirstOrDefault();
                selectedClient.fam = famTB.Text;
                selectedClient.name = nameTB.Text;
                selectedClient.otch = otchTB.Text;
                selectedClient.serPas = int.Parse(serPasTB.Text);
                selectedClient.numPas = int.Parse(numPasTB.Text);
                selectedClient.birth = birthDate.DisplayDate;
                selectedClient.pol = polCB.Text;
                db.SubmitChanges();
            }
            updTable();
        }

        private void clientTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clientTable.SelectedItem != null)
            {
                Client selectedClient = clientTable.SelectedItem as Client;
                famTB.Text = selectedClient.fam;
                nameTB.Text = selectedClient.name;
                otchTB.Text = selectedClient.otch;
                serPasTB.Text = selectedClient.serPas.ToString();
                numPasTB.Text = selectedClient.numPas.ToString();
                birthDate.DisplayDate = selectedClient.birth;
                polCB.Text = selectedClient.pol;
            }
        }

        private void srcText_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (DataContext db = new DataContext(Properties.Settings.Default.connectionString))
            {
                clientTable.ItemsSource = db.GetTable<Client>().Where(c=> c.fam.Contains(srcText.Text)).OrderBy(c => c.fam).ThenBy(c=>c.name);
            }
        }
    }
}
