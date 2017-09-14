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
        /// Gets or sets the index of the selected.
        /// </summary>
        public int SelectedIndex 
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }


		/// <summary>
		/// Toggle button outline color
		/// </summary>
		/// <value>The color of the outline.</value>
		public Color ButtonOutlineColor
		{
            set { SetButtonOutlineColor(value); } // @HACK(sjv): Some people think this is bad,
                                                  // but maybe they are the bad ones.
		}



		/// <summary>
		/// Gets or sets the color of the button background.
		/// </summary>
		public Color ButtonBackgroundColor { get; set; } = Color.White;



        /// <summary>
        /// Gets or sets the color of the selection.
        /// </summary>
        public Color ButtonSelectedBackgroundColor { get; set; } = Color.Blue;



        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        public Color ButtonFontColor { get; set; } = Color.White;



        /// <summary>
        /// Gets or sets the color of the selection font.
        /// </summary>
        public Color ButtonSelectionFontColor { get; set; } = Color.Blue;



        /// <summary>
        /// Gets or sets the button1 text.
        /// </summary>
        public string Button1Text 
        {
            get { return button1Label.Text; }
            set 
            {
                button1Label.Text = value;
            }

        }



		/// <summary>
		/// Gets or sets the button2 text.
		/// </summary>
		public string Button2Text
		{
			get { return button2Label.Text; }
			set
			{
				button2Label.Text = value;
			}

		}



		/// <summary>
		/// Gets or sets the button3 text.
		/// </summary>
		public string Button3Text
		{
			get { return button3Label.Text; }
			set
			{
				button3Label.Text = value;
			}

		}



        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        public double FontSize
        {
            get { return button1Label.FontSize; }
            set
            {
                button1Label.FontSize = value;
                button2Label.FontSize = value;
                button3Label.FontSize = value;
            }
        }



        /// <summary>
        /// Gets or sets the button1 header text.
        /// </summary>
        public string Button1HeaderText
        {
            get { return button1HeaderText.Text; }
            set { button1HeaderText.Text = value; }

        }



        /// <summary>
        /// Gets or sets the button2 header text.
        /// </summary>
		public string Button2HeaderText
		{
			get { return button2HeaderText.Text; }
			set { button2HeaderText.Text = value; }

		}



        /// <summary>
        /// Gets or sets the button3 header text.
        /// </summary>
		public string Button3HeaderText
		{
			get { return button3HeaderText.Text; }
			set { button3HeaderText.Text = value; }

		}


        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="T:MeemicMobileApp.CustomControls.ToggleButtonsControl"/> is button header visible.
        /// </summary>
        public bool IsButtonHeaderVisible
        {
            get { return button1HeaderText.IsVisible; }
            set { SetHeaderTextState(value); }
        }



        /// <summary>
        /// Gets or sets the font family.
        /// </summary>
        public string FontFamily 
        {
            set 
            {
                SetFontForButtons(value);
            }
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

            SetHeaderTextState(true);

        }


        private void SetHeaderTextState(bool visibility)
        {
            button1HeaderText.IsVisible = visibility;
            button2HeaderText.IsVisible = visibility;
            button3HeaderText.IsVisible = visibility;

            if (visibility == false)
            {
                Grid.SetRow(frameButton1, 0);
                Grid.SetRowSpan(frameButton1, 2);

                Grid.SetRow(frameButton2, 0);
                Grid.SetRowSpan(frameButton2, 2);

                Grid.SetRow(frameButton3, 0);
                Grid.SetRowSpan(frameButton3, 2);

            }

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



        private void SetButtonOutlineColor(Color color) 
        {
            for (int i = 0; i < buttons.Count; i++)
                buttons[i].OutlineColor = color;
        }


        private void SetFontForButtons(string font) 
        {
            for (int i = 0; i < buttons.Count; i++)
                if (buttons[0].Content is Label label)
                    label.FontFamily = font;
        }




        static void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as ToggleButtonsControl;
            var index = (int)newValue;

            control.SetActiveByIndex(index);
        }


    }
}
