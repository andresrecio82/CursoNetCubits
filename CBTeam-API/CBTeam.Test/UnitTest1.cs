using AutoMapper;
using CBTeam.Application.Contracts;
using CBTeam.Application.Handlers;
using CBTeam.Application.Models;
using CBTeam.Domain.Entities;
using CBTeam.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace CBTeam.Test
{
	public class GetUserListHandlerTests
	{
		private readonly Mock<IMapper> _mapper;
		private readonly Mock<IValidator<GetUserListRequest>>  _validator;
		private readonly Mock<IUserRepository> _userRepository;

		private GetUserListHandler handler;
		public GetUserListHandlerTests()
		{
			var result = new ValidationResult();

			var userList = new List<User>
			{
				new User
				{
					FirsName="Fernando"
				},
				new User
				{
					FirsName="Micaela"
				},
			};

			var userListDto = new UserDto
			{
				FirsName="FernandoDto"
			};

			_validator = new Mock<IValidator<GetUserListRequest>>();
			_validator
				.Setup(validator => validator.Validate(It.IsAny<GetUserListRequest>()))
				.Returns(result);

			_userRepository = new Mock<IUserRepository> ();
			_userRepository
				.Setup(repository => repository.GetList())
				.Returns(userList);

			_mapper = new Mock<IMapper>();
			_mapper
				.Setup(m => m.Map<UserDto>(It.IsAny<User>()))
				.Returns(userListDto);

			handler = new GetUserListHandler(_mapper.Object,_userRepository.Object,_validator.Object);
		}

		[Fact]
		public async void ObtengoUnRequestValido_RetornoUnResponseValido()
		{
			//arrange 
			
			//act
			var response = await handler.Handle(new GetUserListRequest(),CancellationToken.None);

			//assert
			Assert.NotNull(response);
			Assert.NotNull(response.Userlist);
		}
	}
}