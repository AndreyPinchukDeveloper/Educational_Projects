using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVMExcusesApp.Models
{
    public class ExcuseModel
    {
        public string ExcuseName { get; }
        public string ExcuseResult { get; }
        public DateTime LastUsed { get; }
        public DateTime SaveToDbDate { get; }
        public ExcuseModel(string excuseName, string excuseResult, DateTime lastUsed, DateTime saveToDbDate)
        {
            ExcuseName = excuseName;
            ExcuseResult = excuseResult;
            LastUsed = lastUsed;
            SaveToDbDate = saveToDbDate;
        }
    }
}
