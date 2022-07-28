using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_gameTable.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string genre { get; set; }
        public Guid studio { get; set; }
        public int copiesSold { get; set; }
        public bool multiplayer { get; set; }
        public int year { get; set; }
    }
}
