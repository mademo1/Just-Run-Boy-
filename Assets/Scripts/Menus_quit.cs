using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus_quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void EscenaPrincipal()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("game_place");
    }

    public void EscenaManual()
    {
        SceneManager.LoadScene("game_manual");
    }
}
