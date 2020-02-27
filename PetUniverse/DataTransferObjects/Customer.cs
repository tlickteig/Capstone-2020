using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
	/// <summary>
	/// Creator: Mohamed Elamin
	/// Created: 2020/02/19
	/// Approver: Thomas Dupuy , 2020/02/19 
	///
	/// This Class for creating  the properties of Customer.
	/// </summary>
	public class Customer
    {
		public int CustomerID { get; set; }
		public int UserID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public bool Activ { get; set; }
		public string AddressLineOne { get; set; }
		public string AddressLineTwo { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public int SupervisorID { get; set; }
	}
}
