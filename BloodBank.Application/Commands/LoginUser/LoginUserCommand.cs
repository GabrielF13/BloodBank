using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<Result<LoginUserViewModel>>
    {
        public string Email { get; set; }
        public string Password{ get; set; }
    }
}
