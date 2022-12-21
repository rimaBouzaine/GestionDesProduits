namespace GestionDesProduits.Models
{
    public class ProduitPromo
    {
        public int Id { get; set; }
        public string NomProduit { get; set; }
        public int MagasinId { get; set; }
        public virtual Magasin? Magasins { get; set; }
        public int CategorieId { get; set; }
        public virtual Categorie? Categories { get; set; }
        public virtual ICollection<Stock>? Stocks { get; set; }
        public float prixProduitEnPromo { get; set; }
        public virtual ICollection<LigneProduit>? LigneProduits { get; set; }



    }
}
