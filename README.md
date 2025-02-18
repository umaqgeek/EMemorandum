# E-Memorandum Web App
System to manage memorandum in UTeM.

## 0. Pre-requisites tools

### 0.1. Frontend
- Vue JS version 5
- Node version 18
- NPM version 10

### 0.2. Backend
- .NET Core version 6
- MSSQL server version 2017

### 0.3. Optional
- docker version 24
- docker-compose version 1.29.2

## 1. Running in Local

### 1.1. Database
- Make sure you can connecting to the development database server from your local device
- Dev DB: `devmis20.utem.edu.my`
- The connection config can be viewed inside variable named `EMOConnection` in `AppSettingsEnv/appsettings.json`

### 1.2. Frontend
```
cd web-app
npm install
npm run serve
```

### 1.3. Backend
```
dotnet watch run --environment "Local"
```
OR
```
dotnet watch run
```

### 1.4. To access Swagger API
1. Execute backend step `1.3.` above.
2. Open the local swagger URL at http://localhost:5000/swagger/index.html .

## 2. Deployment & Release

### 2.1. Auto build with GitHub Actions
There is a github workflow process has been defined in this file [build-and-publish.yml](/.github/workflows/build-and-publish.yml). It will be triggered by tags with these prefix:
- `dev-*`
  - For development environment.
  - The zip artefact file from this process can be downloaded from the github actions page.
  - It will be deployed in the server with this URL [devmis.utem.edu.my/emo](https://devmis.utem.edu.my/emo/)
  - Eg.: `git tag dev-1.3.2`
- `stag-*`
  - For staging environment.
  - The zip artefact file from this process can be downloaded from the github actions page.
  - It will be deployed in the server with this URL [qa.utem.edu.my/emo](https://qa.utem.edu.my/emo/)
  - Eg.: `git tag stag-1.3.2`
- `prod-*`
  - For production environment.
  - The zip artefact file from this process can be downloaded from the github actions page.
  - It will be deployed in the server with this URL :TBD.
  - Eg.: `git tag prod-1.3.2`

### 2.2. Manual build
Below are the scripts to be used to build the Frontend (VueJS) and Backend (.NET Core) application into one folder named `publish`. Deploy the build inside that folder into different environment; `development`, `staging`, and `production`.

#### 2.2.1 Manual update Database connection
If you need to update the .NET's environment variables like connection to the database for each environments, you can observe the `appsettings.*.json` files under the folder [AppSettingsEnv](/AppSettingsEnv). The default `appsettings` file is [appsettings.json](/AppSettingsEnv/appsettings.json).

- Local: [appsettings.Local.json](/AppSettingsEnv/appsettings.Local.json)
- Development: [appsettings.Development.json](/AppSettingsEnv/appsettings.Development.json)
- Staging: [appsettings.Staging.json](/AppSettingsEnv/appsettings.Staging.json)
- Production: [appsettings.Local.json](/AppSettingsEnv/appsettings.Production.json)

#### 2.2.2 Manual update API connection
If you need to update the VueJS environment variables like connection from the Frontend to the Backend application for each environments, you can observe the `.env.*` files under the folder [web-app](/web-app/). The default `.env` file is [.env](/web-app/.env.local).

- Local: [.env.local](/web-app/.env.local)
- Development: [.env.development](/web-app/.env.development)
- Staging: [.env.staging](/web-app/.env.staging)
- Production: [.env.production](/web-app/.env.production)

#### 2.2.3. Windows

##### 2.2.3.1. Development
To build in Windows OS for development environment. It will be deployed in the server with this URL [devmis.utem.edu.my/emo](https://devmis.utem.edu.my/emo/)
```
cd web-app
npm install
npm run build:development
cd ..
setx ASPNETCORE_ENVIRONMENT "Development"
dotnet publish -c Release -o ./publish
```

##### 2.2.3.2. Staging
To build in Windows OS for staging environment. It will be deployed in the server with this URL [qa.utem.edu.my/emo](https://qa.utem.edu.my/emo/)
```
cd web-app
npm install
npm run build:staging
cd ..
setx ASPNETCORE_ENVIRONMENT "Staging"
dotnet publish -c Release -o ./publish
```

##### 2.2.3.3. Production
To build in Windows OS for production environment. It will be deployed in the server with this URL :TBD
```
cd web-app
npm install
npm run build:production
cd ..
setx ASPNETCORE_ENVIRONMENT "Production"
dotnet publish -c Release -o ./publish
```

#### 2.2.4. Linux / MacOS

##### 2.2.4.1. Development
To build in Linux OS or MacOS for development environment. It will be deployed in the server with this URL [devmis.utem.edu.my/emo](https://devmis.utem.edu.my/emo/)
```
cd web-app
npm install
npm run build:development
cd ..
export ASPNETCORE_ENVIRONMENT=Development
rm -rf publish
dotnet publish -c Release -o ./publish
```

##### 2.2.4.2. Staging
To build in Linux OS or MacOS for staging environment. It will be deployed in the server with this URL [qa.utem.edu.my/emo](https://qa.utem.edu.my/emo/)
```
cd web-app
npm install
npm run build:staging
cd ..
export ASPNETCORE_ENVIRONMENT=Staging
rm -rf publish
dotnet publish -c Release -o ./publish
```

##### 2.2.4.3. Production
To build in Linux OS or MacOS for production environment. It will be deployed in the server with this URL :TBD
```
cd web-app
npm install
npm run build:production
cd ..
export ASPNETCORE_ENVIRONMENT=Production
rm -rf publish
dotnet publish -c Release -o ./publish
```

## 3. Database & Migration

### 3.1. Add new migration script
1. Create a new model. Eg.: `./Models/User.cs`.
2. Update the DB Context in `./Models/DbContext_EMO.cs`.
3. Run migration script. Eg.:
```
$ dotnet ef migrations add AddUserTable
```
4. Execute the new migration script:
```
$ dotnet ef database update
```

### 3.2. Export all tables and its data into one SQL file
```
$ dotnet ef migrations script -o e_memorandum_db.sql
```