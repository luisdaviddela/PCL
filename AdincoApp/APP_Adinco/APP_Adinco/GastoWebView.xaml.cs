using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_Adinco
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GastoWebView : ContentPage
    {
        public static int idDocumento = 0;
      public  string var = "";
        public GastoWebView(int doc)
        {
            idDocumento = doc;
            InitializeComponent();
            VerDato();
            url();
         var = "680";

        }
        void url()
        {
            reporte.Source = "http://moodle.upalt.edu.mx/course/view.php?id=" + var;
            Indicador.IsVisible = false;
            Indicador.IsRunning = false;
        }
         void VerDato()
        {
            Documento.Text = idDocumento.ToString();

        }
    

    }

}
