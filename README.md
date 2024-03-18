# Forex-app
Web application that provides daily forex prices and management of beneficiaries.

## Prerequisites

Before getting started with forex-app, make sure your development environment includes the following requirements.

* [Visual Studio 2022] version `17.9` with .NET `8.0` installed.

## Running the App

* Open the solution file `forex-app.sln` in Visual studio.

* Press `F5` in Visual Studio. Visual Studio will launch the app in the browser.

## Structure

### Login
  Landing page that consists in a login page. It has basic validations to every field, if it is empty or if not valid(base on the hardcoded data validation). 
  After successful login, the app redirects to the home page.
  It has an hardcoded data validation wich is:
  - clientId = `C14557`
  - userId = `USER23`
  - password = `ExamplePw`
### Home
  After a successful login, this is the main page of the application. It presents us with a table with daily forex data provided from https://www.alphavantage.co.
  Home page provides controls to give the possibility to the user to change the currencies from the dropdown menu that will affect the data shown in the table.
 
### Error
  Default error page, didn't make changes to the generated page.

## Routes

- /Login
- /Home
- /Error

## Code documentation

### Login
- ClientId - String (Mandatory)
- UserId - String (Mandatory)
- Password - String (Mandatory)

#### Methods

`OnPost` - Receives the login data and validate if model is valid and if the login is valid, based on the credentials. Returns the same page if one of the previous cases are invalid or redirect to /Home in case of successful login.<br><br>
`isValidLogin` - Receives the login data and validates the provided info, comparing to the hardcoded login information. Returns true in case of valid login information and false if the data is not valid to login.

### Home

- Don't have a model

#### Methods
`OnGet` - Set the default values when it is the first time it loads the page.<br><br>
`OnPost` - Pretty much the same as the Get method, but it is used to get the data when the submit is called. Received values are used to call the API with the new values.<br><br>
`MakeApiCallAsync` - Receives the currencyFrom and currencyTo to call the API with that values, after a successfull response, it sets the received data to show on the view.
