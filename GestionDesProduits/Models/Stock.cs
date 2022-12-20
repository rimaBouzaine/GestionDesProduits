//using static Humanizer.In;

namespace GestionDesProduits.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int NbrProduit { get; set; }
        public string DescriptionStock { get; set; }
        public int ProduitPromoId{ get; set; }
        public virtual ProduitPromo? ProduitPromo { get; set; }

    }
}
