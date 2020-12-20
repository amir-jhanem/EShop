# E-Commerce Asp.net core clean architecture sample

E-Commerce is a cross platform web app using Razor Pages and sqlite database.

### Structure of Project
Repository include layers divided by **4 project**;
* Core
    * Entities    
    * Interfaces
    * Exceptions
* Application    
    * Interfaces    
    * Services
    * Mapper
    * Exceptions
* Infrastructure
    * Data
    * Repository
    * Services
    * Logging
    * Exceptions
* Web
    * Interfaces
    * Services
    * Pages
    * ViewModels
    * Extensions
    * Mapper

# Screenshoots

- Home : https://imgur.com/zpdjwiT
- Login : https://imgur.com/UX1fGqf
- Register : https://imgur.com/rxcl3oc
- Products : https://imgur.com/sCyYZS9
- CheckOut : https://imgur.com/rtRsCZU
- OrderSubmitted : https://imgur.com/JNDTMqH
- Control Panel : https://imgur.com/8eIiLid
- Manage Orders : https://imgur.com/Re8ri9i
- Manage Products : https://imgur.com/DJ881uk

## Requirements

1. Get .NET Core 3.1 SDK: https://www.microsoft.com/net/download.

## Sample Users
1. Admin `admin@example.com` Password `123456`
2. Customer `amir.jhanem93@gmail.com` Password `123456`

## Run EShop
1. Build `EShop.Web`.
2. Run `EShop.Web` Using `IIS Express`
