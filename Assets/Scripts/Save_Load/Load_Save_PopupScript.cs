using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_Save_PopupScript : MonoBehaviour
{
    //public button settingsButton;
    public bool isOpen;
    public GameObject popUpWindow;
    public GameObject popUpInstance;
    public GameObject backToGameButton;
    public GameObject settingsButton;

    void Start()
    {
        isOpen = false;
    }

    public void LaunchPopUp()
    {
        if (isOpen == false)
        {
            isOpen = true;
            popUpInstance = Instantiate(popUpWindow, settingsButton.transform, false);
            backToGameButton = GameObject.Find("BackButton");
            Button btn = backToGameButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }
    }

    public void TaskOnClick()
    {
        ClosePopUp();
    }

    public void ClosePopUp()
    {
        if (isOpen == true)
        {
            isOpen = false;
            Destroy(popUpInstance);
        }
    }

}