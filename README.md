# Ecommerce Checkout — Gerenciador de Pedidos

Este projeto é uma solução feita em **.NET 10** estruturada pelo terminal (CLI) para gerenciar o cálculo de cupons, itens, pontos de fidelidade e frete de uma loja online. A aplicação conta com testes unitários automáticos usando o framework **xUnit**.

---

## Métodos Implementados (`PedidoService.cs`)

A classe de produção `PedidoService` encapsula as três principais regras de negócio solicitadas:

1. **`GerarCodigoRastreio(string regiao, int numeroPedido)`**
   * **Retorno:** `string`
   * **Regra:** Retorna uma string formatada que junta a região em letras maiúsculas com o número do pedido, preenchido com zeros à esquerda, usando uma máscara de 4 dígitos.
   * *Exemplo:* `"sudeste"`, `42` ➡️ `"SUDESTE-0042"`

2. **`CalcularPontosFidelidade(int valorTotal)`**
   * **Retorno:** `int`
   * **Regra:** O cliente ganha 2 pontos de fidelidade a cada R$ 10 inteiros gastos em compras.
   * *Exemplo:* `150` vira `30` pontos.

3. **`TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)`**
   * **Retorno:** `bool`
   * **Regra:** O frete é grátis se o valor total da compra for maior ou igual a R$ 200, ou se o comprador for um cliente VIP.

---

## Test Coverage (`PedidoServiceTests.cs`)

Os testes foram escritos com o framework **xUnit** usando o atributo `[Fact]`. Eles verificam separadamente tanto os fluxos de sucesso quanto as restrições das regras de negócio. As asserções usadas são estritas.

* **`GerarCodigoRastreio`**  
  * Confirme se a máscara de formatação (`regiao` em letras maiúsculas e `numeroPedido` com 4 dígitos) sai exatamente como esperado.  
  * *Afirmação usada:* `Assert.Equal("SUDESTE-0042", resultado)`

* **`CalcularPontosFidelidade`**  
  * Garante que o cálculo matemático da pontuação com base nas parcelas de R$ 10 está certo.  
  * *Assert statement used:* `Assert.Equal(30, resultado)`

* **`TemDireitoAFreteGratis_VIP_AbaixoDe200`**  
  * Verifique se o sistema dá frete grátis para um cliente VIP mesmo quando o valor da compra é menor que R$ 200.  
  * *Asserção utilizada:* `Assert.True(resultado)`

* **`TemDireitoAFreteGratis_NaoVIP_AbaixoDe200`**  
  Garante que um cliente comum, que não seja VIP, com valor de compra menor que R$ 200, não receba o benefício do frete grátis.  
  * *Asserção utilizada:* `Assert.False(resultado)`

---

##  Instruções de Execução

Siga os passos abaixo no terminal de comandos para limpar, compilar e rodar a suíte de testes do projeto.

### 1. Ir até a raiz da solução
Certifique-se de que o seu terminal está aberto na pasta principal do projeto. Essa é a pasta onde está o arquivo `EcommerceCheckout.sln`.

### 2. Limpe os arquivos temporários e os caches
Para garantir que nenhuma build antiga ou arquivos incorretos das pastas de histórico interfiram no resultado:
```bash
dotnet clean
```

### 3. Execute os Testes Unitários
Para rodar a validação automatizada e obter o relatório de sucesso no terminal, execute:
```bash
dotnet test
```

---
**Garantia da Qualidade de Software**  
*Gestão e Qualidade de Software*  
*Professor Daniel Henrique Matos de Paiva*