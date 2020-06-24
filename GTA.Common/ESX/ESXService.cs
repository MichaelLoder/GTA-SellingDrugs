using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace GTA.Common.ESX
{
    public class ESXService : BaseScript
    {
        public static dynamic ESX;

        public ESXService()
        {
            TriggerEvent("esx:getSharedObject", new object[] { new Action<dynamic>(esx => {
                ESX = esx;
                Debug.WriteLine($"ESX {esx != null}");
            })});
        }
    }
}
