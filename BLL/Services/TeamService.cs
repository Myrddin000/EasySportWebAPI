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
    public class TeamService : ITeamService
    {
        // Liaison avec la DAL (Son Interface 'IUserRepos' + Le nom '_userRepos')
        private readonly ITeamRepository _teamRepository;
        // Construction de l'appel (Son Services 'UserServie' avec comme params Interface 'IUserRepos' et son nom et dans ce constructeur faire l'appel de liaison DAL '_userRepos')
        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public void Create(TeamFormDTO team)
        {
            if (team == null || team.Sport == null)
            {
                throw new Exception("Données incomplètes");
            }
            try
            {
                
                
                _teamRepository.Create(team.ToDAL());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        public IEnumerable<TeamDTO> GetAll()
        {
            try
            {
                return _teamRepository.GetAll().ToBLL();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(TeamFormDTO team)
        {
            if (team.Name == null || team.Sport == null)
            {
                throw new Exception("Données incomplètes");
            }
            try
            {
                _teamRepository.Update(team.ToDAL());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        } 
        public void Delete(Guid Id)
        {
            try
            {
                _teamRepository.Delete(Id);
            }
            catch (Exception)
            {

                throw new Exception();
            };
        }

        public TeamDTO GetDetails(Guid Id)
        {
            try
            {

                return _teamRepository.GetDetails(Id).ToBLL();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void AddPlayer(Guid TeamId, Guid PlayerId)
        {
            
            try
            {
                _teamRepository.AddPlayer(PlayerId, TeamId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletePlayer(Guid TeamId, Guid PlayerId)
        {
            try
            {
                _teamRepository.DeletePlayer(PlayerId, TeamId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public IEnumerable<TeamsUsersDTO> GetAllPlayers(Guid TeamId)
        {
            try
            {
                return _teamRepository.GetAllPlayers(TeamId).ToBLL();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
