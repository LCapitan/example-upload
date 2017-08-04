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
            BindableProperty.Create("SelectedIndex", typeof(int), typeof(ToggleButtonsControl), -1);



        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        public int SelectedIndex 
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            private set { SetValue(SelectedIndexProperty, value); }
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

            SetActiveButton(frame);
            SelectedIndex = buttons.IndexOf(frame);

            var notSelected = buttons.Where(f => f != frame);
            DeactivateButtons(notSelected);
        }



        private void SetActiveButton(Frame frame) 
        {
            frame.BackgroundColor = Color.Blue;
        }



        private void SetDeactiveButton(Frame frame)
        {
            frame.BackgroundColor = Color.White;
        }



        private void DeactivateButtons(IEnumerable<Frame> frames)
        {
            foreach (var frame in frames)
            {
                SetDeactiveButton(frame);
            }
        }



    }
}
