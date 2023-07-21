using EasySport_BLL.Interfaces;
using EasySport_BLL.Models;
using EasySport_BLL.Tools;
using EasySport_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Services
{
    public class UserService : IUserService
    {
        // Liaison avec la DAL (Son Interface 'IUserRepos' + Le nom '_userRepos')
        private readonly IUserRepository _userRepository;
        // Construction de l'appel (Son Services 'UserServie' avec comme params Interface 'IUserRepos' et son nom et dans ce constructeur faire l'appel de liaison DAL '_userRepos')
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(UserFormDTO user)
        {
            if (user == null)
            {
                throw new Exception("incomplete data");
            }
            try
            {
                _userRepository.Create(user.ToDAL());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            try
            {
                return _userRepository.GetAll().ToBLL();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Delete(Guid Id)
        {
            try
            {
                _userRepository.Delete(Id);
            }
            catch (Exception)
            {

                throw new Exception();
            };
        }

        public void Update(UserDTO user)
        {
            if (user.Pseudo == null || user.Email == null || user.Password == null)
            {
                throw new Exception("Données incomplètes");
            }
            try
            {
                _userRepository.Update(user.ToDAL());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public UserFormDTO GetById(Guid Id)
        {
            try
            {
                 return _userRepository.GetById(Id).ToFormBLL();
            }
            catch (Exception)
            {

                throw new Exception();
            };
        }
    }
}
