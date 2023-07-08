using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Filas;



public class SegundaParte : MonoBehaviour
{
    // Listas do unity - configurada na própria interface

    public Color[] cor;
    public Image[] botoes;

    // Filas que armazenam as respostas dadas e as respostas certas

    public ff respostas;
    public ff certas;

    // Vetor que armazena os indices

    public int[] indices;

    // Numero de vidas

    public Text Vidass;

    // Variáveis que controla o tamanho da fase - TAM = quantas fases na mesma parte /NB - Número de botoes contendo as alternativas

    int TAM = 3;
    int NB = 5;
    public int partes = 0; // Terá duas partes - Podendo ser bool , contudo eu decida aumentar é só aumentar aqui e criar o caso no if / case
    int vidas;

    public SegundaParte() // Construtor do vetor que vai guardar os indices
    {
        indices = new int[10];
        cor = new Color[2]; // Duas cores - tranparente e não transparente
        botoes = new Image[30]; // 30 = Número de possiveis respostas (5 * 3 - botoes x tamanho das fases) + 15 respostas ( Imagens dos sinais )
    }


    public int tamex = 0;

    void Start() // Função que inicia após o Botão Start
    {
        StartGame();
        CriaFilas();
        preenchercerto();
        vidas = 2;

    }

    public void CriaFilas() // Cria as filas que vão ser Usadas
    {
        respostas.capacity = TAM + tamex;
        certas.capacity = TAM + tamex;
    }

    void StartGame() // Função pára zerar todas as imagens das Listas do Unity
    {

        foreach(Image img in botoes)
        {
            img.color = cor[0];

        }
    }


    void preenchercerto() // Preencher de forma aleatoria a respostas
    {
        int i;
        char b;
        string x;
        
        for(int j = 0;j < TAM; j++) // Preenchendo de acordo
        {
            i = Random.Range(1, 5);
            x = i.ToString();
            b = x[0];

            indices[j] = i;
            certas.addfila(b);
        }


    }
    
    // Update is called once per frame
    void Update()
    {
        StartGame(); // Fazer todos ficarem apagados

        for (int i = (NB * respostas.size); i < (NB + (NB * respostas.size)); i++) // Apenas mostrar aqueles que vão ser usados em cada fase
        {

            botoes[i].color = cor[1];
            botoes[(TAM * NB + (NB * respostas.size)) + (indices[respostas.size] - 1)].color = cor[1];
        }

        ContinuarGame(); // Verificar se a pessoa acertou

        Vidass.text = "Vidas: " + vidas.ToString(); // Atualizar as vidas
    }
    
    // Função para verificar o jogo

    void ContinuarGame() // Continuar o game, verificar se perdeu ou ganhou
    {

        if(respostas.size == certas.size) // Quando o número de respostas certas for igual ao número de respostas precisas 
        {
            if (respostas.CompararFila(certas, respostas, tamex)) // Dependendo das partes vai para lugares diferntes
            {
                if (partes == 1) 
                {
                    SceneManager.LoadScene("TelaTerceira");
                }

                if (partes == 0)
                {
                    partes++;
                    
                    SceneManager.LoadScene("Sinais2");

                }

                    tamex = 0;

            }
            else
            {
                if (vidas == 0)
                {
                    SceneManager.LoadScene("TelaDerrota");
                }

                // Tem que zerar as tentativas e gerar novas

                vidas--;
                tamex = 0;
                StartGame();
                certas.zerarf();
                preenchercerto();
                MarcadorZerar();



            }


        }

    }

    // Adicionar Elementos - Codificador de cada botão

    public void addSinal1()
    {
        respostas.addfila('1'); // Adiciona 1
    }

    public void addSinal2()
    {
        respostas.addfila('2'); // Adiciona 2
    }

    public void addSinal3()
    {
        respostas.addfila('3'); // Adiciona 3
    }

    public void addSinal4()
    {
        respostas.addfila('4'); // Adiciona 4
    }

    public void addSinal5()
    {
        respostas.addfila('5'); // Adiciona 5
    }

    // Função para desistir do jogo

    public void MarcadorX()
    {
        
        SceneManager.LoadScene("TelaInicio");
    }

    // Função do marcador Zerar !

    public void MarcadorZerar()
    {
        StartGame();
        respostas.zerarf();

    }

}
