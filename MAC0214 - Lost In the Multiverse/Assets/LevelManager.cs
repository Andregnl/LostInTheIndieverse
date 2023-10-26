using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    private void Awake(){
        int unlockLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i = 0; i < buttons.Length; i++){
            if(i < unlockLevel){
                buttons[i].interactable = true;
            }
            else{
                buttons[i].interactable = false;
            }
        }
    }
    public void LoadLevel(int level){
        string levelname = "Level " + level;
        SceneManager.LoadScene(levelname);
    }
}
