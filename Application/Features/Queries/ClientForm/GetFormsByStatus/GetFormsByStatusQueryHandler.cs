using Application.Contracts.ILogging;
using Application.Contracts.Repository_Interface;
using Application.StaticDetails;
using Domain;
using Domain.Common;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.ClientForm.GetFormsByStatus
{
    public class GetFormsByStatusQueryHandler : IRequestHandler<GetFormsByStatusQuery, BaseResult<IEnumerable<Form>>>
    {
        private readonly IAppLogger<GetFormsByStatusQueryHandler> _appLogger;
        private readonly IAdminRepository _adminRepository;

        public GetFormsByStatusQueryHandler(IAppLogger<GetFormsByStatusQueryHandler> appLogger, IAdminRepository adminRepository)
        {
            _appLogger = appLogger;
            _adminRepository = adminRepository;;
        }

        public async Task<BaseResult<IEnumerable<Form>>> Handle(GetFormsByStatusQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Form> getFormByStatus = null;

            try
            {
                _appLogger.LogInformation("Handling GetFormsByStatusQuery with Status: {Status}", request.Status);

                if (!string.IsNullOrEmpty(request.Status))
                {
                    _appLogger.LogInformation("Fetching forms with status: {Status}", request.Status);
                    getFormByStatus = await _adminRepository.GetFormByStatusForAdmin(request.Status);
                }
                else
                {
                    _appLogger.LogWarning("Status is null or empty. Defaulting to StatusSubmitted.");
                    getFormByStatus = await _adminRepository.GetFormByStatusForAdmin(FormStatus.StatusSubmitted);
                }

                _appLogger.LogInformation("Successfully retrieved {Count} forms with status: {Status}", getFormByStatus?.Count() ?? 0, request.Status);
                return BaseResult<IEnumerable<Form>>.Success(getFormByStatus);
            }
            catch (Exception ex)
            {
                _appLogger.LogError("An error occurred while handling GetFormsByStatusQuery with Status: {Status}. Exception: {Exception}", request.Status, ex);
                return BaseResult<IEnumerable<Form>>.Failure("An error occurred while retrieving forms. Please try again later.");
            }
        }



    }
}
