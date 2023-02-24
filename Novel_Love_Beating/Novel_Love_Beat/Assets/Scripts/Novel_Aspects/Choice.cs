using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Choice : MonoBehaviour
{
    public GameObject player_choices;


    public Button[] choices;

    public int[] choices_scene;

    

    public void activated()
    {
        player_choices.SetActive(true);
        Create_scenes();
    }

    private void Create_scenes()
    {
        int a = 0;
        foreach (Button i in choices)
        {

            if(choices_scene[a] == null)
            {
                a = 0;
            }
            a = a + 1;
        }
        
    }

    

    public void Button00_click()
    {
        Nextscene(choices_scene[0]);
    }

    public void Button01_click()
    {
        Nextscene(choices_scene[1]);
    }

    public void Button02_click()
    {
        Nextscene(choices_scene[2]);
    }

    public void Button03_click()
    {
        Nextscene(choices_scene[3]);
    }

    public void Button04_click()
    {
        Nextscene(choices_scene[4]);
    }

    void Nextscene(int scene_num)
    {
        SceneManager.LoadScene(scene_num);
    }
    
}
