#Take Base Image from ASP.NET Core Application to run 
FROM mcr.microsoft.com/dotnet/sdk:6.0 as builder
#Set the work directory inside the image where application files will be copied 
WORKDIR /src
#Copy the project file to image
COPY ./CategoryService.csproj .
#Restore all references used in the project
RUN dotnet restore CategoryService.csproj 
#Copy all the executable references from the application to the image 
#source(.)Project file to Destination(.)src
COPY . .
#Inform the image that the base runtime is ready from the import image 
RUN dotnet build CategoryService.csproj -c debug -o /src/out
#Point to the work directory from where the app will be accessible 
FROM mcr.microsoft.com/dotnet/aspnet:6.0
#Copy the path from where the execution will takes place inside the image
WORKDIR /app
COPY --from=builder /src/out .
#Application will be activated at port 80
EXPOSE 80
#set the entry point application
ENTRYPOINT [ "dotnet", "CategoryService.dll" ]