# Subscription Listing

As a part of the budget123 recruitment process we ask our candidates to complete a practical development challenge. The challenge consists of two parts:

1. You solve the provided task, and send the results to us.
2. We host a session where you present your solution to us, and we all have a nice talk about it.

The task is to implement a simple cmd client that will consume a public api (https://apis.e-conomic.com/#Subscriptions) and list the results:

1. As a company owner I want to be able to list all subscribers including the name of the subscription, sorted by "startDate".
2. As a company owner I want to be able to list all subscriptions including subscriptionlines, sorted by "name".

Write the result list to the screen or a text file. 

We ask that you clone this repository to complete the task, rather than fork it. You can either push it to a repository on your own account, or simply send us the project in a zip if you prefer.

## Considerations

What we're looking for is to see if you have the ability to transform a set of user requirements into a working solution, preferably creating some nice and clean code along the way. We will appreciate if your solution:

-   Works, obviously
-   Contains readable, bug free code
-   Follows sensible structured design patterns and thought proceses

We want to see that you have thought about the design of your application, and considered how it might scale as it's complexity and data volume increases:

-   Consider how your application might scale as it grows in use, and in number of developers working on it
-   Summarise any significant architectural decisions you take, to discuss in the presentation

## Questions

If you have any questions or concerns please simply ask.

---

To help, we have scaffolded a .NET Framework v4.8.1 solution containing some basic setup to get you started.

-   You are welcome to change or remove any part of this code, it is meant simply as a starting point
-   user interface is not that important, we are assesing your ability to design and architect software - focus on that
-   Do not worry about authentication, the test class authenticates with ("demo", "demo") use that.

## Development

To run this project you will need .NET Framework v4.8.1 installed on your environment, the project references Newtonsoft.json NuGet package.

