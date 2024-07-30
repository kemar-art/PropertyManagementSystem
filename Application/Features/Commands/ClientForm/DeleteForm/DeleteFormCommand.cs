using MediatR;

namespace Application.Features.Commands.ClientForm.DeleteForm;

public class DeleteFormCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
