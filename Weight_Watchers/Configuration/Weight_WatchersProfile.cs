using AutoMapper;
using Subscriber.CORE.DTO;
using Subscriber.CORE.Response;
using Subscriber.Data.entites;

namespace Subscriber.WebApi.Configuration
{
    public class Weight_WatchersProfile : Profile
    {
        public Weight_WatchersProfile()
        {
           //CreateMap<Subscribers, SubscribersDTO>().ForMember(p => p.Height, o => o.Ignore()).ReverseMap();
            CreateMap<BaseResponseGeneric<SubscribeCard>, BaseResponseGeneric<SubscribeCardDTO>>();
          // CreateMap<SubscribeCardDTO, SubscribeCard>().ReverseMap();
        }
    }
}
