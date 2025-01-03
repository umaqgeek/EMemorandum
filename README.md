# E-Memorandum Web App
System to manage memorandum in UTeM.

## 0. Pre-requisites tools
- Vue JS version 5
- .NET Core version 6
- Node version 18
- NPM version 10
- MSSQL server version 2017
- docker version 24
- docker-compose version 1.29.2

## 1. Running in Local

### 1.1. Database (via Docker)
```
$ docker-compose -f docker/docker-compose.yml up -d
```
- You can connect to the database via 3rd party app like `DBeaver`, using database credentials from the `docker/docker-compose.yml` file.
```
driver: sqlserver
host: 127.0.0.1
database: master
username: SA
password: P@ssw0rd
```
- Import the database and its tables from under the `/Databases` folder.

### 1.2. Frontend
```
$ cd web-app
$ npm run serve
```

### 1.3. Backend
```
$ dotnet watch run --environment "Local"
```

### 1.4. To access Swagger API
1. Execute backend step `1.3.` above.
2. Open the local swagger URL at http://localhost:5000/swagger/index.html .

## 2. Build & Deployment for other environments

### 2.1. Setup global variable for Environment

#### 2.1.1. On Windows
Open Command Prompt or PowerShell and set the environment variable:

##### 2.1.1.1. Development
```
$ setx ASPNETCORE_ENVIRONMENT "Development"
```

##### 2.1.1.2. Staging
```
$ setx ASPNETCORE_ENVIRONMENT "Staging"
```

##### 2.1.1.3. Production
```
$ setx ASPNETCORE_ENVIRONMENT "Production"
```

#### 2.1.2. On macOS/Linux
In your shell, export the environment variable:

##### 2.1.2.1. Development
```
$ export ASPNETCORE_ENVIRONMENT=Development
```

##### 2.1.2.2. Staging
```
$ export ASPNETCORE_ENVIRONMENT=Staging
```

##### 2.1.2.3. Production
```
$ export ASPNETCORE_ENVIRONMENT=Production
```

### 2.2. Manual Update of Internal Variables

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

### 2.3. Frontend

#### 2.3.1. Development
```
$ cd web-app
$ npm run build:development
```

#### 2.3.2. Staging
```
$ cd web-app
$ npm run build:staging
```

#### 2.3.3. Production
```
$ cd web-app
$ npm run build:production
```

### 2.4. Backend (build & publish)
```
$ rm -rf publish
$ dotnet publish -c Release -o ./publish
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

## 4. Deployment & Release

### 4.1. Auto build with GitHub Actions
There is a github workflow process has been defined in this file [build-and-publish.yml](/.github/workflows/build-and-publish.yml). It will be triggered by tags with these prefix:
- `dev-*`
  - For development environment.
  - The zip artefact file from this process can be downloaded from the github actions page.
  - It will be deployed in the server with this URL [devmis.utem.edu.my/emo](https://devmis.utem.edu.my/emo/)
  - Eg.: `git tag dev-1.3.2`
- `stag-*`
  - For staging environment.
  - The zip artefact file from this process can be downloaded from the github actions page.
  - It will be deployed in the server with this URL :TBD
  - Eg.: `git tag stag-1.3.2`
- `prod-*`
  - For production environment.
  - The zip artefact file from this process can be downloaded from the github actions page.
  - It will be deployed in the server with this URL :TBD.
  - Eg.: `git tag prod-1.3.2`

### 4.2. Manual build
Below are the scripts to be used to build the Frontend (VueJS) and Backend (.NET Core) application into one folder named `publish`. Deploy the build inside that folder into different environment; `development`, `staging`, and `production`.

#### 4.2.1. Windows

##### 4.2.1.1. Development
To build in Windows OS for development environment. It will be deployed in the server with this URL [devmis.utem.edu.my/emo](https://devmis.utem.edu.my/emo/)
```
$ cd web-app && \
    npm install && \
    npm run build:development && \
    cd ..
$ setx ASPNETCORE_ENVIRONMENT "Development"
$ rm -rf publish && \
    dotnet publish -c Release -o ./publish
```

##### 4.2.1.2. Staging
To build in Windows OS for staging environment. It will be deployed in the server with this URL :TBD
```
$ cd web-app && \
    npm install && \
    npm run build:staging && \
    cd ..
$ setx ASPNETCORE_ENVIRONMENT "Staging"
$ rm -rf publish && \
    dotnet publish -c Release -o ./publish
```

##### 4.2.1.3. Production
To build in Windows OS for production environment. It will be deployed in the server with this URL :TBD
```
$ cd web-app && \
    npm install && \
    npm run build:production && \
    cd ..
$ setx ASPNETCORE_ENVIRONMENT "Production"
$ rm -rf publish && \
    dotnet publish -c Release -o ./publish
```

#### 4.2.2. Linux / MacOS

##### 4.2.2.1. Development
To build in Linux OS or MacOS for development environment. It will be deployed in the server with this URL [devmis.utem.edu.my/emo](https://devmis.utem.edu.my/emo/)
```
$ cd web-app && \
    npm install && \
    npm run build:development && \
    cd ..
$ export ASPNETCORE_ENVIRONMENT=Development
$ rm -rf publish && \
    dotnet publish -c Release -o ./publish
```

##### 4.2.2.2. Staging
To build in Linux OS or MacOS for staging environment. It will be deployed in the server with this URL :TBD
```
$ cd web-app && \
    npm install && \
    npm run build:staging && \
    cd ..
$ export ASPNETCORE_ENVIRONMENT=Staging
$ rm -rf publish && \
    dotnet publish -c Release -o ./publish
```

##### 4.2.2.3. Production
To build in Linux OS or MacOS for production environment. It will be deployed in the server with this URL :TBD
```
$ cd web-app && \
    npm install && \
    npm run build:production && \
    cd ..
$ export ASPNETCORE_ENVIRONMENT=Production
$ rm -rf publish && \
    dotnet publish -c Release -o ./publish
```