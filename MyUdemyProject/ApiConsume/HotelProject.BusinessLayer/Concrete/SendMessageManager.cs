using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            this.sendMessageDal = sendMessageDal;
        }

        public void TDelete(SendMessage t)
        {
            sendMessageDal.Delete(t);
        }

        public SendMessage TGetByID(int id)
        {
            var value=sendMessageDal.GetByID(id);
            return value;   
        }

        public List<SendMessage> TGetList()
        {
            return sendMessageDal.GetList();
        }

        public int TGetSendMessageCount()
        {
            return sendMessageDal.GetSendMessageCount();
        }

       

        public void TInsert(SendMessage t)
        {
            sendMessageDal.Insert(t);
        }

        public void TUpdate(SendMessage t)
        {
            sendMessageDal.Update(t);
        }
    }
}
