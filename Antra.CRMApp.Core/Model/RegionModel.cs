using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Antra.CRMApp.Core.Model
{
    public class RegionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [Display(Name ="Enter Name")]
        public string Name { get; set; }
    }
}
