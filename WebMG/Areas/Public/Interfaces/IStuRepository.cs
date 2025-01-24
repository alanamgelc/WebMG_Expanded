using MG.Models;

namespace MGWeb.Areas.Public.Interfaces
{
    public interface IStuRepository
    {
        bool Add(Stu stu);

        bool Update(Stu stu);

        bool Delete(Stu stu);

        bool Save();
        Task AddAsync(Stu stu);


    }
}
