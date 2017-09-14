using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeemicMobileApp.CustomControls
{
    /// <summary>
    /// Custom Navigation Header Control
    /// </summary>
    public partial class NavigationHeaderControl : ContentView
    {
        private readonly Dictionary<NavigationHeaderMode, View[]> navigationHeaderModeToViewMap;



        /// <summary>
        /// The Navigation Mode Property
        /// </summary>
        public static readonly BindableProperty NavigationModeProperty = 
            BindableProperty.Create("NavigationMode", 
                                    typeof(NavigationHeaderMode), typeof(NavigationHeaderControl), 
                                    NavigationHeaderMode.DEFAULT_VALUE, propertyChanged: HandleNavigationModePropertyChanged);


        /// <summary>
        /// The header text property.
        /// </summary>
        public static readonly BindableProperty HeaderTextProperty =
            BindableProperty.Create("HeaderText",
                                    typeof(string), typeof(NavigationHeaderControl),
                                    "", propertyChanged: HandleHeaderTextPropertyChanged);


        /// <summary>
        /// The header text color property.
        /// </summary>
        public static readonly BindableProperty HeaderTextColorProperty =
            BindableProperty.Create("HeaderTextColor",
                                   typeof(Color), typeof(NavigationHeaderMode),
                                    Color.Transparent, propertyChanged: HandleHeaderTextColorPropertyChanged);


        /// <summary>
        /// The button text color property.
        /// </summary>
        public static readonly BindableProperty ButtonTextColorProperty =
            BindableProperty.Create("ButtonTextColor",
                                    typeof(Color), typeof(NavigationHeaderControl),
                                    Color.Transparent, propertyChanged: HandleButtonTextColorPropertyChanged);


        /// <summary>
        /// The cancel button command property.
        /// </summary>
        public static readonly BindableProperty CancelButtonCommandProperty =
            BindableProperty.Create("CancelButtonCommand",
                                    typeof(ICommand), typeof(NavigationHeaderControl),
                                    null, propertyChanged: HandleCancelButtonCommandPropertyChanged);



        /// <summary>
        /// The cancel button command parameters property.
        /// </summary>
        public static readonly BindableProperty CancelButtonCommandParamsProperty =
            BindableProperty.Create("CancelButtonCommandParams",
                                    typeof(object), typeof(NavigationHeaderControl),
                                    null, propertyChanged: HandleCancelButtonCommandParmsProperty);


        /// <summary>
        /// The save button command property.
        /// </summary>
        public static readonly BindableProperty RightButtonCommandProperty =
            BindableProperty.Create("RightButtonCommand",
                                    typeof(ICommand), typeof(NavigationHeaderControl),
                                    null, propertyChanged: HandleRightButtonCommandPropertyChanged);


        /// <summary>
        /// The save button command pararms property.
        /// </summary>
        public static readonly BindableProperty RightButtonCommandPararmsProperty =
            BindableProperty.Create("SRightButtonCommandParams",
                                    typeof(object), typeof(NavigationHeaderControl),
                                    null, propertyChanged: HandleRightButtonCommandParmsProperty);


        /// <summary>
        /// The back button secondary command property.
        /// </summary>
        public static readonly BindableProperty BackButtonSecondaryCommandProperty =
            BindableProperty.Create("BackButtonSecondaryCommand",
                                    typeof(ICommand), typeof(NavigationHeaderControl),
                                    null);


        /// <summary>
        /// Gets or sets the color of the right button background.
        /// </summary>
        /// <value>The color of the right button background.</value>
        public Color RightButtonBackgroundColor
        {
            get { return RightButton.BackgroundColor; }
            set { RightButton.BackgroundColor = value; }
        }



        /// <summary>
        /// Gets or sets the navigation mode for the header
        /// </summary>
        public NavigationHeaderMode NavigationMode
        {
            get { return (NavigationHeaderMode)GetValue(NavigationModeProperty); }
            set { SetValue(NavigationModeProperty, value); }
        }



        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        public string HeaderText 
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }


        /// <summary>
        /// Gets or sets the color of the header text.
        /// </summary>
        public Color HeaderTextColor
        {
            get { return (Color)GetValue(HeaderTextColorProperty); }
            set { SetValue(HeaderTextColorProperty, value); }

        }



        /// <summary>
        /// Gets or sets the color of the button text.
        /// </summary>
        public Color ButtonTextColor
        {
            get { return (Color)GetValue(ButtonTextColorProperty); }
            set { SetValue(ButtonTextColorProperty, value); }
        }



        /// <summary>
        /// Gets or sets the cancel command.
        /// </summary>
        public ICommand CancelCommand 
        {
            get { return (ICommand)GetValue(CancelButtonCommandProperty); }
            set { SetValue(CancelButtonCommandProperty, value); }
        }



        /// <summary>
        /// Gets or sets the cancel button command.
        /// </summary>
        public object CancelCommandParams
        {
            get { return GetValue(CancelButtonCommandParamsProperty); }
            set { SetValue(CancelButtonCommandParamsProperty, value); }
        }



        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        /// <value>The save command.</value>
        public ICommand RightButtonCommand
        {
            get { return (ICommand)GetValue(RightButtonCommandProperty); }
            set { SetValue(RightButtonCommandPararmsProperty, value); }
        }



        /// <summary>
        /// Gets or sets the save command parameters.
        /// </summary>
        /// <value>The save command parameters.</value>
        public object RightButtonCommandParams
        {
            get { return GetValue(RightButtonCommandPararmsProperty); }
            set { SetValue(RightButtonCommandPararmsProperty, value); }
        }


        /// <summary>
        /// Gets or sets the back button secondary command.
        /// </summary>
        public ICommand BackButtonSecondaryCommand
        {
            get { return (ICommand)GetValue(BackButtonSecondaryCommandProperty); }
            set { SetValue(BackButtonSecondaryCommandProperty, value); }
        }



        /// <summary>
        /// Gets or sets the right button text.
        /// </summary>
        public string RightButtonText
        {
            get { return RightButton.Text; }
            set { RightButton.Text = value; }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public NavigationHeaderControl()
        {
            InitializeComponent();

            navigationHeaderModeToViewMap = new Dictionary<NavigationHeaderMode, View[]>
            {
                {
                    NavigationHeaderMode.None, new View[]
                    {
                        BackButton,
                        BackImage,
                        HeaderTextLabel,
                        MenuButton,
                        CancelButton,
                        RightButton
                    }
                },
                {
                    NavigationHeaderMode.BackButton, new View[]
                    {
                        BackButton,
                        BackImage,
                        HeaderTextLabel
                    }
                },
                {
                    NavigationHeaderMode.FormButtons, new View[]
                    {
                        CancelButton,
                        HeaderTextLabel,
                        RightButton
                    }
                },
                {
                    NavigationHeaderMode.MenuButton, new View[]
                    {
                        HeaderTextLabel,
                        MenuButton
                    }
                },
                {
                    NavigationHeaderMode.BackAndButton, new View[]
                    {
                        BackButton,
                        BackImage,
                        HeaderTextLabel,
                        RightButton
                    }
                },
                {
                    // We add this to satisify the default value since we are using an 
                    // enum - if we used .None in this case, it wouldn't fire a property
                    // changed event and the control would not update
                    NavigationHeaderMode.DEFAULT_VALUE, new View[]
                    {
                        BackImage,
                        BackButton,
                        HeaderTextLabel,
                        MenuButton,
                        CancelButton,
                        RightButton
                    }
                }
            };


            
        }



        /// <summary>
        /// Sets the state of the header
        /// </summary>
        /// <param name="prevState">Previous state.</param>
        /// <param name="newState">New state.</param>
        protected void SetState(NavigationHeaderMode prevState, NavigationHeaderMode newState)
        {
            SetVisibility(navigationHeaderModeToViewMap[prevState], false);

            var isHidden = newState == NavigationHeaderMode.None || newState == NavigationHeaderMode.DEFAULT_VALUE;


            SetVisibility(navigationHeaderModeToViewMap[newState], !isHidden);
        }



        /// <summary>
        /// Sets the header text.
        /// </summary>
        /// <param name="text">Text.</param>
        protected void SetHeaderText(string text) 
        {
            HeaderTextLabel.Text = text;
        }



        /// <summary>
        /// Sets the color of the header text.
        /// </summary>
        /// <param name="col">Col.</param>
        protected void SetHeaderTextColor(Color col)
        {
            HeaderTextLabel.TextColor = col;
        }



        /// <summary>
        /// Sets the color of the button text.
        /// </summary>
        /// <param name="col">Col.</param>
        protected void SetButtonTextColor(Color col)
        {
            MenuButton.TextColor = col;
            RightButton.TextColor = col;
            CancelButton.TextColor = col;
            BackButton.TextColor = col;
        }



        /// <summary>
        /// Sets the cancel command.
        /// </summary>
        /// <param name="command">Command.</param>
        protected void SetCancelCommand(ICommand command)
        {
            CancelButton.Command = command;
        }



        /// <summary>
        /// Sets the cancel command parameters.
        /// </summary>
        /// <param name="parms">Parms.</param>
        protected void SetCancelCommandParams(object parms)
        {
            CancelButton.CommandParameter = parms;
        }



        /// <summary>
        /// Sets the save command.
        /// </summary>
        /// <param name="command">Command.</param>
        protected void SetRightButtonCommand(ICommand command)
        {
            RightButton.Command = command;
        }



        /// <summary>
        /// Sets the save command parameters.
        /// </summary>
        /// <param name="parms">Parms.</param>
        protected void SetRightButtonCommandParams(object parms)
        {
            RightButton.CommandParameter = parms;
        }



        private void SetVisibility(View[] views, bool isVisible) 
        {
            for (int i = 0; i < views.Length; i++)
                views[i].IsVisible = isVisible;
        }



        private static void HandleNavigationModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            if (Enum.TryParse(oldValue.ToString(), out NavigationHeaderMode ov) == false)
                return;

            if (Enum.TryParse(newValue.ToString(), out NavigationHeaderMode nv) == false)
                return;

            var control = bindable as NavigationHeaderControl;

            control.SetState(ov, nv);
        }



        private static void HandleHeaderTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NavigationHeaderControl;
            control.SetHeaderText(newValue.ToString());
        }


        private static void HandleHeaderTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) 
        {
            var col = (Color)newValue;

            var control = bindable as NavigationHeaderControl;
            control.SetHeaderTextColor(col);
        }



        private static void HandleButtonTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) 
        {
            var col = (Color)newValue;
            var control = bindable as NavigationHeaderControl;

            control.SetButtonTextColor(col);
        }



        private static void HandleCancelButtonCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var command = newValue as ICommand;

            var control = bindable as NavigationHeaderControl;

            control.SetCancelCommand(command);
        }



        private static void HandleCancelButtonCommandParmsProperty(BindableObject bindable, object oldValue, object newValue) 
        {
            var control = bindable as NavigationHeaderControl;

            control.SetCancelCommandParams(newValue);
        }



        private static void HandleRightButtonCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue) 
        {
            var command = newValue as ICommand;
            var control = bindable as NavigationHeaderControl;

            control.SetRightButtonCommand(command);
        }



        private static void HandleRightButtonCommandParmsProperty(BindableObject bindable, object newValue, object oldValue) 
        {
            var control = bindable as NavigationHeaderControl;

            control.SetRightButtonCommandParams(newValue);
        }


        void Handle_BackButtonClicked(object sender, EventArgs e)
        {
            if(BackButtonSecondaryCommand != null)
            {
                BackButtonSecondaryCommand.Execute(null);
                return;
            }

            Navigation.PopAsync(true);
        }
    }


    public enum NavigationHeaderMode
    {
        None,
        BackButton,
        MenuButton,
        FormButtons,
        BackAndButton,
        DEFAULT_VALUE
    }
}
