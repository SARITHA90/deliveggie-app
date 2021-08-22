# deliveggie-app
DeliVeggie Application for listing prodcuts and its details.
Data Base :  
             DBName:  DeliVeggieDB 
            Collections:     Products ,PriceReductions
API Gateway:  
            DeliVeggieApp.APIGateway is the API endpoint. Which contains 2 GET methods for returning  Products List and Product Details  respectively.
            URL :  https://localhost:44397/api/products , https://localhost:44397/api/products/61229d2daa3aa95942e4b7c8
MicroService & Repository
            DeliVeggieApp.Services.Products (Console APP)   contains the product microservices. Singleton,Repository Pattern and Dependency injection principles are used here.
            Price Reduction logic has been implemented in the GetProductAsync method of Repository.
            Price Reduction Logic : 
                                              Fetch the reduction from DB based on  week day (DateTime.Today.DayOfWeek + 1) 
                                              Price for Today = Price - (Price*Reduction)

RabbitMQ Messaging
           EasyNetQ library is used for achieving asynchronous messaging .DeliVeggieApp.Infrastructure.Messaging contains the Publishers and Subscribers for Messaging. DeliVeggieApp.Infrastructure.BuildingBlocks  contains the entity                         models,message request and response models and their interfaces.
UI
           Angular 9.1.15 is used for implementing Front End. DeliVeggieClientApp contains the UI logic. Two components  created for List and detail page , they are sharing a common data.service for making API calls(returns Observables).
           URL:  http://localhost:4200/
 Unit Test
NUnit is the unit test framework I have used here.Two test methods added for testing Products Microservice. 

Product List
![image](https://user-images.githubusercontent.com/32333543/130367437-abf104e8-a9e0-40a2-be24-09c0957817c8.png)

Product Details

![image](https://user-images.githubusercontent.com/32333543/130367464-87468efe-97a5-41fa-968c-db53127649f7.png)




