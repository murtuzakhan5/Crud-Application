using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter your Name")]
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter your Email")]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter your Phone")]
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }
    }
}
