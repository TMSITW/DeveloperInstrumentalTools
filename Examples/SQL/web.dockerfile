FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY WebApplication.EFCore/bin/Release/netcoreapp3.1/publish/ App/
COPY Database.EFCore/bin/Release/netcoreapp3.1/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "WebApplication.EFCore.dll"]
