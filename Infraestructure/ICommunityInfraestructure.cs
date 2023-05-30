using Infraestructure.DataClass;
using Infrastructure.Model;

namespace Infraestructure;

public interface ICommunityInfraestructure
{
    List<Community> GetAll();
    public Community GetById(int id);
    bool Create(CommunityData communityData); 
    bool Update(int id, CommunityData activityData );
    bool Delete(int id);
}