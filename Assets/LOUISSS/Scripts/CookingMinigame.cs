using UnityEngine;
using UnityEngine.UI;

public class CookingMiniGame : MonoBehaviour
{
    public Slider cookingSlider;
    public float speed = 2.0f;
    private bool isPlaying = true;

    public float[] slidervalues = {0f,0.155f,0.366f,0.46f,0.541f,0.634f,0.846f,1f};

    void Update()
    {
        if (isPlaying)
        {
            // Oscillates the slider value between 0 and 1 over time
            cookingSlider.value = Mathf.PingPong(Time.time * speed, 1);

            // Detect player "click" (Space bar or Mouse click)
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                CheckResult();
            }
        }
    }

    void CheckResult()
    {
        isPlaying = false;
        float finalValue = cookingSlider.value;

        // Define your "Perfect" range (e.g., 0.45 to 0.55 is the center)
        if (finalValue > slidervalues[3] && finalValue < slidervalues[4])
        {
            Debug.Log("Perfectly Cooked!");
        }
        else if (finalValue > slidervalues[2] && finalValue < slidervalues[3]||finalValue > slidervalues[4] && finalValue < slidervalues[5])
        {
            Debug.Log("Good");
        }
        else if (finalValue > slidervalues[1] && finalValue < slidervalues[2]||finalValue > slidervalues[5] && finalValue < slidervalues[6])
        {
            Debug.Log("ok");
        }
        else if (finalValue > slidervalues[0] && finalValue < slidervalues[1]||finalValue > slidervalues[6] && finalValue < slidervalues[7])
        {
            Debug.Log("HORRID");
        }
    }
}
