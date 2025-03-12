using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class RoomsApiController : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomsApiController>>> Get()
    {

    }

    [HttpPost]
    public async Task<ActionResult<RoomsApiController>> Post( RoomsApiController data)
    {
      
    }
}