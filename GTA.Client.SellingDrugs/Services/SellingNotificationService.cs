using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using GTA.Client.SellingDrugs.Models;
using GTA.Client.SellingDrugs.Statics;
using GTA.Common.ESX;
using GTA.Common.Models;
using GTA.Common.Models.Entity;
using GTA.Common.Service;

namespace GTA.Client.SellingDrugs.Services
{
    public class SellingNotificationService : BaseScript
    {
        private Config _config;
        private int secondsRemaining = 0;
        public SellingNotificationService()
        {
            EventHandlers[Strings.SellingDrugsEventName] += new Action<GameEntity>(SellingDrugsHandler);
            Tick += OnTick;
        }

        private void SellingDrugsHandler(GameEntity entity)
        {
            Debug.WriteLine("Player is now selling drugs");
            PlayerPed.IsSellingDrugs = true;
        }

        private async Task OnTick()
        {
            while (ESXService.ESX == null)
            {
                await Delay(10);
            }

            while (PlayerPed.IsSellingDrugs)
            {
                if (secondsRemaining > 0)
                {
                    secondsRemaining -= 1;
                    ESXService.ESX.ShowNotification($"Remaining seconds {secondsRemaining}");
                }

                await Delay(1000);
            }

            await Delay(100);
        }
    }
}
