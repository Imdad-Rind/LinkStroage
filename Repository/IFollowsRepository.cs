using LinkStorage.Models;

namespace LinkStorage.Repository;

public interface IFollowsRepository
{
    public Task<bool> FollowUser(Guid CurrentUserId, Guid FollowingUserId);
    
    public Task<bool> UnFollowUser(Guid CurrentUserId, Guid FollowingUserId);

    public Task<bool> IsUserFollowing(Guid? CurrentUserId, Guid? FollowingUserId);

    public Task<IEnumerable<User>> GetAllFollowersByUserID(Guid Id);
    
    public Task<IEnumerable<User>> GetAllFollowingByUserID(Guid Id);
    public Task<string> GetTheIdOfThePersonWhoISFollowingByIdOfThePersonWhoIsBeingFollowed(string id);

}