using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Model
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(80)]
        public string Description { get; set; }
    }
}
