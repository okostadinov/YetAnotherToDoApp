# Yet Another ToDo App (API)

### Description
The millionth iteration of this classic project. "Hello World"'s great grandfather.
This is a web API implementation using .NET 8 and an in-memory storage for simplicity's sake.
The service interface can be easily extend to a relational as well as a non-relational
database service if necessary.

### Features
* The primary CRUD operations
* A few extra filtering paths for completed and prioritized tasks
* Custom model validation for preventing due dates in the past
* Unit testing of the controller's main functionality

### Usage
* clone the project and navigate to it
* `cd YetAnotherToDoAppAPI`
* `dotnet run` for running the app as is
* `dotnet watch` for development and tracking changes
* `dotnet build` in order to generate a an executable binary
* the `Requests/Tasks.http` provides easily runnable requests when running locally
  * VS Code's REST Client extension allows executing those directly inside the editor
* navigate to the project root and execute `dotnet test` to run the tests

##### Notes
Should external database implementation be pursued, the service interface
will require minor refactoring to account for asynchronous code execution.
Taking into consideration that this isn't necessary for an in-memory storage,
it was opted to forgo unnecessary overengineering as the app currently stands.