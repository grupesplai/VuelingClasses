using AutoMapper;
using System;

namespace VuelingClasses.AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Origin, Destination>()
                .ForMember(d => d.Id, od => od.ResolveUsing(o => o.Id + 1))
                .ForMember(d => d.FName, od => od.ResolveUsing(o => o.FirstName))
                .ForMember(d => d.LName, od => od.ResolveUsing(o => o.LastName))
                .ForMember(d => d.BDestination, od => od.ResolveUsing(o => o.BirthdayOrigin))
                .ForMember(d => d.Years, od => od.ResolveUsing(o => DateTime.Today.AddTicks(-o.BirthdayOrigin.Ticks).Year - 1))
                );
            IMapper iMapper = config.CreateMapper();

            var originObject = new Origin
            {
                Id = 1,
                FirstName = "Pepito",
                LastName = "Grillo Mandril",
                BirthdayOrigin = new DateTime(1990, 11, 12)
            };

            var destination = iMapper.Map<Origin, Destination>(originObject);


            Console.WriteLine(destination.GetType());
            Console.WriteLine("Data Destination Object copied from Origin Object:\\nName: "
                + destination.FName + "\\n Surnames: " + destination.LName + "\\n Birthday: " 
                + destination.BDestination + "\\n Age: "+ destination.Years);
            Console.ReadLine();
        }
    }

    class Origin
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthdayOrigin { get; set; }
    }

    class Destination
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime BDestination { get; set; }
        public int Years { get; set; }
    }
}
