namespace HangmanGame.Data
{
    public class WordLibrary
    {
        private Dictionary<string, List<string>> Words = new Dictionary<string, List<string>>()
        {
            { "Animals", new List<string> { "elephant", "giraffe", "alligator", "kangaroo", "dolphin" } },
            { "Fruits", new List<string> { "banana", "strawberry", "pineapple", "watermelon", "blueberry" } },
            { "Countries", new List<string> { "canada", "brazil", "australia", "germany", "japan" } },
            { "Places", new List<string> { "mountain", "river", "desert", "forest", "ocean" } },
            { "Monuments", new List<string> { "pyramid", "colosseum", "statueofliberty", "eiffeltower", "greatwall" } },
            { "Books", new List<string> { "mobyDick", "warAndPeace", "greatGatsby", "toKillAMockingbird", "1984" } },
            { "Movies", new List<string> { "inception", "gladiator", "titanic", "avatar", "interstellar" } },
            { "Sports", new List<string> { "basketball", "football", "cricket", "badminton", "swimming" } },
            { "Colors", new List<string> { "blue", "orange", "red", "green", "black" } },
            { "Vehicles", new List<string> { "motorcycle", "airplane", "submarine", "helicopter", "spaceship" } },
            { "Instruments", new List<string> { "guitar", "piano", "violin", "drums", "trumpet" } },
            { "Brands", new List<string> { "nike", "adidas", "puma", "reebok", "underarmour" } },
            { "Jobs", new List<string> { "engineer", "doctor", "teacher", "artist", "scientist" } },
            { "Mythology", new List<string> { "zeus", "thor", "anubis", "athena", "loki" } },
            { "Planets", new List<string> { "mercury", "venus", "earth", "mars", "jupiter" } },
            { "Flowers", new List<string> { "rose", "tulip", "daisy", "sunflower", "orchid" } },
            { "Trees", new List<string> { "oak", "maple", "pine", "willow", "birch" } },
            { "Clothes", new List<string> { "jacket", "sneakers", "scarf", "gloves", "sunglasses" } },
            { "Furniture", new List<string> { "sofa", "wardrobe", "bookshelf", "table", "chair" } },
            { "Gems", new List<string> { "diamond", "ruby", "sapphire", "emerald", "amethyst" } },
            { "Cities", new List<string> { "paris", "london", "tokyo", "newyork", "sydney" } },
            { "MusicalGenres", new List<string> { "jazz", "rock", "classical", "country", "reggae" } },
            { "Desserts", new List<string> { "cheesecake", "brownie", "cupcake", "tiramisu", "macarons" } },
            { "Elements", new List<string> { "hydrogen", "oxygen", "carbon", "nitrogen", "helium" } },
            { "Languages", new List<string> { "english", "spanish", "french", "german", "japanese" } },
            { "Marks", new List<string> { "tesla", "ford", "chevrolet", "honda", "toyota" } },
            { "CartoonCharacters", new List<string> { "mickeymouse", "spongebob", "batman", "superman", "pikachu" } },
            { "VideoGames", new List<string> { "minecraft", "fortnite", "zelda", "tetris", "overwatch" } },
            { "MythicalCreatures", new List<string> { "dragon", "unicorn", "phoenix", "griffin", "mermaid" } },
            { "Weather", new List<string> { "hurricane", "tornado", "thunderstorm", "blizzard", "drought" } },
            { "BodyParts", new List<string> { "shoulder", "elbow", "knee", "ankle", "wrist" } },
            { "KitchenItems", new List<string> { "spatula", "whisk", "colander", "blender", "toaster" } },
            { "SpaceTerms", new List<string> { "asteroid", "comet", "galaxy", "nebula", "supernova" } },
            { "SchoolSubjects", new List<string> { "mathematics", "history", "biology", "chemistry", "literature" } },
            { "Holidays", new List<string> { "christmas", "halloween", "thanksgiving", "easter", "valentines" } },
            { "Insects", new List<string> { "butterfly", "beetle", "grasshopper", "dragonfly", "ladybug" } },
            { "Tools", new List<string> { "hammer", "screwdriver", "wrench", "pliers", "chisel" } },
            { "FamousPeople", new List<string> { "einstein", "newton", "curie", "turing", "darwin" } },
            { "Musicians", new List<string> { "mozart", "beethoven", "chopin", "hendrix", "dylan" } },
            { "TVShows", new List<string> { "friends", "breakingbad", "sherlock", "gameofthrones", "strangerthings" } },
            { "BoardGames", new List<string> { "monopoly", "scrabble", "clue", "risk", "catan" } },
            { "TransportationModes", new List<string> { "bicycle", "subway", "ferry", "tram", "rickshaw" } },
            { "JewelryItems", new List<string> { "necklace", "bracelet", "earrings", "ring", "brooch" } },
            { "CookingMethods", new List<string> {  "grilling", "baking","steaming","frying","roasting"} },
            { "Professions", new List<string> { "architect", "pilot", "nurse", "chef", "journalist" } },
            { "FictionalPlaces", new List<string> { "hogwarts", "narnia", "middleearth", "westeros", "atlantis" } },
            { "MythicalWeapons", new List<string> { "excalibur", "mjolnir", "gungnir", "trident", "katana" } },
            { "TypesOfDance", new List<string> { "ballet", "salsa", "tango", "hiphop", "flamenco" } },
            { "TypesOfArt", new List<string> { "sculpture", "painting", "photography", "drawing", "printmaking" } },
            { "TypesOfMusic", new List<string> { "blues", "punk", "metal", "folk", "disco" } },
            { "TypesOfFood", new List<string> { "sushi", "pizza", "burger", "pasta", "salad" } },
            { "TypesOfDrink", new List<string> {  "coffee","tea","smoothie","cocktail","lemonade"} },
            { "TypesOfClothing", new List<string> { "tshirt", "jeans", "sneakers", "jacket", "hat" } },
            { "TypesOfWeather", new List<string> { "sunny", "rainy", "cloudy", "windy", "snowy" } },
            { "TypesOfVehicles", new List<string> { "car", "truck", "bus", "motorcycle", "bicycle" } },
            { "TypesOfComputers", new List<string> { "laptop", "desktop", "tablet", "server", "workstation" } },
            { "TypesOfPhones", new List<string> { "smartphone", "flipphone", "satellitephone", "cordlessphone", "landline" } },
            { "TypesOfHouses", new List<string> { "bungalow", "cottage", "villa", "apartment", "mansion" } },
            { "TypesOfTrees", new List<string> { "oak", "maple", "pine", "birch", "willow" } },
            { "TypesOfFlowers", new List<string> { "rose", "tulip", "daisy", "sunflower", "orchid" } },
            { "TypesOfBirds", new List<string> { "sparrow", "eagle", "parrot", "penguin", "owl" } },
            { "TypesOfFish", new List<string> { "salmon", "trout", "goldfish", "catfish", "tuna" } },
            { "TypesOfReptiles", new List<string> { "lizard", "snake", "tortoise", "chameleon", "gecko" } },
            { "TypesOfAmphibians", new List<string> { "frog", "toad", "salamander", "newt", "caecilian" } },
            { "TypesOfMammals", new List<string> {  "lion","tiger","bear","wolf","fox"} },
            { "TypesOfInsects", new List<string> { "butterfly", "beetle", "ant", "bee", "dragonfly" } },
            { "TypesOfArachnids", new List<string> { "spider", "scorpion", "tick", "mite", "harvestman" } },
            { "TypesOfCrustaceans", new List<string> { "crab", "lobster", "shrimp", "barnacle", "krill" } },
            { "TypesOfMollusks", new List<string> { "octopus", "squid", "clam", "oyster", "snail" } },
            { "TypesOfCnidarians", new List<string> { "jellyfish", "coral", "seaanemone", "hydra", "boxjellyfish" } },
            { "TypesOfEchinoderms", new List<string> {  "starfish","seaurchin","sanddollar","sea cucumber","brittle star"} }
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

        public string GetRandomWord(string category, int wordLength)
        {
            var filteredWords = Words.ContainsKey(category) ?
                Words[category].Where(w => w.Length == wordLength).ToList() :
                new List<string>();

            if (filteredWords.Count == 0)
            {
                return null;
            }

            Random rand = new Random();
            int index = rand.Next(filteredWords.Count);
            return filteredWords[index];
        }
    }
}