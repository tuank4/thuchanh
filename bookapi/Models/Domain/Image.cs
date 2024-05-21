﻿using System.ComponentModel.DataAnnotations.Schema;

namespace bookapi.Models.Domain
{
    public class Image
    {
        public int ID { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string Filename {  get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension {  get; set; }
        public long FileSizeInBytes { get; set; }
        public string FilePath { get; set; }
    }
}
