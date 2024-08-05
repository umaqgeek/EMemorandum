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

## 1. Running in Development

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
$ npm run build
```

### 1.3. Backend
```
$ dotnet watch run
```

### 1.4. To access Swagger API
1. Execute backend step `1.3.` above.
2. Open the local swagger URL at http://localhost:5000/swagger/index.html .

## 2. Installation for Production

### 2.1. Frontend
```
$ cd web-app
$ npm run build
```

### 2.2. Backend (build)
```
$ dotnet build
```

### 2.3. Backend (publish)
```
$ dotnet publish -c Release -o ./publish
```

## 3. Database & Migration

### 3.1. Add new migration script
1. Create a new model like `./Models/User.cs`.
2. Update the DB Context in `./Models/ApplicationDbContext.cs`.
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