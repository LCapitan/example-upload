using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using MeemicMobileApp.ViewModels.Base;

namespace MeemicMobileApp.ViewModels.MyMeemic
{
    public class PoliciesViewModel : BaseViewModel
    {
        private readonly List<Person> allDrivers;
        private readonly Dictionary<int, List<Document>> documentsMap; 
        private int selectedFilterIndex = -1;

        /// <summary>
        /// Gets the insured.
        /// </summary>
        public ObservableCollection<Person> Insured { get; private set; }



        /// <summary>
        /// Gets the documents.
        /// </summary>
        public ObservableCollection<Document> Documents { get; private set; }



        /// <summary>
        /// Gets the drivers.
        /// </summary>
        /// <value>The drivers.</value>
        public ObservableCollection<Tuple<Person, Person>> Drivers { get; private set; }



        /// <summary>
        /// Gets or sets the current policy.
        /// </summary>
        public Policy CurrentPolicy { get; set; }


        /// <summary>
        /// Gets the properties.
        /// </summary>
        public ObservableCollection<Property> Properties { get; private set; }


        public int SelectedFilterIndex 
        {
            get { return selectedFilterIndex; }
            set 
            {
                if(value != selectedFilterIndex)
                {
                    selectedFilterIndex = value;
                }

            }

        }



        /// <summary>
        /// Constructor
        /// </summary>
        public PoliciesViewModel()
        {

            // @NOTE(sjv): This test data should be moved elsewhere...

            allDrivers = new List<Person>
            {
				new Person
				{
					FirstName = "Bradford",
					LastName = "Buckley",
					Gender = Gender.Male,
                    IsPrimary = true,
                    IsInsured = true
				},
				new Person
				{
					FirstName = "Betty",
					LastName = "Buckley",
					Gender = Gender.Female,
                    IsPrimary = false,
                    IsInsured = true
				},
				new Person
				{
					FirstName = "Steve",
					LastName = "Buckley",
					Gender = Gender.Male,
                    IsPrimary = false,
                    IsInsured = false
                                   
				},
				new Person
				{
					FirstName = "Mary",
					LastName = "Buckley",
					Gender = Gender.Female,
                    IsPrimary = false,
                    IsInsured = false
				},
				new Person
				{
					FirstName = "Frank",
					LastName = "Buckley",
					Gender = Gender.Male,
					IsPrimary = false,
                    IsInsured = true
				}
            };

            Insured = new ObservableCollection<Person>(allDrivers.Where(d => d.IsInsured));
            Drivers = new ObservableCollection<Tuple<Person, Person>>();
            Properties = new ObservableCollection<Property>
            {
                new Property
                {
                     ID = "BH83478374",
                    Name = "2008 Honda Prius"
                }
            };

            for (int i = 0; i < allDrivers.Count; i+=2)
            {
                var d1 = allDrivers[i];
                Person d2 = null;

                if((i + 1) < allDrivers.Count)
                    d2 = allDrivers[i + 1];

                Drivers.Add(Tuple.Create(d1, d2));

                if (d2 == null)
                    break;
            }






            OnPropertyChanged("Drivers");
            OnPropertyChanged("Insured");
            OnPropertyChanged("Properties");
        }
    }



    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsInsured { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }



    public class Property
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public enum PropertyType { Auto, Boat, House }
        public PropertyType Type { get; set; }
        public string FormattedID 
        {
            get 
            {
                switch (this.Type)
                {
                    case PropertyType.Auto:
                        return $"VIN {ID}";
                    case PropertyType.Boat:
                        return $"VIN {ID}";
                    case PropertyType.House:
                        return $"HID {ID}";
                }

                return ID;
            }
        }
    }


    public class Document
    {

        public string Name { get; set; }
		public DateTime MailDate { get; set; }
        public string Group { get; set; }
        public string FileURL { get; set; }
    }



    public enum Gender
    {
        Unknown,
        Male,
        Female
    }
}
