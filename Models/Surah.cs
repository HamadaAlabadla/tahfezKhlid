namespace tahfezKhalid.Models
{
    public class Surah
    {
        public string place { get; set; }
        public string type { get; set; }
        public int count { get; set; }
        public string title { get; set; }
        public string titleAr { get; set; }
        public int index { get; set; }
        public int pages { get; set; }
        public List<Juz> juz { get; set; }
    }
}
