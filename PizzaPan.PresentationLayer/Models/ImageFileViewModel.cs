﻿using Microsoft.AspNetCore.Http;

namespace PizzaPan.PresentationLayer.Models
{
    public class ImageFileViewModel
    {
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
