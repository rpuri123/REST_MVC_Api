using AutoMapper;
using Commander.Dtos;
using Commander.Model;

namespace Commander.Profiles
{
  public class CommandsProfile : Profile
  {
      public CommandsProfile()
      {
        //Source -> target
          CreateMap<Command, CommandReadDtos>();
          CreateMap<CommandCreatDto, Command>();
          CreateMap<CommandUpdateDto, Command>();
          CreateMap<Command, CommandUpdateDto>();
      }

  }  
}