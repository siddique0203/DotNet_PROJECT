using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models.DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FeedbackService
    {
        DataAccessFactory factory;

        public FeedbackService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public bool Create(FeedbackDTO dto)
        {
            var mapper = GetMapper();
            var feedback = mapper.Map<Feedback>(dto);
            feedback.CreatedDate = DateTime.Now;

            return factory.FeedbackData().Create(feedback);
        }

        public List<FeedbackDTO> Get()
        {
            var mapper = GetMapper();
            var feedbacks = factory.FeedbackData().Get();
            return mapper.Map<List<FeedbackDTO>>(feedbacks);
        }

        public FeedbackDTO Get(int id)
        {
            var mapper = GetMapper();
            var feedback = factory.FeedbackData().Get(id);
            return mapper.Map<FeedbackDTO>(feedback);
        }

        public bool Update(FeedbackDTO dto)
        {
            var mapper = GetMapper();
            var feedback = mapper.Map<Feedback>(dto);
            return factory.FeedbackData().Update(feedback);
        }

        public bool Delete(int id)
        {
            return factory.FeedbackData().Delete(id);
        }
    }
}
