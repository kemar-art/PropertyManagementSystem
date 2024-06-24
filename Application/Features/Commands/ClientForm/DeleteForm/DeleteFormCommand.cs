using MediatR;

namespace Application.Features.Commands.ClientForm.DeleteForm;

public class DeleteFormCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
