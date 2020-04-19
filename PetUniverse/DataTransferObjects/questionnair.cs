namespace DataTransferObjects
{
    /// <summary>
    /// matching the General Question 
    /// </summary>
    /// <remarks>
    /// by Awaab Elamin 2/4/2020
    /// Mohamed Elamin , 2/21/2020
    /// </remarks>
    /// <Remark>
    /// Updated by: Awaab Elamin
    /// <summary>
    /// the update taking out customer ID to be compatible with DB updte
    /// Customer table updated 
    /// </summary>
    /// </Remark>
    public class Questionnair
    {
        public string question { get; set; }
        public string answer { get; set; }
    }
}
