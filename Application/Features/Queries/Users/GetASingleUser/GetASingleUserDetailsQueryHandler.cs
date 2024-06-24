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

namespace Application.Features.Queries.Users.GetASingleUser;

public class GetASingleUserDetailsQueryHandler : IRequestHandler<GetASingleUserDetailsQuery, GetASingleUserDTO>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetASingleUserDetailsQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<GetASingleUserDTO> Handle(GetASingleUserDetailsQuery request, CancellationToken cancellationToken)
    {
        //Querying the database
        var getUser = await _userRepository.GetByIdAsync(request.Id);

        //Verify if the record does not exist
        if (getUser is null)
        {
            throw new NotFoundException(nameof(GetASingleUserDetailsQuery), request.Id);
        }

        //Mapping the object from the Database to the Dto
        var mapData = _mapper.Map<GetASingleUserDTO>(getUser);

        return mapData;
    }
}
