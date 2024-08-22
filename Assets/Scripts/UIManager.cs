using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    [Header("Elements")]

    [SerializeField] private Button playButton;
    [SerializeField] private Button QuitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonCallback()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButtonCallback()
    {
        Application.Quit();
    }
}
