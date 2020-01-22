FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS base

COPY CosmosDBDetails/bin/Release/netcoreapp2.1/publish/ CosmosDBDetails/

ENTRYPOINT ["dotnet", "CosmosDBDetails/CosmosDBDetails.dll"]
CMD ["argument"]