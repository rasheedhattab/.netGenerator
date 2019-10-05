# .netGenerator
.net and angular Generator
This project is a console application used to generate the CRUD operation for any table.
you can start any screen you want from this project.
this project fasts the development process.
the generator generates n tires layers (Data Access, Service, Entities Validator and API)
also generates angular client-side screens (Add, update and List screens).
Generate the oracle package required for CRUD operations.
I used the t4 to generate files and copy the generated file to the right path.

for more details how to use it visit my blog
http://consoledotwrite.blogspot.com/2019/10/t4.html


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

