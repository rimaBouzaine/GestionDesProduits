using System.ComponentModel.DataAnnotations;

namespace GestionDesProduits.Models
{
    public class LigneProduit
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateDebutPromo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateFinPromo { get; set; }

        public float prixProduit { get; set; }
        public float prixProduitEnPromo { get; set; }
        public int IdProduitPromo { get; set; }
        public virtual ProduitPromo? ProduitPromo { get; set; }

    }
}
