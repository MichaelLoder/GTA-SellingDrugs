using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core.Native;

namespace GTA.Common.Service
{
    public static class ControlsService
    {
        private static int E = 38;
        public static bool EWasPressed()
        {
            return API.IsControlJustPressed(1, E) || API.IsControlPressed(1, E)
                                                   || API.IsControlJustReleased(1, E);
        }
    }
}
