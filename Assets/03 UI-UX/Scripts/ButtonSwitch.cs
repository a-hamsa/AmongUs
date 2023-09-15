using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitch : MonoBehaviour
{
    public Image buttonImage; // Reference to the Image component of the switch button.
    public Sprite onSprite;   // Image for the "on" state.
    public Sprite offSprite;  // Image for the "off" state.

    private bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the switch button state.
        SetButtonState(isOn);
    }

    public void ToggleSwitch()
    {
        isOn = !isOn;
        SetButtonState(isOn);
    }

    private void SetButtonState(bool state)
    {
        buttonImage.sprite = state ? onSprite : offSprite;
        // You can also perform any other actions you want when the state changes here.
    }
}
