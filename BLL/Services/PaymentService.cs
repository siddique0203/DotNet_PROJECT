using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.EF.Models.DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PaymentService
    {
        DataAccessFactory factory;

        public PaymentService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public bool Create(PaymentDTO dto)
        {
            var mapper = GetMapper();
            var payment = mapper.Map<Payment>(dto);

            payment.PaymentDate = DateTime.Now;
            payment.PaymentStatus = "Paid";

            return factory.PaymentData().Create(payment);
        }

        public List<PaymentDTO> Get()
        {
            var mapper = GetMapper();
            return mapper.Map<List<PaymentDTO>>(factory.PaymentData().Get());
        }

        // Get payment by ID
        public PaymentDTO Get(int id)
        {
            var mapper = GetMapper();
            return mapper.Map<PaymentDTO>(factory.PaymentData().Get(id));
        }

        public PaymentDTO GetByBooking(int bookingId)
        {
            var mapper = GetMapper();
            return mapper.Map<PaymentDTO>(factory.PaymentFeature().GetByBooking(bookingId));
        }
        public bool Update(PaymentDTO dto)
        {
            var mapper = GetMapper();
            var payment = mapper.Map<Payment>(dto);
            return factory.PaymentData().Update(payment);
        }
    }
}
