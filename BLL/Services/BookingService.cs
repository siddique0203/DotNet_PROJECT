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
    public class BookingService
    {
        DataAccessFactory factory;

        public BookingService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Booking, BookingDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public bool Create(BookingDTO dto)
        {
            var mapper = GetMapper();
            var booking = mapper.Map<Booking>(dto);

            // Workflow automation
            booking.Status = "Pending";

            return factory.BookingData().Create(booking);
        }

        public List<BookingDTO> Get()
        {
            var mapper = GetMapper();
            var bookings = factory.BookingData().Get();
            return mapper.Map<List<BookingDTO>>(bookings);
        }

        public BookingDTO Get(int id)
        {
            var mapper = GetMapper();
            var booking = factory.BookingData().Get(id);
            return mapper.Map<BookingDTO>(booking);
        }

        public bool Update(BookingDTO dto)
        {
            var mapper = GetMapper();
            var booking = mapper.Map<Booking>(dto);
            return factory.BookingData().Update(booking);
        }

        public bool UpdateStatus(int id, string status)
        {
            var booking = factory.BookingData().Get(id);
            if (booking == null) return false;

            booking.Status = status;
            return factory.BookingData().Update(booking);
        }

        public bool Delete(int id)
        {
            return factory.BookingData().Delete(id);
        }
    }
}
