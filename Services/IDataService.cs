using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamGO.Model;

namespace ExamGO.Services
{
    public interface IDataService
    {
        Task<List<Theme>> GetThemesAsync();
        Task AddThemeAsync(Theme theme);
        Task DeleteThemeAsync(int themeId);

        Task<List<TestSet>> GetTestSetsAsync(int themeId);
        Task AddTestSetAsync(TestSet testSet);
        Task DeleteTestSetAsync(int setId);

        Task<List<FlashCard>> GetFlashCardsAsync(int testSetId);
        Task AddFlashCardAsync(FlashCard card);
        Task DeleteFlashCardAsync(int cardId);
    }
}
