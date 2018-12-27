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
        }

        void BuildView()
        {
            Padding = 12;
            Content = new StackLayout
            {
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions= LayoutOptions.Center,
                        Children =
                        {
                            new Label { Text = "Status:" },
                            new Label { Text = "Online" },
                            new Label { Text = "|" },
                            new Label { Text = "Bal:" },
                            new Label { Text = "$32.98" },
                            new Image { Source = "info", Aspect = Aspect.AspectFit, HeightRequest = 16, WidthRequest = 16}
                        }
                    },
                    new ContentPresenter { VerticalOptions= LayoutOptions.FillAndExpand }
                }
            };
        }
    }

    public class FooterView : ContentView
    {
        public FooterView()
        {
            BuildView();
        }

        void BuildView()
        {
            Padding = 12;
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    new ContentPresenter { VerticalOptions= LayoutOptions.FillAndExpand },
                    new Label { Text = $"Last updated: {DateTime.Now.AddMinutes(-1)}" }
                }
            };
        }
    }

    public class HeaderFooterView : ContentView
    {
        public HeaderFooterView()
        {
            BuildView();
        }

        void BuildView()
        {
            Padding = 12;
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    new StackLayout {
                        HorizontalOptions = LayoutOptions.Center,
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Label { Text = "Status:" },
                            new Label { Text = "Online" },
                            new Label { Text = "|" },
                            new Label { Text = "Bal:" },
                            new Label { Text = "$32.98" },
                            new Image { Source = "info", Aspect = Aspect.AspectFit, HeightRequest = 12, WidthRequest = 12}
                        }
                    },
                    new ContentPresenter { VerticalOptions= LayoutOptions.FillAndExpand },
                    new Label { Text = $"Last updated: {DateTime.Now.AddMinutes(-1)}" }
                }
            };
        }
    }
}
