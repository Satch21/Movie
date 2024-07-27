-Installation : 

-Back :
  - 
  - Initisalition de la bdd : dotnet ef database update
  - Build et lancement de l'api :
        - Swagger : https://localhost:7261/swagger/index.html
  - Dans Program.cs, changer l'adresse du front en fonction du port (exemple policy.WithOrigins("http://localhost:5173"))
  - Le fichier Sample.json contient des exemples d'appels à l'api utilisables dans Swagger

-Front :
   - npm run dev à la racine de movie-front
   - changer le port dans http-common.ts au niveau de l'url de l'api (exemple baseURL: "https://localhost:7261/api") 
