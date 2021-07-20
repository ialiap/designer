FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL autodelete="true"

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM base AS test
LABEL autodelete="true"

RUN curl --silent --location https://deb.nodesource.com/setup_12.x | bash -
RUN apt-get install --yes nodejs

WORKDIR /client-app
COPY ["Designer.Service.API/client-app", "./"]
RUN npm install react-scripts@4.0.1 -g --silent
RUN npm install


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
LABEL autodelete="true"

RUN curl --silent --location https://deb.nodesource.com/setup_12.x | bash -
RUN apt-get install --yes nodejs

WORKDIR /src
COPY ["Designer.Service.API", "Designer.Service.API"]
COPY ["Designer.Common", "Designer.Common"]
RUN dotnet restore "./Designer.Service.API/Designer.Service.API.csproj"
COPY . .

WORKDIR "/src/."
RUN dotnet test
RUN dotnet build "./Designer.Service.API/Designer.Service.API.csproj" -c Release -o /app/build


FROM build AS publish
ARG environment
ENV environment=$environment
LABEL autodelete="true"


RUN echo "Publishing for $environment"
RUN REACT_APP_ENVIRONMENT=$environment CI=true dotnet publish "./Designer.Service.API/Designer.Service.API.csproj" -c Release -o /app/publish


FROM base AS final
LABEL autodelete="true"

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Designer.Service.API.dll"]