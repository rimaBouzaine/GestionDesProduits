﻿namespace GestionDesProduits.Models
{
    public class Magasin
    {
        
            public int Id { get; set; }
            public string NomMagasin { get; set; }
            public string ville { get; set; }
        public virtual ICollection<ProduitPromo>? ProduitPromos { get; set; }






    }
}