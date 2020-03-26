using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Josh Jackson
    /// DATE: 02/07/2020
    /// Checked By: Ethan H, Gabi L
    /// This is a data access class used for Volunteer record - DB interactions
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Josh Jackson
    /// UPDATE DATE: 02/13/2020
    /// WHAT WAS CHANGED: added GetVolunteerByName() method
    /// </remarks>
    public class VolunteerAccessor : IVolunteerAccessor
    {
        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/12/2020
        /// Checked By: Timothy Lickteig
        /// This is a data access method to change a volunteers active status to 1 - true
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        public int ActivateVolunteer(int volunteerID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_reactivate_volunteer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VolunteerID", volunteerID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/12/2020
        /// Checked By: Timothy Lickteig
        /// This is a data access method to change a volunteers active status to 0 - false
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        public int DeactivateVolunteer(int volunteerID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_volunteer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VolunteerID", volunteerID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/06/2020
        /// Checked By: Zoey M
        /// This is a data access method querying a Volunteer by first name
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="wholeName"></param>
        /// <returns></returns>
        public List<Volunteer> GetVolunteerByFirstName(string wholeName)
        {
            List<Volunteer> vol = new List<Volunteer>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_volunteer_by_first_name");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 500);
            cmd.Parameters["@FirstName"].Value = wholeName;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var volunteer = new Volunteer();
                    volunteer.VolunteerID = reader.GetInt32(0);
                    volunteer.FirstName = wholeName;
                    volunteer.LastName = reader.GetString(2);
                    volunteer.Email = reader.GetString(3);
                    volunteer.PhoneNumber = reader.GetString(4);
                    volunteer.OtherNotes = reader.GetString(5);
                    volunteer.Active = reader.GetBoolean(6);
                    vol.Add(volunteer);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vol;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/14/2020
        /// Checked By: Gabi L
        /// This is a data access method querying a Volunteer by first and last name
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public List<Volunteer> GetVolunteerByName(string firstName, string lastName)
        {
            List<Volunteer> vol = new List<Volunteer>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_volunteer_by_name");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 500);
            cmd.Parameters["@FirstName"].Value = firstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 500);
            cmd.Parameters["@LastName"].Value = lastName;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var volunteer = new Volunteer();
                    volunteer.VolunteerID = reader.GetInt32(0);
                    volunteer.FirstName = firstName;
                    volunteer.LastName = lastName;
                    volunteer.Email = reader.GetString(3);
                    volunteer.PhoneNumber = reader.GetString(4);
                    volunteer.OtherNotes = reader.GetString(5);
                    volunteer.Active = reader.GetBoolean(6);
                    vol.Add(volunteer);
                }
                else
                {
                    throw new ApplicationException("Volunteer not found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vol;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/13/2020
        /// Checked By: Timothy Lickteig
        /// This is a data access method querying a Volunteers skills by VolunteerID
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <returns></returns>
        public List<string> GetVolunteerSkillsByID(int volunteerID)
        {
            List<string> skills = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_skills_by_volunteerID");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VolunteerID", SqlDbType.Int);
            cmd.Parameters["@VolunteerID"].Value = volunteerID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string skill = reader.GetString(0);
                    skills.Add(skill);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return skills;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/13/2020
        /// Checked By: Timothy Lickteig
        /// This is a data access method adds or removes a volunteers skill set
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteerID"></param>
        /// <param name="skill"></param>
        /// <param name="delete"></param>
        /// <returns></returns>
        public int InsertOrDeleteVolunteerSkill(int volunteerID, string skill, bool delete = false)
        {
            int rows = 0;

            string cmdText = delete ? "sp_delete_volunteer_skill" : "sp_insert_volunteer_skill";

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VolunteerID", volunteerID);
            cmd.Parameters.AddWithValue("@SkillID", skill);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// This is a data access method inserting a volunteer record to the db
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Josh Jackson
        /// UPDATE DATE: 02/21/2020
        /// WHAT WAS CHANGED: Was swapping new Volunteer's email and phone number. Email in phone field phone in email field. 
        ///  cmd.Parameters.AddWithValue("@Email", volunteer.PhoneNumber); ---> cmd.Parameters.AddWithValue("@Email", volunteer.Email);
        ///  cmd.Parameters.AddWithValue("@PhoneNumber", volunteer.Email); ---> cmd.Parameters.AddWithValue("@PhoneNumber", volunteer.PhoneNumber);
        /// </remarks>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public int InsertVolunteer(Volunteer volunteer)
        {
            int employeeID = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_volunteer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", volunteer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", volunteer.LastName);
            cmd.Parameters.AddWithValue("@Email", volunteer.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", volunteer.PhoneNumber);
            cmd.Parameters.AddWithValue("@OtherNotes", volunteer.OtherNotes);

            try
            {
                conn.Open();
                employeeID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return employeeID;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// This is a data access method used for getting all skills a volunteer could have from the db.
        /// to be populated in the lstUnassigned Skills listbox on the AddEditVolunteerRecord window
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <returns></returns>
        public List<string> SelectAllSkills()
        {
            List<string> skills = new List<string>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_all_skills");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string role = reader.GetString(0);
                    skills.Add(role);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return skills;
        }

        /// <summary>
        /// NAME: Gabrielle Legrand
        /// DATE: 2/6/2020
        /// Checked By: Josh J
        /// This Data Access function will carry out the stored procedure sp select volunteers by active
        /// by communicating directly with the databse. This will bring the list of current active vounteers
        /// to the VolunteerManager.
        /// </summary>
        /// <param name="active"></param>
        /// <returns> List of active volunteers to the VolunteerManager </returns>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>

        public List<Volunteer> SelectVolunteersByActive(bool active = true)
        {
            List<Volunteer> volunteers = new List<Volunteer>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_volunteers_by_active");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Active", SqlDbType.Bit);

            cmd.Parameters["@Active"].Value = active;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                bool rows = reader.HasRows;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var volunteer = new Volunteer();
                        volunteer.VolunteerID = reader.GetInt32(0);
                        volunteer.FirstName = reader.GetString(1);
                        volunteer.LastName = reader.GetString(2);
                        volunteer.Email = reader.GetString(3);
                        volunteer.PhoneNumber = reader.GetString(4);
                        volunteer.OtherNotes = reader.GetString(5);
                        volunteer.Active = reader.GetBoolean(6);
                        volunteers.Add(volunteer);
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return volunteers;
        }

        /// <summary>
        /// NAME: Josh J
        /// DATE: 03/06/2020
        /// Checked By: Zoey M
        /// This Data Access function updates an existing volunteer record with new values acquired from a user
        /// </summary>
        /// <param name="oldVolunteer"></param>
        /// <param name="newVolunteer"></param>
        /// <returns> List of active volunteers to the VolunteerManager </returns>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        public int UpdateVolunteer(Volunteer oldVolunteer, Volunteer newVolunteer)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_volunteer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VolunteerID", oldVolunteer.VolunteerID);

            cmd.Parameters.AddWithValue("@NewFirstName", newVolunteer.FirstName);
            cmd.Parameters.AddWithValue("@NewLastName", newVolunteer.LastName);
            cmd.Parameters.AddWithValue("@NewPhoneNumber", newVolunteer.PhoneNumber);
            cmd.Parameters.AddWithValue("@NewEmail", newVolunteer.Email);
            cmd.Parameters.AddWithValue("@NewNotes", newVolunteer.OtherNotes);

            cmd.Parameters.AddWithValue("@OldFirstName", oldVolunteer.FirstName);
            cmd.Parameters.AddWithValue("@OldLastName", oldVolunteer.LastName);
            cmd.Parameters.AddWithValue("@OldPhoneNumber", oldVolunteer.PhoneNumber);
            cmd.Parameters.AddWithValue("@OldEmail", oldVolunteer.Email);
            cmd.Parameters.AddWithValue("@OldNotes", oldVolunteer.OtherNotes);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }
    }
}
