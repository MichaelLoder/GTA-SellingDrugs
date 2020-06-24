using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using GTA.Client.SellingDrugs.Models;
using GTA.Client.SellingDrugs.Statics;
using GTA.Common.Models;
using GTA.Common.Service;
using Control = GTA.Common.Statics.Control;

namespace GTA.Client.SellingDrugs.Services
{
    public class SellingService : BaseScript
    {
        private int oldPed;
        private Vector3 pedPosition;
        private Config _config;
        public SellingService()
        {
            Debug.WriteLine("Selling Service loaded!");
            LoadConfig();
            Tick += OnTick;
        }

        private async Task OnTick()
        {
            try
            {
                var player = PlayerPed.Ped;
                var pid = PlayerPed.PedId;
                var playerLocation = PlayerPed.PlayerCoords;
                var firstPed = GameWorld.FindFirstPed();
                var nextPed = GameWorld.FindNextPed(firstPed.Handle);
                do
                {
                    // get ped coords
                    var pedPos = nextPed.Entity.PedCoords;
                    var distanceFromPed = VectorService.DistanceBetweenVectors(pedPos, PlayerPed.PlayerCoords);
                    if (distanceFromPed < 3)
                    {
                        if (!PlayerPed.IsAnyVehicle)
                        {
                            if (nextPed.Entity.DoesEntityExist)
                            {
                                if (!nextPed.Entity.IsPedDeadOrDying)
                                {
                                    if (nextPed.Entity.PedType != 28 && !nextPed.Entity.IsPlayer)
                                    {
                                        pedPosition = nextPed.Entity.PedCoords;
                                        if (nextPed.Entity.IsNotPlayerPed
                                            && nextPed.Entity.EntityId != oldPed && ControlsService.EWasPressed())
                                        {
                                            // set old ped entityId
                                            oldPed = nextPed.Entity.EntityId;
                                            nextPed.Entity.SetEntityAsMission();
                                            nextPed.Entity.ClearTasks();
                                            nextPed.Entity.Freeze();
                                            nextPed.Entity.StandStill();
                                            TriggerEvent(Strings.SellingDrugsEventName, nextPed.Entity);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    nextPed = GameWorld.FindNextPed(firstPed.Handle);
                } while (nextPed.Result);
                API.EndFindPed(firstPed.Handle);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error Selling service : {e.Message}");
            }
            await Delay(100);
        }

        private void LoadConfig()
        {
            try
            {
                _config = ConfigService.LoadConfig(Strings.Configlocation, Strings.ConfigKey);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
