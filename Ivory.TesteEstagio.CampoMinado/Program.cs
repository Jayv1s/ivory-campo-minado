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

            List<int> posicaoBombas = new List<int>();
            int tamanho = campoMinado.Tabuleiro.Length;
            int count = 0;
            int i = 0;
            char cima =' ', baixo = ' ';
            char esquerda = ' ', direita = ' ';
            char diagonalSupEsq = ' ', diagonalSupDir = ' ';
            char diagonalInfEsq = ' ', diagonalInfDir = ' ';

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

                    if (esquerda == '\n') // se tiver borda no lado esquerdo
                    {
                        diagonalSupEsq = '\n';
                        diagonalInfEsq = '\n';

                        if (baixo == ' ') // se tiver borda no lado esquerdo e em baixo
                        {
                            diagonalSupDir = campoMinado.Tabuleiro[i - 10];
                            diagonalInfDir = ' ';
                        }
                        else if (cima == ' ')// se tiver borda no lado esquerdo e em cima
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
                    else if (direita == '\r') // se tiver borda no lado direito
                    {
                        diagonalSupDir = '\r';
                        diagonalInfDir = '\r';

                        if (baixo == ' ') // se tiver borda no lado direito e em baixo
                        {
                            diagonalSupEsq = campoMinado.Tabuleiro[i - 12];
                            diagonalInfEsq = ' ';
                        }
                        else if (cima == ' ') // se tiver borda no lado direito e em cima
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
                        if (baixo == ' ') // se tiver borda em baixo
                        {
                            diagonalSupEsq = campoMinado.Tabuleiro[i - 12];
                            diagonalSupDir = campoMinado.Tabuleiro[i - 10];

                            diagonalInfEsq = ' ';
                            diagonalInfDir = ' ';
                        }
                        else if (cima == ' ') // se tiver borda em cima
                        {
                            diagonalInfDir = campoMinado.Tabuleiro[i + 12];
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
                }
                else
                    count++;

                if(posicaoAtual != '\n' && posicaoAtual != '\r' && posicaoAtual != '0' && posicaoAtual != '-')
                {
                    bool bombaEncontrada = false;
                    int bombasVizinhas = 0;
                    int quantidadeCasasFechadas = 0;
                    List<int> casaFechadas = new List<int>();
                    if (cima == '-')
                    {
                        casaFechadas.Add((i - count) - 9);
                        quantidadeCasasFechadas++;
                    }
                    if (baixo == '-')
                    {
                        casaFechadas.Add((i - count) + 9);
                        quantidadeCasasFechadas++;
                    }
                    if (esquerda == '-')
                    {
                        casaFechadas.Add((i - count) - 1);
                        quantidadeCasasFechadas++;
                    }
                    if (direita == '-')
                    {
                        casaFechadas.Add((i - count) + 1);
                        quantidadeCasasFechadas++;
                    }


                    if (diagonalInfDir == '-')
                    {
                        casaFechadas.Add((i - count) + 10);
                        quantidadeCasasFechadas++;
                    }
                    if (diagonalInfEsq == '-')
                    {
                        casaFechadas.Add((i - count) + 8);
                        quantidadeCasasFechadas++;
                    }
                    if (diagonalSupDir == '-')
                    {
                        casaFechadas.Add((i - count) - 8);
                        quantidadeCasasFechadas++;
                    }
                    if (diagonalSupEsq == '-')
                    {
                        casaFechadas.Add((i - count) - 10);
                        quantidadeCasasFechadas++;
                    }

                    int valorCasaAtual = int.Parse(posicaoAtual.ToString());

                    if (quantidadeCasasFechadas == valorCasaAtual)
                    {
                        foreach (var casaVaga in casaFechadas)
                        {
                            if (!posicaoBombas.Contains(casaVaga))
                            {
                                bombaEncontrada = true;
                                posicaoBombas.Add(casaVaga);
                            }

                        }

                        if(bombaEncontrada)
                        {
                            i = 0;
                            count = 0;
                        }
                        else
                        {
                            i++;
                        }

                    }
                    else if(quantidadeCasasFechadas > valorCasaAtual)
                    {
                        foreach (var bombas in posicaoBombas)
                        {
                            if(casaFechadas.Contains(bombas))
                            {
                                quantidadeCasasFechadas--;
                                bombasVizinhas++;
                                casaFechadas.Remove(bombas);
                            }
                        }

                        if(bombasVizinhas == valorCasaAtual && quantidadeCasasFechadas > 0)
                        {
                            foreach (var casaSegura in casaFechadas)
                            {
                                int linha = (int)(casaSegura / 9) + 1;
                                int coluna = (casaSegura % 9) + 1;
                                campoMinado.Abrir(linha, coluna);
                                Console.Clear();
                                Console.WriteLine(campoMinado.Tabuleiro);
                                Console.ReadKey();
                            }
                            i = 0;
                            count = 0;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                else
                {
                    i++;
                }
            } while (i < tamanho && campoMinado.JogoStatus == 0);

            Console.Clear();
            Console.WriteLine(campoMinado.JogoStatus);

            Console.WriteLine("\n \n ");

            Console.WriteLine(campoMinado.Tabuleiro);

            Console.ReadKey();
        }
    }
}
