﻿using EDB.Domain.Entities;

namespace EDB.WebAPI.Model.AccountModel
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public IFormFile ImagePath { get; set; }
        public string? AudioFilePath { get; set; }
    }
}
