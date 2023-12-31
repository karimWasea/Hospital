﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalUtilities
{
    public class Imgoeration
    {

        IWebHostEnvironment webHostEnvironment;

        public Imgoeration(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public string Uploadimg(IFormFile formFiles)
        {
            string filename = null;
            if (formFiles != null)
            {

                string filledirectory = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                filename = Guid.NewGuid() + "-" + formFiles.FileName;
                string filepath = Path.Combine(filledirectory, filename);
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    formFiles.CopyToAsync(fs);
                }
            }
            return filename;

        }








        public string Addrengofimges(IFormFile image)
        {
           
             if(image != null)
            {

                // Generate a unique file name using GUID to avoid name conflicts
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                var newImagePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", fileName);

                using (var stream = new FileStream(newImagePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // Return the new file path
                return $"/Images/{fileName}"; // Store the relative path to the image

            }
            return null;
        }
    }
}




