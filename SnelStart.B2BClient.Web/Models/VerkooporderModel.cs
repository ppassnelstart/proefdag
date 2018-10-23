namespace SnelStart.B2BClient.Web.Models
{
    public class VerkooporderModel
    {
        public string Id { get; set; }
        public int Nummer { get; set; }
        public string Datum { get; set; }
        public string Omschrijving { get; set; }
        public VerkoopfactuurModel Verkoopfactuur { get; set; }
    }
}
