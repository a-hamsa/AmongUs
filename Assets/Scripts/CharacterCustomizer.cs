using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCustomizer : MonoBehaviour
{
    [SerializeField] Color[] allColors;
    // Start is called before the first frame update
    public void SetColor(int colorIndex)
    {
        PlayerMovement.localPlayer.SetColor(allColors[colorIndex]);
        
    }

    public void NextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
