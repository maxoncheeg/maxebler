
using System.Net.Http;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms.VisualStyles;
using maxembler.Models;
using maxembler.Properties;

namespace maxembler
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();


            this.Load += HelpForm_Load;
        }

        private async void HelpForm_Load(object? sender, EventArgs e)
        {
            //var html = ResourceHelper.LoadHtmlFromResources("index.html");
            //var babel = ResourceHelper.LoadHtmlFromResources("babel.min.js");
            //var react = ResourceHelper.LoadHtmlFromResources("react.development.js");
            //var reactdomtorretto = ResourceHelper.LoadHtmlFromResources("react-dom.production.min.js");

            //html = html.Replace("<script src=\"react.development.js\"></script>", $"<script>{react}</script>");
            //html = html.Replace("<script src=\"react-dom.production.min.js\"></script>", $"<script>{reactdomtorretto}</script>");
            //html = html.Replace("<script src=\"babel.min.js\"></script>", $"<script>{babel}</script>");

            //// Преобразование в Base64
            //string base64Html = Convert.ToBase64String(Encoding.UTF8.GetBytes(html));

            //// Создание URI с Base64-контентом
            //string url = $"data:text/html;base64,{base64Html}";

            //await webView.EnsureCoreWebView2Async();

            //webView.Source = new Uri("./Resources/helpgen/index.html");
            webView.Source = new Uri($"file:///{Application.StartupPath}\\Resources\\helpgen\\index.html");

           
        }
    }
}
