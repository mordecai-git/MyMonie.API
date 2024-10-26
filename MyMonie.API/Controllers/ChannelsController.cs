// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.AspNetCore.Mvc;
using MyMonie.Core.Models.Utilities;
using MyMonie.Models.App;
using System.Linq;

namespace MyMonie.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChannelsController : BaseController
{
    private readonly MyMonieContext _context;

    public ChannelsController(MyMonieContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult GetChannels()
    {
        var chs = _context.Channels.ToList();

        var result = new ErrorResult("Unable to return valid response", chs.ToString()); // new SuccessResult(chs);
        return ProcessResponse(result);
    }
}
