using System;
using System.Collections.Generic;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);
            // Realize sua codificação a partir deste ponto, boa sorte!
            //string tabuleiroSemQuebrarLinhas = Regex.Replace(campoMinado.Tabuleiro, @"\t|\n|\r", "");
            List<int> posicaoBombas = new List<int>();
            int tamanho = campoMinado.Tabuleiro.Length;
            int count = 0;
            int i = 0;
            char cima, baixo;
            char esquerda, direita;
            char diagonalSupEsq, diagonalSupDir;
            char diagonalInfEsq, diagonalInfDir;

            do
            {
                char posicaoAtual = campoMinado.Tabuleiro[i];

                if (!(posicaoAtual == '\n' || posicaoAtual == '\r'))
                {
                    if (i >= 0 && i <= 10)//se for a primeira linha
                    {
                        if (i == 0)
                        {
                            esquerda = '\n';
                        }
                        else
                        {
                            esquerda = campoMinado.Tabuleiro[i - 1];
                        }
                        cima = ' ';
                        diagonalSupEsq = ' ';
                        diagonalSupDir = ' ';

                        direita = campoMinado.Tabuleiro[i + 1];
                        baixo = campoMinado.Tabuleiro[i + 11];
                    }
                    else if (i >= 87 && i <= 96)//se for a ultima linha
                    {
                        if (i == 96)
                        {
                            direita = '\r';
                        }
                        else
                        {
                            direita = campoMinado.Tabuleiro[i + 1];
                        }
                        baixo = ' ';
                        diagonalInfEsq = ' ';
                        diagonalInfDir = ' ';

                        esquerda = campoMinado.Tabuleiro[i - 1];
                        cima = campoMinado.Tabuleiro[i - 11];
                    }
                    else
                    {
                        cima = campoMinado.Tabuleiro[i - 11];
                        baixo = campoMinado.Tabuleiro[i + 11];

                        direita = campoMinado.Tabuleiro[i + 1];
                        esquerda = campoMinado.Tabuleiro[i - 1];
                    }

                    if (esquerda == '\n')
                    {
                        diagonalSupEsq = '\n';
                        diagonalInfEsq = '\n';

                        if (baixo == ' ')
                        {
                            diagonalSupDir = campoMinado.Tabuleiro[i - 10];
                            diagonalInfDir = ' ';
                        }
                        else if (cima == ' ')
                        {
                            diagonalInfDir = campoMinado.Tabuleiro[i + 12];
                            diagonalSupDir = ' ';
                        }
                        else
                        {
                            diagonalSupDir = campoMinado.Tabuleiro[i - 10];
                            diagonalInfDir = campoMinado.Tabuleiro[i + 12];
                        }
                    }
                    else if (direita == '\r')
                    {
                        diagonalSupDir = '\r';
                        diagonalInfDir = '\r';

                        if (baixo == ' ')
                        {
                            diagonalSupEsq = campoMinado.Tabuleiro[i - 12];
                            diagonalInfEsq = ' ';
                        }
                        else if (cima == ' ')
                        {
                            diagonalInfEsq = campoMinado.Tabuleiro[i + 10];
                            diagonalSupEsq = ' ';
                        }
                        else
                        {
                            diagonalInfEsq = campoMinado.Tabuleiro[i + 10];
                            diagonalSupEsq = campoMinado.Tabuleiro[i - 12];

                        }
                    }
                    else
                    {
                        if (baixo == ' ')
                        {
                            diagonalSupEsq = campoMinado.Tabuleiro[i - 12];
                            diagonalInfEsq = ' ';
                            diagonalInfDir = ' ';
                        }
                        else if (cima == ' ')
                        {
                            diagonalInfEsq = campoMinado.Tabuleiro[i + 10];
                            diagonalSupEsq = ' ';
                            diagonalSupDir = ' ';
                        }
                        else
                        {
                            diagonalInfDir = campoMinado.Tabuleiro[i + 12];
                            diagonalInfEsq = campoMinado.Tabuleiro[i + 10];

                            diagonalSupDir = campoMinado.Tabuleiro[i - 10];
                            diagonalSupEsq = campoMinado.Tabuleiro[i - 12];
                        }
                    }

                    //switch (posicaoAtual)
                    //{
                    //    case '-':
                    //        if( !posicaoBombas.Contains(i) )
                    //        {
                    //            int indexNaMatriz = i - count;

                    //            int linha = (int)(indexNaMatriz / 9);
                    //            int coluna = indexNaMatriz % 9;

                    //            campoMinado.Abrir(linha, coluna);
                    //        }
                    //        break;

                    //    case '1':
                    //        if(cima == '-')
                    //        {

                    //        }
                    //        break;

                    //    //case '2':
                    //    //    break;

                    //    //case '3':
                    //    //    break;

                    //    //case '-':
                    //    //    break;
                    //    default:
                    //        break;
                    //}
                }
                else
                    count++;
                i++;
            } while (i < tamanho && campoMinado.JogoStatus == 0);

            Console.ReadKey();
        }
    }
}
