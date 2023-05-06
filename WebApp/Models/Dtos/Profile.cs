﻿using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entities;

namespace WebApp.Models.Dtos
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();
    }
}
