# EaterySystem

A small demo of my basic understanding in 7 different techs, namely:

1. ReactJS (JS)
2. Nginx,
3. Spring Boot,
4. ASP.NET,
5. Node JS Express,
6. MySQL,
7. Docker

## Scenario ##
Let's say, I run an online restaurant order system.

When customers arrive at the restaurant, they are told to scan a QR code to place their orders.

The scanned QR code redirects them to the app.

In the app, they can see the list of food/beverages available.

Once they're done browsing, they can place the order and the restaurant is then notified.

## Technical Explanation ##

The client (ReactJS) forwards it's request to the the load balancer (Nginx).

Request is then forwarded to either Spring, ASP.NET or NodeJS via round-robin.

All 3 servers perform have the same functions, just written in different frameworks/languages.

All servers communicates with one database, the MySQL.

All of the applications is then Dockerized.






