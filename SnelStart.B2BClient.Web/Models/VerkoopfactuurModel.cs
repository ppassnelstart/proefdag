namespace SnelStart.B2BClient.Web.Models
{
    public class VerkoopfactuurModel
    {
        public string Id { get; set; }
        public string Uri { get; set; }
        public string Factuurnummer { get; set; }
        public string Factuurdatum { get; set; }
        public double Factuurbedrag { get; set; }
    }
}
