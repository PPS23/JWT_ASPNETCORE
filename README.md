JWT at ASP.NET Core Web API

A basic way to authenticate in ASP.NET Core Web API 8

NuGetPackage installed
  Microsoft.AspNetCore.Authentication.JwtBearer 
  Version: 8.0.7

For JWT Configuration at appsettings
  Issuer: Who issues
  Audience: Whose the token is intended
  Key: must be extensive

In the AuthController, the application requests the token. For the moment, it receives everything through the User and Password fields, and no database validation is being performed. It returns a token that expires in 30 minutes, and this expiration time can be updated in the appsettings.json file.

The UserController is protected with [Authorize], which means all actions inside it require a valid token to be accessible. If you need an action to be accessible without authentication, simply add [AllowAnonymous] to that action.

TEST
With Swagger, first generate the token by calling api/Auth/Login. Then, take the received token, click the Authorize button, and paste the copied token. After that, try executing /api/User/GetAllUsers. For other tests, you can click the Authorize button again and then click Logout. The current token will be removed, and without it you cannot access /api/User/GetAllUsers or any other protected controller.
