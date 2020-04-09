using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Pin
    {
        [Key]
        public int idPin 
        {
            get;
            set;
        }

        public string nomeLocal 
        {
            get;
            set;
        }

        public string pais 
        {
            get;
            set;
        }

        public string coordenadas 
        {
            get;
            set;
        }

        public string descricao 
        {
            get;
            set;
        }
    }
}