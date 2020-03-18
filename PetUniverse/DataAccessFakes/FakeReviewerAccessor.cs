using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/05
    /// Approver: Mohamed Elamin , 2/21/2020
    /// 
    /// create a fake accessor for reviewer for testing
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class FakeReviewerAccessor : IAdoptionAccessor
{
    private List<AdoptionApplication> adoptionApplications = null;
    private List<AdoptionCustomer> customers = null;
    private List<CustomerQuestionnar> customerQuestionnars = null;
    private List<GeneralQuestion> generalQuestions = null;

    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/05
    /// Approver: Mohamed Elamin , 2/21/2020
    /// 
    /// default constructor intialays the private lists to work as fake data base
    /// </summary>
    ///
    /// <remarks>
    /// Updater Awaab Elamin
    /// Updated: 2020/02/15 
    /// Update: (Add General questions list values)
    /// </remarks>    
    public FakeReviewerAccessor()
    {
        adoptionApplications = new List<AdoptionApplication>()
            {
                new AdoptionApplication()
                {
                    AdoptionApplicationID = 10000,
                    CustomerEmail = "Awaab@Awaaab.com",
                    AnimalName = "Bebe",
                    Status = "Reviewer",
                    RecievedDate = DateTime.Now.Date
                },
                new AdoptionApplication()
                {
                    AdoptionApplicationID = 10001,
                    CustomerEmail = "AwaabElamin@Gmail.com",
                    AnimalName = "Bebe",
                    Status = "Reviewer",
                    RecievedDate = DateTime.Now.Date
                },
                new AdoptionApplication()
                {
                    AdoptionApplicationID = 10002,
                    CustomerEmail = "Awaab@live.com",
                    AnimalName = "Bebe",
                    Status = "Reviewer",
                    RecievedDate = DateTime.Now.Date
                },
                new AdoptionApplication()
                {
                    AdoptionApplicationID = 10003,
                    CustomerEmail = "Awaab_Elamin@Student.Kirkwood.edu",
                    AnimalName = "Bebe",
                    Status = "Reviewer",
                    RecievedDate = DateTime.Now.Date
                },
            };
        customers = new List<AdoptionCustomer>()
            {
                new AdoptionCustomer()
                {
                    CustomerEmail = "Awaab@Awaaab.com",
                    FirstName = "Awaab",
                    LastName = "Elamin",
                    PhoneNumber = "3192104964",
                    AddressLineOne = "3000 J St SW",
                    AddressLineTwo = "Apt 105",
                    City = "Cedar Rapids",
                    State = "IA",
                    Zipcode = "52404",
                    Active = true
                },
                new AdoptionCustomer()
                {
                    CustomerEmail = "AwaabElamin@Gmail.com",
                    FirstName = "Addallah",
                    LastName = "Ali",
                    PhoneNumber = "3192104964",
                    AddressLineOne = "3000 J St SW",
                    AddressLineTwo = "Apt 105",
                    City = "Cedar Rapids",
                    State = "IA",
                    Zipcode = "52404",
                    Active = true
                },
                new AdoptionCustomer()
                {
                    CustomerEmail = "Awaab@live.com",
                    FirstName = "AbelSamee",
                    LastName = "Tomsah",
                    PhoneNumber = "3192104964",
                    AddressLineOne = "3000 J St SW",
                    AddressLineTwo = "Apt 105",
                    City = "Cedar Rapids",
                    State = "IA",
                    Zipcode = "52404",
                    Active = true
                },
                new AdoptionCustomer()
                {
                    CustomerEmail = "Awaab_Elamin@Student.Kirkwood.edu",
                    FirstName = "Adam",
                    LastName = "Saleem",
                    PhoneNumber = "3192104964",
                    AddressLineOne = "3000 J St SW",
                    AddressLineTwo = "Apt 105",
                    City = "Cedar Rapids",
                    State = "IA",
                    Zipcode = "52404",
                    Active = true
                },
                new AdoptionCustomer()
                {
                    CustomerEmail = "Awaab@PetUniversal.com",
                    FirstName = "Steph",
                    LastName = "Wiliam",
                    PhoneNumber = "3192104964",
                    AddressLineOne = "3000 J St SW",
                    AddressLineTwo = "Apt 105",
                    City = "Cedar Rapids",
                    State = "IA",
                    Zipcode = "52404",
                    Active = true
                },
                new AdoptionCustomer()
                {
                    CustomerEmail = "Awaab_Elamin@Awab.com",
                    FirstName = "Kamal",
                    LastName = "AlAraby",
                    PhoneNumber = "3192104964",
                    AddressLineOne = "3000 J St SW",
                    AddressLineTwo = "Apt 105",
                    City = "Cedar Rapids",
                    State = "IA",
                    Zipcode = "52404",
                    Active = true
                },
                new AdoptionCustomer()
                {
                    CustomerEmail = "Awaab_Elamin2@Awab.com",
                    FirstName = "Ali",
                    LastName = "Taha",
                    PhoneNumber = "3192104964",
                    AddressLineOne = "3000 J St SW",
                    AddressLineTwo = "Apt 105",
                    City = "Cedar Rapids",
                    State = "IA",
                    Zipcode = "52404",
                    Active = true
                },
            };
        customerQuestionnars = new List<CustomerQuestionnar>()
            {
                new CustomerQuestionnar()
                {
                    QuestionDescription = "Q1",
                    Answer = "Answer1"
                },
                new CustomerQuestionnar()
                {
                   QuestionDescription = "Q2",
                    Answer = "Answer2"
                },
                new CustomerQuestionnar()
                {
                    QuestionDescription = "Q3",
                    Answer = "Answer3"
                },
                new CustomerQuestionnar()
                {
                    QuestionDescription = "Q4",
                    Answer = "Answer4"
                },
                new CustomerQuestionnar()
                {
                   QuestionDescription = "Q5",
                    Answer = "Answer5"
                },
                new CustomerQuestionnar()
                {
                   QuestionDescription = "Q6",
                    Answer = "Answer6"
                },
                new CustomerQuestionnar()
                {
                    QuestionDescription = "Q7",
                    Answer = "Answer7"
                },
                new CustomerQuestionnar()
                {
                   QuestionDescription = "Q8",
                    Answer = "Answer8"
                },
                new CustomerQuestionnar()
                {
                    QuestionDescription = "Q9",
                    Answer = "Answer9"
                },
                new CustomerQuestionnar()
                {
                   QuestionDescription = "Q10",
                    Answer = "Answer10"
                }

            };
        generalQuestions = new List<GeneralQuestion>()
            {
                new GeneralQuestion()
                {
                    QuestionID = 10000,
                    Description = "Question1"
                },
                new GeneralQuestion()
                {
                    QuestionID = 10001,
                    Description = "Question2"
                },
                new GeneralQuestion()
                {
                    QuestionID = 10002,
                    Description = "Question3"
                },
                new GeneralQuestion()
                {
                    QuestionID = 10003,
                    Description = "Question4"
                },
                new GeneralQuestion()
                {
                    QuestionID = 10004,
                    Description = "Question5"
                },
                new GeneralQuestion()
                {
                    QuestionID = 10005,
                    Description = "Question6"
                },
                new GeneralQuestion()
                {
                    QuestionID = 10006,
                    Description = "Question7"
                },
                new GeneralQuestion()
                {
                    QuestionID = 10007,
                    Description = "Question8"
                },
                new GeneralQuestion()
                {
                    QuestionID = 10008,
                    Description = "Question9"
                },
                new GeneralQuestion()
                {
                    QuestionID = 10009,
                    Description = "Question10"
                },
            };

    }
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/15
    /// Approver: Mohamed Elamin , 2/21/2020
    /// 
    /// change the status of the Adoption Apllication status to "Interviewer"
    /// if the reviewer decision is approved. 
    /// if he reviewer decision was "deny" the status of the Adoption apllication will change
    /// to deny.
    /// </summary>
    ///
    /// <remarks>
    /// </remarks>
    /// <param name="adoptionApplicationID"></param>
    /// <param name="decision"></param>
    public int changeAdoptionApplicationStatus(int adoptionApplicationID, string decision)
    {
        int rowsEffects = 0;
        foreach (AdoptionApplication adoptionApplication in adoptionApplications)
        {
            if (adoptionApplicationID == adoptionApplication.AdoptionApplicationID)
            {
                if (decision == "approved")
                {
                    rowsEffects = 1;
                    adoptionApplication.Status = "Interviewer";
                }
                else
                {
                    rowsEffects = 1;
                    adoptionApplication.Status = "Deny";
                }
                break;
            }
        }
        return rowsEffects;
    }

    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/15
    /// Approver: Mohamed Elamin , 2/21/2020
    /// 
    /// retrieve the Adoption Apllication of specific customer
    /// according to his ID
    /// </summary>
    /// <remarks>
    /// Updated by: Awaab Elamin
    /// Date: 3/15/2020
    /// 
    /// Updated to get Adoption Application by Customer Email neither than Customer ID
    /// According to DB update
    /// </remarks>
    /// <param name="customerEmail"></param>
    public AdoptionApplication getAdoptionApplicationByCustomerEmail(String customerEmail)
    {
        AdoptionApplication adoptionApplication = new AdoptionApplication();
        //string customerLastName = "";
        //foreach (AdoptionCustomer customer in customers)
        //{
        //    if (customerID == customer.CustomerID)
        //    {
        //        customerLastName = customer.LastName;
        //        break;
        //    }
        //    foreach (AdoptionApplication adoption in adoptionApplications)
        //    {
        //        if (adoption.CustomerName == customerLastName)
        //        {
        //            adoptionApplication = adoption;
        //            break;
        //        }
        //    }
        //}

        return adoptionApplication;
    }

    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/15
    /// Approver: Mohamed Elamin , 2/21/2020
    /// 
    /// retrieve All Adoption Apllications
    /// </summary>
    /// <remarks>
    /// </remarks>
    public List<AdoptionApplication> getAllAdoptionApplication()
    {

        return adoptionApplications;
    }

    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/15
    /// Approver: Mohamed Elamin , 2/21/2020
    /// 
    /// select the customer record from the customer list
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="customerLastName"></param>
    public AdoptionCustomer getCustomerByCustomerName(string customerLastName)
    {
        AdoptionCustomer ReturnCustomer = new AdoptionCustomer();
        foreach (AdoptionCustomer customer in customers)
        {
            if (customer.LastName == customerLastName)
            {
                ReturnCustomer = customer;
                break;
            }
        }
        return ReturnCustomer;
    }

    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/05
    /// Approver: Mohamed Elamin , 2/21/2020
    /// 
    /// retrieve the customer last name from the customer table
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="customerID">int</param>

    public string getCustomerLastName(int customerID)
    {
        string customerLastName = "";
        //foreach (AdoptionCustomer customer in customers)
        //{
        //    if (customer.CustomerID == customerID)
        //    {
        //        customerLastName = customer.LastName;
        //        break;
        //    }
        //}
        return customerLastName;
    }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/05
        /// Approver: Mohamed Elamin , 2/21/2020
        /// 
        /// retrieve all Adoption Apllications 
        /// </summary>
        /// <remarks>
        /// </remarks>
        public List<CustomerQuestionnar> getCustomerQuestionnair(string customerEmail)
        {
            return customerQuestionnars;
        }


        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/05
        /// Approver: Mohamed Elamin , 2/21/2020
        /// 
        /// retrieve the qustion syntax from the General question table according qusetion Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="questionID">
        /// represent the question number
        /// </param>
        public string getQestionDescription(int questionID)
    {
        string returnQDescription = "";
        foreach (GeneralQuestion question in generalQuestions)
        {
            if (question.QuestionID == questionID)
            {
                returnQDescription = question.Description;
                break;
            }
        }
        return returnQDescription;
    }
}
}
