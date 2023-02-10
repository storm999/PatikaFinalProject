﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PatikaFinalProject.Bussiness.Services
{
    public class JWTGenerator
    {
        public bool ValidateCredentials(LoginRequestModel userModel)
        {
            // TODO connect to DB to valite username and pass
            // In a real project user log in mechanism would be an indivual module:
            // Hashing and salting pass, using authorization/role pattern etc..
            return true;
        }

        public LoginResponseModel GenerateToken(LoginRequestModel userModel)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("How much is this static key secure ?"));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.Role, "Member") };
    
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", claims: claims, audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(100), signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new LoginResponseModel(handler.WriteToken(token), userModel);
        }
    }

    public class LoginRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginResponseModel
    {
        public LoginResponseModel(string token, LoginRequestModel userModel)
        {
            Token = token;
            UserName = userModel.UserName;
        }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
