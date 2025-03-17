
namespace maxembler
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            webView.Source = new Uri(@"file:///C:\Users\maksg\Desktop\CODING\GAMES\maxembler\maxembler\bin\Debug\net9.0-windows\help.html");
        }
    }
}
