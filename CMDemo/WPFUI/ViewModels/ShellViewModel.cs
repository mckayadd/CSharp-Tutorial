using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Screen
    {
		private string _firstName = "John";

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

		private string _lastName = "Doe";
				
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


	}
}
