using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class ImagemPin
    {
        [Key]
        public int idImagem 
        {
            get;
            set;
        }

        public int idPin
        {
            get;
            set;
        }

        public string url
        {
            get;
            set;
        }
    }
}