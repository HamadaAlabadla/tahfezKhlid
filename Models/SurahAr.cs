namespace tahfezKhalid.Models
{
    public class SurahAr
    {
        public List<Aya> verses { get; set; }
        public string nameEnglish { get; set; }
        public string nameTrans { get; set; }
        public string nameArabic { get; set; }
        public int chapterNumber { get; set; }
        public int nVerses { get; set; }
    }
}
