using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MeemicMobileApp.CustomControls
{
    public partial class RadialButtonControl : ContentView
    {
        private readonly Dictionary<Button, Tuple<Image, RadialOption>> buttonIdMap;



        /// <summary>
        /// The options property.
        /// </summary>
        public readonly static BindableProperty OptionsProperty = 
            BindableProperty.Create("Options", typeof(RadialOptions),
                                    typeof(RadialButtonControl), null, 
                                    propertyChanged: HandleOptionsChanged);



        /// <summary>
        /// The selected option property.
        /// </summary>
        public readonly static BindableProperty SelectedOptionProperty =
            BindableProperty.Create("SelectedOption", typeof(RadialOption),
                                    typeof(RadialButtonControl));



        /// <summary>
        /// Radial control options
        /// </summary>
        public RadialOptions Options 
        {
            get { return (RadialOptions)GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }



        /// <summary>
        /// Gets or sets the selected option.
        /// </summary>
        public RadialOption SelectedOption 
        {
            get { return (RadialOption)GetValue(SelectedOptionProperty); }
            set { SetValue(SelectedOptionProperty, value); }
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="T:MeemicMobileApp.CustomControls.RadialButtonControl"/> class.
        /// </summary>
        public RadialButtonControl()
        {
            InitializeComponent();

            buttonIdMap = new Dictionary<Button, Tuple<Image, RadialOption>>();
        }



        private void GenerateButtons() 
        {
            var mainGrid = new Grid();

            for (int i = 0; i < Options.Count; i++) 
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }


            for (int i = 0; i < Options.Count; i++)
            {
                var g = new Grid();

                g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                g.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

                var radioImgOff = new Image
                {
                    Source = "Radio off",
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };

                var radioImgOn = new Image
                {
                    Source = "Radio on",
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    IsVisible = false
				};

                var b = new Button
                {
                    BackgroundColor = Color.Transparent
                };

                b.Clicked += RadioButtonClicked;

                buttonIdMap.Add(b, Tuple.Create(radioImgOn, Options[i]));

                var label = new Label
                {
                    Text = Options[i].Title,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.StartAndExpand
				};

                g.Children.Add(radioImgOff, 0, 0);
                g.Children.Add(radioImgOn, 0, 0);
                g.Children.Add(b, 0, 0);
				g.Children.Add(label, 1, 0);

                g.HorizontalOptions = LayoutOptions.StartAndExpand;

                mainGrid.Children.Add(g, i, 0);

            }

            Content = mainGrid;

        }



        protected void RadioButtonClicked(object sender, EventArgs arrrrrgs) 
        {
            var b = sender as Button;

            foreach(var kvp in buttonIdMap)
            {
                kvp.Value.Item1.IsVisible = b == kvp.Key;
            }

            SelectedOption = buttonIdMap[b]?.Item2;

        }



        private static void HandleOptionsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var c = bindable as RadialButtonControl;
            c.GenerateButtons();
        }
    }



    /// <summary>
    /// Radial option.
    /// </summary>
    public class RadialOption
    {
        
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }



        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

    }


    /// <summary>
    /// lol .net
    /// </summary>
    public class RadialOptions : List<RadialOption> {}
}



