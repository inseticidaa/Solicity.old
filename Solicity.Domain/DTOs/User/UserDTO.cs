﻿namespace Solicity.Domain.DTOs.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UdpatedAt { get; set; }

        public static implicit operator UserDTO(Entities.User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Enabled = user.Enabled,
                IsAdmin = user.IsAdmin,
                CreatedAt = user.CreatedAt,
                UdpatedAt = user.UdpatedAt,
            };
        }
    }
}