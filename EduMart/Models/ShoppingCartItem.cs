﻿using System.ComponentModel.DataAnnotations;

namespace EduMart.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Skills Skills { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
