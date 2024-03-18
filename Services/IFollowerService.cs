using LinkStorage.Models;

namespace LinkStorage.Services;

public interface IFollowerService
{
    public Task<bool> FollowNewUser(Guid userId, Guid followingUserId);
    public Task<bool> UnFollow(Guid userId, Guid followingUserId);

    public Task<bool> IsFollowing(Guid? currentUserID, Guid? followingUserId);

    public Task<IEnumerable<User>> GetAllFollowersByCurrentUserID(Guid id);
    
    public Task<IEnumerable<User>>  GetAllFollowingByCurrentUserID(Guid id);
    
    public Task<string> GetIdOfFollowingByIdOfThePersonWhoIsBeingFollowed(string id);
    
}