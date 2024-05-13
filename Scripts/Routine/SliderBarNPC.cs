using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBarNPC : MonoBehaviour
{
    [SerializeField] private Image _hungerBar;
    [SerializeField] private Image _hygieneBar;
    [SerializeField] private Image _tiredBar;
    [SerializeField] private Image _entertainmentBar;

    public void SliderBarMaxValue(int p_maxValue)
    {
        float fillAmount = 1f * p_maxValue / p_maxValue;

        SetFillAmount(_hungerBar, fillAmount);
        SetFillAmount(_hygieneBar, fillAmount);
        SetFillAmount(_tiredBar, fillAmount);
        SetFillAmount(_entertainmentBar, fillAmount);
    }

    public void SliderBarValue(string p_needsName, int p_maxValue, int p_currentValue)
    {
        float fillAmount = 1f * p_currentValue / p_maxValue;

        switch (p_needsName)
        {
            case "Hunger":
                SmoothFill(_hungerBar, fillAmount);
                break;
            case "Hygiene":
                SmoothFill(_hygieneBar, fillAmount);
                break;
            case "Tired":
                SmoothFill(_tiredBar, fillAmount);
                break;
            case "Entertainment":
                SmoothFill(_entertainmentBar, fillAmount);
                break;
        }
    }

    private void SetFillAmount(Image p_image, float p_fillAmount)
    {
        p_image.fillAmount = p_fillAmount;
    }

    private void SmoothFill(Image p_image, float p_targetFillAmount)
    {
        float currentFillAmount = p_image.fillAmount;
        float smoothTime = 1f;

        p_image.fillAmount = Mathf.Lerp(currentFillAmount, p_targetFillAmount, smoothTime * Time.deltaTime);
    }
}