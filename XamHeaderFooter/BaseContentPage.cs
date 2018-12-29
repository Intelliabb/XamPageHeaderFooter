using System;
using Xamarin.Forms;

namespace XamHeaderFooter
{
    public class BaseContentPage : ContentPage
    {
        readonly ControlTemplate _headerTemplate = new ControlTemplate(typeof(HeaderView));
        readonly ControlTemplate _footerTemplate = new ControlTemplate(typeof(FooterView));
        readonly ControlTemplate _headerFooterTemplate = new ControlTemplate(typeof(HeaderFooterView));

        private Template _template;
        public Template Template
        {
            get { return _template; }
            set { _template = value; UpdateTemplate(); }
        }

        void UpdateTemplate()
        {
            ControlTemplate template = null;
            switch (Template)
            {
                case Template.Header:
                    template = _headerTemplate;
                    break;
                case Template.Footer:
                    template = _footerTemplate;
                    break;
                case Template.HeaderAndFooter:
                    template = _headerFooterTemplate;
                    break;
                default:
                    template = default(ControlTemplate);
                    break;
            }
            ControlTemplate = template;
        }
    }

    public enum Template
    {
        None,
        Header,
        Footer,
        HeaderAndFooter
    }

    public class HeaderView : ContentView
    {
        public HeaderView()
        {
            BuildView();
            BackgroundColor = Color.CadetBlue;
        }

        void BuildView()
        {
            Padding = 0;
            var style = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.TextColorProperty, Value = Color.White },
                    new Setter { Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Center }
                }
            };
            Content = new StackLayout
            {
                Children = {
                    new StackLayout {
                        Padding = 6,
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions= LayoutOptions.End,
                        Children =
                        {
                            new Label { Text = "Points:", Style = style },
                            new Label { Text = "480", FontAttributes = FontAttributes.Bold, Style = style }
                        }
                    },
                    new ContentPresenter { VerticalOptions= LayoutOptions.FillAndExpand, BackgroundColor=Color.White  }
                }
            };
        }
    }

    public class FooterView : ContentView
    {
        public FooterView()
        {
            BuildView();
            BackgroundColor = Color.FromHex("#F0F0F0");
        }

        void BuildView()
        {
            Padding = new Thickness(0, 0, 0, 16);
            Content = new StackLayout
            {
                Children = {
                    new ContentPresenter { VerticalOptions= LayoutOptions.FillAndExpand, BackgroundColor=Color.White  },
                    new Label { Text = $"Last updated: {DateTime.Now.AddMinutes(-1)}", HorizontalTextAlignment= TextAlignment.Center }
                }
            };
        }
    }

    public class HeaderFooterView : ContentView
    {
        public HeaderFooterView()
        {
            BuildView();
            BackgroundColor = Color.FromHex("#F0F0F0");
        }

        void BuildView()
        {
            Padding = new Thickness(0, 12, 0, 16);
            var style = new Style(typeof(Label)) {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value = 12 }
                }
            };

            Content = new StackLayout
            {
                Children = {
                    new StackLayout {
                        HorizontalOptions = LayoutOptions.Center,
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Label { Text = "Status:", Style = style },
                            new Label { Text = "Online", Style = style },
                            new Label { Text = "|", Style = style },
                            new Label { Text = "Bal:", Style = style },
                            new Label { Text = "$32.98", Style = style },
                            new Image { Source = "info", Aspect = Aspect.AspectFit, HeightRequest = 16, WidthRequest = 16 }
                        }
                    },
                    new ContentPresenter { VerticalOptions= LayoutOptions.FillAndExpand, BackgroundColor=Color.White },
                    new Label { Text = $"Last updated: {DateTime.Now.AddMinutes(-1)}", HorizontalTextAlignment= TextAlignment.Center, Style = style }
                }
            };
        }
    }
}
