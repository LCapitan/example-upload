using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MeemicMobileApp.CustomControls
{
    public partial class ToggleButtonsControl : ContentView
    {
		private readonly List<Frame> buttons;



		/// <summary>
		/// The selected index property.
		/// </summary>
		public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create("SelectedIndex", typeof(int), typeof(ToggleButtonsControl), -1, propertyChanged: HandleBindingPropertyChangedDelegate);



        /// <summary>
        /// The outline color property.
        /// </summary>
        public static readonly BindableProperty ButtonOutlineColorProperty =
            BindableProperty.Create("ButtonOutlineColor", typeof(Color), typeof(ToggleButtonsControl), Color.Black, propertyChanged: ButtonOutlineColorPropertyChanged);


        /// <summary>
        /// The button background color property.
        /// </summary>
        public static readonly BindableProperty ButtonBackgroundColorProperty =
            BindableProperty.Create("ButtonBackgroundColor", typeof(Color), typeof(ToggleButtonsControl), Color.White, propertyChanged: ButtonBackgroundColorPropertyChanged);



        /// <summary>
        /// The selection color property.
        /// </summary>
        public static readonly BindableProperty ButtonSelectedBackgroundColorProperty =
            BindableProperty.Create("ButtonSelectedBackgroundColor", typeof(Color), typeof(ToggleButtonsControl), Color.Black, propertyChanged: ButtonSelectedBackgroundColorPropertyChanged);



        /// <summary>
        /// The font color property.
        /// </summary>
        public static readonly BindableProperty ButtonFontColorProperty =
            BindableProperty.Create("ButtonFontColor", typeof(Color), typeof(ToggleButtonsControl), Color.Black, propertyChanged: ButtonFontColorPropertyChanged);



        /// <summary>
        /// The selection font color property.
        /// </summary>
        public static readonly BindableProperty ButtonSelectionFontColorProperty =
            BindableProperty.Create("ButtonSelectionFontColor", typeof(Color), typeof(ToggleButtonsControl), Color.White, propertyChanged: ButtonSelectionFontColorPropertyChanged);



        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        public int SelectedIndex 
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }



        /// <summary>
        /// Gets or sets the color of the button background.
        /// </summary>
        public Color ButtonBackgroundColor
        {
            get { return (Color)GetValue(ButtonBackgroundColorProperty); }
            set { SetValue(ButtonBackgroundColorProperty, value); }
        }



        /// <summary>
        /// Toggle button outline color
        /// </summary>
        /// <value>The color of the outline.</value>
        public Color ButtonOutlineColor 
        {
            get { return (Color)GetValue(ButtonOutlineColorProperty); }
            set { SetValue(ButtonOutlineColorProperty, value); }
        }



        /// <summary>
        /// Gets or sets the color of the selection.
        /// </summary>
        public Color ButtonSelectedBackgroundColor
        {
            get { return (Color)GetValue(ButtonSelectedBackgroundColorProperty); }
            set { SetValue(ButtonSelectedBackgroundColorProperty, value); }
        }



        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        public Color ButtonFontColor 
        {
            get { return (Color)GetValue(ButtonFontColorProperty); }
            set { SetValue(ButtonFontColorProperty, value); }
        }



        /// <summary>
        /// Gets or sets the color of the selection font.
        /// </summary>
        public Color ButtonSelectionFontColor 
        {
            get { return (Color)GetValue(ButtonSelectionFontColorProperty); }
            set { SetValue(ButtonSelectionFontColorProperty, value); }
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="T:MeemicMobileApp.CustomControls.ToggleButtonsControl"/> class.
        /// </summary>
        public ToggleButtonsControl()
        {
            InitializeComponent();

            buttons = new List<Frame>
            {
                frameButton1,
                frameButton2,
                frameButton3
            };

        }



        private void Handle_Tapped(object sender, System.EventArgs e)
        {
            var frame = sender as Frame;
            SetButtonStates(frame);
        }



        private void SetButtonStates(Frame selected) 
        {
			SetActiveButton(selected);
			SelectedIndex = buttons.IndexOf(selected);

			var notSelected = buttons.Where(f => f != selected);
			DeactivateButtons(notSelected);
        }



        private void SetActiveButton(Frame frame) 
        {
            frame.BackgroundColor = ButtonSelectedBackgroundColor;

            if (frame.Content is Label label)
                label.TextColor = ButtonSelectionFontColor;

        }



        private void SetDeactiveButton(Frame frame)
        {
            frame.BackgroundColor = ButtonBackgroundColor;

            if (frame.Content is Label label)
                label.TextColor = ButtonFontColor;
        }



        private void DeactivateButtons(IEnumerable<Frame> frames)
        {
            foreach (var frame in frames)
            {
                SetDeactiveButton(frame);
            }
        }



        private void SetActiveByIndex(int index)
        {
            if (index >= buttons.Count() || index < 0)
                return;

            var frame = buttons[index];

            SetButtonStates(frame);

        }



        static void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as ToggleButtonsControl;
            var index = (int)newValue;

            control.SetActiveByIndex(index);
        }


        private static void ButtonOutlineColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            
        }



        private static void ButtonBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            
        }



        private static void ButtonSelectedBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            
        }


        private static void ButtonFontColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) 
        {
            
        }


        private static void ButtonSelectionFontColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            
        }


    }
}
