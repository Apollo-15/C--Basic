namespace HangmanGame.Data
{
    public class WordLibrary
    {
        private Dictionary<string, List<string>> Words = new Dictionary<string, List<string>>()
        {
            { "Animals", new List<string> { "cat", "rabbit", "giraffe", "elephant", "alligator", "hippopotamus" } },
            { "Fruits", new List<string> { "fig", "pear", "apple", "banana", "pineapple", "blueberry", "watermelon", "pomegranate" } },
            { "Countries", new List<string> { "peru", "brazil", "australia", "argentina", "netherlands", "switzerland" } },
            { "JewelryItems", new List<string> { "ring", "bracelet", "necklace", "earrings", "brooch", "anklebracelet" } },
            { "Sports", new List<string> { "ski", "soccer", "cricket", "baseball", "badminton", "basketball" } },
            { "Movies", new List<string> { "up", "titanic", "gladiator", "interstellar", "jurassicpark", "guardiansofthegalaxy" } },
        };

        public List<string> GetCategories()
        {
            return Words.Keys.ToList();
        }

        public List<string> GetWordsByCategory(string category)
        {
            if (Words.ContainsKey(category))
            {
                return Words[category];
            }
            return new List<string>();
        }

        public string GetRandomWord(string category, int minLength, int maxLength)
        {
            if (!Words.ContainsKey(category) || Words[category].Count == 0)
                return null;

            var filteredWords = Words[category]
                .Where(w => w.Length >= minLength && w.Length <= maxLength)
                .ToList();

            if (filteredWords.Count == 0)
                filteredWords = Words[category];

            Random rand = new Random();
            int index = rand.Next(filteredWords.Count);
            return filteredWords[index];
        }
    }
}