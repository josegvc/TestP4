using UnityEngine;
using System.Collections;





public class PauseGame : MonoBehaviour {

    public Transform PauseMenu;
    public Transform AudioPanel;
    public Transform ConfirmationPanel;
    public Transform Pausebackground;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();


        }
    }
    public void Pause()
    {
        if (PauseMenu.gameObject.activeInHierarchy == false)
        {
            PauseMenu.gameObject.SetActive(true);
            Pausebackground.gameObject.SetActive(true);
            AudioPanel.gameObject.SetActive(false);
            ConfirmationPanel.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            PauseMenu.gameObject.SetActive(false);
            Pausebackground.gameObject.SetActive(false);
            AudioPanel.gameObject.SetActive(false);
            ConfirmationPanel.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

    }







}
