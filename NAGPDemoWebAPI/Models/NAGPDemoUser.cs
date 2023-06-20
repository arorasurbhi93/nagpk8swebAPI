using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NAGPDemoWebAPI.Models
{
    [Table("nagpdemouser")]
	public class NAGPDemoUser
	{
        [Key]
        [Column("Id")]
		public int Id { get; set; }

        [Column("FirstName")]
		public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Experience")]
        public string Experience { get; set; }

        [Column("EnrollmentDate")]
        public DateTime EnrollmentDate { get; set; }

    }
}

