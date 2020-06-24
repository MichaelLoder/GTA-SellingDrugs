using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using GTA.Client.SellingDrugs.Statics;
using GTA.Common.Models;
using GTA.Common.Models.Entity;

namespace GTA.Client.SellingDrugs.Services
{
    public class AnimationService : BaseScript
    {
        public AnimationService()
        {
            EventHandlers[Strings.SellingDrugsEventName] += new Action<GameEntity>(SellingDrugsHandler);
        }

        private async void SellingDrugsHandler(GameEntity entity)
        {
            API.RequestAnimDict("amb@prop_human_bum_bin@idle_b");
            while (!API.HasAnimDictLoaded("amb@prop_human_bum_bin@idle_b"))
            {
                await Delay(10);
            }
            API.TaskPlayAnim(PlayerPed.PedId, "amb@prop_human_bum_bin@idle_b", "idle_d", 100.0F, 200.0F, 5000, 120, 0.2F, false, false, false);
        }
    }
}
