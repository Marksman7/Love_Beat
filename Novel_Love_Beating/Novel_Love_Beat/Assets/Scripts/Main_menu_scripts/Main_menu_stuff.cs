using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu_stuff : MonoBehaviour
{
    public GameObject find_animation;

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    // need to be chagned to exit program
    public void GetMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Go_To_Scene(int num)
    {
        SceneManager.LoadScene(num);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("I am quiting now, but I'll be back later");
        Application.Quit();
    }

    public void find_activation_buttons()
    {
        GameObject activate = GameObject.FindGameObjectWithTag("active_moduel");

        if(activate != null)
        {
            activate.GetComponent<Choice>().activat_choice_oustside();
        }
    }

    public void extra_animation_on()
    {
        if (find_animation != null)
        {
            find_animation.SetActive(true);
        }
    }

    public void extra_animation_off()
    {
        if(find_animation != null)
        {
            find_animation.SetActive(false);
        }
    }

}
