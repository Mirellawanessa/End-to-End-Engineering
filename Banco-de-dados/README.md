# Consultas-no-SQL
Montando Consultas Relacionais no SQL Server
JOINs no SQL Server
JOINs são usados para buscar dados de múltiplas tabelas com base em uma condição lógica.

Tipos Comuns de JOIN:
INNER JOIN (ou JOIN): Retorna apenas as linhas que têm correspondência em ambas as tabelas. É o tipo de JOIN mais utilizado.

SQL

SELECT colunas
FROM tabela1
INNER JOIN tabela2 ON tabela1.coluna_chave = tabela2.coluna_chave;
Exemplo: Listar todos os pedidos com seus respectivos clientes.

LEFT JOIN (ou LEFT OUTER JOIN): Retorna todas as linhas da tabela da esquerda (tabela1) e as linhas correspondentes da tabela da direita (tabela2). Se não houver correspondência na tabela da direita, as colunas dessa tabela virão com NULL.

SQL

SELECT colunas
FROM tabela1
LEFT JOIN tabela2 ON tabela1.coluna_chave = tabela2.coluna_chave;
Exemplo: Listar todos os clientes e os pedidos que eles fizeram (clientes sem pedidos também aparecerão).

RIGHT JOIN (ou RIGHT OUTER JOIN): Retorna todas as linhas da tabela da direita (tabela2) e as linhas correspondentes da tabela da esquerda (tabela1). Se não houver correspondência na tabela da esquerda, as colunas dessa tabela virão com NULL.

SQL

SELECT colunas
FROM tabela1
RIGHT JOIN tabela2 ON tabela1.coluna_chave = tabela2.coluna_chave;
Exemplo: Listar todos os produtos e os itens de pedido associados a eles (produtos que nunca foram pedidos também aparecerão).

FULL JOIN (ou FULL OUTER JOIN): Retorna todas as linhas de ambas as tabelas. Se não houver correspondência em uma das tabelas para uma linha da outra, as colunas da tabela sem correspondência virão com NULL.

SQL

SELECT colunas
FROM tabela1
FULL JOIN tabela2 ON tabela1.coluna_chave = tabela2.coluna_chave;
Exemplo: Listar todos os clientes e todos os produtos, mostrando quais clientes compraram quais produtos, e incluindo clientes que não compraram nada e produtos que não foram comprados.

CROSS JOIN (ou Produto Cartesiano): Retorna todas as combinações possíveis de linhas das duas tabelas. Geralmente não é o que você quer, a menos que tenha um caso de uso muito específico, pois pode gerar um volume enorme de dados.

SQL

SELECT colunas
FROM tabela1
CROSS JOIN tabela2;
Dicas Importantes:
Condição de JOIN (ON): A cláusula ON especifica como as tabelas devem ser relacionadas. Geralmente, você iguala a chave primária (PRIMARY KEY) de uma tabela com a chave estrangeira (FOREIGN KEY) da outra.
Aliases de Tabela: Usar aliases (apelidos) para os nomes das tabelas torna suas consultas mais curtas e legíveis, especialmente quando você tem muitas colunas com o mesmo nome em tabelas diferentes.
SQL

SELECT c.NomeCliente, p.NumeroPedido
FROM Clientes AS c  -- 'c' é o alias para Clientes
INNER JOIN Pedidos AS p ON c.ClienteID = p.ClienteID; -- 'p' é o alias para Pedidos
Qualificando Nomes de Colunas: Quando você junta tabelas que têm colunas com o mesmo nome (por exemplo, ID), você precisa especificar de qual tabela você quer a coluna usando o nome da tabela (ou seu alias) seguido de um ponto: tabela.coluna ou alias.coluna.
Múltiplos JOINs: Você pode juntar mais de duas tabelas em uma única consulta.
SQL

SELECT c.NomeCliente, p.NumeroPedido, i.NomeProduto
FROM Clientes AS c
INNER JOIN Pedidos AS p ON c.ClienteID = p.ClienteID
INNER JOIN ItensPedido AS ip ON p.PedidoID = ip.PedidoID
INNER JOIN Produtos AS i ON ip.ProdutoID = i.ProdutoID;
Cláusula WHERE: Você pode usar a cláusula WHERE em conjunto com os JOINs para filtrar ainda mais os resultados. A condição WHERE é aplicada depois que o JOIN é realizado.
Exemplo Prático:
Suponha que você tenha duas tabelas:

Tabela Clientes:

ClienteID (PK)	NomeCliente
1	João Silva
2	Maria Santos
3	Pedro Almeida

Exportar para as Planilhas
Tabela Pedidos:

PedidoID (PK)	ClienteID (FK)	DataPedido	ValorTotal
101	1	2024-01-15	150.00
102	2	2024-01-17	200.00
103	1	2024-02-01	75.50
104	4	2024-02-05	120.00

Exportar para as Planilhas
Consulta para listar clientes e seus pedidos (INNER JOIN):

SQL

SELECT c.NomeCliente, p.PedidoID, p.DataPedido, p.ValorTotal
FROM Clientes AS c
INNER JOIN Pedidos AS p ON c.ClienteID = p.ClienteID;
Resultado:

NomeCliente	PedidoID	DataPedido	ValorTotal
João Silva	101	2024-01-15	150.00
Maria Santos	102	2024-01-17	200.00
João Silva	103	2024-02-01	75.50

Exportar para as Planilhas
(O pedido 104 não aparece porque seu ClienteID 4 não tem correspondência na tabela Clientes)

Consulta para listar todos os clientes e seus pedidos, se houver (LEFT JOIN):

SQL

SELECT c.NomeCliente, p.PedidoID, p.DataPedido, p.ValorTotal
FROM Clientes AS c
LEFT JOIN Pedidos AS p ON c.ClienteID = p.ClienteID;
Resultado:

NomeCliente	PedidoID	DataPedido	ValorTotal
João Silva	101	2024-01-15	150.00
João Silva	103	2024-02-01	75.50
Maria Santos	102	2024-01-17	200.00
Pedro Almeida	NULL	NULL	NULL

Exportar para as Planilhas