using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces
{
    public interface IDHTSensor
    {
        public Task<ActionResult> GetCurrentValue();             

    }
}
