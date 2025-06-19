using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamGO.Model;

namespace ExamGO.Services
{
     public class InMemoryDataService : IDataService
    {
        private readonly List<Theme> _themes = new();
        private int _testSetIdCounter = 1;
        private int _cardIdCounter = 1;

        // === Темы ===
        public Task<List<Theme>> GetThemesAsync() => Task.FromResult(_themes);

        public Task AddThemeAsync(Theme theme)
        {
            theme.Id = _themes.Count + 1;
            _themes.Add(theme);
            return Task.CompletedTask;
        }

        public Task DeleteThemeAsync(int themeId)
        {
            var theme = _themes.FirstOrDefault(t => t.Id == themeId);
            if (theme != null) _themes.Remove(theme);
            return Task.CompletedTask;
        }

        // === Наборы тестов ===
        public Task<List<TestSet>> GetTestSetsAsync(int themeId)
        {
            var theme = _themes.FirstOrDefault(t => t.Id == themeId);
            var sets = theme?.TestSets ?? new List<TestSet>();
            return Task.FromResult(sets);
        }

        public Task AddTestSetAsync(TestSet testSet)
        {
            testSet.Id = _testSetIdCounter++;
            var theme = _themes.FirstOrDefault(t => t.Id == testSet.ThemeId);
            if (theme != null)
            {
                testSet.Theme = theme;
                theme.TestSets.Add(testSet);
            }
            return Task.CompletedTask;
        }

        public Task DeleteTestSetAsync(int setId)
        {
            foreach (var theme in _themes)
            {
                var set = theme.TestSets.FirstOrDefault(s => s.Id == setId);
                if (set != null)
                {
                    theme.TestSets.Remove(set);
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask;
        }

        // === Карточки ===
        public Task<List<FlashCard>> GetFlashCardsAsync(int testSetId)
        {
            var testSet = _themes
                .SelectMany(t => t.TestSets)
                .FirstOrDefault(s => s.Id == testSetId);

            return Task.FromResult(testSet?.Cards ?? new List<FlashCard>());
        }

        public Task AddFlashCardAsync(FlashCard card)
        {
            card.Id = _cardIdCounter++;

            var testSet = _themes
                .SelectMany(t => t.TestSets)
                .FirstOrDefault(s => s.Id == card.TestSetId);

            if (testSet != null)
            {
                card.TestSet = testSet;
                testSet.Cards.Add(card);
            }

            return Task.CompletedTask;
        }

        public Task DeleteFlashCardAsync(int cardId)
        {
            foreach (var set in _themes.SelectMany(t => t.TestSets))
            {
                var card = set.Cards.FirstOrDefault(c => c.Id == cardId);
                if (card != null)
                {
                    set.Cards.Remove(card);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
