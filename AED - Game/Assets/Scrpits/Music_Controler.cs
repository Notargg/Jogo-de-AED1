using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Classe que controla o tocador de música

public class Music_Controler : MonoBehaviour
{
    // Inicialização das variaveis

    private static Music_Controler instance;
    public AudioSource BGM;
    public AudioClip track0;

    // Declaração de variável

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

    // Caso queira adicionar mais música é só aumentar o número de track

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 0 && SceneManager.GetActiveScene().buildIndex < Telas) // Número de telas que tem no game
        {
            if ( BGM.clip != track0)
            {
                changeBGM(track0);
            }
        }


    }

    // Verifica se a música estiver sendo tocada, se não começa a tocar

    public void changeBGM(AudioClip music)
    {
            BGM.Stop();
            BGM.clip = music;
            BGM.Play();

    }
}
