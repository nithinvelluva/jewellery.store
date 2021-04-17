# jewellery.store

## Frontend developed in [Angular 11]

## Backend developed in [.NET CORE]


## Backend consists of 4 Layers.

  - API Layer (Jewellery.Sore)
- Services Layer (Jewellery.Sore.Services)
- DAL Layer (Jewellery.Sore.DAL)
- Models (Jewellery.Sore.ViewModels)

## SqlLite DB is used as Database,EF CORE is used for DB connectivity.
- DB file (dolittle.db)

## Unit Tests are added using XUnit and Moq frameworks on the Backend Side.
- Jewellery.Sore.Tests

## Unit Tests are added using Jasmine on the Frontend Side.


[Angular 11]: <https://angular.io/>
[.NET CORE]: <https://dotnet.microsoft.com/download/dotnet/3.1>


## Frontend plugins used.

  - bootstrap 4
- font-awesome
- html-to-pdfmake
- jspdf
- pdfmake

## Running the APP

```sh
cd ..\JewelleryStore\Jewellery.Store\ClientApp
npm install
ng build
```

then
```sh
cd ..\JewelleryStore\Jewellery.Store
dotnet run
```

## User Credentials

  - Privileged user (username : user2 , password : password)
- Normal user (username : user1 , password : password )

