﻿using System;
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
        private static int[,] matriz; 
        private List<string> headerMatriz = new List<string>();
        public Leilao()
        {
            InitializeComponent();

        }

        private void btnCarregarArquivo_Click(object sender, EventArgs e)
        {
            IsUploaded = false;                                                                                               //1
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);                                    //1
            string extensao = string.Empty;                                                                                   //1
            string caminho = String.Empty;                                                                                    //1
            IsUploaded = false;                                                                                               //1

            OpenFileDialog x = new OpenFileDialog();                                                                          //1
            x.DefaultExt = "Arquivos Csv | *.csv";                                                                            //1
            x.Filter = "Arquivos Csv|*.csv|Tipo Texto|*.txt";                                                                 //1
            x.InitialDirectory = desktop;                                                                                     //1

            if (x.ShowDialog() == DialogResult.OK)                                                                            //1
            {
                caminho = x.FileName;                                                                                         //1
                txtCaminho.Text = caminho;                                                                                    //1
                extensao = x.FileName.Substring(x.FileName.LastIndexOf('.'));                                                 //1
                IsUploaded = true;                                                                                            //1
            }

            if (IsUploaded)                                                                                                   //1
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
            lstBCaminho.Visible = false;                                                                                        //1
            lstBTempo.Visible = false;                                                                                          //1
            lblTempo.Visible = false;                                                                                           //1
            lblTrajetos.Visible = false;                                                                                        //1
            lstBTrajeto.Items.Clear();                                                                                          //1
            lstBTempo.Items.Clear();                                                                                            //1
            lstBCaminho.Items.Clear();                                                                                            //1
            lstBEntregas.Items.Clear();                                                                                            //1
            arvore.Clear();                                                                                                        //1
            lstEntregas.Clear();                                                                                                    //1
            HeaderVertices = null;                                                                                                   //1

            if (IsUploaded)                                                                                                                   //1
            {
                if (!String.IsNullOrEmpty(extensao))                                                                                          //1
                {
                    List<string> linhas = new List<string>();                                                                                 //1
                    int vertices = 0;                                                                                                        //1
                    int entregas = 0;                                                                                                         //1
                    if (extensao == ".txt" || extensao == ".csv")                                                                             //1
                    {
                        if (File.Exists(caminho))                                                                                            //1
                        {
                            try
                            {
                                using (StreamReader r = new StreamReader(caminho, extensao == ".txt" ? Encoding.UTF8 : Encoding.Default))   //1
                                {
                                    string linha;                                                                                            //1

                                    while ((linha = r.ReadLine()) != null)                                                                   //n + 1
                                    {
                                        if (linha.Trim() != string.Empty)                                                                            //1                                 
                                            linhas.Add(linha.ToUpper().Trim());                                                                            //1   
                                    }
                                }

                                if (linhas[0] != null)
                                {
                                    if (linhas[0].Contains(','))
                                    {
                                        linhas[0] = linhas[0].Remove(linhas[0].IndexOf(','), linhas[0].Length - linhas[0].IndexOf(',')) ;
                                    }

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
                                        matriz = new int[vertices,vertices];
                                        imprimeMatriz(matriz, lblmatriz,vertices,vertices);

                                        if (linhas.Count > vertices + 2)
                                        {
                                            #region Header

                                            if (linhas[1].Contains(','))
                                            {
                                                HeaderVertices = linhas[1].Replace("‘", "").Replace("’", "").Replace("'", "").Split(',');
                                                foreach (string nomeVertice in HeaderVertices)
                                                {
                                                    headerMatriz.Add(nomeVertice);
                                                }
                                                if (HeaderVertices.Length == vertices)
                                                {
                                                    Regex Header = new Regex(@"^[A-ZÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÃÕÇ]+$");
                                                    for (int HeaderIndex = 0; HeaderIndex < HeaderVertices.Length; HeaderIndex++)
                                                    {
                                                        if (HeaderVertices[HeaderIndex].Contains(';'))
                                                        {
                                                            HeaderVertices[HeaderIndex] = HeaderVertices[HeaderIndex].Replace(";", "");
                                                            headerMatriz[HeaderIndex] = HeaderVertices[HeaderIndex].Replace(";", "");
                                                        }
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
                                                    string[] tempoPercurso = linhas[linhaMapa].Split(',');
                                                    if (tempoPercurso.Length == vertices)
                                                    {
                                                        //Matrix
                                                        for (int j = 0; j < vertices; j++)
                                                        {
                                                            if (tempoPercurso[j].Contains(';'))
                                                                tempoPercurso[j] = tempoPercurso[j].Replace(";", "");

                                                            if (int.TryParse(tempoPercurso[j], out minutos))
                                                            {
                                                                if (linhaMapa + 2 <= vertices + 3)
                                                                    matriz[linhaMapa - 2, j] = minutos;
                                                            }
                                                        }
                                                    
                                                        //List
                                                        for (int j = linhaMapa - 2; j < vertices; j++)
                                                        {

                                                            if (tempoPercurso[j].Contains(';'))
                                                                tempoPercurso[j] = tempoPercurso[j].Replace(";", "");

                                                            if (int.TryParse(tempoPercurso[j], out minutos))
                                                            {
                                                                if (linhaMapa == 2 && minutos > 0)
                                                                {
                                                                    arvore.Add(new Mapa(HeaderVertices[linhaMapa - 2], HeaderVertices[j], minutos));
                                                                    
                                                                }
                                                                else
                                                                {
                                                                    if (j > 0 && minutos > 0)
                                                                    {
                                                                        arvore.Add(new Mapa(HeaderVertices[linhaMapa - 2], HeaderVertices[j], minutos));
                                                                       
                                                                    }
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
                                            for (int i = 0; i < vertices-1; i++) {
                                                matriz[i+1, 0] = matriz[0, i+1];
                                                    }
                                            imprimeMatriz(matriz, lblmatriz, vertices, vertices );
                                            MessageBox.Show("");

                                            
                                                   
                                            #endregion Mapa

                                            #region Entregas

                                            if (linhas[vertices + 2].Contains(','))
                                                linhas[vertices + 2] = linhas[vertices + 2].Remove(linhas[vertices + 2].IndexOf(','), linhas[vertices + 2].Length - linhas[vertices + 2].IndexOf(','));
                                           
                                            if (linhas[vertices + 2].Contains(';'))
                                                linhas[vertices + 2] = linhas[vertices + 2].Replace(";", "");

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

                                                            if (entrega[2].Contains(';') || entrega[2].Contains(','))
                                                                entrega[2] = entrega[2].Replace(",", "").Replace(";", "");

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
                                                            {
                                                                int indiceHeader = 0;
                                                                for(int a = 0; a<headerMatriz.Count; a++) 
                                                                {
                                                                    if(headerMatriz[a] == entrega[1]) 
                                                                    {
                                                                        indiceHeader = a;
                                                                    }
                                                                }
                                                                lstEntregas.Add(new Entregas(tempo, entrega[1], indiceHeader, bonus));
                                                            }
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
                            Dijkstra xy = new Dijkstra();
                            xy.dijkstra(matriz, 0, headerMatriz);


                        }
                    }
                }

            }
        }


        private void imprimeMatriz(int[,] m, Label lblMetodo, int colunas, int linhas)
        {
            lblMetodo.Text = "";
            for (int i = 0; i <= m.GetUpperBound(0); i++)//percoro as linhas todas
            {
                for (int j = 0; j <= m.GetUpperBound(1); j++) // percoro as clunas todas
                {
                    lblMetodo.Text += (j == 0 ? "" : " ") + m[i, j]; //adiciona um espaço antes de todas as colunas excepto a primeira, mas ao usares o espaço como separador, vai ficar esquisito caso uns números tenham mais dígitos do que outros
                }
                lblMetodo.Text += "\n"; //muda de linha no fim de cada linha
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
                //usar dikstra
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

                foreach (Entregas ent in lstEntregas)
                {
                    if (ent.Destino == x.Destino)
                        x.TempoTotal = path.tempoGasto * 2;
                }

            }
        
        CalcularMelhoresCaminhos();
        CalcularMelhoresCaminhosWIS();
        btnCalcular.Enabled = false;
    }

    public void CalcularMelhoresCaminhos()
    {
        List<EntregasPossiveis> entrega = new List<EntregasPossiveis>();
        int tempoTotal = 0;
        for (int z = 0; z < lstEntregas.Count; z++)
        {
            entrega.Add(new EntregasPossiveis((lstEntregas[z].Caminho), lstEntregas[z].Bonus));
        }

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
                    if (nova.Caminhos.ToString().Contains(lstEntregas[j].Caminho))
                        continue;
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


        private void CalcularMelhoresCaminhosWIS()
        {
            List<EntregasWIP> entrega = new List<EntregasWIP>();
            entrega.Add(new EntregasWIP("inicio", 0, 0, 0));
            for (int z = 0; z < lstEntregas.Count; z++)
                entrega.Add(new EntregasWIP((lstEntregas[z].Caminho), lstEntregas[z].HorarioSaida, lstEntregas[z].TempoTotal + lstEntregas[z].HorarioSaida, lstEntregas[z].Bonus));

            //orderby == quicksort == O(n log n)
            //var y = entrega.OrderBy(x => x.horarioTermino);
            
            List<EntregasWIP> entregasO = entrega.OrderBy(x => x.horarioTermino).ToList();


            for (int x = entregasO.Count -1; x > 0; x--)
            {
                for (int j = x - 1; j >= 0; j--)
                {
                    if (entregasO[x].horarioSaida >= entregasO[j].horarioTermino)
                    {
                        entregasO[x].predecessora = j;
                        break;
                    }
                }
            }
            int index = 0;
            int valor = 0;
            for (int w = 1; w <= entregasO.Count - 1; w++)
            {
                entregasO[w].BonusTotal = entregasO[w].custo + entregasO[entregasO[w].predecessora].BonusTotal >= entregasO[w - 1].BonusTotal ? entregasO[w].custo + entregasO[entregasO[w].predecessora].BonusTotal : entregasO[w - 1].BonusTotal;
                if (valor <= entregasO[w].BonusTotal)
                {
                    valor = entregasO[w].BonusTotal;
                    index = w;
                }
            }
                int raiz = index;
                Console.WriteLine("\n");
                Console.WriteLine("Melhor(es) Entrega(s): ");
                List<string> melhoresCaminhos = new List<string>();
                while (raiz != 0)
                {
                    melhoresCaminhos.Add(entregasO[raiz].caminho);
                    raiz = entregasO[raiz].predecessora;
                }

                for(int melhores = melhoresCaminhos.Count-1; melhores >= 0; melhores -- )
                    Console.WriteLine(melhoresCaminhos[melhores]);

            }
        
    }
}