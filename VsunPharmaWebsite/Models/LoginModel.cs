using System.ComponentModel.DataAnnotations;

namespace VsunPharmaWebsite.Models
{
    public class LoginModel
    {
        [StringLength(100)]
        public string? EmailID { get; set; }

        [StringLength(100)]
        public string? Password { get; set; }
    }
}
