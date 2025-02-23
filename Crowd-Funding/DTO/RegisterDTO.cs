using System.ComponentModel.DataAnnotations;

namespace Crowd_Funding.DTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        [Required, DataType(dataType: DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(dataType: DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
