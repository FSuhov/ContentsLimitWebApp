# ContentsLimitWebApp
Web Application with ASP.NET backend, SqLite database, Angular-based user-interface

## Getting started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* NodeJS and NPM installed
* DOTNET CLI installed
* Visual Studio 22

### Installing

1. Clone the repo
1. Open the solution in Visual Studio 22
1. Set start-up order:
   1. right-click on solution - select "Set start-up project";
   1. select Multiple start-up projects;
   1. set "Start" for both API and Angular projects (ContentsLimitWebApp and ContentsLimitWebAppAPI);
   1. do not set Start for test project (ContentsLimitWebAppAPITests);
   1. change the order - move API project to be on the top

### Launch instructions

#### In Visual Studio 22

1. Simply click on Start button. The browser window will pop-up automatically.

#### Using CLI

1. Follow the steps listed in "Installing";
1. Run cmd;
1. cd to the folder where Angular project is located (ContentsLimitWebApp);
1. Run the following commands:
   1. npm install
   1. npm start
   1. open browser at https://localhost:4200

Note, that application is configured to use https. That is why, during initial set-up and build it will install ssl certificate.
Please accept it if you will be prompted to.
Later on you may get rid of it, the location of certificates is <your user folder>\AppData\Roaming\ASP.NET\https\.

Currently there are no items in the database. There are 3 categories (Electronics, Clothing, Kitchen), but no items.
So start adding the items! Enjoy!

## Features and principles implemented

The Web Application consists of isolated:
* Front-End application developed on Angular framework;
* Back-End application developed on .NET framework.
These two isolated applications communicates with each other via http.

### Front-End Angular application demonstrates the following features:
* Usage of components and hierarchy of components. HomeComponent has two children (CategoryComponent and AddItemComponent), while CategoryComponent, in turn, has ItemComponent as its child. This gives a good opportunity for further extension as well as allow to easily change the design of ItemComponent template without affecting the parents;
* All types of property bindings: interpolation, property bindning, event binding and two-way binding using [(ngModel)];
* Usage of events passing the data from child to parent;
* Usage of service.

### Back-End .NET application utilizes the following features and principles:
* Layered architecture, where:
1. View Layer is represented by Controllers;
1. Business Logic Layer - by Services (ItemsService, CategoryService);
1. Data Access Layer - by Repositories.
Though there is very few business logic in the assignment, this architecture makes application easily scalable and extendable.
When extra requirements comes up, we can easily add or extend the business logic.
A separate Data Access layer simplifies the changing of database source, but, the most importent, this significantly simplifies the unit-testing,
because we always can mock the result of methods in repository.

* API application also follows the SOLID principles:
1. Single Responsibility - our classes are limited to the managing one certain entity (Item, Category);
1. Interface segregation - interfaces are atomic, defining the methods required for the specific role only;
1. Dependency inversion - we are injecting interfaces into the classes, therefore our modules does not depends on lower level implementations but on abstractions.

* For demonstration of unit-testing, the test project is also added.

