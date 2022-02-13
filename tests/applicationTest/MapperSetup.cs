using application.Profiles;
using AutoMapper;

namespace applicationTest
{
    public static class MapperSetup
    {
       private static IMapper _mapper;
       public static IMapper Mapper => _mapper;
       static MapperSetup(){

           if(_mapper is null){
               _mapper = Init();
           }
       }

       private static IMapper Init(){           
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
           return mockMapper.CreateMapper();
        }
    }
}