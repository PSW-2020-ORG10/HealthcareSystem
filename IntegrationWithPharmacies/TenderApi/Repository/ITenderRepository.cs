using System.Collections.Generic;
using TenderApi.Model;

namespace TenderApi.Repository
{
    public interface ITenderRepository
    {
        Tender Create(Tender tender);
        List<Tender> GetAll();
    }
}
