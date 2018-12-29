using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamHeaderFooter
{
    public partial class HeaderFooterPage : BaseContentPage
    {
        public HeaderFooterPage()
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
