------------------------------------------------------------------------------
* Middleware
1. HTTP Filter
2. Login API, Authentication, Token API, Identity System
	- Research
	- Implement
	- Postman test
	- Theory
	
------------------------------------------------------------------------------
* Middleware
- IdentityDbContext
	+ Implement
	+ Seeding data
- Authentication
	- Login: login with jwt
	- Logout: can not implement, set expire time <5m, and using refresh token key
- Authorization
	- Add role to ClaimType.Role
- Custom Middleware
	- Basic
	- Create class implement from IMiddleware and InvokeAsync method
	- Register the middleware with Services in startup
	- Apply this middleware at config pipeline 
- Implement Filter Middleware