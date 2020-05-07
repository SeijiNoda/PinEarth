using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Avaliacao
    {
        [Key]
        public int idAvaliacao
        {
            get;
            set;
        }

        public int nota
        {
            get;
            set;
        }
    }
}