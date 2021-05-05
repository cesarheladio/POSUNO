﻿using System.ComponentModel.DataAnnotations;

namespace POSUNO.Api.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }      

        public decimal Price { get; set; }

        public float Stock { get; set; }

        public User User { get; set; }



    }
}