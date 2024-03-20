using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTarget : MonoBehaviour
{
    //created a a list to hold the levels
    public List<String> myLevelList = new List<string>();

    public int currentLevel = 1;
    public string sceneToLoad = "Level2";
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerBall")
        {
            MyEventSystem.I.CompleteLevel(1);
            //SceneManager.LoadScene(sceneToLoad);
            LevelLoader();
        }        
    }

    //created a function to handle the logic for loading levels by incrementing on each completed level triger
    private void LevelLoader(){
        if(currentLevel < myLevelList.Count){
            string nextScene = myLevelList[currentLevel];
            SceneManager.LoadScene(nextScene);
            currentLevel++;
        }else{
            //Debug.Log("The level does not exist!");
            SceneManager.LoadScene("Main");
        }
    }
}
