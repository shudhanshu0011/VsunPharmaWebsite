using System.ComponentModel.DataAnnotations;

namespace VsunPharmaWebsite.Models
{
    public class UsersModel
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Role { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
