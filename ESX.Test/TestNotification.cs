using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using GTA.Common.ESX;

namespace ESX.Test
{
    public class TestNotification : BaseScript
    {
        private dynamic ESX;
        public TestNotification()
        {
            Tick += OnTick;
        }

        private async Task OnTick()
        {
            try
            {
                while (ESX == null)
                {
                    ESX = ESXService.ESX;
                    await Delay(100);
                }

               // ESX.ShowNotification("LOADED!!!!");
                await Delay(5000);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
           
        }
    }
}
