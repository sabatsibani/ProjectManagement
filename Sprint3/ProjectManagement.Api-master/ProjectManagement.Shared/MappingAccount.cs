using AutoMapper;
using ProjectManagement.Entities;

namespace ProjectManagement.Shared
{
    public class MappingAccount: Profile
    {
        public MappingAccount()
        {
            CreateMap<User, UpdateUserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateUserModel, User>();
        }
    }
}
