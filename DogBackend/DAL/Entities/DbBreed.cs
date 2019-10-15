using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogBackend.DAL.Entities
{
    [Table("tblBreeds")]
    public class DbBreed
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        public bool IsShow { get; set; }
        public virtual ICollection<DbDog> Dogs { get; set; }
    }
}
