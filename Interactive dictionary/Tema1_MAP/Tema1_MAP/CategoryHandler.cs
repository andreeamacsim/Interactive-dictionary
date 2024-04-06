using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1_MAP
{
    public class CategoryHandler
    {
        private List<string> existingCategories;

        public CategoryHandler(List<Word> words)
        {
            existingCategories = words.Select(w => w.Category).Distinct().ToList();
        }

        public List<string> GetExistingCategories()
        {
            return existingCategories;
        }

        public void AddCategory(string newCategory)
        {
            existingCategories.Add(newCategory);
        }
    }

}
