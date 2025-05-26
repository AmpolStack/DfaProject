# ### Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore ProjectDfa.sln
RUN dotnet publish src/src.csproj -c Release -o /app/publish

# ### Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Usa el puerto que Railway inyecta
ENV ASPNETCORE_URLS=http://+:${PORT}
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE ${PORT}
# Ajusta aquí el nombre real de tu DLL
ENTRYPOINT ["dotnet", "ProjectDfa.dll"]
