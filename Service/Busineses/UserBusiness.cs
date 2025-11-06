using System.Text.RegularExpressions;
using DataLayer.Contracts.Contracts;
using DataLayer.DTOs;
using DataLayer.Errors;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Service.IBusineses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace Service.Busineses
{
    public class UserBusiness(
        IUserRepository userRepository,
        IPasswordHasher<User> passwordhashr,
        IConfiguration configuration) : IUserBusiness
    {
        public async Task Insert(CreateUserDto dto)
        {
            await InsertRegisterAsync(dto);

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                CreationDate = DateTime.Now,
            };

            user.PasswordHash = passwordhashr.HashPassword(user, dto.Password);


            await userRepository.InsertAsync(user);
        }

        public async Task<string?> Login(LoginDto dto)
        {
            ValidateLoginInput(dto);
            User? user = await userRepository.GetByEmail(dto.Email);
            if (user is null)
                throw new ArgumentException(UserError.EmailIsNotExist);

            var verify = passwordhashr.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (verify == PasswordVerificationResult.Failed)
                throw new ArgumentException(UserError.PasswordIsNotValid);

            var token = GenerateJwtToken(user);

            return (token);
        }

        public async Task Delete(int id)
        {
            User user = await userRepository.GetById(id);
            if (user is null)
                throw new ArgumentException(UserError.UserNotFound);

            await userRepository.Delete(user);
        }


        private void ValidateLoginInput(LoginDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email))
                throw new ArgumentNullException(UserError.EmailIsNull);

            if (string.IsNullOrEmpty(dto.Password))
                throw new ArgumentNullException(UserError.PasswordIsNull);

            const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(dto.Email, pattern))
                throw new ArgumentException(UserError.EmialIsNotValid);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("fullname", user.FullName ?? string.Empty)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task InsertRegisterAsync(CreateUserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.FullName))
                throw new ArgumentException(UserError.FullNameIsNull);

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException(UserError.EmailIsNull);

            if (string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException(UserError.PasswordIsNull);


            const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(user.Email, pattern))
                throw new ArgumentException(UserError.EmialIsNotValid);


            var existingUser = await userRepository.GetByEmail(user.Email);
            if (existingUser != null)
                throw new ArgumentException(UserError.UserExist);
        }
    }
}