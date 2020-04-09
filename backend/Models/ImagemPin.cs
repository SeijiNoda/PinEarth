using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class ImagemPin
    {
        [Key]
        public int IdImagem 
        {
            get;
            set;
        }

        public int IdPin
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
    }
}