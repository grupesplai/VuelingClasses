using System;
using System.Collections.Generic;
using Vueling.Aplication.Services.Contrats;
using Vueling.Aplication.DTO;
using Vueling.Infrastructure.Repository.Repository;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Domain.Entities;
using AutoMapper;
using Vueling.Common.Layer;

namespace Vueling.Aplication.Services
{//aqui iria automapper, ya que hace la conversion
    //el servicio tiene QUE INSTANCIAR el Interfaz REPOSITORIO, pero en el constructor se recibe la clase
    //
    public class AlumnoService : IService<AlumnoDTO>
    {//Irepository solo acepta de tipo AlumnoEntity
        private readonly IRepository<AlumnoEntity> iRepositorio;

        public AlumnoService() : this(new AlumnoRepositorycs()) { }

        public AlumnoService(AlumnoRepositorycs alumnoRepositorio) {
            iRepositorio = alumnoRepositorio;
        }
        

        public AlumnoDTO Add(AlumnoDTO alumnoDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AlumnoDTO, AlumnoEntity>()
            .ForMember(d => d.Years, od => od.ResolveUsing(o => DateTime.Today.AddTicks(-o.Birthday.Ticks).Year - 1)));

            IMapper iMapper = config.CreateMapper();

            var destination = iMapper.Map<AlumnoDTO, AlumnoEntity>(alumnoDTO);
            try
            {
                iRepositorio.Add(destination);
            }
            catch (VuelingException ex)
            {
                //log
                throw;
            }
            return alumnoDTO;
        }

        public List<AlumnoDTO> GetAll()
        {
            
            List <AlumnoDTO> AlumnoListEntity= new List<AlumnoDTO>();


            Mapper.Initialize(cfg => cfg.CreateMap<AlumnoDTO, AlumnoEntity>()
            .ReverseMap()
            );


            return AlumnoListEntity;
        }

        public AlumnoDTO GetById(int id)
        {
            throw new NotImplementedException();
        }






        public AlumnoDTO Update(AlumnoDTO model)
        {
            throw new NotImplementedException();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
