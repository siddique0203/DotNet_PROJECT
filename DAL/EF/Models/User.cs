using DAL.EF.Models.DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR(100)")]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR(100)")]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "VARCHAR(20)")]
        public string Phone { get; set; }

        [Required]
        [StringLength(200)]
        [Column(TypeName = "VARCHAR(200)")]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "VARCHAR(20)")]
        public string UserType { get; set; } // Admin / Agency / Customer

        public double Rating { get; set; }
    }
}
