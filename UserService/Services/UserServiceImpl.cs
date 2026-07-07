using Grpc.Core;

namespace UserService.Services;

public class UserServiceImpl : User.UserBase
{
    public override Task<GetUserReply> GetUser(GetUserRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GetUserReply
        {
            Id = request.Id,
            Username = $"User_{request.Id}"
        });
    }
}
