using MediatR;

namespace Application.Features.Commands.DeleteForm;

public class DeleteFormCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
