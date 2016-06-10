using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
   public class JsonHelpers
    {
        public string ObjectToStr()
        {
            ProductTest[] productTest = new ProductTest[]{
                        new ProductTest { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 2 },
                        new ProductTest { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
                        new ProductTest { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
                    };

            return JsonConvert.SerializeObject(productTest);
            return null;
        }
        public void StringToObject(string str,object obj)
        {
            string json = @"{
                          'Name': 'Bad Boys',
                          'ReleaseDate': '1995-4-7T00:00:00',
                          'Genres': [
                            'Action',
                            'Comedy'
                          ]
                        }";
            ProductTest m = JsonConvert.DeserializeObject<ProductTest>(json);
        }

    }
    public class ProductTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
