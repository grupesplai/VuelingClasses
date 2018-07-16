using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace ReposiroryPattern_Example
{
    public class AlmacenController : System.Web.Mvc.Controller
    {
        private readonly IAlmacenRepository _repository;

        public AlmacenController()
        {
            _repository = new TesstAlmacenRepository();
        }

        public AlmacenController(IAlmacenRepository repositorio)
        {
            _repository = repositorio;
        }
    }
}
