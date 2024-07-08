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

namespace Application.Features.Queries.Users.AppUsers.GetAllUsers;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUsersDTO>>
{
    private readonly IMapper _mapper;
    private readonly IAdminRepository _userRepository;

    public GetAllUserQueryHandler(IMapper mapper, IAdminRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<GetAllUsersDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var getAllUsers = await _userRepository.GetAllAsync();

        var mapData = _mapper.Map<IEnumerable<GetAllUsersDTO>>(getAllUsers);

        return mapData;
    }
}
