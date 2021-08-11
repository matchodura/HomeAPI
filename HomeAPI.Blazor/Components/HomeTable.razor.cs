using HomeAPI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Blazor.Components
{
    public partial class HomeTable
    {
        [Parameter]
        public List<Home> Home { get; set; }
    }
}
