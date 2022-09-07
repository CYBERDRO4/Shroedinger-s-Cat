using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuActivateButton : MonoBehaviour
{
    [SerializeField] private Sprite in_off_menu;
    [SerializeField] private Sprite in_on_menu;

    [SerializeField] GameEvent ActiveInactiveMenu;

    private bool menuactive;

    public void ShowHidePanel()
    {
        menuactive = !menuactive;
        ActiveInactiveMenu.Raise();
    }
    public void ChangeImage()
    {
        if (!menuactive)
            GetComponent<Image>().sprite = in_on_menu;
        else if (menuactive)
            GetComponent<Image>().sprite = in_off_menu;
    }
}
