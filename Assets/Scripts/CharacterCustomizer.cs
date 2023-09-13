using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCustomizer : MonoBehaviour
{
    [SerializeField] Color[] allColors;
    [SerializeField] Sprite[] allAccs;
    [SerializeField] GameObject colorPanel;
    [SerializeField] GameObject accsPanel;
    [SerializeField] Button accsBtn;
    [SerializeField] Button colorBtn;
    // Start is called before the first frame update
    public void SetColor(int colorIndex)
    {
        PlayerMovement.localPlayer.SetColor(allColors[colorIndex]);
    }

    public void setAccs(int  accsIndex)
    {
        PlayerMovement.localPlayer.SetAccs(allAccs[accsIndex]);
    }

    public void NextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void EnableColors()
    {
        colorPanel.SetActive(true);
        accsPanel.SetActive(false);
        colorBtn.interactable = false;
        accsBtn.interactable = true;
    }
    public void EnableAccs()
    {
        colorPanel.SetActive(false);
        accsPanel.SetActive(true);
        colorBtn.interactable = true;
        accsBtn.interactable = false;
    }
}
