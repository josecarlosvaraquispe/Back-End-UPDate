using Infrastructure.Context;
using Infrastructure.Model;

namespace Infraestructure;

public class ActivityInfraestructure : IActivityInfraestructure
{
    private UpdateDBContext _updateDbContext;

    public ActivityInfraestructure(UpdateDBContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public List<Activity> GetAll()
    {
        return _updateDbContext.Activities.ToList();
    }
    public bool Create(string Title, string Description, string Address, string Date)
    {
        try
        {
            Activity activity = new Activity();
            activity.Title = Title;
            activity.Description = Description;
            activity.Address = Address;
            activity.Date = Date;
            activity.IsActive = true;

            _updateDbContext.Activities.Add(activity);
            _updateDbContext.SaveChanges();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public bool Update(int id, string Title, string Description, string Address, string Date)
    {
        try
        {
            var activity = _updateDbContext.Activities.Find(id); //obtengo

            activity.Title = Title;
            activity.Description = Description;
            activity.Address = Address;
            activity.Date = Date;

            _updateDbContext.Activities.Update(activity); //modifco


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
        var activity = _updateDbContext.Activities.Find(id); //obtengo

        //_learningCenterDbContext.Tutorials.Remove(tutorial);

        activity.IsActive = false;
        
        _updateDbContext.Activities.Update(activity); //modifco
        
        _updateDbContext.SaveChanges();

        return true;
    }

}