﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlask.DAL.Repository.Entities
{
    public class MoviesEntity
    {
        public int IdMovie { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public string PicturePath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
    }
}
