using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Main menu - Controlador de Botoes

public class MainMenu : MonoBehaviour
{

    // Funções dos botoes

    public void TelaJogo() // Ir para tela de jogo
    {
        SceneManager.LoadScene("TelaGame2");

    }

    public void TelaAlfabeto() // Ir para a tela onde contem o alfabeto
    {
        SceneManager.LoadScene("TelaAlfabeto");

    }

    public void QuitdoJogo() // Ir pro menu
    {
        SceneManager.LoadScene("TelaInicio");
    }

    public void ProsseguirJogo() // Prosseguir o Jogo - após a tela de Ganho / Perda
    {
        SceneManager.LoadScene("TelaAviso");
    }

    public void ComoJogar() // Tela de como Jogar
    {
        SceneManager.LoadScene("TelaComoJogar");
    }

    public void TelaSinais() // Introdução aos Sinais - Todos que serão usados
    {
        SceneManager.LoadScene("Sinais"); // Ir pro Segundo Estágio
    }

    public void TelaTerceiraParte() // Tela da Terceira Parte
    {
        SceneManager.LoadScene("TerceiraParte"); // Ir para o Terceiro Estágio
    }

    public void SairDoGame() // Sair do jogo
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    
    public void TelaColaboradores() // Queremos  colocar uma tela com links / Nossos nomes / Nome de colaboradores
    {
        SceneManager.LoadScene("TelaColaboradores");
    }


    


}
