using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_Choice : MonoBehaviour
{
    private GameObject get_moduel;

    // Start is called before the first frame update
    void Start()
    {
        get_moduel = GameObject.FindGameObjectWithTag("active_moduel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void get_new_moduel(float wait)
    {
        Invoke("wait_here", wait);
    }
    //this is a small wait for everything to get the coorect componets on time
    private void wait_here()
    {
        get_moduel = GameObject.FindGameObjectWithTag("active_moduel");
        if(get_moduel.GetComponent<Novel_Dio>() != null)
        {
            get_moduel.GetComponent<Novel_Dio>().Start_up();
        }
        else
        {
            get_moduel.GetComponent<Novel_Multiple>().Start_up();
        }

        //get_moduel.GetComponent<Choice>().Start_up();
        get_moduel.GetComponent<Choice>().Next_start_up();
    }

    public void Button00_click()
    {
        get_moduel.GetComponent<Choice>().Button00_click();
    }

    public void Button01_click()
    {
        get_moduel.GetComponent<Choice>().Button01_click();
    }

    public void Button02_click()
    {
        get_moduel.GetComponent<Choice>().Button02_click();
    }

    public void Button03_click()
    {
        get_moduel.GetComponent<Choice>().Button03_click();

    }

    public void Button04_click()
    {
        get_moduel.GetComponent<Choice>().Button04_click();
    }
}
