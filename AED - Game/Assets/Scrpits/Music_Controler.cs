using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Classe que controla o tocador de m�sica

public class Music_Controler : MonoBehaviour
{
    // Inicializa��o das variaveis

    private static Music_Controler instance;
    public AudioSource BGM;
    public AudioClip track0;

    // Declara��o de vari�vel

    int Telas = 13;

    // Quando executar

    void Awake()
    {

        if( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }
        else
        {

            Destroy(gameObject);
        }


    }

    // Caso queira adicionar mais m�sica � s� aumentar o n�mero de track

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 0 && SceneManager.GetActiveScene().buildIndex < Telas) // N�mero de telas que tem no game
        {
            if ( BGM.clip != track0)
            {
                changeBGM(track0);
            }
        }


    }

    // Verifica se a m�sica estiver sendo tocada, se n�o come�a a tocar

    public void changeBGM(AudioClip music)
    {
            BGM.Stop();
            BGM.clip = music;
            BGM.Play();

    }
}
