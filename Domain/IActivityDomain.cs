using Infrastructure.Model;

namespace Domain;

public interface IActivityDomain
{
    List<Activity> GetAll();
    bool Create(string Title, string Description, string Address, string Date); 
    bool Update(int id, string Title, string Description, string Address, string Date );
    bool Delete(int id);
}