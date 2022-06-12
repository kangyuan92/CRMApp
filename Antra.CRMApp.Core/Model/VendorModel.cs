using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Model
{
    public class VendorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }


        [Required(ErrorMessage = "City is required")]
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }


        [Required(ErrorMessage = "Country is required")]
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Mobile is required")]
        [Column(TypeName = "varchar(50)")]
        public string Mobile { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [Column(TypeName = "varchar(100)")]
        public string EmailId { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
