using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto,Room>();
            CreateMap<Room, RoomAddDto>();
            //reversemap fonksiyonuyla yukarıdaki eşitlemeyi iki defa yapmamıza gerek kalmadı
            CreateMap<UpdateRoomDto,Room>().ReverseMap();
            
        }
    }
}
