﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class NaatDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreDTO Genre { get; set; }
        
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }


        public DateTime ReleaseDate { get; set; }


        public byte NumberInStock { get; set; }


        public byte NumberAvailable { get; set; }
    }
}