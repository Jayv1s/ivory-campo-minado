using System;
using System.Collections.Generic;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Vizinho
    {
        public char Cima { get; set; }
        public char Baixo { get; set; }
        public char Esquerda { get; set; }
        public char Direita { get; set; }
        public char DiagonalSupEsq { get; set; }
        public char DiagonalSupDir { get; set; }
        public char DiagonalInfEsq { get; set; }
        public char DiagonalInfDir { get; set; }
        public Vizinho()
        {
            Cima = ' ';
            Baixo = ' ';

            Esquerda = ' ';
            Direita = ' ';

            DiagonalSupEsq = ' ';
            DiagonalSupDir = ' ';

            DiagonalInfEsq = ' ';
            DiagonalInfDir = ' ';
        }
    }

    class Operacoes
    {
        public Vizinho IdentificarVizinhos(int indexAtual, string tabuleiro)
        {
            Vizinho vizinho = new Vizinho();

            //se for a primeira linha
            if (indexAtual >= 0 && indexAtual <= 10)
            {
                if (indexAtual == 0)
                {
                    vizinho.Esquerda = '\n';
                }
                else
                {
                    vizinho.Esquerda = tabuleiro[indexAtual - 1];
                }
                vizinho.Cima = ' ';
                vizinho.DiagonalSupEsq = ' ';
                vizinho.DiagonalSupDir = ' ';

                vizinho.Direita = tabuleiro[indexAtual + 1];
                vizinho.Baixo = tabuleiro[indexAtual + 11];
            }
            //se for a ultima linha
            else if (indexAtual >= 87 && indexAtual <= 96)
            {
                if (indexAtual == 96)
                {
                    vizinho.Direita = '\r';
                }
                else
                {
                    vizinho.Direita = tabuleiro[indexAtual + 1];
                }
                vizinho.Baixo = ' ';
                vizinho.DiagonalInfEsq = ' ';
                vizinho.DiagonalInfDir = ' ';

                vizinho.Esquerda = tabuleiro[indexAtual - 1];
                vizinho.Cima = tabuleiro[indexAtual - 11];
            }
            else
            {
                vizinho.Cima = tabuleiro[indexAtual - 11];
                vizinho.Baixo = tabuleiro[indexAtual + 11];

                vizinho.Direita = tabuleiro[indexAtual + 1];
                vizinho.Esquerda = tabuleiro[indexAtual - 1];
            }

            // se tiver borda no lado esquerdo
            if (vizinho.Esquerda == '\n') 
            {
                vizinho.DiagonalSupEsq = '\n';
                vizinho.DiagonalInfEsq = '\n';

                // se tiver borda no lado esquerdo e em baixo
                if (vizinho.Baixo == ' ') 
                {
                    vizinho.DiagonalSupDir = tabuleiro[indexAtual - 10];
                    vizinho.DiagonalInfDir = ' ';
                }
                // se tiver borda no lado esquerdo e em cima
                else if (vizinho.Cima == ' ')
                {
                    vizinho.DiagonalInfDir = tabuleiro[indexAtual + 12];
                    vizinho.DiagonalSupDir = ' ';
                }
                else
                {
                    vizinho.DiagonalSupDir = tabuleiro[indexAtual - 10];
                    vizinho.DiagonalInfDir = tabuleiro[indexAtual + 12];
                }
            }
            // se tiver borda no lado direito
            else if (vizinho.Direita == '\r')
            {
                vizinho.DiagonalSupDir = '\r';
                vizinho.DiagonalInfDir = '\r';

                // se tiver borda no lado direito e em baixo
                if (vizinho.Baixo == ' ') 
                {
                    vizinho.DiagonalSupEsq = tabuleiro[indexAtual - 12];
                    vizinho.DiagonalInfEsq = ' ';
                }
                // se tiver borda no lado direito e em cima
                else if (vizinho.Cima == ' ') 
                {
                    vizinho.DiagonalInfEsq = tabuleiro[indexAtual + 10];
                    vizinho.DiagonalSupEsq = ' ';
                }
                else
                {
                    vizinho.DiagonalInfEsq = tabuleiro[indexAtual + 10];
                    vizinho.DiagonalSupEsq = tabuleiro[indexAtual - 12];
                }
            }
            else
            {
                // se tiver borda em baixo
                if (vizinho.Baixo == ' ') 
                {
                    vizinho.DiagonalSupEsq = tabuleiro[indexAtual - 12];
                    vizinho.DiagonalSupDir = tabuleiro[indexAtual - 10];

                    vizinho.DiagonalInfEsq = ' ';
                    vizinho.DiagonalInfDir = ' ';
                }
                // se tiver borda em cima
                else if (vizinho.Cima == ' ') 
                {
                    vizinho.DiagonalInfDir = tabuleiro[indexAtual + 12];
                    vizinho.DiagonalInfEsq = tabuleiro[indexAtual + 10];

                    vizinho.DiagonalSupEsq = ' ';
                    vizinho.DiagonalSupDir = ' ';
                }
                else
                {
                    vizinho.DiagonalInfDir = tabuleiro[indexAtual + 12];
                    vizinho.DiagonalInfEsq = tabuleiro[indexAtual + 10];

                    vizinho.DiagonalSupDir = tabuleiro[indexAtual - 10];
                    vizinho.DiagonalSupEsq = tabuleiro[indexAtual - 12];
                }
            }

            return vizinho;
        }
        public List<int> IdentificarVizinhosFechados(Vizinho vizinhosAtuais, int indexAtual, int bordas)
        {
            List<int> vizinhosFechadas = new List<int>();

            if (vizinhosAtuais.Cima == '-')
            {
                vizinhosFechadas.Add((indexAtual - bordas) - 9);
            }
            if (vizinhosAtuais.Baixo == '-')
            {
                vizinhosFechadas.Add((indexAtual - bordas) + 9);
            }
            if (vizinhosAtuais.Esquerda == '-')
            {
                vizinhosFechadas.Add((indexAtual - bordas) - 1);
            }
            if (vizinhosAtuais.Direita == '-')
            {
                vizinhosFechadas.Add((indexAtual - bordas) + 1);
            }
            if (vizinhosAtuais.DiagonalInfDir == '-')
            {
                vizinhosFechadas.Add((indexAtual - bordas) + 10);
            }
            if (vizinhosAtuais.DiagonalInfEsq == '-')
            {
                vizinhosFechadas.Add((indexAtual - bordas) + 8);
            }
            if (vizinhosAtuais.DiagonalSupDir == '-')
            {
                vizinhosFechadas.Add((indexAtual - bordas) - 8);
            }
            if (vizinhosAtuais.DiagonalSupEsq == '-')
            {
                vizinhosFechadas.Add((indexAtual - bordas) - 10);
            }

            return vizinhosFechadas;
        }
        public bool MarcaBomba(List<int> vizinhosFechados, List<int> listaDeBombas)
        {
            bool novaBombaEncontrada = false;

            foreach (var vizinhoFechado in vizinhosFechados)
            {
                if (!listaDeBombas.Contains(vizinhoFechado))
                {
                    novaBombaEncontrada = true;
                    listaDeBombas.Add(vizinhoFechado);
                }

            }

            return novaBombaEncontrada;
        }
        public bool AvaliaAbrirVizinhos(List<int> bombasMarcadas, List<int> vizinhosFechados, int quantidadeCasasFechadas, int valorCasaAtual)
        {
            int bombasVizinhas = 0;

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
                return true;
            }
            else
            {
                return false;
            }
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
            List<int> bombasMarcadas = new List<int>();
            List<int> vizinhosFechados;

            Operacoes minhasOperacoes = new Operacoes();
            Vizinho vizinhosAtuais;

            string tabuleiro = campoMinado.Tabuleiro;
            int statusDoJogo = campoMinado.JogoStatus;

            int tamanho = tabuleiro.Length;

            bool novaBombaEncontrada;
            bool podeAbrirVizinhos;
            int quantidadeCasasFechadas;

            int bordas = 0;
            int index = 0;

            int linha;
            int coluna;

            char posicaoAtual;
            int valorCasaAtual;

            Console.ReadKey();
            do
            {
                posicaoAtual = tabuleiro[index];
                // Analisa se a posição atual é borda, casa fechada ou número maior do que 0;
                if (posicaoAtual == '\n' || posicaoAtual == '\r')
                {
                    bordas++;
                    index++;
                }
                else if (posicaoAtual == '0' || posicaoAtual == '-')
                {
                    index++;
                }
                else
                {
                    valorCasaAtual = int.Parse(posicaoAtual.ToString());
                    vizinhosAtuais = minhasOperacoes.IdentificarVizinhos(index, tabuleiro);
                    vizinhosFechados = minhasOperacoes.IdentificarVizinhosFechados(vizinhosAtuais, index, bordas);
                    quantidadeCasasFechadas = vizinhosFechados.Count;

                    if (quantidadeCasasFechadas == valorCasaAtual)
                    {
                        novaBombaEncontrada = minhasOperacoes.MarcaBomba(vizinhosFechados, bombasMarcadas);
                        if (novaBombaEncontrada)
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
                        podeAbrirVizinhos = minhasOperacoes.AvaliaAbrirVizinhos(bombasMarcadas, vizinhosFechados, quantidadeCasasFechadas, valorCasaAtual);

                        if (podeAbrirVizinhos)
                        {
                            foreach (var vizinhoFechado in vizinhosFechados)
                            {
                                linha = (int)(vizinhoFechado / 9) + 1;
                                coluna = (vizinhoFechado % 9) + 1;

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
