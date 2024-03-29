using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Choice : MonoBehaviour
{
    private GameObject player_choices;

    public string[] button_choice_title;

    private GameObject[] get_choices_button = { null, null, null, null, null };

    private TextMeshProUGUI[] button_text = { null, null, null, null, null };

    private Button[] choices = { null, null, null, null, null };

    private GameObject[] get_choices = { null, null, null, null, null };


    public int[] character_points;
    public int[] character_number;

    public int[] choices_scene;

    private int next_scren_num = -1;

    public GameObject[] next_node_set_active;

    private float wait = .05f;

    private GameObject hold_points;

    //back grounds for UI
    private GameObject[] UI_stuff = { null, null, null, null, null };
    

    private void Start()
    {
        Start_up();
    }



    public void Start_up()
    {

        UI_stuff[0] = GameObject.FindGameObjectWithTag("Go_away");
        UI_stuff[1] = GameObject.FindGameObjectWithTag("Go_away_02");
        UI_stuff[2] = GameObject.FindGameObjectWithTag("Go_away_03");
        UI_stuff[3] = GameObject.FindGameObjectWithTag("Go_away_04");
        UI_stuff[4] = GameObject.FindGameObjectWithTag("Go_away_05");

        hold_points = GameObject.FindGameObjectWithTag("hold_ponts");

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
            if (button_text[count] != null)
            {
                button_text[count].text = button_choice_title[count];
            }
        }

        for(int next_obj = 0; next_obj < next_node_set_active.Length; next_obj++)
        {
            if (next_node_set_active[next_obj] == null)
            {
                if(next_node_set_active[0] != null)
                {
                    next_node_set_active[next_obj] = next_node_set_active[0];
                }
            }
        }

        inactive_choices();
        player_choices.SetActive(false);
    }

    public void Next_start_up()
    {
        for (int count = 0; count < choices.Length; count++)
        {

            choices[count] = get_choices[count].GetComponent<Button>();
            button_text[count] = get_choices_button[count].GetComponent<TextMeshProUGUI>();
            if (button_text[count] != null)
            {
                button_text[count].text = button_choice_title[count];
            }
        }

        inactive_choices();
        player_choices.SetActive(false);
    }

    public void activat_choice_oustside()
    {
        active_choices();
    }

    private void active_choices()
    {
        foreach(GameObject cho in get_choices)
        {
            cho.SetActive(true);
        }

        foreach (GameObject ui_background in UI_stuff)
        {
            ui_background.SetActive(true);
        }

    }
    


    private void inactive_choices()
    {
        for (int q = 0; q < choices.Length; q++)
        {
            if(choices_scene[q] < -1 || button_choice_title[q] == "")
            {
                get_choices[q].SetActive(false);
                if(q < UI_stuff.Length)
                {
                    if (UI_stuff[q] != null)
                    {
                        UI_stuff[q].SetActive(false);
                    }
                }
            }
        }
    }

    void next()
    {
        //Debug.Log(this.gameObject);
        this.gameObject.SetActive(false);
    }

    public void activated()
    {


        player_choices.SetActive(true);

        int i = 0;

        foreach(GameObject gt in get_choices)
        {
            if(gt.activeSelf== true)
            {
                i = i + 1;
            }
        }


        if(i <= 0)
        {
            nono();

        }
        else
        {
        Create_scenes();
        }
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
        Nextscene(choices_scene[0], character_number[0], character_points[0], 0);
    }

    public void Button01_click()
    {
        Nextscene(choices_scene[1], character_number[1], character_points[1], 1);
    }

    public void Button02_click()
    {
        Nextscene(choices_scene[2], character_number[2], character_points[2], 2);
    }

    public void Button03_click()
    {
        
        Nextscene(choices_scene[3], character_number[3], character_points[3], 3);
    }

    public void Button04_click()
    {
        Nextscene(choices_scene[4], character_number[4], character_points[4], 4);
    }


    private void nono()
    {
        active_choices();
        this.next_node_set_active[0].SetActive(true);
        player_choices.GetComponent<button_Choice>().get_new_moduel(wait);
        this.gameObject.SetActive(false);
        
    }

    //send to the next scene
    private void Nextscene(int scene_num, int char_num, int char_point, int next_modual_num)
    {
        if (scene_num == next_scren_num)
        {

            //Debug.Log(next_node_set_active);
            //Debug.Log(this.gameObject);
            active_choices();
            if (next_node_set_active[next_modual_num] != null)
            {
                this.next_node_set_active[next_modual_num].SetActive(true);
            }
            else
            {
                Debug.Log("forgot to add a modual in the next_node_set_active array, (located in the modual under choice");
            }
            player_choices.GetComponent<button_Choice>().get_new_moduel(wait);

            if(hold_points != null && hold_points.GetComponent<Point_Holder>().character_points.Length >  4)
            {
                hold_points.GetComponent<Point_Holder>().update_points(char_num, char_point);
            }
            else
            {
                Debug.Log("You forgot to add Point_holder prefab or set it up");
            }

            if(this.gameObject.GetComponent<Novel_Multiple>() != null)
            {
                this.gameObject.GetComponent<Novel_Multiple>().Reset_dialouge_counter();
            }
            else if(this.gameObject.GetComponent<Novel_Dio>() != null)
            {
                this.gameObject.GetComponent<Novel_Dio>().Reset_dialouge_counter();
            }
            this.gameObject.SetActive(false);
        }
        else if(scene_num > -1)
        {

            active_choices();
            //call point script
            //SceneManager.LoadScene(scene_num);

            hold_points.GetComponent<Point_Holder>().Next_scene(scene_num, char_num, char_point);
        }
    }
    
}
