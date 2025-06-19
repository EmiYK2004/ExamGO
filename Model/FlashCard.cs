using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGO.Model
{
    public class FlashCard
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; } = new();
        public int CorrectAnswerIndex { get; set; }

        public int TestSetId { get; set; }
        public TestSet TestSet { get; set; }
    }
}
