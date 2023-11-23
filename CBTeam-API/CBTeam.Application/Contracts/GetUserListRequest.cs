using MediatR;
using Microsoft.VisualBasic;

namespace CBTeam.Application.Contracts
{
	//INPUT del HANDLER
	public  class GetUserListRequest : IRequest<GetUserListResponse>
	{
		public string? Query { get; set; }
	}
}
