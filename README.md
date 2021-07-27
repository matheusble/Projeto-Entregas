# Projeto-Entregas

Leilão de Entregas
Uma startup quer revolucionar o mercado de entregas em sua cidade. Ela desenvolveu uma estratégia de negócios onde os clientes podem pagar um bônus para que a entrega seja priorizada em detrimento às demais. Assim, o objetivo da empresa é que, dentre uma lista de entregas a fazer, ela vai escolher aquelas que vão lhe gerar o maior lucro. Você e sua equipe foram contratados para resolver esse problema de forma eficiente
A solução de software deve atuar sobre duas entradas:4
Uma lista de conexões entre destinos e o tempo em minutos para chegar até elas. Por exemplo:
(A,B,5);(B,C,3);(A,D,2);(C,D,8)


Uma lista de entregas com o horário obrigatório para saída, o destino, e o valor do bônus para fazê-la. Por exemplo: 
Lista de entregas no dia: (0, B, 1); (5,C;10); (10,D,8)
Neste caso a entrega para B vai chegar no tempo 0, a entrega para C no tempo 5, e a entrega para D no tempo 10. 
O bônus para entregar em B é 1; para entregar em C é 10, e para entregar em D é 8.

Neste caso, se a primeira entrega for realizada, o tempo para sair do ponto A e chegar em B deve ser considerado no tempo consumido, ou seja, a tarefa começa em 0 e termina em 10 (tempo do retorno). 
Portanto, a entrega em C já não pode ser mais realizada pois seu tempo de início foi perdido. Sendo possível realizar a entrega para D na sequência, com lucro total de 9. Já se a escolha for para esperar a entrega em C, as entregas em B e D não poderão ser realizadas, contudo, o lucro será de 10. Que é maior. 

Pede-se:
Desenvolva um programa em linguagem de programação à sua escolha que seja capaz de:
Carregar de um arquivo a lista de destinos e suas conexões; (A1)
Carregar a lista de entregas conforme modelo; (A1)
Exibir a sequência de entregas a ser realizada no dia e o lucro que será obtido com elas; (A1 e A2)
Na A1 espera-se uma solução qualquer, não necessariamente calculando os menores caminhos do grafo. 
Na A2 espera-se um algoritmo eficiente que apresente a melhor solução para o problema.
Faça a análise da complexidade de execução e de espaço da solução desenvolvida. (A2)


Exemplo de arquivo de entrada:
4
	‘A’,’B’,’C’,’D’
	0,5,0,2
	5,0,3,0
	0,3,0,8
	2,0,8,0

	3
	0,B,1
	5,C,10
	10,D,8


Disciplina de Inteligência Artificial (IA)
Desenvolver uma versão do Leilão de Entregas utilizando algoritmos de Inteligência Artificial. (A2)
Apresentar resultados comparativos entre a solução utilizada para a disciplina de Análise de Algoritmos com a solução utilizada para a disciplina de Inteligência Artificial.
Apresentar análise comparativa de desempenho, por exemplo: gráficos com iteração do tipo Solução A versus Solução B.


Disciplina de Projeto Interdisciplinar (PI)
Desenvolvimento de um Projeto em Equipe (Ágile em até 4 integrantes) 
Visão de Produto
Apresentação do Problema (Leilão de Entregas);
Especificação da Solução do Problema;
Implementação da Solução;
Apresentação da Solução;
Visão de Projeto
Organização da Equipe
Planejamento e Execução do Projeto (Scrum)

Disciplina de Engenharia de Software
Desenvolvimento do Projeto utilizando metodologia ágil (quebrar o projeto em pequenas entregas de valor)
Descoberta de produto (como montar a visão do produto utilizando técnicas descoberta para isso)
Criar um Trello com as etapas do fluxo de desenvolvimento  e com as atividades quebradas o trello precisa ter a etapa de descoberta do produto até a entrega
Os épicos do projeto devem ter o detalhamento do negócio e as histórias devem ser escritas com instruções de como será feito
Utilização de testes ágeis
Apresentação final do MVP, detalhando método utilizado 

