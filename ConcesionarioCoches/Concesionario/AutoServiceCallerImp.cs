using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario
{
    public class AutoServiceCallerImp : IAutoServiceCaller
    {
        private BMWAutoService bmwAutoService;
        private FordAutoService hondaAutoService;
        private HondaAutoService fordAutoService;

        public AutoServiceCallerImp(BMWAutoService bmwAutoService, FordAutoService hondaAutoService, HondaAutoService fordAutoService)
        {
            this.bmwAutoService = bmwAutoService;
            this.fordAutoService = fordAutoService;
            this.hondaAutoService = hondaAutoService;
        }

        public void callAutoService()
        {
            bmwAutoService.getService();
            fordAutoService.getService();
            hondaAutoService.getService();
        }
    }
}
