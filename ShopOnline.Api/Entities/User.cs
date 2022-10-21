namespace ShopOnline.Api.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int KundenNummer { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Anrede { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public string? Strasse { get; set; }
        public int HausNummer { get; set; }
        public int PLZ { get; set; }
        public string? Ort { get; set; }
        public string? Land { get; set; }
        public string? E_MailAdresse { get; set; }






    }
}
