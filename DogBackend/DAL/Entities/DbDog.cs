using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogBackend.DAL.Entities
{
    [Table("tblDogs")]
    public class DbDog
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [StringLength(256)]
        public string Image { get; set; }
        [ForeignKey("Breed")]
        public int BreedId { get; set; }
        public virtual DbBreed Breed { get; set; }
    }
}
