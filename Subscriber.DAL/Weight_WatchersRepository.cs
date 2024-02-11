using Microsoft.EntityFrameworkCore;
using Subscriber.CORE.Interface_DAL;
using Subscriber.CORE.Response;
using Subscriber.Data;
using Subscriber.Data.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.DAL
{
    public class Weight_WatchersRepository: IWeight_WatchersRepository
    {
        readonly Weight_WatchersContext _weightWatchersContext;
        public Weight_WatchersRepository(Weight_WatchersContext weightWatchersContext)
        {
            _weightWatchersContext = weightWatchersContext;
        }
        public async Task<BaseResponseGeneric<CardResponse>> GetCardDetails(int id)
        {
            try
            {
                var  response = new BaseResponseGeneric<CardResponse>();
                SubscribeCard Card = _weightWatchersContext.Cards.Where(p => p.Id == id).FirstOrDefault();
                if (Card != null)
                {
                    Subscribers subscriber = _weightWatchersContext.Subscribers.Where(p => p.Id == Card.Subscriber_Id).FirstOrDefault();
                    if (subscriber != null)
                    {
                        response.Succeed = true;
                        response.Status = "suceed";
                        response.Response = new CardResponse();
                        response.Response.Id = id;
                        response.Response.Weight = Card.Weight;
                        response.Response.Height = Card.Height;
                        response.Response.BMI = Card.BMI;
                        response.Response.FirstName = subscriber.Firstname;
                        response.Response.LastName = subscriber.Lastname;

                    }
                    else
                    {
                        response.Succeed = false;
                        response.Status = "failed";
                    }
                }
                else
                {
                    response.Succeed = false;
                    response.Status = "failed";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Get card Failed");
            }
        
        }
        public async  Task<BaseResponseGeneric<int>> Login (string email,string password)
        {
            try
            {
                var response = new BaseResponseGeneric<int>();
                Subscribers subscriber= _weightWatchersContext.Subscribers.Where(p=>p.Email == email).FirstOrDefault();
                if (subscriber!=null)
                {
                    SubscribeCard Card = _weightWatchersContext.Cards.Where(p => p.Subscriber_Id == subscriber.Id).FirstOrDefault();
                    if (Card != null)
                    {
                        response.Succeed = true;
                        response.Status = "suceed";
                        response.Response = Card.Id;
                    }
                    else
                    {
                        response.Response =0;
                        response.Succeed = false;
                        response.Status = "failed to get card details";
                    }
                }
                else
                {
                    response.Response = 0;
                    response.Succeed = false;
                    response.Status = "failed to get subscribe details";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("error 401 Login Failed");
            }
           
        }
        public async Task<BaseResponseGeneric<bool>> Register (Subscribers subscribe,double height)
        {
            try
            {
                var response=new BaseResponseGeneric<bool>();
                var newSubscribe = await _weightWatchersContext.Subscribers.AddAsync(subscribe);
                await _weightWatchersContext.SaveChangesAsync();
                SubscribeCard defaultCard = new SubscribeCard
                {
                    OpenDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    BMI = 0,
                    Height = height
                };
                _weightWatchersContext.Cards.AddAsync(defaultCard);
                await _weightWatchersContext.SaveChangesAsync();
                response.Succeed = true;
                response.Response = true;
                response.Status = " subscribe added successfuly";
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("failed to create new subscribe");
            }
          
        }
        public async Task<bool> IsEmailExist(string email)
        {
            return await _weightWatchersContext.Subscribers.AnyAsync(p=>p.Email==email);
           
        }
    }
}
