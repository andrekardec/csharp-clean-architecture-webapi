using CleanArchitectureWebAPI.Application.ViewModels.User;

namespace CleanArchitectureWebAPI.Application.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUserById(Guid id);
        UserViewModel AddUser(UserViewModel userRequest);
    }
}
