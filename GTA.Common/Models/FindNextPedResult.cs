using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core.Native;
using GTA.Common.Models.Entity;

namespace GTA.Common.Models
{
    public class FindNextPedResult
    {
        public bool Result { get; set; }
        public GameEntity Entity { get; set; }
    }
}
