using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Filas;

public class TerceiraParte : MonoBehaviour
{
    // Listas do unity - configurada na própria interface

    public Color[] cor;
    public Image[] botoes;

    // Filas que armazenam as respostas dadas e as respostas certas

    public ff respostas;
    public ff certas;
    public Text SegundaParte;

    // Controladores

    public int i = 0; // Gerar as respostas - Animais
    public int j = 0; // Gerar as respostas - Cores
    int controle = 0; // Número de tentativas
    int TAM = 8; // Tamanho dos vetores que tem todas as imagens

    public int n; // Colocar o número certo
    public int aux = 0; // Auxiliar para colocar no lugar certo
    

    // Start is called before the first frame update
    void Start()
    {
        CriaFilas();
        Limpar();
        ControleJogo();
        n = 20;
        aux = 0;
    }

    // Construtor

    TerceiraParte()
    {

        botoes = new Image[TAM * 2];
        cor = new Color[2];

    }

    // Limpar todas as imagens para depois colocar apenas as que precisam aparecer

    public void Limpar()
    {
        foreach (Image img in botoes)
        {
            img.color = cor[0];

        }

    }

    // Update is called once per frame
    void Update()
    {
        if ( n < 16) // Tamanho maximo de imagens
        {
            botoes[n].color = cor[1];
        }


        
    }

    public void ContinuarGame()
    {
        if( respostas.size == certas.size)
        {
            if (respostas.CompararFila(certas, respostas, 0))
            {
                if (controle == 3) // Número de vezes + 1 que terá que jogar
                {

                    SceneManager.LoadScene("TelaVitoria");

                }

                // Limpar / Reiniciar os controladores / Adicionar tentativa / Chamar Controlador

                Limpar();
                n = 20;
                aux = 0;
                controle++;
                ControleJogo();

            }
            else
            {
                SceneManager.LoadScene("TelaDerrota");
            }

        }

    }



    // Controle de jogo - Gerador de respostas

    public void ControleJogo()
    {

        i = Random.Range(0, 3);
        j = Random.Range(0, 3);

        switch (i)
        {
            case 0:
                SegundaParte.text = "LOBO";
                break;
            case 1:
                SegundaParte.text = "PEIXE";
                break;
            case 2:
                SegundaParte.text = "PORCO";
                break;
            case 3:
                SegundaParte.text = "URSO";
                break;

        }


        switch (j)
        {
            case 0:
                SegundaParte.text = SegundaParte.text + " BEGE";
                break;
            case 1:
                SegundaParte.text = SegundaParte.text + " BRANCO";
                break;
            case 2:
                SegundaParte.text = SegundaParte.text + " CINZA";
                break;
            case 3:
                SegundaParte.text = SegundaParte.text + " MARROM";
                break;

        }

        filaresp();

    }

    // Preencher a fila de respostas

    void filaresp()
    {
        char b;
        string x;

        x = i.ToString();
        b = x[0];
        certas.addfila(b);

        int a = 4 + j; // Auxilia na conversao para char

        x = a.ToString();
        b = x[0];
        certas.addfila(b);

    }

    public void CriaFilas() // Cria as filas que vão ser Usadas
    {
        respostas.capacity = 2;
        certas.capacity = 2;
    }

    // Funções dos botões - Codificador

    public void addSinal0()
    {
        if (respostas.size != certas.size) // Caso nao seja igual pode adicionar
        {
            respostas.addfila('0'); // Adiciona 0
            n = 0 + aux;
            aux = TAM;
        }
            
    }

    public void addSinal1() // Caso nao seja igual pode adicionar
    {

        if (respostas.size != certas.size)// Caso nao seja igual pode adicionar 
        {
            respostas.addfila('1'); // Adiciona 1
            n = 1 + aux;
            aux = TAM;
        }

    }

    public void addSinal2() // Caso nao seja igual pode adicionar
    {
        if (respostas.size != certas.size) // Caso nao seja igual pode adicionar
        {
            respostas.addfila('2'); // Adiciona 2
            n = 2 + aux;
            aux = TAM;
        }

    }

    public void addSinal3() // Caso nao seja igual pode adicionar
    {
        
        if (respostas.size != certas.size)// Caso nao seja igual pode adicionar
        {
            respostas.addfila('3'); // Adiciona 3
            n = 3 + aux;
            aux = TAM;
        }

    }

    public void addSinal4() // Caso nao seja igual pode adicionar
    {
        
        if (respostas.size != certas.size)
        {
            respostas.addfila('4'); // Adicionar 4
            n = 4 + aux;
            aux = TAM;
        }
    }

    public void addSinal5() // Caso nao seja igual pode adicionar
    {
        if (respostas.size != certas.size)
        {
            respostas.addfila('5'); // Adiciona 5
            n = 5 + aux;
            aux = TAM;
        }
    }

    public void addSinal6() // Caso nao seja igual pode adicionar
    {
       
        if (respostas.size != certas.size)
        {
            respostas.addfila('6'); // Adiciona 6
            n = 6 + aux;
            aux = TAM;
        }
    }

    public void addSinal7() // Caso nao seja igual pode adicionar
    {
        if (respostas.size != certas.size)
        {
            respostas.addfila('7'); // Adicona  7
            n = 7 + aux;
            aux = TAM;
        }
    }


    // Função para desistir do jogo

    public void MarcadorX()
    {
        SceneManager.LoadScene("TelaInicio"); // Vai para a tela de inicio
    }

    // Função do marcador Zerar !

    public void MarcadorZerar()
    {
        Limpar(); // Limpar todos
        n = 20;
        aux = 0;
        respostas.zerarf(); // Zerar as respotas

    }
}
