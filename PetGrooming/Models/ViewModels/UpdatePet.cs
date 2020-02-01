using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetGrooming.Models.ViewModels
{
    public class UpdatePet
    {
        //INFORMATION NEEDED TO MAKE UPDATE PET WORK
        //INFO ABOUT ONE PET
        //INFO ABOUT MANY SPECIES

       public Pet pet { get; set; }
        public List<Species> species { get; set; }
    }
}