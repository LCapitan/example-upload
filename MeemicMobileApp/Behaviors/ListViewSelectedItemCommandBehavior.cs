using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeemicMobileApp.Behaviors
{
    public class ListViewSelectedItemCommandBehavior : Behavior<ListView>
    {
        private ListView listView;


        /// <summary>
        /// The command property.
        /// </summary>
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ListViewSelectedItemCommandBehavior), null);



        /// <summary>
        /// The converter property.
        /// </summary>
        public static readonly BindableProperty ConverterProperty =
            BindableProperty.Create("Converter", typeof(IValueConverter), typeof(ListViewSelectedItemCommandBehavior), null);



        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        public ICommand Command 
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }



        /// <summary>
        /// Gets or sets the converter.
        /// </summary>
        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(ConverterProperty); }
            set { SetValue(ConverterProperty, value); }
        }



        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            listView = bindable;

            listView.BindingContextChanged += ListView_BindingContextChanged;
            listView.ItemSelected += ListView_ItemSelected;
        }



        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);

			listView.ItemSelected -= ListView_ItemSelected;
			listView.BindingContextChanged -= ListView_BindingContextChanged;

            listView = null;
        }



        private void ListView_BindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }



        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            BindingContext = listView.BindingContext;
        }



        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
			if (Command == null)
				return;

			var parm = Converter.Convert(e, typeof(object), null, null);

			if (Command.CanExecute(parm))
				Command.Execute(parm);

		}
    }
}
