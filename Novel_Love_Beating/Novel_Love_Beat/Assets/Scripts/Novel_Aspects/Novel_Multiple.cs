using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


//enum that keeps track of which side for the speaking character to be on while talking
public enum Character_Speak
{
    No_Change, Left_side, Right_side
}

//
public class Novel_Multiple : MonoBehaviour
{
    
    public Character_Speak[] Chacter_Speaking;
    //Character names
    public string[] characters;
    //dialouge
    public string[] dialogue_character;

    


    private GameObject get_background;
    private Image Background;
    private Image[] character_art = { null, null, null, null, null};
    //Character art
    public Sprite[] insert_art_character;
    public Sprite insert_art_background;
    private TextMeshProUGUI dialogue_box;
    private TextMeshProUGUI character_name_box;

    private Sprite[] recod_character_show = { null, null};

    private GameObject get_dialogue_box;
    private GameObject get_character_name_box;

    private GameObject[] character_art_reteve = { null, null};

    private int character_number = 0;

    //line of dislouge it on
    private int dialogue_counter = 0;

    int get_character_num = 0;

    string temp_string = "";

    void Start()
    {
        Start_up();
    }
    //On start event's
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

    //Part of the start up when setting up the first dialouge (This was set up for switch when the team wanted a pause and did not want a pause betwean strands of dialouge)
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

        Next_dialogue_line();
        Next_character_art_image();
    }


    //does the next line of dialouge
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

    //Makesure the next character number is 0
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

    //switches character art, and makes on image a bit tranluite because they are not talking
    void Next_character_art_image()
    {
        
        if(character_number == 0)
        {
            character_art[1].sprite = insert_art_character[get_character_num];
            if (get_character_num == 0)
            {
                character_art[0].sprite = insert_art_character[get_character_num + 1];
                recod_character_show[0] = insert_art_character[get_character_num + 1];
            }
            else
            {
                character_art[0].sprite = insert_art_character[get_character_num - 1];
                recod_character_show[0] = insert_art_character[get_character_num - 1];
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
                if (insert_art_character.Length <= get_character_num + 1)
                {
                    recod_character_show[0] = insert_art_character[get_character_num];
                }
                else
                {

                    recod_character_show[0] = insert_art_character[get_character_num + 1];
                }
            }
            else
            {
                character_art[1].sprite = insert_art_character[get_character_num - 1];
                if(insert_art_character.Length <= get_character_num + 1)
                {
                    recod_character_show[0] = insert_art_character[get_character_num];
                }
                else
                {

                    recod_character_show[0] = insert_art_character[get_character_num + 1];
                }
            }
            character_art[1].GetComponent<Image>().color = new Color32(255, 255, 225, 75);
            character_art[0].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }

        character_speaking();


    }

    //Switches the side so the character is speaking on the correct side
    void character_speaking()
    {
        if(Chacter_Speaking.Length > dialogue_counter)
        {
            if (Chacter_Speaking[dialogue_counter] != Character_Speak.No_Change && Chacter_Speaking[dialogue_counter] != null)
            {

            
                if (Chacter_Speaking[dialogue_counter] == Character_Speak.Left_side)
                {
                    character_art[0].sprite = recod_character_show[0];
                    character_art[1].sprite = recod_character_show[1];
                    character_art[0].GetComponent<Image>().color = new Color32(255, 255, 225, 75);
                    character_art[1].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
                }
                else if (Chacter_Speaking[dialogue_counter] == Character_Speak.Right_side)
                {
                    character_art[0].sprite = recod_character_show[1];
                    character_art[1].sprite = recod_character_show[0];
                    character_art[1].GetComponent<Image>().color = new Color32(255, 255, 225, 75);
                    character_art[0].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
                }
            }
        }

        
    }

    //activates the class activate choices
    void ActivateChoices()
    {
        //dialogue_counter = 0;
        this.transform.GetComponent<Choice>().activated();
    }

    //restes the dialouge
    public void Reset_dialouge_counter()
    {
        dialogue_counter = 0;
    }
}
