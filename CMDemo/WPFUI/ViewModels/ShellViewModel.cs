using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object> //Screen
    {
		private string _firstName = "John";
        private string _lastName = "Doe";
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        public ShellViewModel()
        {
				People.Add(new PersonModel { FirstName = "Kedi", LastName = "Can" });
				People.Add(new PersonModel { FirstName = "Kangal", LastName = "Kopek" });
				People.Add(new PersonModel { FirstName = "Zurefa", LastName = "Zurafa" });
        }

        public string FirstName
		{
			get 
			{ 
				return _firstName; 
			}
			set 
			{ 
				_firstName = value; 
				NotifyOfPropertyChange(() => FirstName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		
				
		public string LastName
		{
			get 
			{ 
				return _lastName; 
			}
			set 
			{ 
				_lastName = value; 
				NotifyOfPropertyChange(() => LastName);
				NotifyOfPropertyChange(() => FullName);
			}
		}


		public string FullName
		{
			get 
			{ 
				return $"{FirstName} {LastName}"; 
			}
		}

		

		public BindableCollection<PersonModel> People
		{
			get { return _people; }
			set { _people = value; }
		}


		public PersonModel SelectedPerson
		{
			get 
			{
				return _selectedPerson; 
			}
			set 
			{ 
				_selectedPerson = value; 
				NotifyOfPropertyChange(() => SelectedPerson);
			}
		}

		public bool CanClearText(string firstName, string lastName) // => !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);
		{
			// throw new NotImplementedException();
			//return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
			if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public void ClearText(string firstName, string lastName)
		{
			FirstName = "";
			LastName = "";
		}

		public void LoadPageOne()
		{
            ActivateItemAsync(new FirstChildViewModel());
		}

        public void LoadPageTwo()
        {
            ActivateItemAsync(new SecondChildViewModel());
        }

    }
}
