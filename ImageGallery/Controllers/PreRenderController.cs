﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageGallery.Services;
using ImageGallery.Utility;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageGallery.Controllers
{
    [Route("/[controller]")]
    public class PreRenderController : Controller
    {
        readonly IAlbumService albumService;

        public PreRenderController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        [HttpGet("{width}/{height}")]
        public async Task<IActionResult> Get(string width, string height)
        {
            var image = await albumService.GetPreRenders(ushort.Parse(width), ushort.Parse(height));
            // TODO: content type  from something
            return File(image, "image/png");
        }
    }
}
