using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XT.StorageModel.Classes
{
    public class Key
    {
        [Required(ErrorMessage = "Se requiere el sistema de validación.")]
        public string APISystem { get; set; }
    }
}
