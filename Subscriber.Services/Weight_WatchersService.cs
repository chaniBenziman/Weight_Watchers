using AutoMapper;
using Subscriber.CORE.DTO;
using Subscriber.CORE.Interface_DAL;
using Subscriber.CORE.Response;
using Subscriber.Data.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscriber.CORE.Interface_Service;

namespace Subscriber.Services
{
    public class Weight_WatchersService : IWeight_WatchersService
    {
        readonly IWeight_WatchersRepository _IWeight_WatchersRepository;
        readonly IMapper _mapper;
        public Weight_WatchersService(IWeight_WatchersRepository IWeight_WatchersRepository,IMapper mapper)
        {
            _IWeight_WatchersRepository = IWeight_WatchersRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponseGeneric<CardResponse>> GetCardDetails(int id)
        {
            var cardDetails = await _IWeight_WatchersRepository.GetCardDetails(id);
            if (cardDetails==null)
            {
                cardDetails.Status = "Card not found";
            }
            else
            {
                cardDetails.Succeed = true;
                cardDetails.Status = "Get card details succeede";
            }
            return cardDetails;
        }
        public async Task<BaseResponseGeneric<int>> Login(string email, string password)
        {
            var response = await _IWeight_WatchersRepository.Login(email,password);
            if (!IsValidEmail(email) || password!=null)
            {
                response.Response = 0;
                response.Succeed = false;
                response.Status = "invalid email or password";
            }
            return  _mapper.Map<BaseResponseGeneric<int>>(response);
        }

        public async Task<BaseResponseGeneric<bool>> Register(SubscribersDTO subscriberDTO)
        {
            var response = await _IWeight_WatchersRepository.Register(_mapper.Map<Subscribers>(subscriberDTO), subscriberDTO.Height);
            if (!await _IWeight_WatchersRepository.IsEmailExist(subscriberDTO.Email))
            {
                response.Succeed = false;
                response.Status = "invalid email";
            }
            return response;
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch 
            {

                return false;
            }
        }

       
    }

}
