using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Script para mostrar o Alfabeto para auliar

public class Alfabeto : MonoBehaviour
{
    // Criação das listas

    public Image[] botoes;
    public Color[] cor;

    Alfabeto() // Construtor
    {
        botoes = new Image[3];
        cor = new Color[2];
        controlealf = false;
    }

    //Bool que controla o estato de estar ou não alfabeto e o botao que controla

    bool controlealf;

    // Int que vai ser preciso para trocar o botao "Abrir e fechar Alfabeto"

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        controlealf = false;
    }

    // Update is called once per frame
    void Update()
    {
        Trocar();
        MostrarAlfabeto();
        
    }

    // Trocar o Mostrar e Tirar alfabeto

    public void Trocar()
    {

        if(botoes[i + 1].color == cor[0])
        {
            botoes[i + 2].color = cor[1];
        }
        else
        {
            botoes[i + 2].color = cor[0];
        }
    }

    // Botao para mostrar ou não alfabeto;

    public void add()
    {
        if (controlealf)
            controlealf = false;
        else
            controlealf = true;
    }

    // Função que vai realmente mostrar o alfabeto

    public void MostrarAlfabeto()
    {
        // i  = Index da Imagem do alfabeto


        if (!controlealf)
        {
            botoes[i].color = cor[0];
            botoes[i + 1].color = cor[0];

        }
        else
        {
            botoes[i].color = cor[1];
            botoes[i + 1].color = cor[1];
        }

    }
}
