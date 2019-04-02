using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    public float maxScale = 1f;
    public Slider slider;
    Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        UpdateScale(slider.value);
       
    }

    public void UpdateScale(float value)
    {
        //Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(originalScale.x+(maxScale * value),
            originalScale.y + (maxScale * value),
            originalScale.z + (maxScale * value));
    }
}
