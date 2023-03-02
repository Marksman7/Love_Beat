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

    private int next_scren_num = -1;

    public GameObject next_node_set_active;

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
        if (scene_num == next_scren_num)
        {
            player_choices.SetActive(false);
            next_node_set_active.SetActive(true);
            this.gameObject.SetActive(false);

        }
        else
        {
            SceneManager.LoadScene(scene_num);
        }
    }
    
}
