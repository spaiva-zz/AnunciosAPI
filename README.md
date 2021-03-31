# AnunciosAPI

Para executar a API, deve-se seguir os seguites passos:

1. Baixar o repositório para a máquina onde será executado a API;
2. Alterar o arquivo **appsettings.json** dentro da pasta **Anuncios.Service.API**, alterando a string de conexão, a chave server, colocando o IP da máquina onde está rodando o container (Docker);
3. Executar as requisições na API baseando-se na coloção de testes realizados no Postman que está neste repositório

**Obs¹.:** Para autenticação e segurança, a API utiliza a autenticação Bearer. Para se autenticar, basta realizar o login utilizando o e-mail: admin@email.com.br e senha admin@123.
Será retornado da API um token, o qual deverá ser passado no header das requisições realizadas na API.

**Obs².:** O retorno da imagem do anúncio está formatada na Base64.
