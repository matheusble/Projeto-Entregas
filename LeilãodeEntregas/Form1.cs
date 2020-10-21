using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeilãodeEntregas
{
    public partial class Leilao : Form
    {
        bool IsUploaded = false;
        private static List<Mapa> arvore = new List<Mapa>();
        private static string[] HeaderVertices;
        private static List<Entregas> lstEntregas = new List<Entregas>();
        public Leilao()
        {
            InitializeComponent();

        }

        private void btnCarregarArquivo_Click(object sender, EventArgs e)
        {
            IsUploaded = false;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string extensao = string.Empty;
            string caminho = String.Empty;
            IsUploaded = false;

            OpenFileDialog x = new OpenFileDialog();
            x.DefaultExt = "Arquivos Csv | *.csv";
            x.Filter = "Arquivos Csv|*.csv|Tipo Texto|*.txt";
            x.InitialDirectory = desktop;

            if (x.ShowDialog() == DialogResult.OK)
            {
                caminho = x.FileName;
                txtCaminho.Text = caminho;
                extensao = x.FileName.Substring(x.FileName.LastIndexOf('.'));
                IsUploaded = true;
            }

            if (IsUploaded)
            {
                CarregarConteudo(caminho, extensao);

                foreach (Mapa node in arvore)
                    lstBTrajeto.Items.Add(node.Origem + "->" + node.Destino + " leva " + node.Tempo + " minutos");

                foreach (Entregas ent in lstEntregas)
                    lstBEntregas.Items.Add(HeaderVertices[0] + "->" + ent.Estado + " Saindo as " + ent.HorarioSaida + " Bonus: " + ent.Bonus);

            }
        }


        public void CarregarConteudo(string caminho, string extensao)
        {
            lstBCaminho.Visible = false;
            lstBTempo.Visible = false;
            lstBTrajeto.Items.Clear();
            lstBTempo.Items.Clear();
            lstBCaminho.Items.Clear();
            lstBEntregas.Items.Clear();
            arvore.Clear();
            lstEntregas.Clear();
            HeaderVertices = null;

            if (IsUploaded)
            {
                if (!String.IsNullOrEmpty(extensao))
                {
                    List<string> linhas = new List<string>();
                    int vertices = 0;
                    int entregas = 0;
                    if (extensao == ".txt" || extensao == ".csv")
                    {
                        if (File.Exists(caminho))
                        {
                            try
                            {
                                using (StreamReader r = new StreamReader(caminho, extensao == ".txt" ? Encoding.UTF8 : Encoding.Default))
                                {
                                    string linha;

                                    while ((linha = r.ReadLine()) != null)
                                    {
                                        linhas.Add(linha.ToUpper().Trim());
                                    }
                                }

                                if (linhas[0] != null)
                                {
                                    if (!int.TryParse(linhas[0], out vertices))
                                    {
                                        MessageBox.Show("A matriz deve ser numérica", "Erro linha 1");
                                        return;
                                    }
                                    else if (vertices < 2)
                                    {
                                        MessageBox.Show("Número insuficiente de vertices para a efetuação da entrega", "Erro linha 1");
                                    }
                                    else
                                    {
                                        if (linhas.Count > vertices + 2)
                                        {
                                            #region Header

                                            if (linhas[1].Contains(','))
                                            {
                                                HeaderVertices = linhas[1].Replace("‘", "").Replace("’", "").Replace("'", "").Split(',');
                                                if (HeaderVertices.Length == vertices)
                                                {
                                                    Regex Header = new Regex(@"^[A-ZÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÃÕÇ]+$");
                                                    for (int HeaderIndex = 0; HeaderIndex < HeaderVertices.Length; HeaderIndex++)
                                                    {
                                                        if (!Header.IsMatch(HeaderVertices[HeaderIndex]))
                                                        {
                                                            MessageBox.Show("Nome do vertice imcompatível! Nome do vertice deve ser escrito entre aspas simples e deve conter apenas letras", "Erro vertice " + HeaderIndex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            return;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Numero de vertices não condiz com o numero cadastrado na linha 1", "Erro linha 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                            }
                                            #endregion Header

                                            #region Mapa
                                            int minutos = 0;
                                            for (int linhaMapa = 2; linhaMapa < vertices + 2; linhaMapa++)
                                            {
                                                if (linhas[linhaMapa].Contains(','))
                                                {
                                                    string[] custo = linhas[linhaMapa].Split(',');
                                                    if (custo.Length == vertices)
                                                    {
                                                        //for(int j = 0; j < vertices; j++)   Willian 18/10 config para não pegar a volta
                                                        for (int j = linhaMapa - 2; j < vertices; j++)
                                                        {
                                                            if (int.TryParse(custo[j], out minutos))
                                                            {
                                                                if (linhaMapa == 2 && minutos > 0)
                                                                    arvore.Add(new Mapa(HeaderVertices[linhaMapa - 2], HeaderVertices[j], minutos));
                                                                else
                                                                {
                                                                    if (j > 0 && minutos > 0)
                                                                        arvore.Add(new Mapa(HeaderVertices[linhaMapa - 2], HeaderVertices[j], minutos));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Os valores do mapa devem ser numericos!", "Erro linha " + linhaMapa + 1);
                                                                return;
                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Mapa não condiz com o número de vertices!", "Erro no mapa.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return;
                                                    }

                                                }
                                                else
                                                {
                                                    MessageBox.Show("Linha " + linhaMapa + 1 + " em formato incorreto!", "Erro no mapa.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                            }

                                            #endregion Mapa

                                            #region Entregas

                                            if (!int.TryParse(linhas[vertices + 2], out entregas))
                                            {
                                                MessageBox.Show("Campo de entregas incorreto! Deve ser numérico!", "Erro linha " + (vertices + 3), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                            else if (entregas < 1)
                                            {
                                                MessageBox.Show("Quantidade de entregas inválida!", "Erro linha " + vertices + 3);
                                                return;
                                            }
                                            else
                                            {
                                                if (!(entregas == (linhas.Count - (vertices + 3))))
                                                {
                                                    MessageBox.Show("Numero de entregas não condiz com o número de entregas cadastrado.", "Erro linha " + (vertices + 3) + "+", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                                else
                                                {
                                                    for (int z = vertices + 3; z < linhas.Count; z++)
                                                    {
                                                        string[] entrega = new string[3];
                                                        int bonus = 0;
                                                        int tempo = 0;
                                                        bool validarVertice = false;
                                                        if (linhas[z].Contains(','))
                                                        {
                                                            entrega = linhas[z].Split(',');
                                                            if (entrega.Length > 3)
                                                            {
                                                                MessageBox.Show("Formato de entrega incorreto!", "Erro linha " + z);
                                                                return;
                                                            }
                                                            if (!int.TryParse(entrega[0], out tempo) || !int.TryParse(entrega[2], out bonus))
                                                            {
                                                                MessageBox.Show("O formato de bonus e tempo da entrega deve ser inteiro", "Erro linha " + z);
                                                                return;
                                                            }
                                                            else if (tempo < 0 || bonus < 0)
                                                            {
                                                                MessageBox.Show("O formato de bonus e tempo da entrega deve ser inteiro", "Erro linha " + z);
                                                                return;
                                                            }

                                                            foreach (string header in HeaderVertices)
                                                            {
                                                                if (entrega[1] == header)
                                                                    validarVertice = true;
                                                            }
                                                            if (validarVertice)
                                                                lstEntregas.Add(new Entregas(tempo, entrega[1], bonus));
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Entrega em uma formato incorreto!", "Erro linha " + z, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            return;
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion Entregas
                                        }
                                        else
                                        {
                                            MessageBox.Show("Linhas insuficientes para o cadastro do mapa", "Erro linha 2-" + (vertices + 2), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                    }
                                }
                                btnCalcular.Enabled = true;
                            }
                            catch (IOException x)
                            {
                                if (x.Message.Contains("sendo usado"))
                                {
                                    MessageBox.Show("Para que se possa fazer a leitura do arquivo, ele não pode estar em execução! Feche o arquivo!", "Arquivo em uso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Erro: " + x.Message, "Erro inesperado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                }

            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            lblTempo.Visible = true;
            lblTrajetos.Visible = true;
            lstBCaminho.Visible = true;
            lstBTempo.Visible = true;
            Graph grafo = new Graph();
            foreach (string x in HeaderVertices)
                grafo.addVertice(x);

            foreach (Mapa v in arvore)
                grafo.addVizinho(v.Origem, v.Destino, v.Tempo);

            foreach (Entregas x in lstEntregas)
            {
                x.Destino = BFS.Buscar(grafo.vertex[0], x.Estado);
            }
            int entrega = 1;
            foreach (Entregas x in lstEntregas)
            {
                string y = String.Empty;
                Queue<Vertex> q = new Queue<Vertex>();
                List<Caminho> paths = new List<Caminho>();
                string caminho = string.Empty;

                q.Enqueue(x.Destino);
                Caminho path = new Caminho();
                while (q.Count > 0)
                {
                    Vertex nd = q.Dequeue();
                    path.path.Add(nd.Estado);
                    path.tempoGasto += nd.Tempo;
                    if (nd.Nivel > 0)
                        q.Enqueue(nd.Pais[0]);
                }

                for (int z = path.path.Count - 1; z >= 0; z--)
                {
                    if(z == 0)
                        caminho += path.path[z];
                    else
                        caminho += path.path[z] + "=>";
                }
                lstBCaminho.Items.Add(caminho);
                lstBTempo.Items.Add("Entrega " + entrega + " - Tempo: " + path.tempoGasto*2);
                entrega++;
            }
        
        CalcularMelhoresCaminhos();
    }

    public void CalcularMelhoresCaminhos()
    {
        //lista com as entregas possiveis baseadas no calculo de hora de saida do ponto A(raiz)
        List<EntregasPossiveis> entrega = new List<EntregasPossiveis>();

        int tempoTotal = 0;
        //Primeiro for adiciona todos os caminhos sem soma de caminhos
        for (int z = 0; z < lstEntregas.Count; z++)
        {
            entrega.Add(new EntregasPossiveis((lstEntregas[z].Caminho), lstEntregas[z].Bonus));
        }

        //Segundo for tenta achar os caminhos que podem ser somados aos caminhos iniciais
        for (int i = 0; i < lstEntregas.Count; i++)
        {
            EntregasPossiveis x = new EntregasPossiveis();
            x.Caminhos.Append(lstEntregas[i].Caminho + "    ");
            x.Lucro += lstEntregas[i].Bonus;
            tempoTotal += lstEntregas[i].HorarioSaida + lstEntregas[i].TempoTotal;

            for (int j = 0; j < lstEntregas.Count; j++)
            {
                foreach (EntregasPossiveis nova in entrega)
                {
                    //Se o caminho já tiver sido adicionado segue para a proxima interação
                    if (nova.Caminhos.ToString().Contains(lstEntregas[j].Caminho))
                        continue;
                    //Se o tempo total dos caminhos anteriores, levando em conta o horario de saída + o tempo total de viagem for MENOR que o Horário de saída do próximo caminho ele adiciona
                    else if (tempoTotal <= lstEntregas[j].HorarioSaida)
                    {
                        x.Caminhos.Append(lstEntregas[j].Caminho + "    ");
                        x.Lucro += lstEntregas[j].Bonus;
                        tempoTotal += lstEntregas[j].HorarioSaida + lstEntregas[j].TempoTotal;
                        j = 0;
                    }
                }
            }
            entrega.Add(x);
            tempoTotal = 0;
        }

        int melhorLucro = entrega.Max(x => x.Lucro);
        EntregasPossiveis ent = entrega.Find(x => x.Lucro == melhorLucro);

        MessageBox.Show("O melhor lucro possível é seguindo o caminho: \n" + ent.Caminhos, "Lucro Total = " + ent.Lucro, MessageBoxButtons.OK, MessageBoxIcon.Information);

    }

}
}
