# EaterySystem

A small demo of my basic understanding in 7 different techs, namely:

1. Flutter
2. Nginx,
3. Spring Boot,
4. ASP.NET,
5. Node JS Express,
6. MySQL,
7. Docker

## Scenario ##
Let's say I run an online restaurant order system.

When customers arrive at the restaurant, they are told to scan a QR code to browse and place orders.

The scanned QR code redirects them to the web app.

In the app, they can see the list of food/beverages available.

Once they're done browsing, orders can be placed.

## Technical Overview ##

The client (Flutter) forwards all request to the the load balancer (Nginx).

Request is then forwarded to either servers Spring, ASP.NET or NodeJS via round-robin format.

All 3 servers have the same functions, just written in different frameworks/languages.

Each of the server communicates with database (MySQL) via varying ORM tools/frameworks.

Spring - Hibernate

ASP.NET - Entity Framework 6

NodeJS Express - Prism

All of the applications are then Dockerized.

## To Do ##
Complete Spring Boot app
Deploy to AWS Lambda





