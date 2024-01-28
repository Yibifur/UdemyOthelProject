using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Lütfen oda numarasını giriniz")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Lütfen oda görseli giriniz")]
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen fiyat bilgisi giriniz")]
        
        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen oda başlığı bilgisi  giriniz")]
        [StringLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen yatak sayısı  giriniz")]
        public int BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen banyo sayısı  giriniz")]
        public int BathCount { get; set; }
        //[Required(ErrorMessage = "Lütfen wifi bilgisi giriniz")]
        public string Wifi { get; set; }
        [Required(ErrorMessage = "Lütfen oda ile ilgili gerekli açıklama giriniz")]
        public string Description { get; set; }
    }
}
