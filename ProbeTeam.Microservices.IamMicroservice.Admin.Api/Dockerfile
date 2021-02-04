FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/ProbeTeam.Microservices.IamMicroservice.Admin.Api/ProbeTeam.Microservices.IamMicroservice.Admin.Api.csproj", "src/ProbeTeam.Microservices.IamMicroservice.Admin.Api/"]
COPY ["src/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.Shared/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.Shared.csproj", "src/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.Shared/"]
COPY ["src/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer.csproj", "src/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/"]
COPY ["src/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL.csproj", "src/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.MySql/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.MySql.csproj", "src/ProbeTeam.Microservices.IamMicroservice.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/ProbeTeam.Microservices.IamMicroservice.Admin.Api/ProbeTeam.Microservices.IamMicroservice.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/ProbeTeam.Microservices.IamMicroservice.Admin.Api"
RUN dotnet build "ProbeTeam.Microservices.IamMicroservice.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProbeTeam.Microservices.IamMicroservice.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "ProbeTeam.Microservices.IamMicroservice.Admin.Api.dll"]