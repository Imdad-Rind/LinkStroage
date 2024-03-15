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


    public async  Task CreateLink(Links links)
    {
        await _context.Links.AddAsync(links);
        await _context.SaveChangesAsync();
    }

    public async Task<Links> GetLinkById(Guid? id)
    {
        var lnk = await _context.Links.FindAsync(id);
        if (lnk == null)
        {
            throw new Exception("Link not found");
        }

        return lnk;
    }

    public async Task<IEnumerable<Links>> GetAllLinks()
    {
        return await _context.Links.ToListAsync();
    }

    public async Task<IEnumerable<Links>> GetAllPublicLinksAndTheirUsernameById(Guid? id)
    {
        var StringUserId = id.ToString();
        return await _context.Links.Include(l => l.User)
            .Where(l => l.IsPublic & l.User.Id == StringUserId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Links>> GetAllPublicLinksAndTheirUsername()
    {
        return await _context.Links.Include(l => l.User)
            .Where(l => l.IsPublic)
            .ToListAsync();

    }

    public async Task<IEnumerable<Links>> GetAllTheLinksByUserId(Guid id)
    {
        var StringUserId = id.ToString();
        return await _context.Links.Include(l => l.User).Where(l => l.User.Id == StringUserId).ToListAsync();
    }

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

    public async Task<Links> UpdateLink(Links link)
    {
        _context.Links.Update(link);
        await _context.SaveChangesAsync();
        
        return link;
    }

    public async Task<bool> IsLinkPresent(string url)
    {
        return await _context.Links.AnyAsync(l => l.Link.Contains(url));

    }

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