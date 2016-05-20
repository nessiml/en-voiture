using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnVoiture
{
    class Trottoir
    {
        public enum Obstacle
        {
            ROUTE,
            TROTTOIR,
            RIEN
        }
        

        public bool DetectionTrottoir()
        {
            return true;
        }

        public bool DetectionRoute()
        {
            return true;
        }

        public bool PositionVoiture()
        {
            return true;
        }
    }
}
