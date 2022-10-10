using BenchmarkDotNet.Attributes;
using Bogus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace benchmark
{
    #region models 
    public class Product
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

    public class Customer
    {
        public Guid id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Product> products { get; set; }
    }
    #endregion

    [MemoryDiagnoser]
    public class DeseralizationTest
    {
        private string _customers;
        private string s1, s2;

        public DeseralizationTest()
        {
            // Setting up faker using Bogus Libray
            var product = new Faker<Product>()
                .RuleFor(x => x.id, x => Guid.NewGuid())
                .RuleFor(x => x.Name, x => x.Commerce.ProductName())
                .RuleFor(x => x.Category, x => x.Commerce.ProductAdjective())
                .RuleFor(x => x.Discount, x => Convert.ToDecimal(x.Commerce.Price(min: 0.0m, max: 0.1m)))
                .RuleFor(x => x.Price, x => Convert.ToDecimal(x.Commerce.Price(min: 100.0m, max: 1000.0m)));

            var customers = new Faker<Customer>()
                .RuleFor(x => x.id, x => Guid.NewGuid())
                .RuleFor(x => x.FristName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.Phone, x => x.Person.Phone)
                .RuleFor(x => x.products, x => product.Generate(100))
                .Generate(100);

            // serialize the list of customers 
            _customers = JsonConvert.SerializeObject(customers);
        }

        [Benchmark(Baseline = true)]
        public void Deserialize_ToJArray()
        {
            var jarray = JsonConvert.DeserializeObject<JArray>(_customers);
            s1 = jarray[87]["products"][55]["Name"].ToString();
        }
        [Benchmark]
        public void Deserialize_ConcreteClass()
        {
            var cus = JsonConvert.DeserializeObject<List<Customer>>(_customers);
            s2 = cus[87].products[55].Name;
        }
    }
}
