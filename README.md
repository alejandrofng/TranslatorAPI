# TranslatorAPI
This project provides a solution for the following problem: 

## api-creation-challenge
Code challenge part of the interview process in LanguageWire
Hi fellow candidate!
Are you ready for the next step of our interview process?
I hope you are as excited as we are to review your code. :-)
First considerations
Time is important but not the most!
We check when you access this repo, and then when you clone it or fork it, and the time between commits.
No pressure! It doesn't mean that you need to rush a solution, but it can't also take forever.
First thing to do is to fork this repo adding your name as a suffix and add a test file (just a test.txt with no content is fine), push it, and then share the repo with us (user: LanguageWireConnectors).
## Challenge description
We want you to provide a REST API to satisfy the following business requirements gathered from our user story mapping session:
### Translation basket (basket) creation:
We can create a basket by specifying a project id, a customer id, a list of target languages (language codes) and an expected due date. Project id will be the identifier for this basket.
### Add files to translate to the basket:
We now attach the files we already uploaded using another API to the project. In order to do so we add to the project with a project id the file entities providing the following for each file: file id, file name, file type, file content, and comments.
The "file type" will be the extension of the file.
The "file content" consist of the plain sentences that are inside the file splitted by the token '#LW-Test#'.
The comments are only for the consideration of the translator once it gets there.
### View a basket:
At any time, the API client should be able to check what's inside the basket with certain id.
Our endpoint would return: The project id, the customer id, the target languages, the due date, the remaining time for the due date. And...
The list of files indicating the id, name, type, and comments. And...
The calculated price for the translation based on items we have so far.
Acceptance criteria for price calculation
*	Standard price per word is 0,07€
*	When a word is repeated inside the same file the price is 0,02€.
*	When a full sentence is repeated in the same file the price is 0 for the whole sentence.
*	When a word is repeated in another file the price is 0,05€.
*	When a full sentence is repeated in another file the price is 0,01€ for each word.
*	For PDF type formats the price is 20% more than the standard one.
*	For PSD type formats (Photoshop) the price is 35% more than the standard one.
*	The target language "es-ES" gets a 20% discount on the total price.
### What we want you to do
*	Create clean code, with good practices, following standards and good principles and design patterns. Readability.
*	Create a clean architecture. Easy to open and understand what's the project about.
*	Make sure you satisfy the calculation rules.
*	Wrap up when you hand it over. A brief comment on what you think about the test would be appreciated.
*	Don't forget to let us know that you are done by reaching out to your contact person in LW!

### Solution
* A clean architecture approach was used to organize the structure of the project. Resulting in:
API, Application, Domain, Infrastructure, Tests.
* FluentValidation was used to validate the DTOs coming into the API.
* Unit testing was implemented for the domain layer.
* Extensions were used to ease the responsibility segregation, regarding the DTO mapping.
* A command pattern was used to implement the calculation of the Price.
* An abstract class was used to ease the implementation of Id’s and dbContext extensions.
* A code first database proposition was used to store data and to ease the test of the functionality. Data is seeded from the DbContext.

To implement migrations in your system, follow these steps:
install dotnet ef (https://docs.microsoft.com/es-es/ef/core/cli/dotnet)
Input the following command in the package manager console:
```sh
cd ..\TranslatorAPI\Infrastructure
```
To add a new migration:
```sh
dotnet ef migrations add “migrationName” -s ..\TranslatorAPI
```
To remove the last migration added:
```sh
dotnet ef migrations remove -s ..\TranslatorAPI
```
To apply changes on your database:
```sh
dotnet ef database update -s ..\TranslatorAPI
```
### TODO:
Further segregate responsibilities doing the following:
* A CQRS approach would separate the Database context from the controller and focus the logic of the requests somewhere else, leaving the controller with you’re the minimum data to specify how to consume each of the endpoints.
* Price calculation is not abstracted enough.
* Seeding for dummy data can be done on separate files to keep the dbContext class understandable.
* Double check on the possibility to abstract both language and filetype (both are identified by strings and both are possible causes for price alterations). If there is a third entity capable of alterating the price that is not using a string as identifier it might break the abstraction.
* As language codes follow an ISO standard, a regex could be used to further validate the code inputed by the user.
