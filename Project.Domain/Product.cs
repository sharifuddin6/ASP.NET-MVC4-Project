﻿using System;

namespace Project.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
