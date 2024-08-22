using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonManager : MonoBehaviour
{


    [Header("Elements")]
    [SerializeField] private Button playButton;
    [SerializeField] private TMP_InputField nameInputField;
        

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(onStartButtonClicked);
    }

    private void onStartButtonClicked()
    {
        //Playername to be saved 
        PlayerPrefs.SetString("PlayerName", nameInputField.text);
        PlayerPrefs.Save();

        // Load game scene
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
