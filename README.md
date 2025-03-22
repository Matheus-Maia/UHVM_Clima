# UHVM Clima

UHVM Clima é um simulador de coleta de dados meteorológicos, gerando registros de temperatura, pressão, umidade, altitude, direção do vento, velocidade do vento, precipitação e índice UV, e os salva em um CSV.

O projeto foi baseado no artigo "Read environmental conditions from a sensor", que demonstra como usar .NET para coletar dados ambientais com sensores. Adaptei o conceito para simular a coleta de dados sem depender de hardware específico.

https://learn.microsoft.com/en-us/dotnet/iot/tutorials/temp-sensor

## 📋 Tecnologias Utilizadas
- C# (.NET 9)
- Docker (opcional)
- GitHub

## 🔌 Como Executar o Projeto

### Pré-requisitos
- .NET SDK 9 instalado
- Docker (opcional, para executar via contêiner)
- Git

### Clone o Repositório
```bash
git clone https://github.com/Matheus-Maia/UHVM_Clima.git
cd UHVM_Clima
```

### Executando via .NET

1. restaura as dependências do projeto, baixando e instalando os pacotes NuGet necessários:
```bash
dotnet restore
```

2. Compile o projeto:
```bash
dotnet build
```

3. Execute o projeto:
```bash
dotnet run
```

## Executando via Docker

1. Baixe a imagem do Docker Hub:

```bash
docker pull matheusmaia535/uhvm_clima:latest
```

2. Construa a imagem Docker (caso necessário):

```bash
docker build -t uhvm_clima .
```

3. Crie a pasta `dados` para armazenar os arquivos gerados:

```bash
mkdir -p dados
```

4. Execute o container:

```bash
docker run --rm -v $(pwd)/dados:/app/dados uhvm_clima
```

## 📄 Dados Gerados
Cada execução gera um arquivo CSV com o seguinte formato:

| Timestamp    | UTCTime | Temperature | Pressure | Humidity | Altitude | WindDirection | WindSpeed | Rainfall | UVIndex |
|-------------|---------|-------------|----------|----------|----------|---------------|-----------|----------|---------|
| 2025-03-02  | 0000    | 25.3        | 1013.2   | 65.4     | 400      | 90.5         | 15.3      | 0.0      | 3.2     |
| 2025-03-02  | 0100    | 24.8        | 1012.8   | 66.2     | 410      | 95.0         | 14.8      | 0.0      | 2.8     |

## 🛠️ Como Funciona
- A classe `SimulatedSensor` gera valores aleatórios para temperatura, pressão, umidade, altitude, direção do vento, velocidade do vento, chuva e índice UV.
- A classe `DateTimeSimulator` gera a data aleatória para o ano 2025.
- Os dados são escritos em um arquivo CSV a cada iteração com um intervalo simulado de 1 segundo.

## 🚀 Autor
**Matheus Maia**

Email: matheusmaia535@gmail.com

## 📄 Licença
Este projeto é licenciado sob a licença MIT.

