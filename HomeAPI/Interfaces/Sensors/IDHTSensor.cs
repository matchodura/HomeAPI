using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces
{
    public interface IDHTSensorsensor
    {
        public Task<ActionResult> GetCurrentValue();             

    }
}
