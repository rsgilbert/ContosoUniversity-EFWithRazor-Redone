using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student 
    {
        public int ID { get; set; }


        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; } = string.Empty;


        [Display(Name = "First Name")]
        public string FirstMidName { get; set; } = string.Empty;

        [Display(Name ="Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}