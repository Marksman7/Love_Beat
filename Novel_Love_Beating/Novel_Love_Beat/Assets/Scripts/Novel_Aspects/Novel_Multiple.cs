using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum Character_Speak
{
    Left_side, Right_side
}


public class Novel_Multiple : MonoBehaviour
{
    public Character_Speak[] Chacter_Speaking;

    public string[] characters;
    public string[] dialogue_character;

    


    private GameObject get_background;
    private Image Background;
    private Image[] character_art = { null, null, null, null, null};
    public Sprite[] insert_art_character;
    public Sprite insert_art_background;
    private TextMeshProUGUI dialogue_box;
    private TextMeshProUGUI character_name_box;

    private GameObject get_dialogue_box;
    private GameObject get_character_name_box;

    private GameObject[] character_art_reteve = { null, null};

    private int character_number = 0;
    private int dialogue_counter = 0;

    int get_character_num = 0;

    string temp_string = "";

    void Start()
    {
        Start_up();
    }

    public void Start_up()
    {
        

        get_background = GameObject.FindGameObjectWithTag("background");
        character_art_reteve[0] = GameObject.FindGameObjectWithTag("left_char_image");
        character_art_reteve[1] = GameObject.FindGameObjectWithTag("Right_char_image");

        get_dialogue_box = GameObject.FindGameObjectWithTag("dialogue_box");

        get_character_name_box = GameObject.FindGameObjectWithTag("character_name_box");

        Background = get_background.GetComponent<Image>();

        character_art[0] = character_art_reteve[0].GetComponent<Image>();
        character_art[1] = character_art_reteve[1].GetComponent<Image>();

        dialogue_box = get_dialogue_box.GetComponent<TextMeshProUGUI>();

        character_name_box = get_character_name_box.GetComponent<TextMeshProUGUI>();

        /*int im_char = 0;
        foreach(Image im in character_art)
        {

            if(im_char >= insert_art_character.Length)
            {
                im_char = 0;
            }

            im.sprite = insert_art_character[im_char];
            im_char = im_char + 1;
            
        }*/
        character_art[0].sprite = insert_art_character[0];
        character_art[1].sprite = insert_art_character[1];



        Background.sprite = insert_art_background;

        if (dialogue_box == null)
        {
            Debug.Log("There is no dialogue_box connected");
        }

        Start_dialogue_line();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Next_dialogue_line();
        }
    }

    void Start_dialogue_line()
    {
        /*if(characters[0] != null)
        {
            //Debug.Log("notpe");
        }*/

        //dialogue_box.text = dialogue_character[0].Remove(0, 1); ;//dialogue_counter
        dialogue_box.text = "";

        //character_name_box.text = characters[get_character_num];//character_number
        character_name_box.text = "";

        Next_character_art_image();
    }

    void Next_dialogue_line()
    {
        

        if (dialogue_counter >= dialogue_character.Length)
        {
            ActivateChoices();
        }
        else
        {
            //dialogue_box.text = dialogue_character[dialogue_counter];
            /*int*/
            

            get_character_num = Int32.Parse(dialogue_character[dialogue_counter][0].ToString());

            /*string*/
            Debug.Log(character_name_box);
            Debug.Log(get_character_num);
            character_name_box.text = characters[get_character_num];
            temp_string = characters[get_character_num];
            //temp_string = temp_string.Remove(0, 1);
            dialogue_box.text = dialogue_character[dialogue_counter].Remove(0, 1);

            Next_character_line();

            dialogue_counter = dialogue_counter + 1;
        }

    }

    void Next_character_line()
    {

        character_number = character_number + 1;
        if (character_number >= characters.Length)
        {
            character_number = 0;
            
            Next_character_art_image();
        }
        else
        {
            Next_character_art_image();
        }
    }

    void Next_character_art_image()
    {
        
        if(character_number == 0)
        {
            character_art[1].sprite = insert_art_character[get_character_num];
            if (get_character_num == 0)
            {
                character_art[0].sprite = insert_art_character[get_character_num + 1];
            }
            else
            {
                character_art[0].sprite = insert_art_character[get_character_num - 1];
            }
            //character_art[1].sprite = insert_art_character[0];
            character_art[0].GetComponent<Image>().color = new Color32(255, 255, 225, 75);
            character_art[1].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
        else
        {
            character_art[0].sprite = insert_art_character[get_character_num];
            if(get_character_num == 0)
            {
                character_art[1].sprite = insert_art_character[get_character_num + 1];
            }
            else
            {
                character_art[1].sprite = insert_art_character[get_character_num - 1];
            }
            character_art[1].GetComponent<Image>().color = new Color32(255, 255, 225, 75);
            character_art[0].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }


        character_speaking();
    }

    void character_speaking()
    {
        if(Chacter_Speaking.Length > dialogue_counter)
        {
            if (Chacter_Speaking[dialogue_counter] == Character_Speak.Left_side)
            {
                character_art[0].GetComponent<Image>().color = new Color32(255, 255, 225, 75);
                character_art[1].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            }
            else (Chacter_Speaking[dialogue_counter] == Character_Speak.Right_side)
            {
                character_art[1].GetComponent<Image>().color = new Color32(255, 255, 225, 75);
                character_art[0].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            }
        }

        
    }


    void ActivateChoices()
    {
        //dialogue_counter = 0;
        this.transform.GetComponent<Choice>().activated();
    }


    public void Reset_dialouge_counter()
    {
        dialogue_counter = 0;
    }
}
