using System;
using System.Collections.Generic;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Vizinho
    {
        public char cima, baixo;
        public char esquerda, direita;
        public char diagonalSupEsq, diagonalSupDir;
        public char diagonalInfEsq, diagonalInfDir;

        public Vizinho()
        {
            cima = ' ';
            baixo = ' ';

            esquerda = ' ';
            direita = ' ';

            diagonalSupEsq = ' ';
            diagonalSupDir = ' ';

            diagonalInfEsq = ' ';
            diagonalInfDir = ' ';
        }
    }

    class Operacoes
    {
        public Vizinho IdentificarVizinhos(int indexAtual, char posicaoAtual, string tabuleiro)
        {
            Vizinho vizinho = new Vizinho();


            if (indexAtual >= 0 && indexAtual <= 10)//se for a primeira linha
            {
                if (indexAtual == 0)
                {
                    vizinho.esquerda = '\n';
                }
                else
                {
                    vizinho.esquerda = tabuleiro[indexAtual - 1];
                }
                vizinho.cima = ' ';
                vizinho.diagonalSupEsq = ' ';
                vizinho.diagonalSupDir = ' ';

                vizinho.direita = tabuleiro[indexAtual + 1];
                vizinho.baixo = tabuleiro[indexAtual + 11];
            }
            else if (indexAtual >= 87 && indexAtual <= 96)//se for a ultima linha
            {
                if (indexAtual == 96)
                {
                    vizinho.direita = '\r';
                }
                else
                {
                    vizinho.direita = tabuleiro[indexAtual + 1];
                }
                vizinho.baixo = ' ';
                vizinho.diagonalInfEsq = ' ';
                vizinho.diagonalInfDir = ' ';

                vizinho.esquerda = tabuleiro[indexAtual - 1];
                vizinho.cima = tabuleiro[indexAtual - 11];
            }
            else
            {
                vizinho.cima = tabuleiro[indexAtual - 11];
                vizinho.baixo = tabuleiro[indexAtual + 11];

                vizinho.direita = tabuleiro[indexAtual + 1];
                vizinho.esquerda = tabuleiro[indexAtual - 1];
            }

            if (vizinho.esquerda == '\n') // se tiver borda no lado esquerdo
            {
                vizinho.diagonalSupEsq = '\n';
                vizinho.diagonalInfEsq = '\n';

                if (vizinho.baixo == ' ') // se tiver borda no lado esquerdo e em baixo
                {
                    vizinho.diagonalSupDir = tabuleiro[indexAtual - 10];
                    vizinho.diagonalInfDir = ' ';
                }
                else if (vizinho.cima == ' ')// se tiver borda no lado esquerdo e em cima
                {
                    vizinho.diagonalInfDir = tabuleiro[indexAtual + 12];
                    vizinho.diagonalSupDir = ' ';
                }
                else
                {
                    vizinho.diagonalSupDir = tabuleiro[indexAtual - 10];
                    vizinho.diagonalInfDir = tabuleiro[indexAtual + 12];
                }
            }
            else if (vizinho.direita == '\r') // se tiver borda no lado direito
            {
                vizinho.diagonalSupDir = '\r';
                vizinho.diagonalInfDir = '\r';

                if (vizinho.baixo == ' ') // se tiver borda no lado direito e em baixo
                {
                    vizinho.diagonalSupEsq = tabuleiro[indexAtual - 12];
                    vizinho.diagonalInfEsq = ' ';
                }
                else if (vizinho.cima == ' ') // se tiver borda no lado direito e em cima
                {
                    vizinho.diagonalInfEsq = tabuleiro[indexAtual + 10];
                    vizinho.diagonalSupEsq = ' ';
                }
                else
                {
                    vizinho.diagonalInfEsq = tabuleiro[indexAtual + 10];
                    vizinho.diagonalSupEsq = tabuleiro[indexAtual - 12];
                }
            }
            else
            {
                if (vizinho.baixo == ' ') // se tiver borda em baixo
                {
                    vizinho.diagonalSupEsq = tabuleiro[indexAtual - 12];
                    vizinho.diagonalSupDir = tabuleiro[indexAtual - 10];

                    vizinho.diagonalInfEsq = ' ';
                    vizinho.diagonalInfDir = ' ';
                }
                else if (vizinho.cima == ' ') // se tiver borda em cima
                {
                    vizinho.diagonalInfDir = tabuleiro[indexAtual + 12];
                    vizinho.diagonalInfEsq = tabuleiro[indexAtual + 10];
                    vizinho.diagonalSupEsq = ' ';
                    vizinho.diagonalSupDir = ' ';
                }
                else
                {
                    vizinho.diagonalInfDir = tabuleiro[indexAtual + 12];
                    vizinho.diagonalInfEsq = tabuleiro[indexAtual + 10];

                    vizinho.diagonalSupDir = tabuleiro[indexAtual - 10];
                    vizinho.diagonalSupEsq = tabuleiro[indexAtual - 12];
                }
            }

            return vizinho;
        }

        public List<int> IdentificarVizinhosFechados(Vizinho vizinhosAtuais, int indexAtual, int bordas)
        {
            List<int> vizinhosFechadas = new List<int>();

            if (vizinhosAtuais.cima == '-')
                vizinhosFechadas.Add((indexAtual - bordas) - 9);

            if (vizinhosAtuais.baixo == '-')
                vizinhosFechadas.Add((indexAtual - bordas) + 9);

            if (vizinhosAtuais.esquerda == '-')
                vizinhosFechadas.Add((indexAtual - bordas) - 1);

            if (vizinhosAtuais.direita == '-')
                vizinhosFechadas.Add((indexAtual - bordas) + 1);

            if (vizinhosAtuais.diagonalInfDir == '-')
                vizinhosFechadas.Add((indexAtual - bordas) + 10);

            if (vizinhosAtuais.diagonalInfEsq == '-')
                vizinhosFechadas.Add((indexAtual - bordas) + 8);

            if (vizinhosAtuais.diagonalSupDir == '-')
                vizinhosFechadas.Add((indexAtual - bordas) - 8);

            if (vizinhosAtuais.diagonalSupEsq == '-')
                vizinhosFechadas.Add((indexAtual - bordas) - 10);


            return vizinhosFechadas;
        }

        public void AnalisarVizinhosFechados()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);
            // Realize sua codificação a partir deste ponto, boa sorte!

            string tabuleiro = campoMinado.Tabuleiro;
            int statusDoJogo = campoMinado.JogoStatus;

            Operacoes minhasFuncoes = new Operacoes();
            Vizinho vizinhosAtuais = new Vizinho();


            List<int> bombasMarcadas = new List<int>();

            List<int> vizinhosFechados = new List<int>();

            bool bombaEncontrada;
            int bombasVizinhas;
            int quantidadeCasasFechadas;

            int tamanho = campoMinado.Tabuleiro.Length;
            int bordas = 0;
            int index = 0;

            char posicaoAtual;
            int valorCasaAtual;


            do
            {
                bombaEncontrada = false;
                bombasVizinhas = 0;

                vizinhosAtuais = new Vizinho();
                posicaoAtual = tabuleiro[index];
                


                if (!(posicaoAtual == '\n' || posicaoAtual == '\r'))
                    vizinhosAtuais = minhasFuncoes.IdentificarVizinhos(index, posicaoAtual, tabuleiro);
                else
                    bordas++;

                if (posicaoAtual != '\n' && posicaoAtual != '\r' && posicaoAtual != '0' && posicaoAtual != '-')
                {
                    valorCasaAtual = int.Parse(posicaoAtual.ToString());
                    vizinhosFechados = minhasFuncoes.IdentificarVizinhosFechados(vizinhosAtuais, index, bordas);
                    quantidadeCasasFechadas = vizinhosFechados.Count;


                    if (quantidadeCasasFechadas == valorCasaAtual)
                    {
                        foreach (int vizinhoFechado in vizinhosFechados)
                        {
                            if (!bombasMarcadas.Contains(vizinhoFechado))
                            {
                                bombaEncontrada = true;
                                bombasMarcadas.Add(vizinhoFechado);
                            }

                        }

                        if (bombaEncontrada)
                        {
                            index = 0;
                            bordas = 0;
                        }
                        else
                        {
                            index++;
                        }

                    }
                    else if (quantidadeCasasFechadas > valorCasaAtual)
                    {
                        foreach (var bombas in bombasMarcadas)
                        {
                            if (vizinhosFechados.Contains(bombas))
                            {
                                quantidadeCasasFechadas--;
                                bombasVizinhas++;
                                vizinhosFechados.Remove(bombas);
                            }
                        }

                        if (bombasVizinhas == valorCasaAtual && quantidadeCasasFechadas > 0)
                        {
                            foreach (int vizinhoFechado in vizinhosFechados)
                            {
                                int linha = (int)(vizinhoFechado / 9) + 1;
                                int coluna = (vizinhoFechado % 9) + 1;
                                campoMinado.Abrir(linha, coluna);
                                tabuleiro = campoMinado.Tabuleiro;

                                Console.Clear();
                                Console.WriteLine($"A casa da linha {linha}, coluna {coluna} foi aberta!");
                                Console.WriteLine(tabuleiro);
                                Console.ReadKey();
                            }
                            index = 0;
                            bordas = 0;
                        }
                        else
                        {
                            index++;
                        }
                    }
                }
                else
                {
                    index++;
                }
            } while (index < tamanho && statusDoJogo == 0);

            Console.Clear();

            statusDoJogo = campoMinado.JogoStatus;
            tabuleiro = campoMinado.Tabuleiro;

            Console.WriteLine($"Status do jogo: {statusDoJogo}");
            Console.WriteLine("\n \n ");
            Console.WriteLine($"{tabuleiro}");
            Console.WriteLine("\nFim de jogo!");

            Console.ReadKey();
        }
    }
}
