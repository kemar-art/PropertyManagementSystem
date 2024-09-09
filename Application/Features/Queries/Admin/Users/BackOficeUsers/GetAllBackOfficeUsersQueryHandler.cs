using Application.Contracts.Repository_Interface;
using Application.Features.Queries.ClientForm.GetAllForms;
using AutoMapper;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Admin.Users.BackOficeUsers;

public class GetAllBackOfficeUsersQueryHandler : IRequestHandler<GetAllBackOfficeUsersQuery, IEnumerable<GetAllBackOfficeUsersDTO>>
{
    private readonly IMapper _mapper;
    private readonly IAdminRepository _userRepository;

    public GetAllBackOfficeUsersQueryHandler(IMapper mapper, IAdminRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<GetAllBackOfficeUsersDTO>> Handle(GetAllBackOfficeUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllBackOfficeUsers();
        return users;
    }
}
