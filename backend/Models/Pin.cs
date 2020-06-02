using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Pin
    {
        [Key]
        public int IdPin 
        {
            get;
            set;
        }

        public string NomeLocal 
        {
            get;
            set;
        }

        public string Pais 
        {
            get;
            set;
        }

        public string Coordenadas 
        {
            get;
            set;
        }

        public string Descricao 
        {
            get;
            set;
        }

        public string WikipediaUrl
        {
            get;
            set;
        }
    }
}