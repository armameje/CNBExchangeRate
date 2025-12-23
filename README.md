# CNB ExchangeRate Provider

## About
Web application composed of Angular for frontend and ASP.NET Core Web API for backend, consuming from a third-party API https://api.cnb.cz/cnbapi/. The API exposes an endpoint for getting exchange rates for the current day. The Angular website fetches those data and displays them.

## Prerequisites
The project utilizes docker for containerization of the application and ease of deployment. You will need the following things properly installed on your computer.

For Windows
* Docker Desktop
* Windows Subsystem for Linux 2 (WSL 2)
* 4GB RAM minimum 
* Hardware virtualization enabled in BIOS/UEFI

For Linux
* Docker Engine
* Docker CLI
* containerd

## Backend
The backend utilizes C# alongside ASP.NET Core Web API using .NET 8. It implements clean architecture and global exception handling.

## Frontend
The frontend utilizes Angular and TypeScript. For it's style, CSS, Tailwind, and Spartan UI were used.

## Docker
Using bash or any cli, change directory to the folder where the docker-compose.yml file is located and execute the command below.

```sh
docker-compose up -d --build
```
API
 - https://localhost:8757/
 
Website
 - http://localhost:4201/