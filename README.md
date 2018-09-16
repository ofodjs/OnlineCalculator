# Online Calculator
Online Calculator was developed as an example usage of latest technologies such as Angular 6 on UI side and WebApi on backend.

On UI was used Angular 6.1 with TypeScript, Twitter Bootstrap 4.1 for styling, and Angular CLI for project building.

Backend side uses WebApi2, Autofac as IoC container. Server code has unit tests for domain and web projects.

Both sides uses input data validation.

API on backend uses port 4201. Angular project uses default port 4200.

# How to run?

1. Running Angular
   - Install Node.js
   - Install all packages used in this project by running next command in folder 'angular':
   ```
   npm i
   ```
   - Now you could run development server by command:
   ```
   ng s
   ```

2. Runnig backend
   - Download Visual Studio to work with project. Recommended Visual Studio Community 2017.
   - Open solution file [server/OnlineCalculator.sln](server/OnlineCalculator.sln) in Visual Studio.
   - Build solution.
   - Run project on IIS Express by clicking on corresponding button on toolbar.
   - In just opened window replace port number from 4201 to 4200 to be 'http://localhost:4200'.

3. Now address 'http://localhost:4200' should be used to work with Online Calculator.
