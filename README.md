# .NET Core Sample API

Basic API implemented for a coding challenge.

# Requirements

This API was designed to fit the following requirements:

1. Create an API that returns "Hello World"
1. Use Simple Injector for constructor injection between the API and a mocked data layer, using business objects and interfaces.
1. Consume the API from a webpage using jQuery, Angular 2+, or Vue. The result should show "hello world" 10x\*.

\* This was clarified as such: "it makes more sense if [the API] was called once and the plage displayed [the result] 10x."

###### Considerations
* The C# code needs to be asynchronous.
* Sample.API and Sample.Presentation should use .NET Core >= 2.0.
* Sample.Infrastructure and Sample.Domain should use .NET Standard.
* EntityFramework may not be used.
* Entities do not require interfaces.

# Structure

* Sample.API
	* .NET Core Web API that defines the MessagesController
	* Presents one method.
	* GET /api/messages
		* Returns a list of all messages stored in the mock data layer.
* Sample.Domain
	* Interfaces
		* IMessageRepository
			* Describes the methods a repository of messages should present. 
	* Entities
		* Message
			* A simple object that wraps a string message in the Text attribute.
* Sample.Infrastructure
	* Contains an in-memory implementation of IMessageRepository aptly named InMemoryMessageRepository
	* Repository is constructed off of a static list, supplied via SimpleInjector
* Sample.Presentation
	* .NET Core + Angular 7 website
	* Calls GET /api/messages when the respective button is pressed
	* Displays the first message 10x.
