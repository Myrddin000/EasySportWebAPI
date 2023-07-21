using EasySport_BLL.Interfaces;
using EasySport_BLL.Models;
using EasySport_BLL.Tools;
using EasySport_DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Services
{
    
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _Configuration;


        //constructeur
        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _Configuration = configuration;

        }



        public TokenDTO Auth(LoginDTO login)
        {
            UserDTO user = _authRepository.Auth(login.Login, login.Password).ToBLL();

            if (user.Password != login.Password)
            {
                throw new Exception("Mot de passe incorrecte");
            }
            List<Claim> Claims = new List<Claim>
                {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),

                };

            string Token = GenerateToken(_Configuration["Jwt:Key"], Claims);
            UserRegisteredDTO userRegisteredDTO = user.UserRegisteredToBLL();
            return new TokenDTO(Token, userRegisteredDTO);


        }

        public string GenerateToken(string secretkey, List<Claim> claims)
        {
            //creer une sorte de clé de sécu unique
            SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            //reçoit les claims/parametres descriptifs
            SecurityTokenDescriptor TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature),
            };

            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            SecurityToken Token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(Token);
        }
    }
}
