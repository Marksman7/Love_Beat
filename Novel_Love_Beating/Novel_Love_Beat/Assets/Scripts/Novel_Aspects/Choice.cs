using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Choice : MonoBehaviour
{
    private GameObject player_choices;

    public string[] button_choice_title;

    private GameObject[] get_choices_button = { null, null, null, null, null };

    private TextMeshProUGUI[] button_text = { null, null, null, null, null };

    private Button[] choices = { null, null, null, null, null };

    private GameObject[] get_choices = { null, null, null, null, null};

    public int[] choices_scene;

    private int next_scren_num = -1;

    public GameObject next_node_set_active;

    private float wait = .01f;

    private void Start()
    {
        //Debug.Log(this.gameObject);
        next_scren_num = -1;

        player_choices = GameObject.FindGameObjectWithTag("player_choice_sheet");

        get_choices[0] = GameObject.FindGameObjectWithTag("get_choices_01");
        get_choices[1] = GameObject.FindGameObjectWithTag("get_choices_02");
        get_choices[2] = GameObject.FindGameObjectWithTag("get_choices_03");
        get_choices[3] = GameObject.FindGameObjectWithTag("get_choices_04");
        get_choices[4] = GameObject.FindGameObjectWithTag("get_choices_05");

        get_choices_button[0] = GameObject.FindGameObjectWithTag("get_choices_01_button");
        get_choices_button[1] = GameObject.FindGameObjectWithTag("get_choices_02_button");
        get_choices_button[2] = GameObject.FindGameObjectWithTag("get_choices_03_button");
        get_choices_button[3] = GameObject.FindGameObjectWithTag("get_choices_04_button");
        get_choices_button[4] = GameObject.FindGameObjectWithTag("get_choices_05_button");

        for (int count = 0; count < choices.Length; count++)
        {

            choices[count] = get_choices[count].GetComponent<Button>();
            button_text[count] = get_choices_button[count].GetComponent<TextMeshProUGUI>();
            if(button_text[count] != null)
            {
                button_text[count].text = button_choice_title[count];
            }
        }
        player_choices.SetActive(false);

    }

    void next()
    {
        //Debug.Log(this.gameObject);
        this.gameObject.SetActive(false);
    }

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

    private void nono()
    {
        this.next_node_set_active.SetActive(true);
        this.gameObject.SetActive(false);
        
    }

    private void Nextscene(int scene_num)
    {
        if (scene_num == next_scren_num)
        {

            //Debug.Log(next_node_set_active);
            //Debug.Log(this.gameObject);
            this.next_node_set_active.SetActive(true);
            player_choices.GetComponent<button_Choice>().get_new_moduel(wait);
            this.gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(scene_num);
        }
    }
    
}
