using Subscriber.CORE.DTO;
using Subscriber.CORE.Response;
using Subscriber.Data.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.CORE.Interface_DAL
{
    public interface IWeight_WatchersRepository
    {
        public Task<BaseResponseGeneric<bool>> Register(Subscribers subscriber, double height);
        public Task<BaseResponseGeneric<int>> Login(string password, string email);
        public Task<BaseResponseGeneric<CardResponse>> GetCardDetails(int id);
        public Task<bool> IsEmailExist(string email);
    }
}
