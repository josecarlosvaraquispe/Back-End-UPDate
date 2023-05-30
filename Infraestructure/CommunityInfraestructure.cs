using Infraestructure.DataClass;
using Infrastructure.Context;
using Infrastructure.Model;

namespace Infraestructure;

public class CommunityInfraestructure : ICommunityInfraestructure
{
    private UpdateDBContext _updateDbContext;

    public CommunityInfraestructure(UpdateDBContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public List<Community> GetAll()
    {
        return _updateDbContext.Communities.Where(community => community.IsActive).ToList();
    }
    
    public Community GetById (int id)
    {
        return _updateDbContext.Communities.Single(community => community.IsActive && community.Id == id);
    }
    
    public bool Create(CommunityData communityData)
    {
        try
        {
            Community community = new Community();
            community.Name = communityData.Name;
            community.Description = communityData.Description;
            community.CreatedAt = communityData.CreatedAt;
            community.IsActive = true;

            _updateDbContext.Communities.Add(community);
            _updateDbContext.SaveChanges();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public bool Update(int id, CommunityData communityData)
    {
        try
        {
            var community = _updateDbContext.Communities.Find(id);

            community.Name = communityData.Name;
            community.Description = communityData.Description;
            community.CreatedAt = communityData.CreatedAt;

            _updateDbContext.Communities.Update(community);
            
            _updateDbContext.SaveChanges();

            return true;
        }
        
        catch (Exception exception)
        {
            return false;
        }

    }

    public bool Delete(int id)
    {
        var community = _updateDbContext.Communities.Find(id);
        community.IsActive = false;

        _updateDbContext.Communities.Update(community);
        _updateDbContext.SaveChanges();

        return true;
    }
}