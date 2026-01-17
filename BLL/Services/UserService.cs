using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        DataAccessFactory factory;

        public UserService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public bool Create(UserDTO dto)
        {
            var mapper = GetMapper();
            var user = mapper.Map<User>(dto);
            return factory.UserData().Create(user);
        }

        public List<UserDTO> Get()
        {
            var mapper = GetMapper();
            var users = factory.UserData().Get();
            return mapper.Map<List<UserDTO>>(users);
        }

        public UserDTO Get(int id)
        {
            var mapper = GetMapper();
            var user = factory.UserData().Get(id);
            return mapper.Map<UserDTO>(user);
        }

        public bool Update(UserDTO dto)
        {
            var mapper = GetMapper();
            var user = mapper.Map<User>(dto);
            return factory.UserData().Update(user);
        }

        public bool Delete(int id)
        {
            return factory.UserData().Delete(id);
        }
    }
}
