using AutoMapper;
using CBTeam.Application.Contracts;
using CBTeam.Application.Models;
using CBTeam.Domain.Entities;
using CBTeam.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace CBTeam.Application.Handlers
{
	public class GetUserListHandler : IRequestHandler<GetUserListRequest, GetUserListResponse>
	{
		private readonly IMapper _mapper;
		private readonly IValidator<GetUserListRequest> _validator;
		private readonly IUserRepository _userRepository;
		public GetUserListHandler(IMapper mapper, IUserRepository userRepository, IValidator<GetUserListRequest> validator) 
		{
			_mapper = mapper;
			_userRepository = userRepository;
			_validator = validator;
		}
		public async Task<GetUserListResponse> Handle(GetUserListRequest request, CancellationToken cancellationToken)
		{
			var response = new GetUserListResponse();

			var result = _validator.Validate(request);
			
			await Task.Delay(0, cancellationToken);

			var userList = _userRepository.GetList();

			response.Userlist = userList
				.Select(r => MapTo(r))
				.ToList();

			return response;
		}

		private UserDto MapTo(User user) 
		{
			return _mapper.Map<UserDto>(user);
		}

	}
}
