using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace GTA.Common.Models.Entity
{
    public class GameEntity
    {
        public GameEntity(int entityId)
        {
            EntityId = entityId;
        }
        public int EntityId { get; set; }
        public bool DoesEntityExist => API.DoesEntityExist(EntityId);
        public bool IsInAnyVehicle => API.IsPedInAnyVehicle(EntityId,true);
        public int PedType => API.GetPedType(EntityId);
        public Vector3 PedCoords => API.GetEntityCoords(EntityId, false);
        public bool IsPedDeadOrDying => API.IsPedDeadOrDying(EntityId, true);
        public bool IsPlayer => API.IsPedAPlayer(EntityId);
        public bool IsNotPlayerPed => EntityId != API.GetPlayerPed(-1);

        public void SetEntityAsMission()
        {
            API.SetEntityAsMissionEntity(EntityId,false,false);
        }

        public void ClearTasks()
        {
            API.ClearPedTasks(EntityId);
        }

        public void Freeze()
        {
            API.FreezeEntityPosition(EntityId,true);
        }

        public void StandStill()
        {
            API.TaskStandStill(EntityId,6000);
        }


    }
}
