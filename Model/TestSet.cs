using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGO.Model
{
    public class TestSet
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int ThemeId { get; set; }
        public Theme Theme { get; set; }

        public List<FlashCard> Cards { get; set; } = new();
    }
}
