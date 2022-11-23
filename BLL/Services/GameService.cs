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
    public class GameService : IGameService
    {
        // Liaison avec la DAL (Son Interface 'IUserRepos' + Le nom '_userRepos')
        private readonly IGameRepository _gameRepository;

        // Construction de l'appel (Son Services 'UserServie' avec comme params Interface 'IUserRepos' et son nom et dans ce constructeur faire l'appel de liaison DAL '_userRepos')
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }



        public void Create(GameFormDTO game)
        {
            //if (game = null)
            //{
            //    throw new Exception("Données Incomplètes");
            //}
            try
            {
                _gameRepository.Create(game.ToDAL());
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
                _gameRepository.Delete(Id);
            }
            catch (Exception)
            {

                throw new Exception();
            };
        }

        public IEnumerable<GameDTO> GetAll()
        {
            try
            {
                return _gameRepository.GetAll().ToBLL();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<GamesUsersDTO> GetHeadcount(Guid Id)
        {
            try
            {
                return _gameRepository.GetHeadcount(Id).ToBLL();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(GameFormDTO game)
        {
            if (game.Date == null || game.StartTime == null || game.EndTime == null || game.ScoreA == null || game.ScoreB == null)
            {
                throw new Exception("Données incomplètes");
            }
            try
            {
                _gameRepository.Update(game.ToDAL());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

      
    }
}
