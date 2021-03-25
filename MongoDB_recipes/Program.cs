using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB_recipes
{
    class RecipeContext
    {
        protected static IMongoDatabase MongoDB;

        public RecipeContext()
        {
            var Client = new MongoClient();
            MongoDB = Client.GetDatabase("RecipeDB");
            var Collection = MongoDB.GetCollection<RecipeCollection>("RecipeCollection");
        }

        public IMongoCollection<RecipeCollection> RecipeCollection
        {
            get { return MongoDB.GetCollection<RecipeCollection>("RecipeCollection"); }
        }

    }

    public class RecipeCollection
    {
        public ObjectId Id { get; set; }
        public string _titel { get; set; }
        public string _ingredients { get; set; }
        public string _category { get; set; }
        public string intructions { get; set; }

        public override string ToString()
        {
            return "Titel: " + _titel + " Ingredients: " + _ingredients + " Category: " + _category + " Instructions: " + intructions + " ";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var Client = new MongoClient();
            var MongoDB = Client.GetDatabase("RecipeDB");
            var Collection = MongoDB.GetCollection<RecipeCollection>("RecipeCollection");

            Console.WriteLine(Collection);
            DoFindAllRecipes();
            Console.ReadLine();
        }

        private static void DoFindAllRecipes()
        {
            RecipeContext ctx = new RecipeContext();
            

            var recipes = ctx.RecipeCollection.Find(new BsonDocument()).ToList();

            Console.WriteLine("ALL RECIPES: ");
            foreach (RecipeCollection recipeCollection in recipes)
            {
                Console.WriteLine(recipeCollection);
            }
        }

   
    }
}
