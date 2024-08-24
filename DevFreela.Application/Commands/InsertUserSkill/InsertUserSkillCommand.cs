using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertUserSkill
{
    public class InsertUserSkillCommand:IRequest<ResultViewModel>
    {
        public int[] SkillsIds { get; set; }
        public int Id { get; set; }
    }
}
