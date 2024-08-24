using DevFreela.Application.Models;
using MediatR;


namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand:IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}
