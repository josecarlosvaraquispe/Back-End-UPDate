using Infraestructure;
using Infraestructure.DataClass;
using Infrastructure.Model;

namespace Domain;

public class CommunityDomain : ICommunityDomain
{
    private ICommunityInfraestructure _communityInfraestructure;
    
    public CommunityDomain(ICommunityInfraestructure communityInfraestructure)
    {
        _communityInfraestructure = communityInfraestructure;
    }

    public List<Community> GetAll()
    {
        return _communityInfraestructure.GetAll();
    }

    public Community GetById(int id)
    {
        return _communityInfraestructure.GetById(id);
    }

    public bool Create(CommunityData communityData)
    {
        return _communityInfraestructure.Create(communityData);
    }

    public bool Update(int id, CommunityData communityData)
    {
        return _communityInfraestructure.Update(id, communityData);
    }

    public bool Delete(int id)
    {
        return _communityInfraestructure.Delete(id);
    }
}