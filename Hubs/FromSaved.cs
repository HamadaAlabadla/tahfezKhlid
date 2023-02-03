using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net;
using tahfezKhalid.Models;

namespace tahfezKhalid.Hubs
{
    public class FromSaved : Hub
    {
        [Obsolete]

        public void changeSurahNum(string index)
        {
            var nums = index.Split('_');
            var indexto = 0;
            var i = 0;

            try
            {
                indexto = int.Parse(nums[0]);
                i = int.Parse(nums[1]);
            }
            catch
            {
                indexto = 1;
            }

            var webClient = new WebClient();
            var json = webClient.DownloadString("wwwroot/Quran.json");
            var surah = JsonConvert.DeserializeObject<List<Surah>>(json);
            var count = surah.FirstOrDefault(x => x.index == indexto).count;
            // var listCount = Enumerable.Range(1, count).ToList();
            Clients.Caller.SendAsync("OnNewSurah", count, i);
        }

        public void NumPages(int i,int SFrom , int VFrom, int STo , int VTo)
        {
            var from = SFrom + "";
            if (from.Length == 1)
                from = "00" + from;
            if (from.Length == 2)
                from = "0" + from;

            

            var ayas = "";
            var webClient = new WebClient();
            if (SFrom == STo)
            {
                var json = webClient.DownloadString("wwwroot/quran/" + from + ".json");
                var SurahAyas = JsonConvert.DeserializeObject<SurahAr>(json);
                for (int j = VFrom; j <= VTo; j++)
                {
                    ayas += SurahAyas.verses.FirstOrDefault(x => x.verseNumber == j).verseString;
                    ayas += "   ";
                }
            }
            else
            {
                for (int j = SFrom; j >= STo; j--)
                {
                    var To = j + "";
                    if (To.Length == 1)
                        To = "00" + To;
                    if (To.Length == 2)
                        To = "0" + To;

                    var json = webClient.DownloadString("wwwroot/quran/" + To + ".json");
                    var SurahAyas = JsonConvert.DeserializeObject<SurahAr>(json);

                    if (j == SFrom)
                    {
                        
                        for (int q = VFrom; q <= SurahAyas.nVerses; q++)
                        {
                            ayas += SurahAyas.verses.FirstOrDefault(x => x.verseNumber == q).verseString;
                            ayas += "   ";
                        }
                    }else if(j == STo)
                    {
                        for (int q = 1; q <= VTo; q++)
                        {
                            ayas += SurahAyas.verses.FirstOrDefault(x => x.verseNumber == q).verseString;
                            ayas += "   ";
                        }
                    }
                    else
                    {
                        for (int q = 1; q <= SurahAyas.nVerses; q++)
                        {
                            ayas += SurahAyas.verses.FirstOrDefault(x => x.verseNumber == q).verseString;
                            ayas += "   ";
                        }
                    }
                }
            }
            double numPages =Math.Round((ayas.Length / 79.0)/15.0 ,1,MidpointRounding.AwayFromZero);
            Clients.Caller.SendAsync("changeNumSurah", numPages, i);
        }


        public void changeSurahNumReview(string index)
        {
            var nums = index.Split('_');
            var indexto = 0;
            var i = 0;

            try
            {
                indexto = int.Parse(nums[0]);
                i = int.Parse(nums[1]);
            }
            catch
            {
                indexto = 1;
            }

            var webClient = new WebClient();
            var json = webClient.DownloadString("wwwroot/Quran.json");
            var surah = JsonConvert.DeserializeObject<List<Surah>>(json);
            var count = surah.FirstOrDefault(x => x.index == indexto).count;
            // var listCount = Enumerable.Range(1, count).ToList();
            Clients.Caller.SendAsync("OnNewSurahReview", count, i);
        }

        public void NumPagesReview(int i, int SFrom, int VFrom, int STo, int VTo)
        {
            var from = SFrom + "";
            if (from.Length == 1)
                from = "00" + from;
            if (from.Length == 2)
                from = "0" + from;



            var ayas = "";
            var webClient = new WebClient();
            if (SFrom == STo)
            {
                var json = webClient.DownloadString("wwwroot/quran/" + from + ".json");
                var SurahAyas = JsonConvert.DeserializeObject<SurahAr>(json);
                for (int j = VFrom; j <= VTo; j++)
                {
                    ayas += SurahAyas.verses.FirstOrDefault(x => x.verseNumber == j).verseString;
                    ayas += "   ";
                }
            }
            else
            {
                for (int j = SFrom; j >= STo; j--)
                {
                    var To = j + "";
                    if (To.Length == 1)
                        To = "00" + To;
                    if (To.Length == 2)
                        To = "0" + To;

                    var json = webClient.DownloadString("wwwroot/quran/" + To + ".json");
                    var SurahAyas = JsonConvert.DeserializeObject<SurahAr>(json);

                    if (j == SFrom)
                    {

                        for (int q = VFrom; q <= SurahAyas.nVerses; q++)
                        {
                            ayas += SurahAyas.verses.FirstOrDefault(x => x.verseNumber == q).verseString;
                            ayas += "   ";
                        }
                    }
                    else if (j == STo)
                    {
                        for (int q = 1; q <= VTo; q++)
                        {
                            ayas += SurahAyas.verses.FirstOrDefault(x => x.verseNumber == q).verseString;
                            ayas += "   ";
                        }
                    }
                    else
                    {
                        for (int q = 1; q <= SurahAyas.nVerses; q++)
                        {
                            ayas += SurahAyas.verses.FirstOrDefault(x => x.verseNumber == q).verseString;
                            ayas += "   ";
                        }
                    }
                }
            }
            double numPages = Math.Round((ayas.Length / 79.0) / 15.0, 1, MidpointRounding.AwayFromZero);
            Clients.Caller.SendAsync("changeNumSurahReview", numPages, i);
        }
    }
}