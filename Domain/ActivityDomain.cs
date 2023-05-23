using Infraestructure;
using Infrastructure.Model;

namespace Domain;

public class ActivityDomain: IActivityDomain
{
    private IActivityInfraestructure _activityInfraestructure;

    public ActivityDomain(IActivityInfraestructure activityInfraestructure)
    {
        _activityInfraestructure = activityInfraestructure;
    }

    public List<Activity> GetAll()
    {
        return _activityInfraestructure.GetAll();
    }

    public bool Create(string Title, string Description, string Address, string Date)
    {
        return _activityInfraestructure.Create(Title, Description, Address, Date);
    }

    public bool Update(int id, string Title, string Description, string Address, string Date)
    {
        return _activityInfraestructure.Update(id, Title, Description, Address, Date);
    }

    public bool Delete(int id)
    {
        return _activityInfraestructure.Delete(id);
    }
}