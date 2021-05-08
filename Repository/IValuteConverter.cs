using System;
using System.Threading.Tasks;
using Converter.Model;

namespace Converter.Repository
{
    public interface IValuteConverter
    {
        Task<ValCurs> GetCurse();
        Task<ValCurs> GetCurse(DateTime? selectedDate);
    }
}