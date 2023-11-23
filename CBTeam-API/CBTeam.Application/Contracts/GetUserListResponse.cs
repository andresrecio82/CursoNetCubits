using CBTeam.Application.Models;
using CBTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTeam.Application.Contracts
{
   //OUTPUT del handler
	public class GetUserListResponse
	{
		public List<UserDto>? Userlist{ get; set; }
	}
}
