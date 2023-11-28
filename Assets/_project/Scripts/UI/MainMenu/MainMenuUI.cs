using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public Interactable startButton, exitButton;
    public GameObject listRoom;
    
    private void Start()
    {
        startButton.OnClick.AddListener(StartGame);
        exitButton.OnClick.AddListener(ExitGame);
        
        gameObject.SetActive(true);
    }
    
    private void StartGame()
    {
        listRoom.SetActive(true);
        gameObject.SetActive(false);
    }
    
    private void ExitGame()
    {
        Application.Quit();
    }
}
