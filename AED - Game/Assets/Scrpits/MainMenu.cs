using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Main menu - Controlador de Botoes

public class MainMenu : MonoBehaviour
{

    // Fun��es dos botoes

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

    public void ProsseguirJogo() // Prosseguir o Jogo - ap�s a tela de Ganho / Perda
    {
        SceneManager.LoadScene("TelaAviso");
    }

    public void ComoJogar() // Tela de como Jogar
    {
        SceneManager.LoadScene("TelaComoJogar");
    }

    public void TelaSinais() // Introdu��o aos Sinais - Todos que ser�o usados
    {
        SceneManager.LoadScene("Sinais"); // Ir pro Segundo Est�gio
    }

    public void TelaTerceiraParte() // Tela da Terceira Parte
    {
        SceneManager.LoadScene("TerceiraParte"); // Ir para o Terceiro Est�gio
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
