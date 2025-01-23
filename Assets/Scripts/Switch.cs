using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public Image On;
    public Image Off;
    public Image img;
    int index;

    void Start()
    {
    }

    void Update()
    {
        if (img != null)
        {
            img.gameObject.SetActive(index == 0);
        }
    }

    public void ON()
    {
        index = 1;

        if (Off != null)
            Off.gameObject.SetActive(true);
        else
            Debug.LogError("The Off reference is null!");

        if (On != null)
            On.gameObject.SetActive(false);
        else
            Debug.LogError("The On reference is null!");
    }

    public void OFF()
    {
        index = 0;

        if (On != null)
            On.gameObject.SetActive(true);
        else
            Debug.LogError("The On reference is null!");

        if (Off != null)
            Off.gameObject.SetActive(false);
        else
            Debug.LogError("The Off reference is null!");
    }
}
