# algoritmo-jogodaforca

Um algoritmo que analisa uma biblioteca de palavras em português do Brasil para descobrir a palavra que o usuário digitou.

O propósito de desenvolvimento deste trabalho foi criar um algoritmo que aplicasse os conceitos de inteligência artificial, como poda e domínio, de mandeira prática. 
Desenvolvi um algoritmo que efetua tentativas de descobrir qual é a palavra digitada pelo usuário, tendo um número máximo de erros (também definido pelo usuário) durante as tentativas.

Domínio

O domínio do algoritmo é o vocabulário da língua portuguesa do Brasil. Desta maneira, o algoritmo toma como base de conhecimento as palavras em língua portuguesa que conhece para tentar descobrir qual a palavra.


Informações

O algoritmo foi escrito em linguagem C# no o Visual Studio.
A classe que efetua os processos de análise (Robo.cs) contém mais de 300 linhas de código.
Foi utilizado de forma extensa conceitos de orientação a objetos com C#, assim como tipos de dados como struct, por exemplo.
A base de conhecimento é um txt de quase 30000 palavras.


Resultados observados:

Palavras -	Erros necessários para acerto
Paralelepipedo -	0
Carro	- 2
Trem	- 2
Abacate	- 2
Casa	- 6


Observação

É possível ver que o computador, com as instruções certas, consegue aplicar o conhecimento humano com uma grande eficiência, executando grandes filtros lógicos rapidamente e alcançando o objetivo. 
Também é notável que o algoritmo teve dificuldade em analisar palavras menores e comuns, pois estas palavras possuem várias palavras semelhantes no dicionário (Casa, por exemplo: cara, cada, cama, etc.), sendo necessárias mais tentativas. Uma otimização possívelseria incluir uma flag para indicar palavras mais comuns para as pessoas.
