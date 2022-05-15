package app.controllers;

import java.util.List;
import java.util.Optional;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import app.models.Orders;
import app.services.OrderService;

@RestController
public class OrderController {
	
	private static final Logger log = LoggerFactory.getLogger(OrderController.class);
	
	@Autowired
	OrderService orderService;
	
	@GetMapping("/api/order/{restaurantId}/{tableNumber}")
	private ResponseEntity<List<Orders>> get(
			@PathVariable("restaurantId") Integer restaurantId, 
			@PathVariable("tableNumber") Integer tableNumber ) {
	
		ResponseEntity<List<Orders>> orders = orderService.get(restaurantId, tableNumber);
		
		return orders;
	}	

}
