using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.TestimonialDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            //Service mapping
            CreateMap<ResultServiceDto,Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            //Register mapping
            CreateMap<CreateNewUserDto,AppUser>().ReverseMap();
            CreateMap<CreateLoginDto, AppUser>().ReverseMap();
            //About mapping
            CreateMap<UpdateAboutDto,About>().ReverseMap();
            CreateMap<ResultAboutDto, About>().ReverseMap();
            //Testimonial mapping
            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            //Staff mapping
            CreateMap<ResultStaffDto, Staff>().ReverseMap();
            //Subscribe mapping
            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();
            //Booking mapping
            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<ApprovedBookingDto, Booking>().ReverseMap();
            //Guest mapping

            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();

        }
    }
}
