using UnityEngine;
using System.Collections.Generic; // Required for using Lists

// This line allows you to right-click in your Project folder to create new recipes!
[CreateAssetMenu(fileName = "New Recipe", menuName = "Cooking/Recipe")]
public class Recipe : ScriptableObject
{
    [Header("Recipe Info")]
    public string dishName;

    [Header("Ingredients Needed")]
    // This is the list of ingredient names (e.g., "Tomato", "Water")
    public List<string> requiredIngredients;

    [Header("Optional Settings")]
    public Sprite completedDishSprite; // If you want to show a picture of the food
    public float cookingTime = 5.0f;   // How long it takes to cook

    
}
