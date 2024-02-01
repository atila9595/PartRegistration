FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia o arquivo de projeto e restaura as dependências
COPY ["ApiRegistro.csproj", "."]
RUN dotnet restore 

# Copia o restante do código do projeto
COPY . .

# Compila o projeto
RUN dotnet build -c Release -o /app/build

FROM build AS publish
# Publica o projeto
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia os arquivos publicados do estágio de publicação
COPY --from=publish /app/publish .

# Define o comando de entrada
ENTRYPOINT ["dotnet", "ApiRegistro.dll"]
