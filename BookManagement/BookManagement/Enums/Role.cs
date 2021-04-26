using System.ComponentModel.DataAnnotations;

namespace BookManagement.Enums
{
    public enum Role {
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "User")]
        User
    }
}