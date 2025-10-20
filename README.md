# Subscription
Subscription system based on Asp.net core 9 on VSA

# 1. Why did you choose this structure and these technologies ?

I implemented the web services using .NET 9 with a RESTful architecture. For better performance and simplicity, I used Minimal APIs, which demonstrated noticeably higher efficiency compared to the traditional controller-based approach. However, in enterprise-level applications, I still prefer using controllers for Web APIs because they offer better structure and flexibility for more complex scenarios.

.NET 9 has shown excellent performance, speed, and stability in recent years. Its cross-platform support also makes it an ideal choice for developing modern and scalable applications.

For the application architecture, I adopted the Vertical Slice Architecture, which follows a feature-based structure. This approach ensures high cohesion within each slice and low coupling between slices, allowing for a more organized, maintainable, and business-focused design. It also makes understanding the domain logic and adding new features much easier.

For data access, I used Entity Framework Core (EF Core) as the ORM. EF Core offers strong performance, seamless integration with .NET, and excellent support for relational data, fully meeting the project’s needs.

Regarding the database, I chose Microsoft SQL Server as the relational database system since there was no particular need for a NoSQL database in this task. In my opinion, SQL Server — along with other relational systems like PostgreSQL — is a solid and reliable choice for this kind of project.

I intentionally avoided using the Repository Pattern and Unit of Work Pattern because I wanted to keep the project simple. As you may know, these patterns are often considered anti-patterns in modern EF Core applications, since EF Core’s DbContext already provides similar functionality by managing the unit of work and repository responsibilities internally. While these patterns still have valid use cases for abstraction and adhering to the Dependency Inversion Principle (DIP), in this case, I found them unnecessary.

Additionally, I didn’t use AutoMapper or similar libraries because the project’s scale didn’t require it. Instead, I preferred to perform manual mapping, which kept the implementation straightforward and transparent. However, for scenarios involving more complex model-to-DTO or JSON mappings, I do recommend and use mapping solutions—whether manual mapping or tools like AutoMapper, Mapster, and similar libraries—depending on the project’s complexity and requirements.
