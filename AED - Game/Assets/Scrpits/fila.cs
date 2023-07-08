
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



using Filas;


public class fila : MonoBehaviour
{

    // Chamada das filas

    public ff a;
    public ff b;

    // Controlador de Partes

    public int partes = 0;

    // Lista de Imagens e Cor - Cor transparente e n�o transparente / Imagem - Mostrar nov�s imagens nos botoes

    public Image[] botoes;
    public Color[] cor;

    // Textos para mostrar o que tem que escrever ( Segunda Parte ) / O que est� sendo escrito ( Tentativa )

    public Text SegundaParte;
    public Text Tentativa;
    public Text Vidass;

    // Declara��o de vari�veis

    public int tamex = 0;
    private int control = 0; // Garantir que n�o seja a mesma palavra duas vezes
    public int controle = 0; // Controla a quantidade de tentativas
    public int max = 1; // Maximo de rodadas em cada fase
    int vidas;

    // Come�o do jogo

    void Start()
    {

        CriaFilas();
        StartGame(0);
        ControleJogo();
        controle = 0;
        vidas = 1;

    }

    // Deixar todas as imagens apagadas

    void StartGame(int x)
    {

        foreach (Image img in botoes)
        {
            img.color = cor[x];

        }


    }

    // Fun��o para atualizar as filas

    public void CriaFilas()
    {
        a.capacity = 4 + partes;
        b.capacity = 4 + partes;
        a.head = 0;
        b.head = 0;
        a.tail = -1;
        b.tail = -1;
        a.size = 0;
        b.size = 0;

    }


    // Chamada toda vez que tem atualiza��o de frame

    void Update()
    {
        int cores = partes % 2;
        StartGame(cores);
        ContinuarGame();
        Vidass.text = "Vidas: " + vidas.ToString();
    }

    // Controle da palavra que deve ser escrita

    public void ControleJogo()
    {

        int i = Random.Range(0,9);


        if (partes == 0)
        {

            if (control == i)
            {
                i++;
            }


            switch (i)
            {
                case 0:
                    SegundaParte.text = "BOLA";
                    break;
                case 1:
                    SegundaParte.text = "BALA";
                    break;
                case 2:
                    SegundaParte.text = "BOLO";
                    break;
                case 3:
                    SegundaParte.text = "SALA";
                    break;
                case 4:
                    SegundaParte.text = "SOLA";
                    break;
                case 5:
                    SegundaParte.text = "SOLO";
                    break;
                case 6:
                    SegundaParte.text = "LOBA";
                    break;
                case 7:
                    SegundaParte.text = "LOBO";
                    break;
                case 8:
                    SegundaParte.text = "BOA";
                    tamex = -1;
                    break;
                default:
                    SegundaParte.text = "BOLO";
                    break;

            }

            control = i;

        }

        if (partes == 1)
        {

            if (control == i)
            {
                i++;
            }


            switch (i)
            {
                case 0:
                    SegundaParte.text = "PORCO";
                    break;
                case 1:
                    SegundaParte.text = "PORCA";
                    break;
                case 2:
                    SegundaParte.text = "CARRO";
                    break;
                case 3:
                    SegundaParte.text = "CORPO";
                    break;
                case 4:
                    SegundaParte.text = "POUCA";
                    break;
                case 5:
                    SegundaParte.text = "POUCO";
                    break;
                case 6:
                    SegundaParte.text = "ROUPA";
                    break;
                case 7:
                    SegundaParte.text = "ROUCO";
                    break;
                case 8:
                    SegundaParte.text = "ROUCA";
                    break;
                case 9:
                    SegundaParte.text = "ARCO";
                    tamex = -1;
                    break;


            }

            control = i;
        }

        if (partes == 2)
        {

            if (control == i)
            {
                i++;
            }

            switch (i)
            {
                case 0:
                    SegundaParte.text = "MORDER";
                    tamex = 0;
                    break;
                case 1:
                    SegundaParte.text = "DOR   ";
                    tamex = -3;
                    break;
                case 2:
                    SegundaParte.text = "DORMIR";
                    tamex = 0;
                    break;
                case 3:
                    SegundaParte.text = "MEDIR ";
                    tamex = -1;
                    break;
                case 4:
                    SegundaParte.text = "RIR   ";
                    tamex = -3;
                    break;
                case 5:
                    SegundaParte.text = "ODOR  ";
                    tamex = -2;
                    break;
                case 6:
                    SegundaParte.text = "DEDO  ";
                    tamex = -2;
                    break;
                case 7:
                    SegundaParte.text = "RODO  ";
                    tamex = -2;
                    break;
                case 8:
                    SegundaParte.text = "REMO  ";
                    tamex = -2;
                    break;
                default:
                    SegundaParte.text = "MEDO  ";
                    tamex = -2;
                    break;


            }

            control = i;
        }

        

        filaresp();


    }

    // Preencher a fila de respostas de acordo com o banco de dados

    public void filaresp()
    {
        for (int j = 0; j < b.capacity + tamex; j++)
        {
            char x = SegundaParte.text[j];
            b.addfila(x);

        }


    }

    // Fun��o para continuar o jogo

    public void ContinuarGame()
    {

        if (a.size == b.size) // Assim que os dois tiverem o mesmo tamanho
        {
            

            if (a.CompararFila(b,a, tamex)) // Compara retirando cada elemento
            {
                // Se for igual a palavra
                
                if (controle >= max) // Se controle for mais ou igual ( Maior ou igual pois ter� casos - terceira fase da primeira parte - que ter� mais
                {

                    if(controle > (max + (max - 1))) // Adicionar duas vezes na terceira fase
                    {
                         SceneManager.LoadScene("Introdu��oSeg"); // Ir pro Segundo Est�gio
                    }

                    if ( partes == 1) // Se partes for igual a 1 j� cria a parte para ir pro terceiro n�vel
                    {
                        partes++;
                        CriaFilas(); // A partir do momento que muda - ele j� atualiza para aumentar o espa�o para assim que criar a fila de resposta - j� ter 6 elementos
                        
                    }

                    if (partes == 0)
                    {
                        partes++; // Adicionar Partes - Por isso na outra tela tem partes = 1;
                        SceneManager.LoadScene("TelaGamess"); // Muda de tela
                        
                    }


                }
                
                // Continua o jogo

                controle++;


            }
            else
            {
                if (vidas == 0)
                {
                    SceneManager.LoadScene("TelaDerrota"); // Caso n�o seja igual - j� aplica a derrota
                }



                vidas--;
   

            }

            tamex = 0;
            Tentativa.text = "";
            StartGame(0);
            a.zerarf();
            b.zerarf();
            ControleJogo();


        }

    }

    // Fun��es para adicionarem na fila - B O L A S R P C U M E D I - Futuramente haver� mais coisas

    // Como � percet�vel, em alguns momentos as mesmas fun��es acambam ofertando conteudos diferentes de acordo com o est�gio do jogo

    public void addB()
    {


        a.addfila('B');
        Tentativa.text = Tentativa.text + 'B';
        

    }

    public void addO() // Adiciona R Tamb�m
    {
        if (partes < 2)
        {
            a.addfila('O');
            Tentativa.text = Tentativa.text + 'O';

        }
        else
        {
            a.addfila('R');
            Tentativa.text = Tentativa.text + 'R';

        }

        
    }

    public void addL()
    {
        a.addfila('L');
        Tentativa.text = Tentativa.text + 'L';
        

    }

    public void addA() // Adiciona E Tamb�m
    {
        if (partes < 2)
        {
            a.addfila('A');
            Tentativa.text = Tentativa.text + 'A';

        }
        else
        {
            a.addfila('E');
            Tentativa.text = Tentativa.text + 'E';

        }
       
    }

    public void addS()
    {
        a.addfila('S');
        Tentativa.text = Tentativa.text + 'S';
        
    }

    public void addP() // Adiciona D Tamb�m
    {
        if (partes < 2)
        {
            a.addfila('P');
            Tentativa.text = Tentativa.text + 'P';

        }
        else
        {
            a.addfila('D');
            Tentativa.text = Tentativa.text + 'D';

        }
        
    }

    public void addR() // Adiciona M Tamb�m
    {
        if (partes < 2)
        {
            a.addfila('R');
            Tentativa.text = Tentativa.text + 'R';

        }
        else
        {
            a.addfila('M');
            Tentativa.text = Tentativa.text + 'M';

        }
        
    }

    public void addU() // Adiciona O Tamb�m
    {
        if (partes < 2)
        {
            a.addfila('U');
            Tentativa.text = Tentativa.text + 'U';

        }
        else
        {
            a.addfila('O');
            Tentativa.text = Tentativa.text + 'O';

        }
        
    }

    public void addC() // Adiciona o � Tamb�m
    {
        if (partes < 2)
        {
            a.addfila('C');
            Tentativa.text = Tentativa.text + 'C';

        }
        else
        {
            a.addfila('I');
            Tentativa.text = Tentativa.text + 'I';

        }
        

    }

    // Fun��o para desistir do jogo

    public void MarcadorX()
    {
        
        Tentativa.text = "";
        SceneManager.LoadScene("TelaInicio");

    }

    // Fun��o do marcador Zerar !

    public void MarcadorZerar()
    {

        a.zerarf();
        Tentativa.text = "";

    }

}
