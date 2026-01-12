namespace Rijschool.Applicatie.DTOs.Rijles
{
    public class RijlesDto
    {
        public int Id { get; set; }
        public string LeerlingNaam { get; set; }
        public string InstructeurNaam { get; set; }
        public DateTime Datum { get; set; }
        public string StartTijd { get; set; }
        public string EindTijd { get; set; }
        public string Ophaaladres { get; set; }
        public string Lesdoel { get; set; }
        public string Commentaar { get; set; }
        public string Status { get; set; }
    }

}
