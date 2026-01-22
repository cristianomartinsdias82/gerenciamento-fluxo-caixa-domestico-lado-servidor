Solução para gerenciamento de fluxo de caixa doméstico - Back-end

# Requisitos para execução da aplicação
Ter os seguintes programas instalados na máquina:<br/>
- Git<br/>
- Docker<br/>
- SDK do Dotnet Core 10<br/>
- Estar com as portas 27020 e 5295 disponíveis para o banco de dados e servidor http, respectivamente<br/>

# Execução de programas
Inicie o Docker caso já não esteja executando<br/>

# Preparação para execução da aplicação
Após ter os programas mencionados acima instalados:<br/>
- Abra um prompt de comando ou Powershell

- Baixe este repositório em algum diretório de sua preferência através do seguinte comando:<br/>
X:\caminho\para\projeto>git clone https://github.com/cristianomartinsdias82/gerenciamento-fluxo-caixa-domestico-lado-servidor.git [ENTER]<br/>

- Em seguida, navegue até a seguinte pasta através do seguinte comando:<br/>
cd X:\caminho\para\projeto\src\hosts\HouseholdCashflowManagerApi [ENTER]<br/>

- No diretório, digite os seguintes comandos:<br/>
dotnet secrets init [ENTER]<br/>
dotnet user-secrets set "DatabaseSettings:ConnectionString" "mongodb://localhost:27020/" [ENTER]<br />
dotnet user-secrets set "DatabaseSettings:DatabaseName" "HouseholdCashFlowManagementDb" [ENTER]<br />
dotnet user-secrets set "SecuritySettings:Cors:Policies:Default:AllowedOrigins" "http://localhost:5173" [ENTER]<br />
dotnet user-secrets set "SecuritySettings:Cors:Policies:Default:AllowedMethods" AllowedHeaders [ENTER]<br />
dotnet user-secrets set "SecuritySettings:Cors:Policies:Default:AllowedHeaders" "*" [ENTER]<br />

- Digite os seguintes comandos:<br/>
docker run --name hcfm-db -p 27020:27017 -d mongo:8.0 [ENTER]<br/>
dotnet run [ENTER]<br/>

- Caso já não tenha feito, execute as instruções contidas no repositório do front-end desta aplicação, disponíveis na seguinte url:<br/>
https://github.com/cristianomartinsdias82/gerenciamento-fluxo-caixa-domestico-lado-cliente/blob/main/README.md
