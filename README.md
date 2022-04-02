# EaterySystem

A small demo of my basic understanding in 7 different techs, namely:

ReactJS (JS)
Nginx,
Spring Boot,
ASP.NET,
Node JS Express,
MySQL,
Docker

The client (ReactJS) forwards it's request to the the load balancer (Nginx).

Request is then forwarded to either Spring, ASP.NET or NodeJS via round-robin.

All 3 servers perform have the same functions, just written in different frameworks/languages.

All servers communicates with one database, the MySQL.

All of the applications is then Dockerized.

Context:
Let's say, I run an online restaurant order system.
When customers arrive at the restaurant, they are told to scan a QR code to place their orders.
The scanned QR code redirects them to the app.
In the app, they can see the menu (fetched from DB), and also see what everyone else has ordered on the same table. 






