using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.ViewModels
{
    // represents the contract between views & controllers
    public class AuthLogin {

        [Required]
        public string Username  { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password  { get; set; }
    }
}