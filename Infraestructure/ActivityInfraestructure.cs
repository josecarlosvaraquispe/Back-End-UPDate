using Infraestructure.DataClass;
using Infrastructure.Context;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class ActivityInfraestructure : IActivityInfraestructure
{
    private UpdateDBContext _updateDbContext;

    public ActivityInfraestructure(UpdateDBContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public async Task<List<Activity>> GetAll()
    {
        return await _updateDbContext.Activities.Where(activity => activity.IsActive).ToListAsync();
    }
    public async Task<Activity> GetById(int id)
    {
        return await _updateDbContext.Activities.SingleAsync(activity => activity.IsActive && activity.Id == id);
    }
    public async Task<bool> Create(ActivityData activityData)
    {
        try
        {
            Activity activity = new Activity();
            activity.Title = activityData.Title;
            activity.Description = activityData.Description;
            activity.Address = activityData.Address;
            activity.Date = activityData.Date;
            activity.IsActive = true;

            await _updateDbContext.Activities.AddAsync(activity);
            await _updateDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public bool Update(int id, ActivityData activityData)
    {
        try
        {
            //using (var transaction = _updateDbContext.Database.BeginTransaction()){}
            var activity = _updateDbContext.Activities.Find(id); //obtengo

            activity.Title = activityData.Title;
            activity.Description = activityData.Description;
            activity.Address = activityData.Address;
            activity.Date = activityData.Date;

            _updateDbContext.Activities.Update(activity); //modifco


            _updateDbContext.SaveChanges();

            return true;
        }
        catch (Exception ex)
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