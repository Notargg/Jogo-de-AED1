using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sinais : MonoBehaviour
{
    // Criação das variaveis - Listas para auxiliar

    public Image[] botoes;
    public Color[] cor;

    // Variaveis

    public int i = 0;
    public Text Oquee;
    int TAM = 17;

    // Construtor

    Sinais()
    {
        botoes = new Image[TAM * 2];
        cor = new Color[2];
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Image img in botoes)
        {
            img.color = cor[0];

        }

    }

    // Update is called once per frame
    void Update()
    {
        botoes[i].color = cor[1];
        botoes[i + TAM].color = cor[1];

        if ( i > (0) && i < (TAM -1))
        {

            botoes[i - 1].color = cor[0];
            botoes[i + 1].color = cor[0];
            botoes[i + (TAM - 1)].color = cor[0];
            botoes[i + (TAM + 1)].color = cor[0];
        }


        if( i == 0) // No caso de ser 0, para não sair do array na função acima, tem esse caso particular
        {
            botoes[1].color = cor[0];
            botoes[1 + TAM].color = cor[0];
        }

        ATT(); // Atualiza
    }

    void ATT() // Função para ir atualizando de acordo com o que o usuário Clica
    {
        switch (i) // Caso de todos os sinais que serão utilizados
        {
            case 0:
                Oquee.text = "AMARELO";
                break;
            case 1:
                Oquee.text = "AZUL";
                break;
            case 2:
                Oquee.text = "BEGE";
                break;
            case 3:
                Oquee.text = "BRANCO";
                break;
            case 4:
                Oquee.text = "CINZA";
                break;
            case 5:
                Oquee.text = "LARANJA";
                break;
            case 6:
                Oquee.text = "LILAS";
                break;
            case 7:
                Oquee.text = "MARROM";
                break;
            case 8:
                Oquee.text = "LOBO";
                break;
            case 9:
                Oquee.text = "MORCEGO";
                break;
            case 10:
                Oquee.text = "ONÇA";
                break;
            case 11:
                Oquee.text = "PANDA";
                break;
            case 12:
                Oquee.text = "PEIXE";
                break;
            case 13:
                Oquee.text = "PORCO";
                break;
            case 14:
                Oquee.text = "RATO";
                break;
            case 15:
                Oquee.text = "URSO";
                break;
            case 16:
                Oquee.text = "VACA";
                break;

        }

    }

    // Função para ir com o vetor

    public void ADD()
    {
        if(i < (TAM - 1))
        {
            i++;
        }
    }

    // Função para voltar com o vetor 

    public void REMOVE()
    {

        if( i > 0)
        {

            i--;
        }

    }
}
