namespace puertas.Settings{
    public class MongoDbSettings{
        public string host { get; set; }
        public string port { get; set; }

        public string connectionString{
            get{
                return $"mongodb://{host}:{port}";
            }
        }
    }

}