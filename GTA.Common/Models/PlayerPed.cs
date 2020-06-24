using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace GTA.Common.Models
{
    public static class PlayerPed
    {
        public static bool IsSellingDrugs { get; set; }
        public static int Ped => API.GetPlayerPed(-1);
        public static int PedId => API.PlayerPedId();
        public static Vector3 PlayerCoords => API.GetEntityCoords(Ped, false);
        public static bool HasDrugs { get; set; }
        public static bool IsAnyVehicle => API.IsPedInAnyVehicle(Ped, true);
    }
}
