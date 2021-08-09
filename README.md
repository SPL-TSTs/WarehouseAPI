# WarehouseAPI
Project to store device information. This project has been developed in .Net Core 3.1, using Azure Table Storage as database.

## Running the API

* Open the solution Warehouse which is inside Warehouse folder using your Visual Studio.
* Set as startup project Warehouse.API project.
* Go to the appsettings.json and replace the value of the variable AzureConnectionString with the key provided by email.
* Press Ctrl+F5 of F5 for debugging
* This project is listening the port 44354 in your localhost, be sure that you have that port free, otherwise you can change this value in Warehouse.API/Properties/launchSettings.json.
* The landing page is the swagger documentation.
* Start testing!

## Running the Angular client

* Make sure you have installed npm in your PC, as well as the Angular CLI before running the project.
* Open the solution AngularClient which is inside AngularClientApp using your Visual Studio.
* Run the project by pressing F5 or Ctrl+F5
* In the landing page you can navigate to the page to add new devices and after that you can go to the fetch page in order to check all the devices that have been stored.
