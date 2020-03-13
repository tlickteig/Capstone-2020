using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
   public class MedicalHistory
    {
        public int AnimalID { get; set; }//0

        public string AnimalName { get; set; }//1


        public string AnimalSpeciesID { get; set; }//2
      

        public string Vaccinations { get; set; }//3

        public bool Spayed_Neutered { get; set; }//4

        public DateTime MostRecentVaccinationDate { get; set; }//5

        public string AdditionalNotes { get; set; }//6

      


    }


}
