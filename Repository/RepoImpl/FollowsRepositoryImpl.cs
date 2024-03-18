using LinkStorage.Data;
using LinkStorage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LinkStorage.Repository.RepoImpl;

public class FollowsRepositoryImpl : IFollowsRepository
{
    private readonly LinkStorageDbContext _context;

    public FollowsRepositoryImpl(LinkStorageDbContext context)
    {
        _context = context;
       
    }

    public async Task<bool> FollowUser(Guid CurrentUserId, Guid FollowingUserId)
    {
        if (CurrentUserId == FollowingUserId)
        {
            return false;
        }

        var follow =
            await _context.Follows.FirstOrDefaultAsync(f =>
                f.Follower_Id == CurrentUserId.ToString() && f.Following_Id == FollowingUserId.ToString());

        if (follow != null)
        {
            return false;
        }

        await _context.Follows.AddAsync(new Follows
        {
            Following_Id = FollowingUserId.ToString(),
            Follower_Id = CurrentUserId.ToString() 
            
        });

        
        
        
        await _context.SaveChangesAsync();
        return true;
        

    }

    public async Task<bool> UnFollowUser(Guid CurrentUserId, Guid FollowingUserId)
    {
        if (CurrentUserId == FollowingUserId)
        {
            return false;
        }
        
        var follow =
            await _context.Follows.FirstOrDefaultAsync(f =>
                f.Follower_Id == CurrentUserId.ToString() && f.Following_Id == FollowingUserId.ToString());

        if (follow != null)
        {
             _context.Follows.Remove(follow);
             await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> IsUserFollowing(Guid? CurrentUserId, Guid? FollowingUserId)
    {
        return await _context.Follows.AnyAsync(f =>
            f.Follower_Id == CurrentUserId.ToString() && f.Following_Id == FollowingUserId.ToString());
    }

    public async Task<IEnumerable<User>>  GetAllFollowersByUserID(Guid Id)
    {
        return
            await _context.Users
                .Where(u => u.Id == Id.ToString())
                    .SelectMany(u => u.Followers.Select(f => f.Followers))
                        .ToListAsync();

    }

    public async Task<IEnumerable<User>>  GetAllFollowingByUserID(Guid Id)
    {
        return
            await _context.Users
                .Where(u => u.Id == Id.ToString())
                    .SelectMany(u => u.Following.Select(f => f.Following))
                        .ToListAsync();
    }

    public async Task<string> GetTheIdOfThePersonWhoISFollowingByIdOfThePersonWhoIsBeingFollowed(string id)
    {
        var following = await _context.Follows.SingleOrDefaultAsync(f => f.Follower_Id == id);
        if (following != null)
        {
            return following.Following_Id;
        }

        return null;
    }
}