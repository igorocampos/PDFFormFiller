FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["PDFFormFiller/PDFFormFiller.csproj", "PDFFormFiller/"]
RUN dotnet restore "PDFFormFiller/PDFFormFiller.csproj"
COPY . .
WORKDIR "/src/PDFFormFiller"
RUN dotnet build "PDFFormFiller.csproj" -c Release -o /app/build
RUN dotnet test "../UnitTests/UnitTests.csproj"
RUN dotnet test "../IntegrationTests/IntegrationTests.csproj"


FROM build AS publish
RUN dotnet publish "PDFFormFiller.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDFFormFiller.dll"]