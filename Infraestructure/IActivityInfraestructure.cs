using Infraestructure.DataClass;
using Infrastructure.Model;

namespace Infraestructure;

public interface IActivityInfraestructure
{
    public Task<List<Activity>> GetAll();
    public Task<Activity> GetById(int id);
    Task<bool> Create(ActivityData activityData); 
    bool Update(int id, ActivityData activityData );
    bool Delete(int id);
    
}