using System.Collections.Generic; 
using System.Linq;                
using UnityEngine;      
public class RecipeManager : MonoBehaviour {
    public List<Recipe> allRecipes; // Drag your Recipe files here in the Inspector

    public string CheckRecipes(List<Ingredient> potIngredients) 
    {
        // 1. Convert the list of Ingredient OBJECTS into a list of NAME STRINGS
        List<string> potNames = potIngredients.Select(i => i.ingredientName).ToList();

        foreach (Recipe recipe in allRecipes) 
        {
            if (recipe.requiredIngredients.Count != potNames.Count) continue;

            // 2. Sort both string lists
            var potSorted = potNames.OrderBy(n => n);
            var recipeSorted = recipe.requiredIngredients.OrderBy(n => n);

            // 3. Compare them (Now both are List<string>!)
            if (potSorted.SequenceEqual(recipeSorted)) 
            {
                return recipe.dishName;
            }
        }
        return "Burnt Mess";
    }

}
