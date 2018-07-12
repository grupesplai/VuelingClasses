using System;
using System.Collections.Generic;
using AutoMapper;

namespace AutoMapper
{
    public class Foo
    {
        public string A { get; set; }
        public int B { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Region, Country>());

            var foo = new Foo { A = "test", B = 100500 };

            var foo_copy = Mapper.Map<Foo>(foo);

            Console.WriteLine("foo type is {0}", foo.GetType());
            Console.WriteLine("foo_copy type is {0}", foo_copy.GetType());

            Console.WriteLine("foo.A={0} foo.B={1}", foo.A, foo.B);
            Console.WriteLine("foo_copy.A={0} foo_copy.B={1}", foo_copy.A, foo_copy.B);
        }
    }
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; } // FK
    }