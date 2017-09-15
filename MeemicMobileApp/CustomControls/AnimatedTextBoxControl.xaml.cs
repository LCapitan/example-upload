using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeemicMobileApp.CustomControls
{
    public partial class AnimatedTextBoxControl : ContentView
    {
        public AnimatedTextBoxControl()
        {
            InitializeComponent();

            entryField.Focused += EntryFieldFocused;
            entryField.Unfocused += EntryFieldLostFocus;
        }

        async void EntryFieldFocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(entryField.Text))
                await placeHolderText.TranslateTo(0, -entryField.Height+(placeHolderText.Height / 2.0), 100, Easing.SinInOut);
        }

		async void EntryFieldLostFocus(object sender, FocusEventArgs e)
		{
            if (string.IsNullOrEmpty(entryField.Text))
                await placeHolderText.TranslateTo(0, 0, 100, Easing.SinInOut);
		}


        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (placeHolderText.Y > 0.1f)
                await placeHolderText.TranslateTo(placeHolderText.X, 0, 1000, Easing.SinInOut);
            else 
                await placeHolderText.TranslateTo(placeHolderText.X, -entryField.Height, 1000, Easing.SinInOut);
        }
    }
}
