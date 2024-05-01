using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male= 1 ,
        [EnumMember(Value ="Female")]
        Female =2
    }
    public enum EmployeeType
    {
        FullTime = 1 ,
        PartTime = 2,
    }
    public class Employee : BaseModel
    {
     

        [MaxLength(20) ,MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Range(20,60)]
        [Required]
        public int Age { get; set; }

        [Range(8000,80000)]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }


        [Required]
        public Gender Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^[1-9]{1,3}-[a-zA-Z]{3,20}-[a-zA-Z]{3,20}-[a-zA-Z]{3,20}$" 
                          , ErrorMessage = "Address Must Be Like 123-street-city-country")
        ]
        public string Address { get; set; }

       
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }

        public EmployeeType EmployeeType { get; set; }

    }
}
