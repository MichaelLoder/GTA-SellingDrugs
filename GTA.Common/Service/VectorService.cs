using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace GTA.Common.Service
{
    public class VectorService
    {
        public static float DistanceBetweenVectors(Vector3 loc1, Vector3 loc2)
        {
            return API.GetDistanceBetweenCoords(loc1.X, loc1.Y, loc1.Z, loc2.X, loc2.Y, loc2.Z, true);
        }
    }
}
