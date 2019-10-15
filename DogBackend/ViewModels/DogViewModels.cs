﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBackend.ViewModels
{
    public class DogVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public class DogCreateVM
    {
        public string Name { get; set; }
        public int BreedId { get; set; }
        public string Image { get; set; }
    }
}
