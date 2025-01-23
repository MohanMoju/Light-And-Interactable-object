using UnityEngine;
using UnityEngine.UI;

public class ScaleWithSlider : MonoBehaviour
{
    public GameObject PlaceHolderObject; 
    public Slider scaleSlider;
    private Vector3 originalScale; 

    void Start()
    {
        originalScale = PlaceHolderObject != null ? PlaceHolderObject.transform.localScale : Vector3.one;

        if (scaleSlider != null)
        {
            scaleSlider.onValueChanged.AddListener(UpdateScale);
        }
    }

    public void UpdateScale(float value)
    {
        if (PlaceHolderObject != null)
        {
            PlaceHolderObject.transform.localScale = originalScale * value;
        }
    }
}
