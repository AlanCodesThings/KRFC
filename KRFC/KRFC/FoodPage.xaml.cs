using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KRFC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodPage : ContentPage
    {
        static Dictionary<string, KoreanWord> wordDict = new Dictionary<string, KoreanWord>();
        static Random rnd = new Random();
        int i = 0;
        static List<string> listFood = new List<string>();
        static List<string> listkorFood = new List<string>();
        Plugin.SimpleAudioPlayer.ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

        public FoodPage()
        {
            InitializeComponent();
            
            cardWord.Text = "Swipe LEFT for English, RIGHT for Korean" + "\n\n" + "and UP for a new card!";
        }

        static public List<string> getlistFood()
        {
            if(wordDict.Count <= 0)
            {
                switch (MainPage.getCategory())
                {
                    case "food":
                        wordDict.Add("Apple", new KoreanWord("사과", "sagwa"));
                        wordDict.Add("Banana", new KoreanWord("바나나", "banana"));
                        wordDict.Add("Potato", new KoreanWord("감자", "gamja"));
                        wordDict.Add("Cabbage", new KoreanWord("양배추", "yangbaechu"));
                        wordDict.Add("Mango", new KoreanWord("망고", "mang-go"));
                        break;
                    case "transportation":
                        wordDict.Add("Bicycle", new KoreanWord("자전거", "jajeongeo"));
                        wordDict.Add("Car", new KoreanWord("자동차", "jadongcha"));
                        wordDict.Add("Train", new KoreanWord("기차", "gicha"));
                        break;
                    case "actions":
                        wordDict.Add("Eat", new KoreanWord("먹다", "meogda"));
                        wordDict.Add("Laugh", new KoreanWord("웃다", "usda"));
                        wordDict.Add("Fight", new KoreanWord("싸우다", "ssauda"));
                        break;
                    case "places":
                        wordDict.Add("Restaurant", new KoreanWord("레스토랑", "leseutolang"));
                        wordDict.Add("Beach", new KoreanWord("바닷가", "badasga"));
                        wordDict.Add("Home", new KoreanWord("집", "jib"));
                        break;
                    case "greetings":
                        wordDict.Add("Hello", new KoreanWord("안녕하세요", "annyeonghaseyo"));
                        wordDict.Add("Good Morning", new KoreanWord("좋은 아침", "joh-eun achim"));
                        wordDict.Add("Good Night", new KoreanWord("안녕히 주무세요", "annyeonghi jumuseyo"));
                        break;
                }
            }
            listFood = wordDict.Keys.ToList();
            return listFood; 
        }
        static public List<string> getlistkorFood()
        {
            if (listkorFood.Count <= 0)
            {
                foreach (KeyValuePair<string, KoreanWord> entry in wordDict)
                {
                    listkorFood.Add(entry.Value.getKoreanWord() + "  " + entry.Value.getEnglishSound());
                }
             }
            return listkorFood;
        }

        static public void emptyLists()
        {
            listFood.Clear();
            listkorFood.Clear();
            wordDict.Clear();
        }


            void OnSwiped(object sender, SwipedEventArgs e)
        {
            var currentWord = wordDict.ElementAt(i);

            switch (e.Direction)
            {

                case SwipeDirection.Left:
                    cardWord.Text = currentWord.Key;
                    break;
                case SwipeDirection.Right:
                    cardWord.Text = currentWord.Value.getKoreanWord() + "\n" + currentWord.Value.getEnglishSound();
                    break;
                case SwipeDirection.Up:
                    i++;
                    if (i >= wordDict.Count)
                    {
                        i = 0;
                    }
                    currentWord = wordDict.ElementAt(i);
                    cardFrame.BackgroundColor = Color.FromRgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                    cardWord.Text = currentWord.Key;
                    break;
                case SwipeDirection.Down:
                    player.Load(currentWord.Key.ToLower()+ ".mp3");
                    player.Play();
                    break;
            }
        }


    }

    public class KoreanWord
    {
        string koreanWord;
        string englishSound;
        public KoreanWord(string koreanWord, string pronunciation)
        {
            this.koreanWord = koreanWord;
            englishSound = pronunciation;
        }

        public String getKoreanWord()
        {
            return koreanWord;
        }
        public String getEnglishSound()
        {
            return englishSound;
        }
    }
}