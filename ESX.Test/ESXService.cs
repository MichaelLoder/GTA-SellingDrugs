using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace GTA.Common.ESX
{
    public class ESXService : BaseScript
    {
        public static dynamic ESX;

        public ESXService()
        {
            Tick += OnTick;
            Debug.WriteLine($"ESX service");
            
            

            API.RegisterCommand("TestESX", new Action<int, List<object>, string>((source, args, raw) =>
            {
                // Getting xPlayer Using ESX APi
                var xPlayer = ESX.GetPlayerFromId(source);
                var Job = xPlayer.getJob();
                xPlayer.triggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[JobInfo]", $"Your Job is {Job.name}. Your Grade Is {Job.grade_name}. Your Salary is {Job.grade_salary}" }
                });
            }), false);
        }

        private async Task OnTick()
        {
            while (ESX == null)
            {
                TriggerEvent("esx:getSharedObject", new object[] { new Action<dynamic>(esx => {
                    ESX = esx;
                    Debug.WriteLine($"ESX {esx != null}");
                })});
                await Delay(500);
            }
        }
    }
}
