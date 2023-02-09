# FunctionApp29
Sample isolated dotnet function app demonstrating scoped service usage inside middleware and function.

`IMyScopedService` is registered as a dependency with scoped lifetime.

 * `IMyScopedService` is being injected to Function class constructor and used inside the http trigger function.
 * `IMyScopedService` is also resolved inside the Invoke method of the middelware.
 *  The `GetId` method of the `IMyScopedService` is called from both the function and from the middleware and the result is logged. You can see it gets the same Id (suggesting that both places are using the same instance of `IMyScopedService` during a function invocation). Each function invocation will create a new instance of `IMyScopedService`.

![image](https://user-images.githubusercontent.com/144469/217903918-5e4942fa-4a25-4b4d-ac74-4b1ba0b03460.png)
