using System;

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

            int tamanho = campoMinado.Tabuleiro.Length;
            char cima, baixo;
            char esquerda, direita;
            char diagonalSupEsq, diagonalSupDir;
            char diagonalInfEsq, diagonalInfDir;

            for (int i = 0; i < tamanho; i++)
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
                    }
                    else if (direita == '\r')
                    {
                        diagonalSupDir = '\r';
                        diagonalInfDir = '\r';

                        if (baixo == ' ')
                        {
                            diagonalSupEsq = campoMinado.Tabuleiro[i - 10];
                            diagonalInfEsq = ' ';
                        }
                        else if (cima == ' ')
                        {
                            diagonalInfEsq = campoMinado.Tabuleiro[i + 12];
                            diagonalSupEsq = ' ';
                        }
                    }
                    else 
                    {
                        if (baixo == ' ')
                        {
                            diagonalSupEsq = campoMinado.Tabuleiro[i - 10];
                            diagonalInfEsq = ' ';
                            diagonalInfDir = ' ';
                        }
                        else if (cima == ' ')
                        {
                            diagonalInfEsq = campoMinado.Tabuleiro[i + 12];
                            diagonalSupEsq = ' ';
                            diagonalSupDir = ' ';
                        }
                        else
                        {
                            diagonalInfDir = campoMinado.Tabuleiro[i - 10];
                            diagonalInfEsq = campoMinado.Tabuleiro[i - 12];
                            diagonalSupDir = campoMinado.Tabuleiro[i + 10];
                            diagonalSupEsq = campoMinado.Tabuleiro[i + 12];
                        }
                    }
                }

            }



            //AnalisaJogo(campoMinado, tamanho);
            Console.ReadKey();

        }

        //static void AnalisaJogo(CampoMinado MeuJogo, int tamanho)
        //{

        //    if(MeuJogo.JogoStatus == 0)
        //    {
        //        switch (posicaoAtual)
        //        {
        //            case '3':
        //                break;

        //            case '2':
        //                break;

        //            case '1':
        //                break;

        //            case '0':
        //                break;

        //            case '-':
        //                break;

        //            case ' ':
        //                break;

        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}
