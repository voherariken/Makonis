using System.ComponentModel.DataAnnotations;

namespace Makonis.Web.Models
{
    public class CustomerViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage ="FirstName cannot be more than 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "LastName cannot be more than 50 characters")]
        public string LastName { get; set; }
    }
}
