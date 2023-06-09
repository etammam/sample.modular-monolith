# What is a Modular Monolith Architecture?
A modular monolith architecture is a software development approach that leverages a single, large codebase instead of multiple, isolated, small codebases. The codebase is logically divided into separate modules that can be developed, tested, and maintained independently.

Each module is designed to be loosely coupled, meaning that changes to one module won’t affect any other. This makes it easier for a team to work on their own parts of the codebase without needing to understand the entire system. This significantly reduces the amount of time and effort required to make changes or add new features.

The architecture also allows communication within a single process using both synchronous and asynchronous methods while maintaining logical separations and bounded contexts.

All these lead to a more scalable and resilient application with faster time to market for new features and updates. I would like to share my experience with architecture, highlighting its benefits and drawbacks.

Concerns with using modular monolith architecture include:
Long compilation times.
Long-running test.
Deployment to production takes a long time.
Limited language agnosticism.
Centralized development.
In-Depth Examination of These Limitations
1. Long compilation time
Long compilation time, which can be a problem for large projects with a lot of code. This can be incredibly frustrating for developers working on local machines, as it can take significant time to build and test code changes. However, this issue can be mitigated by only running a clean command of package manager when necessary, as this builds only modified files, as it does most of the IDEs.
Though from time to time, you would still need to run the build command with clean. Overall, while long compilation times can be a challenge with modular monolith architecture, there are ways to minimize the impact and improve the efficiency of the development process.

2. Long-running tests
Similar to long compilation time, there is a workaround, run tests separately by module, class, or individual test. Run all tests only in CI.

3. Deployment to production takes a long time
Deployment to production can take a long time, especially for large projects with a lot of code and complex CI/CD pipelines. This can be a significant issue for developers, as it can delay the release of new features and updates to the production environment. 
In some cases, it may not be possible to have a fixed issue and have code in production within a short timeframe, such as 10–30 minutes. To reach a point where deployment takes such a long time, the project would typically have around 1 million lines of code, which would be equivalent to 50 developers working on and maintaining the project for five years.

4. Limited Language Agnosticism
As it is not as flexible in terms of incorporating different programming languages. While this can be an issue for some developers, it is important to note most programming languages are capable of handling the majority of business logic and can be used effectively in a modular monolith architecture.

5. Centralized Development
Centralized development is a huge limitation of using modular monolith architecture. Introducing new technologies and finding the most appropriate tool for each case and application may be more challenging. This can be a challenge for developers who want to use the latest tools and technologies to improve the performance, scalability, or functionality of their applications. In some cases, introducing a new technology stack into a modular monolith project can be difficult due to resistance from other developers on the project who are comfortable with the existing technologies, and the numbers of developer are not just five but hundreds.

6. A single point of failure
A single point of failure can be a critical issue in a modular monolithic application, as the entire system is vulnerable to failure if that one component fails. This can lead to significant downtime and loss of revenue or other consequences. However, even when using a microservice architecture, which aims to minimize the impact of failures by dividing the system into smaller, independent components, there is still the possibility of experiencing downtime if one of the systems fails. To address this concern, it is important to design the system with redundancy and failover mechanisms in place. However, if you are concerned about having a specific module operate independently from the others and asynchronously, you may want to consider separating it from the core of the application and keeping the rest of the codebase in place.

As with microservices, Modular Monolith has its limitation and workarounds.

Now that we’ve covered the drawbacks of using a modular monolith, let’s discuss the benefits.

The benefits of using a modular monolith architecture include the following:
Increased productivity: With a single codebase, developers can quickly identify and address any issues they encounter. This makes the development process more efficient and helps the team to get more done in less time.
Ease of creating new modules, with no need to set up infrastructure, continuous integration/continuous delivery, databases, etc.
The simplicity of debugging.
Ability to easily split the application into different services and convert the project to microservice architecture.
Improved team collaboration, as responsibilities, can be divided across modules, and merge conflicts are minimized, compared to traditional monolithic applications.
A less complex architecture compared to microservices, without the need for additional tools such as Service Discovery, Message Brokers, API Specifications management and etc.
A cohesive and loosely coupled system, with the ability to ensure at compile time that no modules access other modules except through their APIs and at build time using ArchUnit that no dependencies exist between certain modules.
The option to use different databases. Although this may be challenging due to using a single transaction across modules if configured so (in the case of using a relational database).
The single database and process ensure strong consistency and low latency.
Consistent version when running the project locally, without the need for having dependent services or configured remote environments.
Self-maintained, allowing developers to introduce new concepts and technologies only with the agreement of the entire project’s developers.
Modular monolith architectures may be a good fit for the following cases:
Greenfield implementations, such as a new financial services platform in the early stages of development.
Systems with low to moderate scales, such as a movie ticket booking platform serving several thousand users and handling a few million transactions per week.
Non-complex business software platforms, such as a notes/documents syncing and management platform for consumer apps.
Oversized legacy applications that need to be split into microservices but are not yet ready for complete separation into independent services.
Startups, as a modular monolith, can provide a strong foundation and fast development.
Systems with low traffic, such as those that are not yet expecting or experiencing less than 1000 requests per second. In these cases, a modular monolith may be sufficient to handle the traffic without the need for the additional complexity and infrastructure required by a microservice architecture.


# Resources
- [Exploring the Benefits and Limitations of a Modular Monolith Architecture](https://medium.com/javarevisited/exploring-the-benefits-and-challenges-of-a-modular-monolith-architecture-5ee9f69988c8#:~:text=A%20modular%20monolith%20architecture%20is,%2C%20tested%2C%20and%20maintained%20independently.)