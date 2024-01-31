using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context _context) : base(_context)
        {
        }

        public void BookingStatusChangedApproved(Booking booking)
        {
            var context = new Context();

            var value=context.Bookings.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
            value.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangedApproved2(int id)
        {
            var context = new Context();

            var value = context.Bookings.Find(id);
            value.Status = "Onaylandı";
            context.SaveChanges();
        }
    }
}
