namespace WebApp.Models
{
	public static class Categoriesrepository
	{

		private static List<Category> _categories = new List<Category>()
		{
			new Category {CategoryId = 1 ,CategoryName="cola", CategoryDescription="Soft Drinks"},
			new Category {CategoryId = 2 ,CategoryName="Ice cream", CategoryDescription="Iced products"},
			new Category {CategoryId = 3 ,CategoryName="Milk", CategoryDescription="fridged products"},

		};
		
		public static void AddCategory( Category category)
		{
			var maxID = _categories.Max( x => x.CategoryId );
			category.CategoryId = ++maxID;
			_categories.Add(category);
		}

		public static List<Category> GetCategories() => _categories;

		public static Category? GetCategoryByID(int categoryID)
		{
			var category = _categories.FirstOrDefault( x => x.CategoryId == categoryID );
			if(category != null)
			{
				return new Category
				{
					CategoryId = category.CategoryId,
					CategoryName = category.CategoryName,
					CategoryDescription = category.CategoryDescription,
				};
			}
			return null;

		}

		//it wont update the real data but i want to check it 
		public static void UpdateCategory(int categoryID, Category category)
		{
			if (categoryID != category.CategoryId) return;

			var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryID);
			if (categoryToUpdate != null)
			{
				categoryToUpdate.CategoryName=category.CategoryName;
				categoryToUpdate.CategoryDescription=category.CategoryDescription;
			}

		}


		public static void DelelteCategory(int categoryID)
		{
			var category = _categories.FirstOrDefault(x => x.CategoryId == categoryID);
			if(category != null)
			{
				_categories.Remove(category);
			}
		}







	}
}
