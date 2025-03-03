# UHVM Clima

Este projeto simula a coleta de dados meteorológicos para cidades utilizando sensores virtuais. Ele gera dados aleatórios para diversas variáveis climáticas e os grava em um arquivo CSV.

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

1. Compile o projeto:
```bash
dotnet build
```

2. Execute o projeto:
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
- A classe `DateTimeSimulator` gera datas aleatórias entre 2023 e a data atual.
- Os dados são escritos em um arquivo CSV a cada iteração com um intervalo simulado de 1 segundo.

## 🚀 Autor
**Matheus Maia**

Email: matheusmaia535@gmail.com

## 📄 Licença
Este projeto é licenciado sob a licença MIT.

