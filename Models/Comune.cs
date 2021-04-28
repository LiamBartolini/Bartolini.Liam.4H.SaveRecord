namespace Bartolini.Liam._4H.SaveRecord.Models
{
    public class Comune
    {
        public int ID { get; set; }
        public string NomeComune { get; set; }
        public string CodiceCatastale { get; set; }
    
        public Comune() { }

        public Comune(string riga)
        {
            string[] colonne = riga.Split(',');
            
        }
    }
}