using LinkStorage.Data;
using LinkStorage.Models;
using LinkStorage.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LinkStorage.Repository.RepoImpl;

public class LinkRepositoryImpl : ILinkRepository
{
    private readonly LinkStorageDbContext _context;

    public LinkRepositoryImpl(LinkStorageDbContext context)
    {
        this._context = context;
    }
    
    
    /* create a new link or upload*/

    public async  Task CreateLink(Links links)
    {
        await _context.Links.AddAsync(links);
        await _context.SaveChangesAsync();
    }
    
    /* get the link by its id*/
    public async Task<Links> GetLinkById(Guid? id)
    {
        var lnk = await _context.Links.FindAsync(id);
        if (lnk == null)
        {
            throw new Exception("Link not found");
        }

        return lnk;
    }
    /* get all the links from DB */
    public async Task<IEnumerable<Links>> GetAllLinks()
    {
        return await _context.Links.ToListAsync();
    }
    /*
     *
     * get the all the public links and user's username from DB by the id of the user who uploaded them
     * 
     */
    public async Task<IEnumerable<Links>> GetAllPublicLinksAndTheirUsernameById(Guid? id)
    {
        var StringUserId = id.ToString();
        return await _context.Links.Include(l => l.User)
            .Where(l => l.IsPublic & l.User.Id == StringUserId)
            .ToListAsync();
    }
    
    /*
     * get all the public links From DB with User's username who uploaded them
     * */
    public async Task<IEnumerable<Links>> GetAllPublicLinksAndTheirUsername()
    {
        return await _context.Links.Include(l => l.User)
            .Where(l => l.IsPublic)
            .ToListAsync();

    }
    /*
     * get all the links by the user id of the uploader
     */
    public async Task<IEnumerable<Links>> GetAllTheLinksByUserId(Guid id)
    {
        var StringUserId = id.ToString();
        return await _context.Links.Include(l => l.User)
            .Where(l => l.User.Id == StringUserId)
            .ToListAsync();
    }
   
    /*
     *
     * here i want get all public link post by user who is being followed by the current user
     * to get all the all link i am using current user id
     * 
     */
    
    public async Task<IEnumerable<Links>> GetAllThePublicLinksOfUserYouFollowingByYourId(Guid yourUserId)
    {
        
        var followedUserIds = await _context.Follows
            .Where(uf => uf.Follower_Id == yourUserId.ToString())
            .Select(uf => uf.Following_Id)
            .ToListAsync();

        var posts = await _context.Links.Include(l => l.User)
            .Where(p => followedUserIds.Contains(p.User.Id) && p.IsPublic)
            .ToListAsync();

        return posts;


    }
    

    /* delete link from DB*/
    public async Task DeleteLinkById(Guid id)
    {
        var lnk = await _context.Links.FindAsync(id);
        if (lnk == null)
        {
            throw new Exception("Link not found");
        }

        _context.Links.Remove(lnk);
        await _context.SaveChangesAsync();
    }
        /*
         * update link
         */
    public async Task<Links> UpdateLink(Links link)
    {
        _context.Links.Update(link);
        await _context.SaveChangesAsync();
        
        return link;
    }
    /*
     * check if the link is already present in the DB 
     */
    public async Task<bool> IsLinkPresent(string url)
    {
        return await _context.Links.AnyAsync(l => l.Link.Contains(url));

    }
        /*
         *
         * if the link is already present in DB so get raw html for embed link 
         * 
         */
    public async Task<string> GetHtmlByUrl(string url)
    {
        if (await IsLinkPresent(url))
        {
            var lnk = await _context.Links.FirstOrDefaultAsync(l => l.Link.Contains(url));
            return lnk.RawHtml;
        }

        return null;
    }
}