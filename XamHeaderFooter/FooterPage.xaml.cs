using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamHeaderFooter
{
    public partial class FooterPage : BaseContentPage
    {
        public FooterPage()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            NamesList.ItemsSource = new string[] {
                "Homer",
                "Marge",
                "Lisa",
                "Bart",
                "Maggie"
            };
        }
    }
}
