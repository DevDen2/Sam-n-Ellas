using System.Collections.Generic; 
using System.Linq;                
using UnityEngine;      
public class PotCook : MonoBehaviour
{
    public List<Ingredient> ingredientsInPot = new List<Ingredient>();
    public RecipeManager recipeManager; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Cook();
        }
    }
    // Triggered when an ingredient is dropped in
    public void OnIngredientDropped(Ingredient newIngredient) {
        ingredientsInPot.Add(newIngredient); 
        Debug.Log($"Added {newIngredient.ingredientName} to the pot!");
    }

    // Triggered when the player clicks "Cook"
    public void Cook() {
        string result = recipeManager.CheckRecipes(ingredientsInPot);
        Debug.Log("You made: " + result);
        ingredientsInPot.Clear(); // Empty the list for the next dish!
    }
}
