------------------------------------------------------------------------------
* Design Pattern
	- Research
	- Implement
	- Theory


------------------------------------------------------------------------------
* Design 
+ DataAccess
	- Models
	- Configuration instead of Annotation
	- DesignTimeDatabase help to inject DbContextOptions<DbContext> into ApplicationDbContext at runtime, no need to use another Framework
	- Using Configuration to get information from json file
		- A.GetChildren(): using when data's A is array, each item is ConfigurationSession
		- section.GetChildren().Select(e => e.Value): we can combine between GetChildren with Select to return IEnumberable value, when each item is array of entire object such as [1, "Sos", 20]
	- DataSeeding
+ Repository
+ UnitOfWork
+ Dependency Injection
	- Using ServiceCollection class to manage the services in the application
	- ServiceProvider is the object contain all the Service, this object will be created when we use BuildServiceProvider() method to build ServiceCollection
	- serviceProvider.GetService<AnotherProgram>(): use this method to force get the specific service from service colection
+ UnitTest
	- TestApplication: using database memory ensure that is not effect to another database
	- Create BaseClassTest for other class can implement
