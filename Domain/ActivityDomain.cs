using System.Runtime.InteropServices.JavaScript;
using Infraestructure;
using Infraestructure.DataClass;
using Infrastructure.Model;

namespace Domain;

public class ActivityDomain: IActivityDomain
{
    private IActivityInfraestructure _activityInfraestructure;

    public ActivityDomain(IActivityInfraestructure activityInfraestructure)
    {
        _activityInfraestructure = activityInfraestructure;
    }

    public async Task<List<Activity>> GetAll()
    {
        return await _activityInfraestructure.GetAll();
    }

    public async Task<Activity> GetById(int id)
    {
        return await _activityInfraestructure.GetById(id);
    }

    public async Task<bool> Create(ActivityData activityData)
    {
        return await _activityInfraestructure.Create(activityData);
    }

    public bool Update(int id, ActivityData activityData)
    {
        return _activityInfraestructure.Update(id, activityData);
    }

    public bool Delete(int id)
    {
        return _activityInfraestructure.Delete(id);
    }
}