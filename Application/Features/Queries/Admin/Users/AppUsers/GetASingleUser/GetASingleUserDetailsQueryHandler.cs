using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Queries.ClientForm.GetASingleForm;
using AutoMapper;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Admin.Users.AppUsers.GetASingleUser;

public class GetASingleUserDetailsQueryHandler : IRequestHandler<GetASingleUserDetailsQuery, GetASingleUserDTO>
{
    private readonly IMapper _mapper;
    private readonly IAdminRepository _userRepository;
    private readonly IClientRepository _clientRepository;

    public GetASingleUserDetailsQueryHandler(IMapper mapper, IAdminRepository userRepository, IClientRepository clientRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _clientRepository = clientRepository;
    }

    public async Task<GetASingleUserDTO> Handle(GetASingleUserDetailsQuery request, CancellationToken cancellationToken)
    {
        //Querying the database
        var getUser = await _clientRepository.GetClientById(request.userId);

        //Verify if the record exist
        if (getUser is null)
        {
            throw new NotFoundException(nameof(GetASingleUserDetailsQuery), request.userId);
        }

        //Mapping the object from the Database to the Dto
        var mapData = _mapper.Map<GetASingleUserDTO>(getUser);

        return mapData;
    }
}
