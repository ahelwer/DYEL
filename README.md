DYEL
====

A fitness-oriented social network app. Created as a final project for the CPSC 471 (databases) class at the University of Calgary in the Fall 2013 semester.

Live demo website (create an account!): http://dyeldemo.azurewebsites.net

Full spec & user manual (.pdf): https://skydrive.live.com/redir?resid=55025043B9B81FAF%215023

The website uses AngularJS to query a C# ASP.NET Web API backend, which in turn uses the Entity Framework to query a database. My primary motivation in this project was learning AngularJS.

To download/build/run:

1) Check out or download this repository.

2) Open in Visual Studio 2013.

3) Build the project; NuGet should automatically download all required packages.

4) Open the Package Manager Console by clicking on Tools > Library Package Manager > Package Manager Console. Enter the command “update-database” and press enter. This will create and initialize the database for local testing.

5) Run the project. The website will open in your default web browser, with the newly-created database devoid of content.
