using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core.Native;
using GTA.Common.Models.Entity;

namespace GTA.Common.Models
{
    public static class GameWorld
    {
        public static FindFirstPedResult FindFirstPed()
        {
            int firstPed = 0;
            var handle = API.FindFirstPed(ref firstPed);
            return new FindFirstPedResult()
            {
                Handle = handle,
                Entity = firstPed
            };
        }

        public static FindNextPedResult FindNextPed(int handle)
        {
            int entity = 0;
            var result = API.FindNextPed(handle, ref entity);
            return new FindNextPedResult()
            {
                Entity = new GameEntity(entity),
                Result = result
            };
        }
    }
}
