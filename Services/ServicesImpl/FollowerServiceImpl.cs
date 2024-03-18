using LinkStorage.Models;
using LinkStorage.Repository;

namespace LinkStorage.Services.ServicesImpl;

public class FollowerServiceImpl : IFollowerService
{
    private readonly IFollowsRepository _repo;

    public FollowerServiceImpl(IFollowsRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> FollowNewUser(Guid userId, Guid followingUserId)
    {
        return await _repo.FollowUser(userId, followingUserId);
    }

    public async Task<bool> UnFollow(Guid userId, Guid followingUserId)
    {
        return await _repo.UnFollowUser(userId,followingUserId);
    }

    public async Task<bool> IsFollowing(Guid? currentUserID, Guid? followingUserId)
    {
        return await _repo.IsUserFollowing(currentUserID, followingUserId);
    }

    public async Task<IEnumerable<User>> GetAllFollowersByCurrentUserID(Guid id)
    {
        return await _repo.GetAllFollowersByUserID(id);
    }

    public async Task<IEnumerable<User>> GetAllFollowingByCurrentUserID(Guid id)
    {
        return await _repo.GetAllFollowingByUserID(id);
    }

    public async Task<string> GetIdOfFollowingByIdOfThePersonWhoIsBeingFollowed(string id)
    {
        return await _repo.GetTheIdOfThePersonWhoISFollowingByIdOfThePersonWhoIsBeingFollowed(id);
    }
}