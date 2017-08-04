using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace MeemicMobileApp.CustomControls
{
    public partial class ItemsContainerControl : ContentView
    {

        /// <summary>
        /// The items source property.
        /// </summary>
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(ItemsContainerControl), 
                                    null, propertyChanged: HandleBindingPropertyChangedDelegate);



        /// <summary>
        /// The item template property.
        /// </summary>
        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(ItemsContainerControl),
                                    null, propertyChanged: HandleBindingPropertyChangedDelegate);



        /// <summary>
        /// Gets or sets the items source.
        /// </summary>
        public IEnumerable ItemsSource 
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }



        /// <summary>
        /// Gets or sets the item template.
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }




        public ItemsContainerControl()
        {
            InitializeComponent();
        }


        protected void Populate()
        {
            if (ItemsSource == null || ItemTemplate == null)
                return;

            rootStackLayout.Children.Clear();

            foreach(var item in ItemsSource)
            {
                var view = (View)ItemTemplate.CreateContent();

                if (view is BindableObject bindableObject)
                    bindableObject.BindingContext = item;

                rootStackLayout.Children.Add(view);
            }

        }



        static void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            ((ItemsContainerControl)bindable).Populate();
        }
    }
}
