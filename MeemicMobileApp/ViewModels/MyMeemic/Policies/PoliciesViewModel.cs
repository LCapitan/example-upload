using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MeemicMobileApp.ViewModels.Base;

namespace MeemicMobileApp.ViewModels.MyMeemic.Policies
{
    public class PoliciesViewModel : BaseViewModel
    {
        private readonly List<Person> allDrivers;
        private readonly Dictionary<int, List<DocumentGroup>> documentsMap; 
        private int selectedFilterIndex = -1;

        /// <summary>
        /// Gets the insured.
        /// </summary>
        public ObservableCollection<Person> Insured { get; private set; }



        /// <summary>
        /// Gets the documents.
        /// </summary>
        public ObservableCollection<DocumentGroup> DocumentGroups { get; private set; }



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


        /// <summary>
        /// Gets or sets the index of the selected filter.
        /// </summary>
        public int SelectedFilterIndex 
        {
            get { return selectedFilterIndex; }
            set 
            {
                if(value != selectedFilterIndex && value <= documentsMap.Count())
                {
                    selectedFilterIndex = value;
                    DocumentGroups = new ObservableCollection<DocumentGroup>(documentsMap[selectedFilterIndex]);
                    // @TODO(sjv): We would sort here... or before on load
                    OnPropertyChanged("DocumentGroups");
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

            for (int i = 0; i < allDrivers.Count; i += 2)
            {
                var d1 = allDrivers[i];
                Person d2 = null;

                if ((i + 1) < allDrivers.Count)
                    d2 = allDrivers[i + 1];

                Drivers.Add(Tuple.Create(d1, d2));

                if (d2 == null)
                    break;
            }



            documentsMap = new Dictionary<int, List<DocumentGroup>>
            {
                {
                    0, new List<DocumentGroup>
                    {
                        new DocumentGroup
                        {
                            GroupName = null,
                            Documents = new ObservableCollection<Document>
                            {
                                new Document
                                {
                                    Name = "Declaration",
                                    FileURL = string.Empty,
                                    MailDate = "01/01/2016"
                                },
                                new Document
                                {
                                    Name = "Reinstatement Notice",
                                    FileURL = string.Empty,
                                    MailDate = "01/02/2016"
                                },
                                new Document
                                {
                                    Name = "Additional Documents",
                                    FileURL = string.Empty,
                                    MailDate = "01/05/2016"
                                }
                            }
                        },

						new DocumentGroup
						{
							GroupName = "Billing",
							Documents = new ObservableCollection<Document>
							{
								new Document
								{
									Name = "Billing #1",
									FileURL = string.Empty,
									MailDate = "04/01/2016"
								},
								new Document
								{
									Name = "Billing #2",
									FileURL = string.Empty,
									MailDate = "08/02/2016"
								},
								new Document
								{
									Name = "Declaration",
									FileURL = string.Empty,
									MailDate = "01/01/2016"
								},
								new Document
								{
									Name = "Reinstatement Notice",
									FileURL = string.Empty,
									MailDate = "01/02/2016"
								},
								new Document
								{
									Name = "Additional Documents",
									FileURL = string.Empty,
									MailDate = "01/05/2016"
								}
							}
						},

						new DocumentGroup
						{
							GroupName = "Billing",
							Documents = new ObservableCollection<Document>
							{
								new Document
								{
									Name = "Billing #1",
									FileURL = string.Empty,
									MailDate = "04/01/2016"
								},
								new Document
								{
									Name = "Billing #2",
									FileURL = string.Empty,
									MailDate = "08/02/2016"
								}
							}
						}
                    }
                },
                { 1, new List<DocumentGroup>
					{
						new DocumentGroup
						{
							GroupName = null,
							Documents = new ObservableCollection<Document>
							{
								new Document
								{
									Name = "Declaration",
									FileURL = string.Empty,
									MailDate = "01/01/2017"
								},
								new Document
								{
									Name = "More Documents",
									FileURL = string.Empty,
									MailDate = "01/05/2017"
								}
							}
						},

						new DocumentGroup
						{
							GroupName = "Billing",
							Documents = new ObservableCollection<Document>
							{
								new Document
								{
									Name = "Billing #12",
									FileURL = string.Empty,
									MailDate = "10/01/2017"
								},
								new Document
								{
									Name = "Billing #32",
									FileURL = string.Empty,
									MailDate = "11/04/2017"
								},
                                new Document
								{
									Name = "Billing #14",
									FileURL = string.Empty,
									MailDate = "03/04/2017"
								}
							}
						}
					}
				},
				{ 2, new List<DocumentGroup>
					{
						new DocumentGroup
						{
							GroupName = null,
							Documents = new ObservableCollection<Document>
							{
								new Document
								{
									Name = "More Documents",
									FileURL = string.Empty,
									MailDate = "01/01/2018"
								}
							}
						}
					}
				}
            };

            SelectedFilterIndex = 0;

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


    public class DocumentGroup 
    {
        public string GroupName { get; set; }
        public ObservableCollection<Document> Documents { get; set; }
    }


    public class Document
    {

        public string Name { get; set; }
		public string MailDate { get; set; }
        public string FileURL { get; set; }
    }



    public enum Gender
    {
        Unknown,
        Male,
        Female
    }
}
