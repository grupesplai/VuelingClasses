using AutoMapper;
using Cobalco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cobalco.Controllers
{//clase para ejercicio automapper

    public class AlumnoControllerAutomapper : Profile
    {
        public AlumnoControllerAutomapper()
        {
            CreateMap<Alumno, AlumnoViewModel>().ReverseMap();


        }
        
    }
}