using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
	/// <summary>
	/// Creator: Awaab Elamin
	/// Created: 2020/02/04
	/// Approver
	///
	/// Class contains all reviewer Accessor
	/// </summary>
	public class ReviewerAccessor : IAdoptionAccessor
	{
		public ReviewerAccessor()
		{
		}

		/// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/15
		/// Approver: Mohamed Elamin , 2/21/2020
		/// 
		/// Update stauts of addoption application
		/// to "Interviewer" or Deny
		/// According to Reviewer Decision 
		/// </summary>
		/// Updater Awaab Elamin
		/// Updated:  3/3/2020
		/// Approver: Mohamed Elamin , 3/4/2020
		/// Update: update the status of the adoption application to any status that include in the 
		/// AdoptionApplicationTable
		/// 
		/// <remarks>
		/// </remarks>
		/// <param name="decision"></param>
		public int changeAdoptionApplicationStatus(int adoptionApplicationID, string decision)
		{
			int count = 0;
			var conn = DBConnection.GetConnection();
			string cmdText = @"sp_update_adoption_application_status";
			var cmd = new SqlCommand(cmdText, conn);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.Add("@AdoptionApplicationID", SqlDbType.Int);
			cmd.Parameters.Add("@status", SqlDbType.NVarChar, 100);

			cmd.Parameters["@AdoptionApplicationID"].Value = adoptionApplicationID;

		
				cmd.Parameters["@status"].Value = decision;
			
			try
			{
				conn.Open();
				count = cmd.ExecuteNonQuery();
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				conn.Close();
			}

			return count;
		}

		/// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/15
		/// Approver: Mohamed Elamin , 2/21/2020
		/// 
		/// retrieve Adoption Application 
		/// for a customer 
		/// from Customer Questionnar table
		/// by his ID
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="customerEmail"></param>
		public AdoptionApplication getAdoptionApplicationByCustomerEmail(string customerEmail)
		{
			AdoptionApplication adoptionApplication = new AdoptionApplication();

		//	var conn = DBConnection.GetConnection();
		//	string cmdText = @"sp_get_Adoption_Application_By_CustomerID";
		//	var cmd = new SqlCommand(cmdText, conn);
		//	cmd.CommandType = CommandType.StoredProcedure;

		//	cmd.Parameters.Add("@customerID", SqlDbType.Int);
		//	cmd.Parameters["@customerID"].Value = customerID;

		//	try
		//	{
		//		conn.Open();
		//		SqlDataReader reader = cmd.ExecuteReader();
		//		if (reader.HasRows)
		//		{
		//			while (reader.Read())
		//			{

		//				adoptionApplication.AdoptionApplicationID = reader.GetInt32(0);
		//				adoptionApplication.CustomerName = getCustomerLastName(customerID);
		//				adoptionApplication.AnimalName = getAnimalName(reader.GetInt32(1));
		//				adoptionApplication.Status = reader.GetString(2);
		//				adoptionApplication.RecievedDate = reader.GetDateTime(3);
		//			}
		//			reader.Close();
		//		}
		//	}
		//	catch (Exception)
		//	{

		//		throw;
		//	}
		//	finally
		//	{
		//		conn.Close();
		//	}
			return adoptionApplication;
		}

		/// <summary>
		/// method to get all Adoption Applications
		/// </summary>
		/// <remarks>
		/// Created by Awaab Elamin 4/2/2020
		/// 
		/// </remarks>
		/// <reviewed>
		/// Mohamed Elamin , 2/21/2020
		/// </reviewed>
		/// <returns></returns>
		public List<AdoptionApplication> getAllAdoptionApplication()
		{
			List<AdoptionApplication> adoptionApplications = new List<AdoptionApplication>();

			var conn = DBConnection.GetConnection();
			string cmdText = @"sp_get_Adoption_Application";
			var cmd = new SqlCommand(cmdText, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						AdoptionApplication adoptionApplication = new AdoptionApplication();
						adoptionApplication.AdoptionApplicationID = reader.GetInt32(0);
						adoptionApplication.CustomerEmail = reader.GetString(1);
						adoptionApplication.AnimalName = reader.GetString(2);
						adoptionApplication.Status = reader.GetString(3);
						adoptionApplication.RecievedDate = reader.GetDateTime(4);
						adoptionApplications.Add(adoptionApplication);
					}
					reader.Close();
				}
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				conn.Close();
			}
			return adoptionApplications;

		}
		/// <summary>
		/// retrieve the animal name from the animal table
		/// </summary>
		/// <param name="animalID"> it is the animal id</param>
		/// <returns> the animal name</returns>
		/// <remarks>
		/// by Awaab Elamin 2/5/2020
		/// Mohamed Elamin , 2/21/2020
		/// 
		/// </remarks>
		private string getAnimalName(int animalID)
		{
			string animalName = "";
			var conn = DBConnection.GetConnection();
			string cmdText = @"sp_get_animal_by_id";
			var cmd = new SqlCommand(cmdText, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@animalId", SqlDbType.Int);
			cmd.Parameters["@animalId"].Value = animalID;
			try
			{
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					reader.Read();
					Animal animal = new Animal();
					animal.AnimalID = reader.GetInt32(0);
					animal.AnimalName = reader.GetString(1);
					animal.Dob = reader.GetDateTime(2);
					animal.AnimalBreed = reader.GetString(3);
					animal.ArrivalDate = reader.GetDateTime(4);
					animal.CurrentlyHoused = reader.GetBoolean(5);
					animal.Adoptable = reader.GetBoolean(6);
					animal.Active = reader.GetBoolean(7);
					animal.AnimalSpeciesID = reader.GetString(8);

					animalName = animal.AnimalName;

				}

				reader.Close();
			}
			catch (Exception)
			{

				throw;
			}
			return animalName;
		}

		/// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/15
		/// Approver: Mohamed Elamin , 2/21/2020
		/// 
		/// retrieve Customer record from customer table by his last name
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="customerLastName"></param>
		public AdoptionCustomer getCustomerByCustomerName(string customerLastName)
		{
			AdoptionCustomer ourCustomer = new AdoptionCustomer();
			//List<AdoptionCustomer> customers = new List<AdoptionCustomer>();
			//var conn = DBConnection.GetConnection();
			//string cmdText = @"sp_select_all_active_users";
			//var cmd = new SqlCommand(cmdText, conn);
			//cmd.CommandType = CommandType.StoredProcedure;
			//try
			//{
			//	conn.Open();
			//	SqlDataReader reader = cmd.ExecuteReader();
			//	if (reader.HasRows)
			//	{
			//		while (reader.Read())
			//		{
			//			AdoptionCustomer activeCustomer = new AdoptionCustomer();
			//			activeCustomer.CustomerID = reader.GetInt32(0);
			//			activeCustomer.FirstName = reader.GetString(1);
			//			activeCustomer.LastName = reader.GetString(2);
			//			activeCustomer.PhoneNumber = reader.GetString(3);
			//			activeCustomer.Email = reader.GetString(4);
			//			activeCustomer.Active = true;
			//			customers.Add(activeCustomer);
			//		}
			//		reader.Close();
			//	}
			//	foreach (AdoptionCustomer customer in customers)
			//	{
			//		if (customer.LastName == customerLastName)
			//		{
			//			int customerID = getCustomerID(customer.CustomerID);
			//			ourCustomer = customer;
			//			ourCustomer.CustomerID = customerID;
			//		}
			//	}
			//}
			//catch (Exception)
			//{

			//	throw;
			//}
			//finally
			//{
			//	conn.Close();
			//}
			return ourCustomer;
		}

		/// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/25
		/// 
		/// retrieve Customer id from customer table by his userID
		/// </summary>
		/// <remarks>
		/// Updated by : Awaab Elamin
		/// Date: 3/16/2020
		/// After Customer Table updated in DB, we don not need to below method
		/// </remarks>
		/// <param name="customerLastName"></param>
		//private int getCustomerID(int userID)
		//{
		//	int customerID = 0;
		//	List<AdoptionCustomer> customers = new List<AdoptionCustomer>();
		//	var conn = DBConnection.GetConnection();
		//	string cmdText = @"sp_get_CustomerID_By_User_ID";
		//	var cmd = new SqlCommand(cmdText, conn);
		//	cmd.CommandType = CommandType.StoredProcedure;
		//	cmd.Parameters.Add("@UserID", SqlDbType.Int);
		//	cmd.Parameters["@UserID"].Value = userID;
		//	try
		//	{
		//		conn.Open();
		//		SqlDataReader reader = cmd.ExecuteReader();
		//		if (reader.HasRows)
		//		{
		//			while (reader.Read())
		//			{
		//				customerID = reader.GetInt32(0);
		//			}
		//			reader.Close();
		//		}

		//	}
		//	catch (Exception)
		//	{

		//		throw;
		//	}
		//	finally
		//	{
		//		conn.Close();
		//	}
		//	return customerID;
		//}

		/// <summary>
		/// retrieve the customer full name "first and last
		/// </summary>
		/// <param name="customerID"></param>
		/// <returns> FirstName + Last name</returns>
		/// /// <remarks>
		/// by Awaab Elamin 2/5/2020
		/// Mohamed Elamin , 2/21/2020
		/// </remarks>
		public string getCustomerLastName(int customerID)
		{
			String customerName = null;

			var conn = DBConnection.GetConnection();
			string cmdText = @"sp_select_CustomerName_by_CustomerID";
			var cmd = new SqlCommand(cmdText, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@customerId", SqlDbType.Int);
			cmd.Parameters["@CustomerID"].Value = customerID;
			try
			{
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					reader.Read();

					customerName = reader.GetString(1);

				}

				reader.Close();
			}
			catch (Exception)
			{

				throw;
			}
			return customerName;

		}

		/// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/15
		/// Approver: Mohamed Elamin , 2/21/2020
		/// 
		/// retrieve Qyestionnar syntax  from General Questionnair by its ID
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="questionID"></param>
		public string getQestionDescription(int questionID)
		{
			String questionDescription = null;

			var conn = DBConnection.GetConnection();
			string cmdText = @"sp_get_question_description_by_questionId";
			var cmd = new SqlCommand(cmdText, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@QuestionID", SqlDbType.Int);
			cmd.Parameters["@QuestionID"].Value = questionID;
			try
			{
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					reader.Read();
					questionDescription = reader.GetString(0);

				}

				reader.Close();
			}
			catch (Exception)
			{

				throw;
			}
			return questionDescription;
		}

		/// <summary>
		/// Creator: Awaab Elamin
		/// Created: 2020/02/15
		/// Approver: Mohamed Elamin , 2/21/2020
		/// 
		/// retrieve Customer Questionnair record from customers Questionnairs table by his ID
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="customerID"></param>
		public List<CustomerQuestionnar> getCustomerQuestionnair(string customerEmail)
		{
			List<CustomerQuestionnar> customerQuestionnars = new List<CustomerQuestionnar>();
			var conn = DBConnection.GetConnection();
			string cmdText = @"sp_get_Customer_Answer_By_CustomrEmail";
			var cmd = new SqlCommand(cmdText, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@CustomerEmail", customerEmail);
			try
			{
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						CustomerQuestionnar customerQuestionnar
							= new CustomerQuestionnar();
						customerQuestionnar.QuestionDescription= reader.GetString(0);
						customerQuestionnar.Answer = reader.GetString(1);
						customerQuestionnars.Add(customerQuestionnar);
					}
					reader.Close();
				}
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				conn.Close();
			}
			return customerQuestionnars;
		}

		public List<CustomerQuestionnar> getAllQuestions()
		{
			List<CustomerQuestionnar> customerQuestionnars = new List<CustomerQuestionnar>();
			var conn = DBConnection.GetConnection();
			string cmdText = @"sp_get_all_General_Questions";
			var cmd = new SqlCommand(cmdText, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						CustomerQuestionnar customerQuestionnar
							= new CustomerQuestionnar();
						customerQuestionnar.QuestionDescription = reader.GetString(0);
						customerQuestionnars.Add(customerQuestionnar);
					}
					reader.Close();
				}
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				conn.Close();
			}
			return customerQuestionnars;
		}

		public bool insertAdoptionApplication(MVCAdoptionApplication adoptionApplication)
		{
			bool result = false;
			var conn = DBConnection.GetConnection();
			var cmd = new SqlCommand("sp_add_new_adoptionApplication", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@CustomerEmail", adoptionApplication.CustomerEmail);
			cmd.Parameters.AddWithValue("@RecievedDate", adoptionApplication.RecievedDate);
			cmd.Parameters.AddWithValue("@Status", adoptionApplication.Status);
			cmd.Parameters.AddWithValue("@AnimalID", adoptionApplication.AnimalID);
			try
			{
				conn.Open();
				if ((int)cmd.ExecuteNonQuery() == 1)
				{
					result = true;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				conn.Close();
			}
			return result;
		}

		
	}
}
