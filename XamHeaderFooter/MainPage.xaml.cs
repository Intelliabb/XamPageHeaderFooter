using Xamarin.Forms;

namespace XamHeaderFooter
{
    public partial class MainPage : BaseContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            Page page = null;

            switch (button.CommandParameter)
            {
                case "0":
                    page = new HeaderPage();
                    break;
                case "1":
                    page = new FooterPage();
                    break;
                case "2":
                default:
                    page = new HeaderFooterPage();
                    break;
            }

            Navigation.PushAsync(page);
        }
    }
}
