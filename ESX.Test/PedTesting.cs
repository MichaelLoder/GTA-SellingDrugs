using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using GTA.Common.Models;
using GTA.Common.Service;

namespace ESX.Test
{
    public class PedTesting : BaseScript
    {
        public PedTesting()
        {
            Tick += OnTick;
            API.RegisterCommand("peds", new Action<dynamic, List<dynamic>, string>((dynamic source, List<dynamic> args, string rawCommand) =>
            {
                string pedHandles = "PEDS IN GAME : ";
                foreach (var p in World.GetAllPeds())
                {
                    pedHandles += p.Handle + ", ";
                }
                Debug.WriteLine(pedHandles.Trim().Trim(','));
            }), false);
        }

        private async Task OnTick()
        {
            try
            {
                await Delay(10);
                Debug.WriteLine($" E pressed : {ControlsService.EWasPressed()}");
                //var firstPed = GameWorld.FindFirstPed();
                //Debug.WriteLine($"Find first Ped : {firstPed.Handle} , {firstPed.Entity}");
                //var findNextPed = GameWorld.FindNextPed(firstPed.Handle);
                //Debug.WriteLine($"Find next ped : {findNextPed.Result} , {findNextPed.Entity}");
                //Debug.WriteLine($"ALL PEDS COUNT : {World.GetAllPeds().Length}");
                //API.EndFindPed(firstPed.Handle);
                await Delay(2000);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"ERROR : {e.Message}");
            }
        }
    }
}
