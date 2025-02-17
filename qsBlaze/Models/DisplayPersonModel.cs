using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace qsBlaze.Models
{
    public class DisplayPersonModel
    {
        private int Id;
        [Required]
        [NotNull]
        [StringLength(50, ErrorMessage = "First Name is too long.")]
        public string FirstName { get; set; }

        [Required]
        [NotNull]
        [StringLength(50, ErrorMessage = "Last Name is too long.")]
        public string LastName { get; set; }

        [Required]
        [NotNull]
        [StringLength(50, ErrorMessage = "User Name is too long.")]
        public string UserName { get; set; }

        [Required]
        [NotNull]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
