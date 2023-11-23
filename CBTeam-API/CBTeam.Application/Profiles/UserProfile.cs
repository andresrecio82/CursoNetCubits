using AutoMapper;
using CBTeam.Application.Models;
using CBTeam.Domain.Entities;

namespace CBTeam.Application.Profiles
{
	public class UserProfile: Profile
	{
		public UserProfile() 
		{
			CreateMap<User, UserDto>();
		}
		
	}
}
 