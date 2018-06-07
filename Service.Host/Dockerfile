FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app


FROM microsoft/dotnet:2.0-sdk AS build-sdk
WORKDIR /src
COPY BishopTakeshi.sln ./
COPY Application/Application.csproj Application/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Application
RUN dotnet build -c Release -o /app


FROM build-sdk AS publish
RUN dotnet publish -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BishopTakeshi.Application.dll"]
