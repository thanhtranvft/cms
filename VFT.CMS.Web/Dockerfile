#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VFT.CMS.Web/VFT.CMS.Web.csproj", "VFT.CMS.Web/"]
COPY ["VFT.CMS.Application/VFT.CMS.Application.csproj", "VFT.CMS.Application/"]
COPY ["VFT.CMS.Entities/VFT.CMS.Entities.csproj", "VFT.CMS.Entities/"]
COPY ["VFT.Shared/VFT.Shared.csproj", "VFT.Shared/"]
COPY ["VFT.CMS.EntityFrameworkCore/VFT.CMS.EntityFrameworkCore.csproj", "VFT.CMS.EntityFrameworkCore/"]
COPY ["VFT.CMS.Resources/VFT.CMS.Resources.csproj", "VFT.CMS.Resources/"]
RUN dotnet restore "VFT.CMS.Web/VFT.CMS.Web.csproj"
COPY . .
WORKDIR "/src/VFT.CMS.Web"
RUN dotnet build "VFT.CMS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VFT.CMS.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VFT.CMS.Web.dll"]