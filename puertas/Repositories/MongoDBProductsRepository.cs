using puertas.Models;
using MongoDB.Driver;

namespace puertas.Repositories{
    //to run a mongo docker container
    //docker run -d --rm --name mongo -p 23017:27017 -v mongodbdata:/data/db mongo
    public class MongoDbProductsRepository : IProductsRepository
    {
        private const string databaseName = "puertas";
        private const string collectionName = "products";
        private readonly IMongoCollection<Product> productsCollection;

        public MongoDbProductsRepository(IMongoClient mongoclient){
            IMongoDatabase database = mongoclient.GetDatabase(databaseName);
            productsCollection = database.GetCollection<Product>(collectionName);
        }
        
        public void CreateProduct(Product product)
        {
           productsCollection.InsertOne(product);
        }

        public bool DeleteProduct(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts() 
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}