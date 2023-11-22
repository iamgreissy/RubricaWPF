using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syziu.regreis._4i.rubrica;
    public partial class MainWindow : Window
    {   
    public MainWindow()
    {
        InitializeComponent();
    }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Contatto[] Contatti = new Contatto[3];

            try
            {
                Contatto c = new Contatto();
                c.Numero = 1;
                c.Nome = "Syziu";
                c.Cognome = "Regreis";
                c.EMail = "g.s04gg@gmail.com";
                c.Telefono = "345678";
                c.CAP = "47842";

                Contatti[0] = c;

                Contatto c1 = new Contatto { Numero = 2, Nome = "Giulia", Cognome = "Dumea" };
                Contatti[1] = c1;

                Contatto c2 = new Contatto(2, "Natasha", "Leone");
                Contatti[2] = c2;


            }
            catch (Exception err)
            {
                MessageBox.Show("No no!!\n" + err.Message);
            }

        dgDati.ItemsSource = Contatti;

        private void dgDati_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Contatto contatto = e.Row.Item as Contatto;

            if (contatto != null && (contatto.Numero < 0 || contatto.Numero > 100))
            {
                e.Row.Background = Brushes.Red;
            }
            else
            {
                e.Row.ClearValue(DataGridRow.BackgroundProperty);
            }
        }
    }
}