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
    /// Creator: Steven Cardona
    /// Created: 02/11/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Class of methods for Accessing using information
    /// </summary>
    public class UserAccessor : IUserAccessor
    {
        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/11/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// This method connects to the database and inserts a user via the sp_insert_user stored procedure
        /// </summary>
        /// <remarks>
        /// Updater: Steven Cardona
        /// Updated: 03/01/2020
        /// Update: Added parameters for Address lines         
        /// </remarks>
        /// <param name="petUniverseUser">The user that is going to be inserted into the database</param>
        /// <returns>Returns true if insert is successful else returns false</returns>
        public bool InsertNewUser(PetUniverseUser petUniverseUser)
        {
            bool isInserted = false;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_user", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FirstName", petUniverseUser.FirstName);
            cmd.Parameters.AddWithValue("@LastName", petUniverseUser.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", petUniverseUser.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", petUniverseUser.Email);
            cmd.Parameters.AddWithValue("@Address1", petUniverseUser.Address1);
            cmd.Parameters.AddWithValue("@Address2", ((object)petUniverseUser.Address2) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@City", petUniverseUser.City);
            cmd.Parameters.AddWithValue("@State", petUniverseUser.State);
            cmd.Parameters.AddWithValue("@Zipcode", petUniverseUser.ZipCode);

            try
            {
                conn.Open();
                isInserted = 1 == cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return isInserted;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/11/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// This method connects to the database and
        /// selects all active users via the sp_select_all_active_users stored procedure
        /// </summary>
        /// <remarks>
        /// Updater: Steven Cardona
        /// Updated: 03/01/2020
        /// Update: Added lines to pull Address lines from reader
        /// </remarks>
        /// <returns>Returns a list of PetUniverseUsers</returns>
        public List<PetUniverseUser> SelectAllActivePetUniverseUsers()
        {
            List<PetUniverseUser> users = new List<PetUniverseUser>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_active_users", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new PetUniverseUser()
                    {
                        PUUserID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        PhoneNumber = reader.GetString(3),
                        Email = reader.GetString(4),
                        Address1 = reader.GetString(5),
                        Address2 = reader.IsDBNull(6) ? null : reader.GetString(6),
                        City = reader.GetString(7),
                        State = reader.GetString(8),
                        ZipCode = reader.GetString(9)
                    });
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
            return users;
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/4/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This method is used to authenticate the user and make sure they exist for login
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// CHANGE:
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public PetUniverseUser AuthenticateUser(string username, string passwordHash)
        {
            PetUniverseUser result = null;

            //Get a connection
            var conn = DBConnection.GetConnection();

            //Call the sproc
            var cmd = new SqlCommand("sp_authenticate_user");
            cmd.Connection = conn;

            //Set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Create the parameters
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            //Set the parameters
            cmd.Parameters["@Email"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                conn.Open();

                if (1 == Convert.ToInt32(cmd.ExecuteScalar()))
                {
                    //Check the db for the given email
                    result = getUserByEmail(username);
                }
                else
                {
                    throw new ApplicationException("User not found.");
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



        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to find retrieve a user based on the provided email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public PetUniverseUser getUserByEmail(string email)
        {
            PetUniverseUser user = null;

            var conn = DBConnection.GetConnection();

            //Sprocs
            var cmd1 = new SqlCommand("sp_select_user_by_email");
            var cmd2 = new SqlCommand("sp_select_roles_by_userID");

            cmd1.Connection = conn;
            cmd2.Connection = conn;

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;


            cmd1.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd1.Parameters["@Email"].Value = email;

            cmd2.Parameters.Add("@UserID", SqlDbType.Int);

            try
            {
                conn.Open();

                var reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    //Create new user to set properties
                    user = new PetUniverseUser();

                    user.PUUserID = reader1.GetInt32(0);
                    user.FirstName = reader1.GetString(1);
                    user.LastName = reader1.GetString(2);
                    user.PhoneNumber = reader1.GetString(3);
                    user.Email = email;
                }
                else
                {
                    throw new ApplicationException("User not found.");
                }
                reader1.Close();

                cmd2.Parameters["@UserID"].Value = user.PUUserID;
                var reader2 = cmd2.ExecuteReader();

                //Add roles to list
                List<string> roles = new List<string>();
                while (reader2.Read())
                {
                    string role = reader2.GetString(0);
                    roles.Add(role);
                }
                user.PURoles = roles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to check if provided email exists
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns>bool if user exists</returns>
        public bool CheckIfUserExists(string userName)
        {
            bool exists = false;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_check_email_exists");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);

            cmd.Parameters["@Email"].Value = userName;
            try
            {
                conn.Open();
                var rows = 0;
                rows = Convert.ToInt32(cmd.ExecuteScalar());
                exists = (rows == 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return exists;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to lock out the user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <param name="currentDate"></param>
        /// <param name="unlockDate"></param>
        /// <returns>bool if locked</returns>
        public bool LockoutUser(string userName, DateTime currentDate, DateTime unlockDate)
        {
            bool isLocked = false;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_lockout_user");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@UnlockDate", SqlDbType.DateTime);
            cmd.Parameters.Add("@LockDate", SqlDbType.DateTime);

            cmd.Parameters["@Email"].Value = userName;
            cmd.Parameters["@UnlockDate"].Value = unlockDate;
            cmd.Parameters["@LockDate"].Value = currentDate;
            try
            {
                conn.Open();
                var rows = 0;
                rows = cmd.ExecuteNonQuery();
                isLocked = (rows == 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return isLocked;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to unlock the user based on time
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns>bool if user is unlocked</returns>
        public bool TimeoutUserUnlock(string userName)
        {
            bool isUnlocked = false;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_unlock_user_by_date");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);

            cmd.Parameters["@Email"].Value = userName;
            try
            {
                conn.Open();
                var rows = 0;
                rows = cmd.ExecuteNonQuery();
                isUnlocked = (rows == 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return isUnlocked;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to retrieve the unlock date
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DateTime getUnlockDate(string userName)
        {

            DateTime unlockDate = new DateTime();
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_get_unlock_date");

            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters["@Email"].Value = userName;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    unlockDate = reader.IsDBNull(0) ? DateTime.Now.AddMinutes(-5) : reader.GetDateTime(0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return unlockDate;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        ///
        /// This method connects to the database and retrieves users in a department
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>      
        /// <param name="DepartmentID"></param>
        /// <returns></returns>
        public List<PetUniverseUser> GetDepartmentUsers(string DepartmentID)
        {
            List<PetUniverseUser> users = new List<PetUniverseUser>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_department_users");

            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("DepartmentID", SqlDbType.NVarChar, 50);
            cmd.Parameters["DepartmentID"].Value = DepartmentID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new PetUniverseUser()
                    {
                        PUUserID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        PhoneNumber = reader.GetString(3),
                        Email = reader.GetString(4),
                        Address1 = reader.GetString(5),
                        Address2 = reader.IsDBNull(6) ? null : reader.GetString(6),
                        City = reader.GetString(7),
                        State = reader.GetString(8),
                        ZipCode = reader.GetString(9),
                    });
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
            return users;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 3/17/2020
        /// Approver: Kaleb Bachert
        /// 
        /// This method is used to Change status of User Reading Policies
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="UserID"></param>
        /// <returns>int rows affected</returns>
        public int ChangeUserHasReadPoliciesStandards(int UserID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_change_user_has_read", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UserID);

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
        /// Creator: Zach Behrensmeyer
        /// Created: 3/1/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to find retrieve a user based on the provided ID
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public PetUniverseUser getUserByUserID(int UserID)
        {
            PetUniverseUser user = null;

            var conn = DBConnection.GetConnection();

            //Sprocs
            var cmd = new SqlCommand("sp_select_user_by_id");

            cmd.Connection = conn;


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 250);
            cmd.Parameters["@UserID"].Value = UserID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //Create new user to set properties
                    user = new PetUniverseUser();

                    user.PUUserID = UserID;
                    user.FirstName = reader.GetString(0);
                    user.LastName = reader.GetString(1);
                    user.PhoneNumber = reader.GetString(2);
                    user.Email = reader.GetString(3);
                }
                else
                {
                    throw new ApplicationException("User not found.");
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
            return user;
        }

    }
}
