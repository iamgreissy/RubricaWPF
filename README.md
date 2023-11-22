# RubricaWPF

Nel file Contatto.cs, si ha una semplice implementazione che crea una classe Contatto per rappresentare le informazioni di contatto. Il programma crea una lista di contatti (rubrica), aggiunge alcuni contatti e li stampa sulla console. La classe Contatto include costruttori per inizializzare gli oggetti Contatto in vari modi, inclusa la lettura di una riga CSV. Con l'aggiunta del costruttore (che accetta una "riga" proveniente dal file CSV), un tryParse (che generalmente viene usato per convertire il tipo di una variabile, in questo caso la prima colonna della riga CSV in un numero intero) e un LoadingRow (colora una riga fuori dal range disponibile della rubrica, segnandola di rosso come per indicare che c'è un errore) abbiamo completato la richiesta "rubricaColor".

Un altro file dove ho dovuto lavorare è nel file Xaml.cs, dove si deve gestire la rubrica effettiva.
```C#
public partial class MainWindow : Window
{   
    public MainWindow()
    {
        InitializeComponent();
    }
```
MainWindow è una classe che estende Window, rappresentando la finestra principale dell'applicazione.
Il costruttore MainWindow chiama il metodo InitializeComponent(), che è generato automaticamente quando si progetta un'interfaccia utente con XAML.
```C#
private void InitializeComponent()
{
    throw new NotImplementedException();
}
```
Questo metodo viene chiamato dal costruttore MainWindow e solleva un'eccezione NotImplementedException. Tuttavia, in un'applicazione WPF normale generata da Visual Studio, questo metodo viene automaticamente generato dal sistema e non richiede un'implementazione diretta nel codice.
```C#
private void Window_Loaded(object sender, RoutedEventArgs e)
{
    Contatto[] Contatti = new Contatto[3];

    try
    {
        Contatto c = new Contatto();

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

    // Assegnamento della lista di contatti al DataGrid
    dgDati.ItemsSource = Contatti;
}
```
Questo metodo viene chiamato quando la finestra viene caricata.
Crea un array di oggetti Contatto e cerca di popolarlo con tre istanze diverse della classe Contatto.
Gestisce eventuali eccezioni mostrando un messaggio tramite MessageBox.
Infine, assegna l'array di contatti (Contatti) come origine dati per il DataGrid (dgDati).
```C#
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
```
Questo evento viene chiamato quando una riga del DataGrid (dgDati) viene caricata.
Verifica se il Numero del contatto è al di fuori dell'intervallo consentito (0-100) e, in tal caso, colora la riga di rosso. Altrimenti, ripristina il colore predefinito.





