using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject IntroMenu; // Reference to the menu panel

    // This method gets called when the button is clicked
    public void HideMenu()
    {
        IntroMenu.SetActive(false);
    }
}