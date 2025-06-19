using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGO.Model
{
    public class Theme
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<TestSet> TestSets { get; set; } = new();
    }
}
