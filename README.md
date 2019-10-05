# .netGenerator
.net and angular Generator
This project is a console application used to generate the CRUD operation for any table.
you can start any screen you want from this project.
this project fasts the development process.
the generator generates n tires layers (Data Access, Service, Entities Validator and API)
also generates angular client-side screens (Add, update and List screens).
Generate the oracle package required for CRUD operations.
I used the t4 to generate files and copy the generated file to the right path.

The output from this project is:
1. Generated oracle package for CRUD operation
2. Entity that represent the Table.
3. Data access class that calls the database stored procedures.
4. Service Layer that calls the Data access Layer.
5. Validator class using FluentValidation that validates the required fields and Max length.
6. API controller that calls the service layer.
7. Angular Components (Add, Update and List)
8. Angular service and view



To start using this project: 

1.Add this project to your solution

2.Go to app.config and put the oracle connection string.

3.From app.config appSettings section change the path of generated files according  to your projects paths.

4.Update the t4 files according  to your code standard or your way of coding.

5.Go to Program.cs file and put your table name (that you want to generate) by changing tableName property.

6 Run the application

I hope this project helps developers to generate the CRUD operation for any table.
Contact me if you need any help
Best Regards.

