using Infrastructure.Model;

namespace Infraestructure;

public interface IActivityInfraestructure
{
    List<Activity> GetAll();
    bool Create(string Title, string Description, string Address, string Date); 
    bool Update(int id, string Title, string Description, string Address, string Date );
    bool Delete(int id);
    
}