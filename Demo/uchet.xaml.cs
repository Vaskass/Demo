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
    /// Логика взаимодействия для uchet.xaml
    /// </summary>
    public partial class uchet : Window
    {
        public uchet()
        {
            InitializeComponent();
        }
        List<int> client = new List<int>();
        List<int> room = new List<int>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updTbl();

        }

        void updTbl()
        {
            using (DataContext db = new DataContext(Properties.Settings.Default.connectionString))
            {
                var srcFIO = db.GetTable<Client>().Where(c => c.fam.Contains(srcTB.Text));
                var view = from uc in db.GetTable<Uchet>()
                           join rm in db.GetTable<Room>() on uc.IDroom equals rm.ID
                           join cl in srcFIO on uc.IDclient equals cl.ID
                           orderby cl.fam descending
                           select new UchetView { ID = uc.ID, IDclient = cl.ID, IDroom = rm.ID, FIO = cl.fam + " " + cl.name + " " + cl.otch, numRoom = rm.numRoom, dateIn = uc.dateIn, dateOut = uc.dateOut, summ = uc.summ };
                uchetTable.ItemsSource = view;
                client.Clear();
                clientCB.Items.Clear();
                foreach (Client cl in db.GetTable<Client>())
                {
                    clientCB.Items.Add(cl.fam + " " + cl.name + " " + cl.otch);
                    client.Add(cl.ID);
                }
                if (clientCB.Items.Count > 0)
                {
                    clientCB.SelectedIndex = 0;
                }

                room.Clear();
                roomCB.Items.Clear();
                foreach (Room rm in db.GetTable<Room>())
                {
                    roomCB.Items.Add(rm.numRoom);
                    room.Add(rm.ID);
                }
                if (roomCB.Items.Count > 0)
                {
                    roomCB.SelectedIndex = 0;
                }
            }

        }
        private void clientTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (uchetTable.SelectedItem != null)
            {
                clientCB.SelectedItem = (uchetTable.SelectedItem as UchetView).FIO;
                roomCB.SelectedItem = (uchetTable.SelectedItem as UchetView).numRoom;
                inDatePick.SelectedDate = (uchetTable.SelectedItem as UchetView).dateIn;
                outDatePick.SelectedDate = (uchetTable.SelectedItem as UchetView).dateOut;
            }
        }

        private void srcTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            updTbl();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext db = new DataContext(Properties.Settings.Default.connectionString))
            {
                float sum = db.GetTable<Room>().Where(rm => rm.ID == room[roomCB.SelectedIndex]).FirstOrDefault().price * outDatePick.SelectedDate.GetValueOrDefault(DateTime.Now).Subtract(inDatePick.SelectedDate.GetValueOrDefault(DateTime.Now)).Days;
                Uchet newuchet = new Uchet
                {
                    IDclient = client[clientCB.SelectedIndex],
                    IDroom = room[roomCB.SelectedIndex],
                    dateIn = inDatePick.SelectedDate.GetValueOrDefault(DateTime.Now),
                    dateOut = outDatePick.SelectedDate.GetValueOrDefault(DateTime.Now),
                    summ = sum
                };
                db.GetTable<Uchet>().InsertOnSubmit(newuchet);
                db.SubmitChanges();
            }
            updTbl();
        }
    }
}
